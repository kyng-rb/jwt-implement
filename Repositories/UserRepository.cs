using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwt_implement.Models;

namespace jwt_implement.Repositories
{
    public class UserRepository
    {
        public User GetUser(string userName)
        {
            var userRecords = new List<User>() {
                new User()
                {
                    UserName="Rey",
                    Password="Rey",
                    Role="Admin"
                },
                new User()
                {
                    UserName="Jose",
                    Password = "Jose",
                    Role = "User"
                },new User()
                {
                    UserName="Rodriguez",
                    Password="Rodriguez",
                    Role = "Manager"
                }
            };

            return userRecords.FirstOrDefault(x => x.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}