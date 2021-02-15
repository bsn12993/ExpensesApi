using Expenses.Core.Helpers;
using Expenses.Core.Models;
using Expenses.Core.Models.User;
using Expenses.Data.EntityModel;
using System;
using System.Collections.Generic;

namespace Expenses.Core.Mappers
{
    public static class UserMapper
    {
        public static User GetUserEntity(this CreateUserModel createUser)
        {
            return new User
            {
                Name = createUser.Name,
                LastName = createUser.LastName,
                Email = createUser.Email,
                Password = createUser.Password.Encrypt(),
                CreatedAt = DateTime.Now
            };
        }

        public static User GetUserEntity(this UpdateUserModel updateUser)
        {
            return new User
            {
                Id = updateUser.Id,
                Name = updateUser.Name,
                LastName = updateUser.LastName,
                Email = updateUser.Email,
                Password = updateUser.Password.Encrypt(),
                UpdatedAt = DateTime.Now
            };
        }

        public static List<FindUserModel> GetListModel(this List<User> list)
        {
            var collection = new List<FindUserModel>();
            foreach (var item in list)
            {
                collection.Add(new FindUserModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    LastName = item.LastName,
                    Email = item.Email
                });
            }
            return collection;
        }

        public static FindUserModel GetUserModel(this User user)
        {
            return new FindUserModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                LastName = user.LastName,
                Image = user.Image
            };
        }
    }
}
