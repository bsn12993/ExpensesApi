using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;
using ExpensesApp.Data.Models;
using ExpensesApp.Data.Services;
using Expenses.Data.UnitOfWork;
using ExpensesApp.Core.Models.Expense;
using ExpensesApp.Core.Exceptions;
using ExpensesApp.Core.Enums;

namespace Expenses.Data.Services
{
    public class ExpenseService : BaseService
    {
        public ExpenseService(UnitOfWorkContainer uow)
        {
            _response = new Response();
            _context = new Context.EntityContext();
            _uow = uow;
        }

        public Response GetExpenses()
        {
            try
            {
                var collection = _uow.Repository.ExpenseRepository.FindAll();
                var collection_aux = new List<ExpenseModel>();
                foreach(var item in collection)
                {
                    var expense = new ExpenseModel
                    {
                        Id = item.Id,
                        Date = item.ExpenseDate,
                        Amount = item.Amount,
                        Category = item.Category.Name,
                        Description = item.Category.Description
                    };
                    collection_aux.Add(expense);
                }
                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", collection_aux);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response GetExpencesHistory(int userId)
        {
            try
            {
                if (userId == 0) 
                    throw new IdRequiredException("El id del usuario es requerido");

                var collection = _uow.Repository.ExpenseRepository.FindAll(userId);
                var collection_aux = new List<ExpenseModel>();
                foreach (var item in collection)
                {
                    var expense = new ExpenseModel
                    {
                        Id = item.Id,
                        Date = item.ExpenseDate,
                        Amount = item.Amount,
                        Category = item.Category.Name,
                        Description = item.Category.Description
                    };
                    collection_aux.Add(expense);
                }
                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", collection_aux);
            }
            catch(IdRequiredException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response GetExpensesById(int expenseId)
        {
            try
            {
                if (expenseId == 0) 
                    throw new IdRequiredException("El id es requerido");

                var findExpense = _uow.Repository.ExpenseRepository.FindById(expenseId);
                if (findExpense == null) 
                    throw new RecordNotFoundException($"No se encontro el gasto con el id {expenseId}");

                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", findExpense);
            }
            catch(IdRequiredException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(RecordNotFoundException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response GetExpenceByUser(int userId)
        {
            try
            {
                if (userId == 0) 
                    throw new IdRequiredException("El id del usuario es requerido");

                var collection = _uow.Repository.ExpenseRepository.FindAll(userId);
                var collection_aux = new List<ExpenseModel>();
                foreach (var item in collection)
                {
                    var expense = new ExpenseModel
                    {
                        Id = item.Id,
                        Date = item.ExpenseDate,
                        Amount = item.Amount,
                        Category = item.Category.Name,
                        Description = item.Category.Description
                    };
                    collection_aux.Add(expense);
                }
                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", collection_aux);
            }
            catch(IdRequiredException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        /*
        public Response GetTotalExpenceByCategoryAndUser(int userId)
        {
            try
            {
                if (userId == 0) 
                    throw new IdRequiredException("El id del usuario es requerido");

                var collection = _uow.Repository.ExpenseRepository.FindTotalByCategoryAndUser(userId);
                return _response.GetResponse(true, "ok", collection);
            }
            catch (IdRequiredException e)
            {
                return _response.GetResponse(false, e.Message);
            }
            catch (Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }
        */

        public Response PostExpense(CreateExpenseModel createExpense)
        {
           using(var transaction = _uow.BeginTransaction())
           {
                try
                {
                    if (createExpense == null)
                        throw new ModelIsNullException("No se recibierón datos para crear el gasto");

                    if (createExpense.UserId == 0) 
                        throw new IdRequiredException("El id del usuario es requerido");

                    if (createExpense.CategoryId == 0)
                        throw new IdRequiredException("El id de la categoría es requerido");

                    if (createExpense.ExpenseDate == null)
                        throw new DateIsRequiredException("La fecha del gasto es requerido");

                    if (createExpense.Amount == 0)
                        throw new AmountIsRequiredException("El monto es requerido");

                    var expense = new Expense
                    {
                        Amount = createExpense.Amount,
                        CategoryId = createExpense.CategoryId,
                        ExpenseDate = createExpense.ExpenseDate,
                        UserId = createExpense.UserId
                    };
                    var expenseCreated = _uow.Repository.ExpenseRepository.Create(expense);
                    transaction.Commit();
                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", expenseCreated);
                }
                catch(IdRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (DateIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (AmountIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(ModelIsNullException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
           }
        }

        public Response PutExpense(UpdateExpenseModel updateExpense,int expenseId)
        {
            using(var transaction = _uow.BeginTransaction())
            {

                try
                {
                    if (updateExpense == null)
                        throw new ModelIsNullException("No se recibierón datos para actualizar gasto");

                    if (expenseId == 0)
                        throw new IdRequiredException($"El id del usuario es requerido");

                    if (updateExpense.CategoryId == 0)
                        throw new IdRequiredException("El id de la categoría es requerido");

                    if (updateExpense.ExpenseDate == null)
                        throw new DateIsRequiredException("La fehca del gasto es requerido");

                    if (updateExpense.Amount == 0)
                        throw new AmountIsRequiredException("El monto es requerido");

                    var findExpense = _uow.Repository.ExpenseRepository.FindById(expenseId);
                    if (findExpense == null) 
                        throw new RecordNotFoundException($"No se encontro el gasto con el id {expenseId} para actualizar");

                    findExpense.Amount = updateExpense.Amount;
                    findExpense.ExpenseDate = updateExpense.ExpenseDate;

                    var expenseUpdated = _uow.Repository.ExpenseRepository.Update(findExpense);
                    transaction.Commit();
                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", expenseUpdated);
                }
                catch (IdRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (DateIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (AmountIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(RecordNotFoundException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(ModelIsNullException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
            }
        }

        public Response DeleteExpense(int expenseId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    if (expenseId == 0)
                        throw new IdRequiredException("El id del gasto es requerido");

                    var findExpense = _uow.Repository.ExpenseRepository.FindById(expenseId);
                    if (findExpense == null) 
                        throw new RecordNotFoundException($"No se encontro el gasto con el id {expenseId} para eliminar");

                    var expenseDeleted = _uow.Repository.ExpenseRepository.Delete(findExpense);
                    transaction.Commit();
                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", expenseDeleted);
                }
                catch(IdRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(RecordNotFoundException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
            }
        }
    }
}
