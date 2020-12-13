using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using ExpensesApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Data.Repositories
{
    public class IncomeRepository : BaseRepository
    {
        public IncomeRepository(EntityContext context)
        {
            _context = context;
        }

        public List<Income> FindAll()
        {
            try
            {
                var findIncomes = _context.Incomes.ToList();
                return findIncomes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Income> FindAll(int userId)
        {
            try
            {
                var findIncomes = _context.Incomes
                    .Where(x => x.UserId == userId)
                    .OrderByDescending(x => x.Date)
                    .ToList();
                return findIncomes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Income FindById(int incomeId)
        {
            try
            {
                var findIncome = _context.Incomes
                    .Where(x => x.Id == incomeId)
                    .SingleOrDefault();
                return findIncome;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public decimal? FindTotal(int iduser)
        {
            try
            {
                var findTotalIncomes = (_context.Incomes
                    .Where(x => x.UserId == iduser)
                    .Sum(x => x.Amount).HasValue) ?
                    _context.Incomes
                    .Where(x => x.UserId == iduser)
                    .Sum(x => x.Amount) : 0M;
                return findTotalIncomes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Income Create(Income income)
        {
            try
            {
                income.CreatedAt = DateTime.Now;
                _context.Incomes.Add(income);
                _context.SaveChanges();
                return income;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Income Update(Income income)
        {
            try
            {
                income.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return income;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Income Delete(Income income)
        {
            try
            {
                income.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                return income;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
