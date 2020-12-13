using Expenses.Core.Models;
using Expenses.Data.DataAccess;
using Expenses.Data.EntityModel;
using ExpensesApp.Core.Helpers;
using System;

namespace Expenses.Data.Services
{
    public class UsersServices
    {
        private DA_Users DA_Users { get; set; }
        private Response _response;

        public UsersServices()
        {
            DA_Users = new DA_Users();
            _response = new Response();
        }

        public Response GetUsers()
        {
            try
            {
                var collection = DA_Users.GetUsers();
                return _response.GetResponse(true, "ok", collection);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetUserById(int iduser)
        {
            try
            {
                var user = DA_Users.GetUserById(iduser);
                return _response.GetResponse(true, "ok", user);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetUserEmailAndPassaword(string email, string password)
        {
            try
            {
                password = password.Encrypt();
                var user= DA_Users.GetUserByEmailAndPassword(email, password);
                return _response.GetResponse(true, "ok", user);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PostUser(User user)
        {
            try
            {
                var password_aux = user.Password;
                user.Password = password_aux.Encrypt();
                var userCreated = DA_Users.InsertUser(user);
                return _response.GetResponse(true, "ok", userCreated);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PutUser(User user,int iduser)
        {
            try
            {
                var userUpdated = DA_Users.UpdateUser(user, iduser);
                return _response.GetResponse(true, "ok", userUpdated);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PutUserName(string name, int iduser)
        {
            try
            {
                var userUpdated=DA_Users.UpdateUserName(name, iduser);
                return _response.GetResponse(true, "ok", userUpdated);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PutUserLastName(string lastName, int iduser)
        {
            try
            {
                var userUpdated = DA_Users.UpdateUserLastName(lastName, iduser);
                return _response.GetResponse(true, "ok", userUpdated);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PutUserEmail(string email, int iduser)
        {
            try
            {
                var userUpdated = DA_Users.UpdateUserEmail(email, iduser);
                return _response.GetResponse(true, "ok", userUpdated);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PutUserPassword(string password, int iduser)
        {
            try
            {
                var userUpdated= DA_Users.UpdateUserPassword(password, iduser);
                return _response.GetResponse(true, "ok", userUpdated);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response DeleteUser(int iduser)
        {
            try
            {
                var userDeleted= DA_Users.DeleteUser(iduser);
                return _response.GetResponse(true, "ok", userDeleted);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }
    }
}
