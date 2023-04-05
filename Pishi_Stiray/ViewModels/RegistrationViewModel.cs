using DevExpress.Mvvm;
using Pishi_Stiray.Services;
using Pishi_Stiray.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pishi_Stiray.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;
        public string UserFName { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public bool PasswordCountChecker
        {
            get
            {
                if (Password is null || Password.Length < 6) 
                    return false;
                return true;
            }
        }
        public bool LoginChecker
        {
            get
            {
                if(_userService.AuthorizationChecker(UserLogin)) 
                    return true;
                return false;
            }
        }

        public RegistrationViewModel(UserService userService, PageService pageService)
        {
            _userService = userService;
            _pageService = pageService;
        }

        public ICommand RegistrationCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _userService.Registration(UserFName, UserName, UserSurname, UserLogin, Password);
                }, bool () =>
                {
                    if (string.IsNullOrWhiteSpace(UserFName) || string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(UserSurname) || string.IsNullOrWhiteSpace(UserLogin) || string.IsNullOrWhiteSpace(Password))
                        return false;
                    else if (!_userService.AuthorizationChecker(UserLogin) || Password.Length < 6)
                        return false;
                    else
                        return true;
                });
            }
        }

        public ICommand AuthorizationCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _pageService.ChangePage(new Authorization());
                });
            }
        }
    }
}
