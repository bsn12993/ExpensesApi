﻿using Expenses.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Expenses.Web.Services
{
    public class ApiServices : HttpClient
    {
        private string UrlApi
        {
            get
            {
                return ConfigurationManager.AppSettings["urlApi"].ToString();
            }
        }
        #region Constructors
        private ApiServices() : base()
        {
            
            Timeout = TimeSpan.FromMilliseconds(15000);
            MaxResponseContentBufferSize = 256000;
            BaseAddress = new Uri(UrlApi);
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion

        #region Singleton
        private static readonly ApiServices instance = new ApiServices();
        static ApiServices() { }
        public static ApiServices GetInstance()
        {
            if (instance == null) return new ApiServices();
            else return instance;
        }
        #endregion

        #region Methods 
        
        public async Task<Response> GetList<T>(string url)
        {
            try
            {
                var response = await GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var msg = JsonConvert.DeserializeObject<Response>(result);
                    return new Response
                    {
                        IsSuccess = msg.IsSuccess,
                        Message = msg.Message,
                        Result = null
                    };
                }
                var responseData = JsonConvert.DeserializeObject<Response>(result);
                var data = JsonConvert.DeserializeObject<List<T>>(((JArray)responseData.Result).ToString());
                responseData.Result = data;
                return responseData;
            }
            catch (OperationCanceledException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response> GetItem<T>(string url)
        {
            try
            {
                var response = await GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Response>(result);
                T data;
                if (responseData.IsSuccess)
                {
                    data = JsonConvert.DeserializeObject<T>(((JObject)responseData.Result).ToString());
                    responseData.Result = data;
                }

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = responseData.Message,
                        Result = null
                    };
                }
                return responseData;
            }
            catch (OperationCanceledException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response> PostItem<T>(string url, T item)
        {
            try
            {
                var body = JsonConvert.SerializeObject(item);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<Response>(result);
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = default(T),
                        Message = responseData.Message
                    };
                }
                return responseData;
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response> PutItem<T>(string url, T item, int id)
        {
            try
            {
                var body = JsonConvert.SerializeObject(item);
                var content = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await PutAsync($"{url}/{id}", content);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = default(T)
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response> DeleteItem<T>(string url, int id)
        {
            try
            {
                var response = await DeleteAsync($"{url}/{id}");

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Result = default(T)
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Ok",
                    Result = list
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        #endregion
    }
}