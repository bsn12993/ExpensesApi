using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Data.Repositories
{
    public class IncomeRepository
    {
        EntityContext EntityContext { get; set; }

        public IncomeRepository()
        {
            EntityContext = new EntityContext();
        }

        public List<Income> GetIncomes()
        {
            try
            {
                var collection = EntityContext.Incomes.ToList();
                return collection;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Income> GetIncomesByUser(int iduser)
        {
            try
            {
                var collection = EntityContext.Incomes.Where(x => x.User_Id == iduser).OrderByDescending(x => x.Date).ToList();
                return collection;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Income GetIncomeById(int idincome)
        {
            try
            {
                var item = EntityContext.Incomes.Where(x => x.Income_Id == idincome).SingleOrDefault();
                return item;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public decimal? GetIncomesTotal(int iduser)
        {
            try
            {
                var incomes = (EntityContext.Incomes
                    .Where(x => x.User_Id == iduser)
                    .Sum(x => x.Amount).HasValue) ? 
                    EntityContext.Incomes
                    .Where(x => x.User_Id == iduser)
                    .Sum(x => x.Amount) : 0M;
                return incomes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Income InsertIncome(Income income)
        {
            try
            {
                EntityContext.Incomes.Add(income);
                EntityContext.SaveChanges();

                return income;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Income UpdateIncome(Income income, int idincome)
        {
            try
            {
                var incomeTarget = EntityContext.Incomes
                    .Where(x => x.Income_Id == idincome)
                    .SingleOrDefault();
                return incomeTarget;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public Income DeleteIncome(int idincome)
        {
            try
            {
                var incomeTarget = EntityContext.Incomes
                    .Where(x => x.Income_Id == idincome)
                    .SingleOrDefault();
                return incomeTarget;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
