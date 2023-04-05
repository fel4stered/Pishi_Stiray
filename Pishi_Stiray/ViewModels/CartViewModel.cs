using DevExpress.Mvvm;
using Pishi_Stiray.Data;
using Pishi_Stiray.Models;
using Pishi_Stiray.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pishi_Stiray.ViewModels
{
    public class CartViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly PageService _pageService;
        private readonly UserService _userService;
        private readonly NewSchemaContext _schemaContext;
        private readonly CartService _cartService;

        public int CartCount { get; set; } = 0;
        public string ProfileInfo { get; set; }
        public string ProfileButton { get; set; }
        public ObservableCollection<ProductDB> cart { get; set; }
        public float? Price { get; set; }

        public ProductDB SelectedItem
        {
            get { return GetValue<ProductDB>(); }
            set { SetValue(value); }
        }

        public CartViewModel(PageService pageService, UserService userService, NewSchemaContext schemaContext, CartService cartService)
        {
            _pageService = pageService;
            _userService = userService;
            _schemaContext = schemaContext;
            _cartService = cartService;
            cart = new ObservableCollection<ProductDB>(_cartService.cart);
            Profile();
            UpdateCart();
        }

        public ICommand CartRemove
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    cart.Remove(SelectedItem);
                    UpdateCart();
                });
            }
        }

        public void UpdateCart()
        {
            CartCount = cart.Count;
            Price = (float?)Math.Round((decimal)cart.Sum(x => x.DisplayedPrice), 2);
        }

        public void Profile()
        {
            if (_userService.UserInfo is null)
            {
                ProfileInfo = "Вы вошли как Гость";
                ProfileButton = "Войти";
            }
            else
            {
                ProfileButton = "Выйти";
                _schemaContext.Roles.ToList();
                ProfileInfo = $"ФИО: {_userService.UserInfo.UserSurname} {_userService.UserInfo.UserName[0]}. {_userService.UserInfo.UserPatronymic[0]}.\nРоль: {_userService.UserInfo.UserRoleNavigation.RoleName}";
            }
        }
    }
}
