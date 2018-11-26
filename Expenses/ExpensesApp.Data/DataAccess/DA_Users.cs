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
    public class DA_Users
    {
        EntityContext EntityContext { get; set; }
        Response Response { get; set; }

        public DA_Users()
        {
            EntityContext = new EntityContext();
            Response = new Response();
        }

        public Response GetUsers()
        {
            try
            {
                var Users = EntityContext.Users.ToList();
                if (Users != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Users;
                }
                else throw new Exception("No se recuperaron datos");
            }
            catch(Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }



        public Response GetUserById(int iduser)
        {
            try
            {
                var Users = EntityContext.Users.Where(x => x.User_Id == iduser).SingleOrDefault();
                if (Users != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Users;
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



        public Response GetUserByEmailAndPassword(string email, string password)
        {
            try
            {
                var Users = EntityContext.Users.Where(x => x.Email.Equals(email) && x.Password.Equals(password)).SingleOrDefault();
                if (Users != null)
                {
                    Response.IsSuccess = true;
                    Response.Message = "Se recuperaron datos";
                    Response.Result = Users;
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




        public Response InsertUser(User user)
        {
            try
            {
                var validateUser = EntityContext.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).LongCount();
                if (validateUser == 0)
                {
                    EntityContext.Users.Add(user);
                    EntityContext.SaveChanges();
                    Response.IsSuccess = true;
                    Response.Message = "Se ha registrado un nuevo usuario";
                    Response.Result = null;
                }
                else
                {
                    Response.IsSuccess = false;
                    Response.Message = "Ya existe un usuario con el mismo correo";
                    Response.Result = null;
                }
            }
            catch (Exception e)
            {
                Response.IsSuccess = false;
                Response.Message = e.Message;
                Response.Result = null;
            }
            return Response;
        }


        public Response UpdateUser(User user, int iduser)
        {
            try
            {
                var userTarget = EntityContext.Users.Where(x => x.User_Id == iduser).SingleOrDefault();
                if (userTarget != null)
                {
                    userTarget.Email = user.Email;
                    userTarget.LastName = user.LastName;
                    userTarget.Name = user.Name;
                    userTarget.Password = user.Password;
                    EntityContext.SaveChanges();

                    Response.IsSuccess = true;
                    Response.Message = "Se ha actualizado el usuario";
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


        public Response DeleteUser(int iduser)
        {
            try
            {
                var userTarget = EntityContext.Users.Where(x => x.User_Id == iduser).SingleOrDefault();
                if (userTarget != null)
                {
                    EntityContext.Users.Remove(userTarget);
                    EntityContext.SaveChanges();

                    Response.IsSuccess = true;
                    Response.Message = "Se ha eliminado el usuario";
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
