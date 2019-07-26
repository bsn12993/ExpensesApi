using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using ExpensesApp.Data.EntityModel;
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
                //var Categories = EntityContext.Database.SqlQuery<Category>("exec GetCategories").ToList();
                var Categories = EntityContext.Categories.ToList();
                if (Categories != null && Categories.Count > 0) 
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Categories;
                }
                else throw new Exception("No se recuperaron datos de categorías");
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
                //var Category = EntityContext.Database.SqlQuery<Category>("exec GetCategoriesById @idcategory={0}", idcategory).SingleOrDefault();
                var Category = EntityContext.Categories.Where(x => x.Category_Id == idcategory).SingleOrDefault();
                if (Category != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Category;
                }
                else throw new Exception("No se recuperaron datos de categorías");
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }

        public Response GetCategoryByUser(int iduser)
        {
            try
            {
                var Category = EntityContext.UserCategories
                    .Include("User").Include("Category").Where(x => x.User.User_Id == iduser).ToList();
                //var Category = EntityContext.
                //    Categories.Include("User").Where(x => x.User.User_Id == iduser).SingleOrDefault();
                if (Category != null && Category.Count > 0) 
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Category;
                }
                else throw new Exception("No se recuperaron datos de categorías");
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }

        public Response InsertCategory(UserCategory userCategory)
        {          
            using (var transaction = EntityContext.Database.BeginTransaction())
            {
                try
                {
                    //EntityContext.Database.SqlQuery<Category>("exec PostCategories @name={0}, @description={1}, @status={2}, @iduser={3}", category.Name, category.Description, category.Status, category.User.User_Id);
                    var idcategory = EntityContext.Categories.Add(userCategory.Category).Category_Id;
                    userCategory.Category_Id = idcategory;
                    userCategory.User = null;

                    EntityContext.UserCategories.Add(userCategory);
                    EntityContext.SaveChanges();

                    Response.IsSuccess = true;
                    Response.Message = "Se registro la categoria";
                    Response.Result = null;
                    transaction.Commit();
                    return Response;
                }
                catch(Exception e)
                {
                    Response.IsSuccess = false;
                    Response.Message = e.Message;
                    Response.Result = null;
                    transaction.Rollback();
                    return Response;
                }
            }
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
