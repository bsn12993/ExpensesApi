using Expenses.Core.Models;
using System;
using ExpensesApp.Data.Services;
using Expenses.Data.UnitOfWork;
using Expenses.Core.Mappers;
using Expenses.Core.Helpers;
using Expenses.Core.Models.User;
using ExpensesApp.Core.Exceptions;
using ExpensesApp.Core.Enums;

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
                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", collection.GetListModel());
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response GetUserById(int userId)
        {
            try
            {
                if (userId == 0)
                    throw new IdRequiredException("El id es requerido");

                var findUser = _uow.Repository.UserRepository.FindById(userId);
                if (findUser == null) 
                    throw new RecordNotFoundException($"No se encontro el usuario con el id {userId}");

                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", findUser.GetUserModel());
            }
            catch(IdRequiredException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(RecordNotFoundException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response GetUserEmailAndPassaword(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    throw new EmailRequiredException("El correo es requerido o no es valido");

                if (string.IsNullOrEmpty(password))
                    throw new PasswordRequiredException("La contraseña es requerida");

                password = password.Encrypt();
                var findUser = _uow.Repository.UserRepository.Find(email, password);
                if (findUser == null) 
                    throw new RecordNotFoundException($"No se encontro el usuario con el correo {email}");

                return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", findUser.GetUserModel());
            }
            catch(EmailRequiredException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(PasswordRequiredException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(RecordNotFoundException e)
            {
                return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
            }
            catch(Exception e)
            {
                return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
            }
        }

        public Response PostUser(CreateUserModel createUser)
        {
            using (var transaction = _uow.BeginTransaction()) 
            {
                try
                {
                    if (createUser == null)
                        throw new ModelIsNullException("No se recibierón datos para crear un usuario");

                    if (string.IsNullOrEmpty(createUser.Email))
                        throw new EmailRequiredException("El correo es requerido o no es valido");

                    if (string.IsNullOrEmpty(createUser.Password))
                        throw new PasswordRequiredException("El contraseña es requerida");

                    if (string.IsNullOrEmpty(createUser.Name))
                        throw new NameIsRequiredException("El nombre es requerido");

                    if (string.IsNullOrEmpty(createUser.LastName))
                        throw new NameIsRequiredException("El apellido es requerido");

                    var newUser = createUser.GetUserEntity();
                    var userCreated = _uow.Repository.UserRepository.Create(newUser);
                    transaction.Commit();
                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", userCreated.GetUserModel());
                }
                catch(EmailRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(PasswordRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(NameIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(ModelIsNullException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
            }
        }

        public Response PutUser(UpdateUserModel updateUser,int userId)
        {
            using(var transaction = _uow.BeginTransaction())
            {

                try
                {
                    if (updateUser == null)
                        throw new ModelIsNullException("No se recibierón datos para crear un usuario");

                    if (userId == 0)
                        throw new IdRequiredException("El id es requerido");

                    if (string.IsNullOrEmpty(updateUser.Email))
                        throw new EmailRequiredException("El correo es requerido o no es valido");

                    if (string.IsNullOrEmpty(updateUser.Password))
                        throw new PasswordRequiredException("La contraseña es requerida");

                    if (string.IsNullOrEmpty(updateUser.Name))
                        throw new NameIsRequiredException("El nombre es requerido");

                    if (string.IsNullOrEmpty(updateUser.LastName))
                        throw new NameIsRequiredException("El apellido es requerido");

                    var findUser = _uow.Repository.UserRepository.FindById(userId);
                    if (findUser == null) 
                        throw new RecordNotFoundException($"No se encontro el usuario con id {userId} para actualizar");

                    findUser.Name = updateUser.Name;
                    findUser.LastName = updateUser.LastName;
                    findUser.Password = updateUser.Password.Encrypt();
                    findUser.Email = updateUser.Email;

                    var userUpdated = _uow.Repository.UserRepository.Update(findUser);
                    transaction.Commit();

                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", userUpdated.GetUserModel());
                }
                catch(IdRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (EmailRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (PasswordRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (NameIsRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(RecordNotFoundException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(ModelIsNullException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
            }
        }

        public Response DeleteUser(int userId)
        {
            using(var transaction = _uow.BeginTransaction())
            {
                try
                {
                    if (userId == 0)
                        throw new IdRequiredException("El id es requerido");

                    var findUser = _uow.Repository.UserRepository.FindById(userId);
                    if (findUser == null) 
                        throw new RecordNotFoundException($"No se encontro el usuario con el id {userId} para eliminar");

                    var userDeleted = _uow.Repository.UserRepository.Delete(findUser);
                    transaction.Commit();
                    return _response.GetResponse((int)EnumCodeResponse.SUCCESS, "ok", userDeleted);
                }
                catch(IdRequiredException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch(RecordNotFoundException e)
                {
                    return _response.GetResponse((int)EnumCodeResponse.WARNING, e.Message);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return _response.GetResponse((int)EnumCodeResponse.ERROR, e.Message);
                }
            }
        }
    }
}
