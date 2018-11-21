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
    public class DA_Category
    {
        EntityContext EntityContext { get; set; }
        Response Response { get; set; }

        public DA_Category()
        {
            EntityContext = new EntityContext();
            Response = new Response();
        }

        public Response GetCategories()
        {
            try
            {
                var Categories = EntityContext.Categories.ToList();
                if (Categories != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Categories;
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

        public Response GetCategoryById(int idcategory)
        {
            try
            {
                var Category = EntityContext.Categories.Where(x => x.Category_Id == idcategory).SingleOrDefault();
                if (Category != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Category;
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

        public Response InsertCategory(Category category)
        {
            try
            {
                EntityContext.Categories.Add(category);
                EntityContext.SaveChanges();

                Response.IsSuccess = true;
                Response.Message = "Se registro la categoria";
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


        public Response UpdateCategory(Category category, int idcategory)
        {
            try
            {
                var categoryTarget = EntityContext.Categories.Where(x => x.Category_Id == idcategory).SingleOrDefault();
                if (categoryTarget != null)
                {
                    categoryTarget.Description = category.Description;
                    categoryTarget.Name = category.Name;
                    categoryTarget.Status = category.Status;
                    EntityContext.SaveChanges();

                    Response.IsSuccess = true;
                    Response.Message = "Se actualizo la categoria";
                    Response.Result = null;
                }
                else throw new Exception("No se encontraron datos disponibles");
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }


        public Response DeleteCategory(int idcategory)
        {
            try
            {
                var category = EntityContext.Categories.Where(x => x.Category_Id == idcategory).SingleOrDefault();
                if (category != null)
                {
                    EntityContext.Categories.Remove(category);
                    EntityContext.SaveChanges();

                    Response.IsSuccess = true;
                    Response.Message = "Se elimino la categoria";
                    Response.Result = null;
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch(Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }
    }
}
