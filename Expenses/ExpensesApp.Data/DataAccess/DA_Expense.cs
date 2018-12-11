using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Response GetExpences()
        {
            try
            {
                var Expenses = EntityContext.Expenses.Include("Category").OrderByDescending(x => x.Date).ToList();
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

        public Response GetExpencesHistory(int iduser)
        {
            try
            {
                var Expenses = EntityContext.Expenses.Include("Category").Where(x => x.User_Id == iduser).ToList();
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

        public Response GetExpenceByUser(int iduser)
        {
            try
            {
                var Expense = EntityContext.Expenses.Where(x => x.User_Id == iduser).ToList();
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


        public Response GetTotalExpenceByCategoryAndUser(int idcategory, int iduser)
        {
            try
            {
                var Expense = EntityContext.Expenses.Where(x => x.Category_Id == idcategory && x.User_Id == iduser).Sum(x => x.Amount);
                Response.IsSuccess = true;
                Response.Message = "Se recuperaron datos";
                Response.Result = Expense;
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

                Response.IsSuccess = true;
                Response.Message = "se ha registrado el gasto";
                Response.Result = null;
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

                    Response.IsSuccess = true;
                    Response.Message = "se ha actualizado el gasto";
                    Response.Result = null;
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

                    Response.IsSuccess = true;
                    Response.Message = "se ha eliminado el gasto";
                    Response.Result = null;
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
