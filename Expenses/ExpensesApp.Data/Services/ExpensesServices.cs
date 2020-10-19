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
    public class ExpensesServices
    {
        DA_Expense DA_Expense { get; set; }

        public ExpensesServices()
        {
            DA_Expense = new DA_Expense();
        }

        public Response GetExpenses()
        {
            return DA_Expense.GetExpences();
        }

        public Response GetExpencesHistory(int iduser)
        {
            return DA_Expense.GetExpencesHistory(iduser);
        }

        public Response GetExpensesById(int idexpense)
        {
            return DA_Expense.GetExpenceById(idexpense);
        }

        public Response GetExpenceByUser(int iduser)
        {
            return DA_Expense.GetExpenceByUser(iduser);
        }

        public Response GetTotalExpenceByCategoryAndUser(int iduser)
        {
            return DA_Expense.GetTotalExpenceByCategoryAndUser(iduser);
        }

        public Response PostExpense(Expense expense)
        {
            return DA_Expense.InsertExpence(expense);
        }

        public Response PutExpense(Expense expense,int idexpense)
        {
            return DA_Expense.UpdateExpence(expense, idexpense);
        }

        public Response DeleteExpense(int idexpense)
        {
            return DA_Expense.DeleteExpence(idexpense);
        }
    }
}
