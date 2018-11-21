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
    public class DA_Income
    {
        EntityContext EntityContext { get; set; }
        Response Response { get; set; }


        public Response GetIncomes()
        {
            try
            {
                var Incomes = EntityContext.Incomes.ToList();
                if (Incomes != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Incomes;
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


        public Response GetIncomeById(int idincome)
        {
            try
            {
                var Incomes = EntityContext.Incomes.Where(x => x.Income_Id == idincome).SingleOrDefault();
                if (Incomes != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Incomes;
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

        public Response GetTotalIncomesByUser(int iduser)
        {
            try
            {
                var Incomes = EntityContext.Incomes.Where(x => x.User_Id == iduser).Sum(x => x.Amount);
                Response.IsSuccess = true;
                Response.Message = "Se recuperaron datos";
                Response.Result = Incomes;
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }


        public Response InsertIncome(Income income)
        {
            try
            {
                EntityContext.Incomes.Add(income);
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


        public Response UpdateIncome(Income income, int idincome)
        {
            try
            {
                var incomeTarget = EntityContext.Incomes.Where(x => x.Income_Id == idincome).SingleOrDefault();
                if (incomeTarget != null)
                {
                    incomeTarget.Amount = income.Amount;
                    incomeTarget.Date = income.Date;
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


        public Response DeleteIncome(int idincome)
        {
            try
            {
                var incomeTarget = EntityContext.Incomes.Where(x => x.Income_Id == idincome).SingleOrDefault();
                if (incomeTarget != null)
                {
                    EntityContext.Incomes.Remove(incomeTarget);
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
