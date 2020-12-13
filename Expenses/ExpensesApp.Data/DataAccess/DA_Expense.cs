using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using ExpensesApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Expenses.Data.DataAccess
{
    public class DA_Expense
    {
        EntityContext EntityContext { get; set; }
        Response Response { get; set; }

        public DA_Expense()
        {
            EntityContext = new EntityContext();
            Response = new Response();
        }

        public List<Expense> GetExpences()
        {
            try
            {
                var expenses = EntityContext.Expenses
                    .Include("Category")
                    .OrderByDescending(x => x.Date)
                    .ToList();
                return expenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Expense> GetExpencesHistory(int iduser)
        {
            try
            {
                var expenses = EntityContext.Expenses
                    .Include("Category")
                    .Where(x => x.User_Id == iduser)
                    .ToList();
                return expenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Expense GetExpenceById(int idexpense)
        {
            try
            {
                var expense = EntityContext.Expenses
                    .Where(x => x.Expense_Id == idexpense)
                    .SingleOrDefault();
                return expense;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Expense> GetExpenceByUser(int iduser)
        {
            try
            {
                var expenses = EntityContext.Expenses
                    .Include("Category")
                    .Where(x => x.User_Id == iduser)
                    .ToList();
                return expenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ExpenseCategory> GetTotalExpenceByCategoryAndUser(int iduser)
        {
            try
            {
                var expenses = EntityContext.Database
                    .SqlQuery<ExpenseCategory>(@"sp_GetCategoryExpensesTotal @iduser", new SqlParameter("@iduser", iduser))
                    .ToList();
                return expenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Expense InsertExpence(Expense expense)
        {
            try
            {
                EntityContext.Expenses.Add(expense);
                EntityContext.SaveChanges();

                return expense;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Expense UpdateExpence(Expense expense,int idexpense)
        {
            try
            {
                var expenseTarget = EntityContext.Expenses
                    .Where(x => x.Expense_Id == idexpense)
                    .SingleOrDefault();
                return expenseTarget;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Expense DeleteExpence(int idexpense)
        {
            try
            {
                var expenseTarget = EntityContext.Expenses
                    .Where(x => x.Expense_Id == idexpense)
                    .SingleOrDefault();
                return expenseTarget;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
