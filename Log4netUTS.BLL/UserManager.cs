using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4netUTS.DAL;

using Smark.Data;


namespace Log4netUTS.BLL
{
    public class UserManager
    {
        public bool CheckUser(string userName, string password)
        {
            var user = (Users.userName == userName & Users.password == password & Users.isDeleted == false).ListFirst<Users>();
            return user != null;
        }

        public bool AddUser(string UserName, string passWord)
        {
            Users u = new Users();
            u.IsDeleted = false;
            u.IsLocked = false;
            u.UserName = UserName;
            u.Password = Smark.Core.Functions.MD5Crypto(passWord);
            u.Save();
            return true;
        }
    }
}
