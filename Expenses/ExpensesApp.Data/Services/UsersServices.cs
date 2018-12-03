using Expenses.Core.Models;
using Expenses.Data.DataAccess;
using Expenses.Data.EntityModel;
using ExpensesApp.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data.Services
{
    public class UsersServices
    {
        DA_Users DA_Users { get; set; }

        public UsersServices()
        {
            DA_Users = new DA_Users();
        }

        public Response GetUsers()
        {
            return DA_Users.GetUsers();
        }

        public Response GetUserById(int iduser)
        {
            return DA_Users.GetUserById(iduser);
        }

        public Response GetUserEmailAndPassaword(string email, string password)
        {
            return DA_Users.GetUserByEmailAndPassword(email.Decrypter(), password.Decrypter());
        }

        public Response PostUser(User user)
        {
            return DA_Users.InsertUser(user);
        }

        public Response PutUser(User user,int iduser)
        {
            return DA_Users.UpdateUser(user, iduser);
        }

        public Response DeleteUser(int iduser)
        {
            return DA_Users.DeleteUser(iduser);
        }
    }
}
