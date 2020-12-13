using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using Expenses.Data.Repositories;
using System;
using ExpensesApp.Data.Models;
using System.Collections.Generic;

namespace Expenses.Data.Services
{
    public class IncomeService
    {
        private IncomeRepository _incomeRepository { get; set; }
        private Response _response;

        public IncomeService()
        {
            _incomeRepository = new IncomeRepository();
            _response = new Response();
        }

        public Response GetIncomes()
        {
            try
            {
                var collection = _incomeRepository.GetIncomes();
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
                var collection = _incomeRepository.GetIncomesByUser(iduser);
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
                var item = _incomeRepository.GetIncomeById(idincome);
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
                var total = _incomeRepository.GetIncomesTotal(iduser);
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
                var item = _incomeRepository.InsertIncome(income);
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
                var item = _incomeRepository.UpdateIncome(income, idincome);
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
                var item = _incomeRepository.DeleteIncome(idincome);
                return _response.GetResponse(true, "ok", item);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }
    }
}
