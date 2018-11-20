﻿using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data.DataAccess
{
    public class DA_Expense
    {
        EntityContext EntityContext { get; set; }
        Response Response { get; set; }

        public Response GetExpences()
        {
            try
            {
                var Expenses = EntityContext.Expenses.ToList();
                if (Expenses != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Expenses;
                }
                else throw new Exception("No se recuperaron datos");
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }


        public Response GetExpenceById(int idexpense)
        {
            try
            {
                var Expense = EntityContext.Expenses.Where(x => x.Expense_Id == idexpense).SingleOrDefault();
                if (Expense != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Expense;
                }
                else throw new Exception("No se recuperaron datos");
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }

        public Response InsertExpence(Expense expense)
        {
            try
            {
                EntityContext.Expenses.Add(expense);
                EntityContext.SaveChanges();
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }


        public Response UpdateExpence(Expense expense,int idexpense)
        {
            try
            {
                var expenseTarget = EntityContext.Expenses.Where(x => x.Expense_Id == idexpense).SingleOrDefault();
                if (expenseTarget != null)
                {
                    expenseTarget.Amount = expense.Amount;
                    expenseTarget.Category_Id = expense.Category_Id;
                    expenseTarget.Date = expense.Date;
                    EntityContext.SaveChanges();
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }

        public Response DeleteExpence(int idexpense)
        {
            try
            {
                var expenseTarget = EntityContext.Expenses.Where(x => x.Expense_Id == idexpense).SingleOrDefault();
                if (expenseTarget != null)
                {
                    EntityContext.Expenses.Remove(expenseTarget);
                    EntityContext.SaveChanges();
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }
    }
}
