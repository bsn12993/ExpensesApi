using Expenses.Core.Models;
using Expenses.Data.EntityModel;
using System;
using ExpensesApp.Data.Services;
using Expenses.Data.UnitOfWork;
using Expenses.Core.Mappers;
using Expenses.Core.Helpers;
using Expenses.Core.Models.User;

namespace Expenses.Data.Services
{
    public class UserService : BaseService
    {
        public UserService(UnitOfWorkContainer uow)
        {
            _response = new Response();
            _context = new Context.EntityContext();
            _uow = uow;
        }

        public Response GetUsers()
        {
            try
            {
                var collection = _uow.Repository.UserRepository.FindAll();
                return _response.GetResponse(true, "ok", collection.GetListModel());
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response GetUserById(int userId)
        {
            try
            {
                var findUser = _uow.Repository.UserRepository.FindById(userId);
                if (findUser == null) throw new Exception("No se encontro el registro");
                return _response.GetResponse(true, "ok", findUser.GetUserModel());
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
                var findUser = _uow.Repository.UserRepository.Find(email, password);
                if (findUser == null) throw new Exception("No se encontro el registro");
                return _response.GetResponse(true, "ok", findUser.GetUserModel());
            }
            catch(Exception e)
            {
                return _response.GetResponse(false, e.Message);
            }
        }

        public Response PostUser(CreateUserModel createUser)
        {
            using (var transaction = _uow.BeginTransaction()) 
            {
                try
                {
                    var newUser = createUser.GetUserEntity();
                    var userCreated = _uow.Repository.UserRepository.Create(newUser);
                    transaction.Commit();
                    return _response.GetResponse(true, "ok", userCreated.GetUserModel());
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }

        public Response PutUser(UpdateUserModel updateUser,int userId)
        {
            using(var transaction = _uow.BeginTransaction())
            {

                try
                {
                    var findUser = _uow.Repository.UserRepository.FindById(userId);
                    if (findUser == null) throw new Exception("No se encontro el registro");

                    findUser.Name = updateUser.Name;
                    findUser.LastName = updateUser.LastName;
                    findUser.Password = updateUser.Password.Encrypt();
                    findUser.Email = updateUser.Email;

                    var userUpdated = _uow.Repository.UserRepository.Update(findUser);
                    transaction.Commit();

                    return _response.GetResponse(true, "ok", userUpdated.GetUserModel());
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }

        public Response DeleteUser(int userId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var findUser = _uow.Repository.UserRepository.FindById(userId);
                    if (findUser == null) throw new Exception("No se encontro el registro");

                    var userDeleted = _uow.Repository.UserRepository.Delete(findUser);
                    transaction.Commit();
                    return _response.GetResponse(true, "ok", userDeleted);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse(false, e.Message);
                }
            }
        }
    }
}
