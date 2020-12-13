﻿using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<User> GetUsers()
        {
            try
            {
                var users = EntityContext.Users.ToList();
                return users;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public User GetUserById(int iduser)
        {
            try
            {
                var user = EntityContext.Users
                    .Where(x => x.User_Id == iduser)
                    .SingleOrDefault();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public User GetUserByEmailAndPassword(string email, string password)
        {
            try
            {
                var user = EntityContext.Users
                    .Where(x => x.Email.Equals(email) && x.Password.Equals(password))
                    .SingleOrDefault();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User InsertUser(User user)
        {
            try
            {
                var validateUser = EntityContext.Users
                    .Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password))
                    .LongCount();
                if (validateUser == 0)
                {
                    EntityContext.Users.Add(user);
                    EntityContext.SaveChanges();
                    return user;
                }
                else
                {
                    throw new Exception("Ya existe un usuario con el mismo correo");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User UpdateUser(User user, int iduser)
        {
            try
            {
                var userTarget = EntityContext.Users
                    .Where(x => x.User_Id == iduser)
                    .SingleOrDefault();
                if (userTarget != null)
                {
                    userTarget.Email = user.Email;
                    userTarget.LastName = user.LastName;
                    userTarget.Name = user.Name;
                    userTarget.Password = user.Password;
                    EntityContext.SaveChanges();

                    return user;
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Response UpdateUserName(string name, int iduser)
        {
            try
            {
                var userTarget = EntityContext.Users.Where(x => x.User_Id == iduser).SingleOrDefault();
                if (userTarget != null)
                {
                    userTarget.Name = name;
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

        public User UpdateUserLastName(string lastName, int iduser)
        {
            try
            {
                var userTarget = EntityContext.Users.Where(x => x.User_Id == iduser).SingleOrDefault();
                if (userTarget != null)
                {
                    userTarget.LastName = lastName;
                    EntityContext.SaveChanges();

                    return userTarget;
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User UpdateUserEmail(string email, int iduser)
        {
            try
            {
                var userTarget = EntityContext.Users.Where(x => x.User_Id == iduser).SingleOrDefault();
                if (userTarget != null)
                {
                    userTarget.Email = email;
                    EntityContext.SaveChanges();

                    return userTarget;
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User UpdateUserPassword(string password, int iduser)
        {
            try
            {
                var userTarget = EntityContext.Users.Where(x => x.User_Id == iduser).SingleOrDefault();
                if (userTarget != null)
                {
                    userTarget.Password = password;
                    EntityContext.SaveChanges();

                    return userTarget;
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User DeleteUser(int iduser)
        {
            try
            {
                var userTarget = EntityContext.Users.Where(x => x.User_Id == iduser).SingleOrDefault();
                if (userTarget != null)
                {
                    EntityContext.Users.Remove(userTarget);
                    EntityContext.SaveChanges();

                    return userTarget;
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
