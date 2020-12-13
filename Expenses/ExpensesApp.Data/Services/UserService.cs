using Expenses.Core.Models;
using Expenses.Data.Repositories;
using Expenses.Data.EntityModel;
using ExpensesApp.Core.Helpers;
using System;

namespace Expenses.Data.Services
{
    public class UserService
    {
        private UserRepository _userRepository { get; set; }
        private Response _response;

        public UserService()
        {
            _userRepository = new UserRepository();
            _response = new Response();
        }

        public Response GetUsers()
        {
            try
            {
                var collection = _userRepository.GetUsers();
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
                var user = _userRepository.GetUserById(iduser);
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
                var user= _userRepository.GetUserByEmailAndPassword(email, password);
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
                var userCreated = _userRepository.InsertUser(user);
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
                var userUpdated = _userRepository.UpdateUser(user, iduser);
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
                var userUpdated=_userRepository.UpdateUserName(name, iduser);
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
                var userUpdated = _userRepository.UpdateUserLastName(lastName, iduser);
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
                var userUpdated = _userRepository.UpdateUserEmail(email, iduser);
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
                var userUpdated= _userRepository.UpdateUserPassword(password, iduser);
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
                var userDeleted= _userRepository.DeleteUser(iduser);
                return _response.GetResponse(true, "ok", userDeleted);
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }
    }
}
