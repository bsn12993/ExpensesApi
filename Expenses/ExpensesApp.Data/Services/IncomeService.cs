using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using System;
using ExpensesApp.Data.Models;
using System.Collections.Generic;
using ExpensesApp.Data.Services;
using Expenses.Data.UnitOfWork;
using ExpensesApp.Core.Models.Income;

namespace Expenses.Data.Services
{
    public class IncomeService : BaseService
    {

        public IncomeService(UnitOfWorkContainer uow)
        {
            _response = new Response();
            _context = new Context.EntityContext();
            _uow = uow;
        }

        public Response GetIncomes()
        {
            try
            {
                var collection = _uow.Repository.IncomeRepository.FindAll();
                var collection_aux = new List<IncomeModel>();
                foreach(var item in collection)
                {
                    var income = new IncomeModel
                    {
                        Id = item.Id,
                        Date = item.IncomeDate,
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

        public Response GetIncomesByUser(int userId)
        {
            try
            {
                var collection = _uow.Repository.IncomeRepository.FindAll(userId);
                var collection_aux = new List<IncomeModel>();
                foreach (var item in collection)
                {
                    var income = new IncomeModel
                    {
                        Id = item.Id,
                        Date = item.IncomeDate,
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

        public Response GetIncomeById(int incomeId)
        {
            try
            {
                var item = _uow.Repository.IncomeRepository.FindById(incomeId);
                return _response.GetResponse(true, "ok", item);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetIncomesTotal(int userId)
        {
            try
            {
                var total = _uow.Repository.IncomeRepository.FindTotal(userId);
                return _response.GetResponse(true, "ok", total);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PostIncome(CreateIncomeModel createIncome)
        {
            using(var transaction = _uow.BeginTransaction())
            {

                try
                {
                    var income = new Income
                    {
                        Amount = createIncome.Amount,
                        IncomeDate = createIncome.Date
                    };
                    var item = _uow.Repository.IncomeRepository.Create(income);
                    transaction.Commit();

                    return _response.GetResponse(true, "ok", item);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }

        public Response PutIncome(UpdateIncomeModel updateIncome, int incomeId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var findIncome = _uow.Repository.IncomeRepository.FindById(incomeId);
                    if (findIncome == null) throw new Exception("No se encontro registro");

                    findIncome.Amount = updateIncome.Amount;
                    findIncome.IncomeDate = updateIncome.Date;

                    var item = _uow.Repository.IncomeRepository.Update(findIncome);
                    transaction.Commit();
                    return _response.GetResponse(true, "ok", item);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }

        public Response DeleteIncome(int incomeId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var findIncome = _uow.Repository.IncomeRepository.FindById(incomeId);
                    if (findIncome == null) throw new Exception("No se encontro registro");

                    var item = _uow.Repository.IncomeRepository.Delete(findIncome);
                    transaction.Commit();
                    return _response.GetResponse(true, "ok", item);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }
    }
}
