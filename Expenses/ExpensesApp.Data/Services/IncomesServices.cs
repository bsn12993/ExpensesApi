using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using Expenses.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Services
{
    public class IncomesServices
    {
        DA_Income DA_Income { get; set; }

        public IncomesServices()
        {
            DA_Income = new DA_Income();
        }

        public Response GetIncomes()
        {
            return DA_Income.GetIncomes();
        }

        public Response GetIncomesByUser(int iduser)
        {
            return DA_Income.GetIncomesByUser(iduser);
        }

        public Response GetIncomeById(int idincome)
        {
            return DA_Income.GetIncomeById(idincome);
        }

        public Response GetIncomesTotal(int iduser)
        {
            return DA_Income.GetIncomesTotal(iduser);
        }

        public Response PostIncome(Income income)
        {
            return DA_Income.InsertIncome(income);
        }

        public Response PutIncome(Income income, int idincome)
        {
            return DA_Income.UpdateIncome(income, idincome);
        }

        public Response DeleteIncome(int idincome)
        {
            return DA_Income.DeleteIncome(idincome);
        }
    }
}
