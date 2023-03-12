using DevExpress.Mvvm;
using Egor92.MvvmNavigation.Abstractions;
using Pishi_Stiray.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Pishi_Stiray.Views;
using System.Windows.Threading;

namespace Pishi_Stiray.ViewModels
{
    public class AuthorizationViewModel : ViewModelBase
    {
        private readonly UserService _userService;
        private readonly PageService _pageService;

        public string UserLogin { get; set; }
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public AuthorizationViewModel(UserService userService, PageService pageService)
        {
            _userService = userService;
            _pageService = pageService;
        }
        public ICommand AuthorizationCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if(_userService.AuthorizationChecker(UserLogin,Password))
                    {
                        _pageService.ChangePage(new BrowseProduct());
                    }
                    else
                    {
                        ErrorMessage = "Неверный логин или пароль";
                    }
                }, bool() =>
                {
                    if (string.IsNullOrWhiteSpace(UserLogin) || string.IsNullOrWhiteSpace(Password))
                    {
                        ErrorMessage = "Пустые поля";
                        return false;
                    }
                    else if(ErrorMessage == "Неверный логин или пароль")
                    {
                        return false;
                        
                    }
                    else
                    {
                        ErrorMessage = string.Empty;
                        return true;
                    }
                });
            }
        }
        public ICommand AuthorizationGuestCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _pageService.ChangePage(new BrowseProduct());
                });
            }
        }
    }
}
