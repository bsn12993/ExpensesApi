﻿using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using Expenses.Data.Repositories;
using System;
using System.Collections.Generic;
using ExpensesApp.Data.Models;

namespace Expenses.Data.Services
{
    public class ExpenseService
    {
        private ExpenseRepository _expenseRepository { get; set; }
        private Response _response;

        public ExpenseService()
        {
            _expenseRepository = new ExpenseRepository();
            _response = new Response();
        }

        public Response GetExpenses()
        {
            try
            {
                var collection = _expenseRepository.GetExpences();
                var collection_aux = new List<ExpenseModel>();
                foreach(var item in collection)
                {
                    var expense = new ExpenseModel
                    {
                        Id = item.Expense_Id,
                        Date = item.Date,
                        Amount = item.Amount,
                        Category = item.Category.Name,
                        Description = item.Category.Description
                    };
                    collection_aux.Add(expense);
                }
                return _response.GetResponse(true, "ok", collection_aux);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetExpencesHistory(int iduser)
        {
            try
            {
                var collection = _expenseRepository.GetExpencesHistory(iduser);
                var collection_aux = new List<ExpenseModel>();
                foreach (var item in collection)
                {
                    var expense = new ExpenseModel
                    {
                        Id = item.Expense_Id,
                        Date = item.Date,
                        Amount = item.Amount,
                        Category = item.Category.Name,
                        Description = item.Category.Description
                    };
                    collection_aux.Add(expense);
                }
                return _response.GetResponse(true, "ok", collection_aux);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetExpensesById(int idexpense)
        {
            try
            {
                var item = _expenseRepository.GetExpenceById(idexpense);
                return _response.GetResponse(true, "ok", item);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetExpenceByUser(int iduser)
        {
            try
            {
                var collection = _expenseRepository.GetExpenceByUser(iduser);
                var collection_aux = new List<ExpenseModel>();
                foreach (var item in collection)
                {
                    var expense = new ExpenseModel
                    {
                        Id = item.Expense_Id,
                        Date = item.Date,
                        Amount = item.Amount,
                        Category = item.Category.Name,
                        Description = item.Category.Description
                    };
                    collection_aux.Add(expense);
                }
                return _response.GetResponse(true, "ok", collection_aux);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetTotalExpenceByCategoryAndUser(int iduser)
        {
            try
            {
                var collection = _expenseRepository.GetTotalExpenceByCategoryAndUser(iduser);
                return _response.GetResponse(true, "ok", collection);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PostExpense(Expense expense)
        {
            try
            {
                var expenseCreated = _expenseRepository.InsertExpence(expense);
                return _response.GetResponse(true, "ok", expenseCreated);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PutExpense(Expense expense,int idexpense)
        {
            try
            {
                var expenseUpdated = _expenseRepository.UpdateExpence(expense, idexpense);
                return _response.GetResponse(true, "ok", expenseUpdated);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response DeleteExpense(int idexpense)
        {
            try
            {
                var expenseDeleted = _expenseRepository.DeleteExpence(idexpense);
                return _response.GetResponse(true, "ok", expenseDeleted);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }
    }
}