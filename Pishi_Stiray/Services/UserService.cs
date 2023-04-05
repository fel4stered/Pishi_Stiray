using Pishi_Stiray.Data;
using Pishi_Stiray.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Pishi_Stiray.Services
{
    public class UserService
    {
        private readonly NewSchemaContext _schemaContext;
        public User UserInfo { get; set; }

        public UserService(NewSchemaContext schemaContext)
        {
            _schemaContext = schemaContext;
        }
        public bool AuthorizationChecker(string UserLogin, string Password)
        {
            var User = _schemaContext.Users.SingleOrDefault(x => x.UserLogin == UserLogin);
            _schemaContext.Roles.ToList();
            if (User == null) return false;
            if(User.UserPassword == Password)
            {
                //UserInfo = new List<string>()
                //{
                //    User.UserSurname, User.UserName, User.UserPatronymic, User.UserRoleNavigation.RoleName
                //};
                UserInfo = User;
                return true;
            }
            return false;
        }
        public bool AuthorizationChecker(string UserLogin)
        {
            var User = _schemaContext.Users.SingleOrDefault(x => x.UserLogin == UserLogin);
            if (User == null) 
                return true;
            else 
                return false;
        }
        public void Registration(string UserFName, string UserName, string UserSurname, string UserLogin, string Password)
        {
            User user = new User()
            {
                UserSurname = UserFName,
                UserName = UserName,
                UserPatronymic = UserSurname,
                UserLogin = UserLogin,
                UserPassword = Password,
                UserRole = 2,
            };
            _schemaContext.Users.Add(user);
            _schemaContext.SaveChanges();
        }
        public List<string> GetUserData(int UserID)
        {
            var User = _schemaContext.Users.Single(x => x.UserId == UserID);
            List<string> data = new List<string> { User.UserId.ToString(), User.UserLogin, User.UserPassword, User.UserName, User.UserSurname, User.UserRole.ToString(), User.UserPatronymic};
            return data;
        }
    }
}
