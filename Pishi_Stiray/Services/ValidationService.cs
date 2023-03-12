using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.Services
{
    public class ValidationService
    {
        string ErrorMessage = string.Empty;
        public bool ValidAuthorization(string UserLogin, string Password)
        {
            if (string.IsNullOrWhiteSpace(UserLogin) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Пустые поля";
                return true;
            }
            else return false;
        }
    }
}
