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
        public int UserId { get; set; }

        public UserService(NewSchemaContext schemaContext)
        {
            _schemaContext = schemaContext;
        }
        public bool AuthorizationChecker(string UserLogin, string Password)
        {
            var User = _schemaContext.Users.SingleOrDefault(x => x.UserLogin == UserLogin);
            if (User == null) return false;
            
            if(User.UserPassword == Password)
            {
                UserId = User.UserId;
                return true;
            }
            return false;
        }
        public List<string> GetUserData(int UserID)
        {
            var User = _schemaContext.Users.Single(x => x.UserId == UserID);
            List<string> data = new List<string> { User.UserId.ToString(), User.UserLogin, User.UserPassword, User.UserName, User.UserSurname, User.UserRole.ToString(), User.UserPatronymic};
            return data;
        }
    }
}
