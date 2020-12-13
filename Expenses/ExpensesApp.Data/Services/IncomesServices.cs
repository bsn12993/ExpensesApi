using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using Expenses.Data.DataAccess;
using System;
using ExpensesApp.Data.Models;
using System.Collections.Generic;

namespace Expenses.Data.Services
{
    public class IncomesServices
    {
        private DA_Income DA_Income { get; set; }
        private Response _response;

        public IncomesServices()
        {
            DA_Income = new DA_Income();
            _response = new Response();
        }

        public Response GetIncomes()
        {
            try
            {
                var collection = DA_Income.GetIncomes();
                var collection_aux = new List<IncomeModel>();
                foreach(var item in collection)
                {
                    var income = new IncomeModel
                    {
                        Id = item.Income_Id,
                        Date = item.Date,
                        Amount = item.Amount
                    };
                    collection_aux.Add(income);
                }
                return _response.GetResponse(true, "ok", collection_aux);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetIncomesByUser(int iduser)
        {
            try
            {
                var collection = DA_Income.GetIncomesByUser(iduser);
                var collection_aux = new List<IncomeModel>();
                foreach (var item in collection)
                {
                    var income = new IncomeModel
                    {
                        Id = item.Income_Id,
                        Date = item.Date,
                        Amount = item.Amount
                    };
                    collection_aux.Add(income);
                }
                return _response.GetResponse(true, "ok", collection_aux);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetIncomeById(int idincome)
        {
            try
            {
                var item = DA_Income.GetIncomeById(idincome);
                return _response.GetResponse(true, "ok", item);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetIncomesTotal(int iduser)
        {
            try
            {
                var total = DA_Income.GetIncomesTotal(iduser);
                return _response.GetResponse(true, "ok", total);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PostIncome(Income income)
        {
            try
            {
                var item = DA_Income.InsertIncome(income);
                return _response.GetResponse(true, "ok", item);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PutIncome(Income income, int idincome)
        {
            try
            {
                var item = DA_Income.UpdateIncome(income, idincome);
                return _response.GetResponse(true, "ok", item);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response DeleteIncome(int idincome)
        {
            try
            {
                var item = DA_Income.DeleteIncome(idincome);
                return _response.GetResponse(true, "ok", item);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }
    }
}
