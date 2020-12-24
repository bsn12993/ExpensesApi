using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using ExpensesApp.Core.Models;
using ExpensesApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Expenses.Data.Repositories
{
    public class ExpenseRepository : BaseRepository
    {
        public ExpenseRepository(EntityContext context)
        {
            _context = context;
        }

        public List<Expense> FindAll()
        {
            try
            {
                var findExpenses = _context.Expenses
                    .Include("Category")
                    .OrderByDescending(x => x.ExpenseDate)
                    .Where(x => x.DeletedAt == null)
                    .ToList();
                return findExpenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Expense> FindHistoryByUser(int userId)
        {
            try
            {
                var findExpenses = _context.Expenses
                    .Include("Category")
                    .Where(x => x.UserId == userId && x.DeletedAt == null)
                    .ToList();
                return findExpenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Expense FindById(int expenseId)
        {
            try
            {
                var findExpense = _context.Expenses
                    .Where(x => x.Id == expenseId && x.DeletedAt == null)
                    .SingleOrDefault();
                return findExpense;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Expense> FindAll(int userId)
        {
            try
            {
                var findExpenses = _context.Expenses
                    .Include("Category")
                    .Where(x => x.UserId == userId && x.DeletedAt == null)
                    .ToList();
                return findExpenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /**
        public List<ExpenseCategory> FindTotalByCategoryAndUser(int userId)
        {
            try
            {
                var findExpenses = _context.Database
                    .SqlQuery<ExpenseCategory>(@"sp_GetCategoryExpensesTotal @iduser", new SqlParameter("@iduser", userId))
                    .ToList();
                return findExpenses;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        **/

        public Expense Create(Expense expense)
        {
            try
            {
                expense.CreatedAt = DateTime.Now;
                _context.Expenses.Add(expense);
                _context.SaveChanges();
                return expense;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Expense Update(Expense expense)
        {
            try
            {
                expense.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return expense;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Expense Delete(Expense expense)
        {
            try
            {
                expense.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                return expense;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
