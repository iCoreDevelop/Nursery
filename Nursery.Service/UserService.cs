using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nursery.Data.MySQL;
using Nursery.Entity;

namespace Nursery.Service
{
    public class UserService
    {
        private UserData userData;

        public UserService()
        {
            userData = new UserData();
        }

        public int ValidateUser(User user)
        {
            return userData.ValidateUser(user);
        }

    }
}
