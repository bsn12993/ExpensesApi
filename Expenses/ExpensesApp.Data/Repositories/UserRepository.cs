using Expenses.Core.Models;
using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using ExpensesApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Data.Repositories
{
    public class UserRepository : BaseRepository
    {
        public UserRepository(EntityContext context)
        {
            _context = context;
        }

        public List<User> FindAll()
        {
            try
            {
                var findUsers = _context.Users
                    .Where(x => x.DeletedAt == null)
                    .ToList();
                return findUsers;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public User FindById(int userId)
        {
            try
            {
                var findUser = _context.Users
                    .Where(x => x.Id == userId && x.DeletedAt == null)
                    .SingleOrDefault();
                return findUser;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public User Find(string email, string password)
        {
            try
            {
                var findUser = _context.Users
                    .Where(x => 
                        x.Email.Equals(email) && 
                        x.Password.Equals(password) &&
                        x.DeletedAt == null)
                    .SingleOrDefault();
                return findUser;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Create(User user)
        {
            try
            {
                var findUser = _context.Users
                    .Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password))
                    .LongCount();
                if (findUser == 0)
                {
                    _context.Users.Add(user);
                    _context.SaveChanges();
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

        public User Update(User user)
        {
            try
            {
                user.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
 
  

        public User Update(string password, int userId)
        {
            try
            {
                var userTarget = _context.Users
                    .Where(x => x.Id == userId)
                    .SingleOrDefault();
                if (userTarget != null)
                {
                    userTarget.Password = password;
                    _context.SaveChanges();

                    return userTarget;
                }
                else throw new Exception("No se encontro el registro disponible");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public User Delete(User user)
        {
            try
            {
                user.DeletedAt = DateTime.Now;
                _context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
