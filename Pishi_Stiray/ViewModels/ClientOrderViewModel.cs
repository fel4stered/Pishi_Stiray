using DevExpress.Mvvm;
using Pishi_Stiray.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.ViewModels
{
    public class ClientOrderViewModel : ViewModelBase
    {
        private readonly UserService _userService;
        private readonly CartService _cartService;
        private readonly PageService _pageService;

        public ClientOrderViewModel(UserService userService, CartService cartService, PageService pageService)
        {
            _userService = userService;
            _cartService = cartService;
            _pageService = pageService;
        }
    }
}
