using DevExpress.Mvvm;
using FluentNHibernate.Utils;
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
using System.Windows;
using System.Windows.Input;

namespace Pishi_Stiray.ViewModels
{
    public class CartViewModel : ViewModelBase
    {
        private readonly PageService _pageService;
        private readonly UserService _userService;
        private readonly NewSchemaContext _schemaContext;
        private readonly CartService _cartService;

        public int CartCount { get; set; } = 0;
        public string ProfileInfo { get; set; }
        public string ProfileButton { get; set; }
        public ObservableDictionary<ProductDB, int> cart { get; set; }
        public float? Price { get; set; }

        public KeyValuePair<ProductDB, int> SelectedItem
        {
            get { return GetValue<KeyValuePair<ProductDB, int>>(); }
            set { SetValue(value); }
        }

        public CartViewModel(PageService pageService, UserService userService, NewSchemaContext schemaContext, CartService cartService)
        {
            _pageService = pageService;
            _userService = userService;
            _schemaContext = schemaContext;
            _cartService = cartService;
            if(cartService.cart != null)
            {
                cart = new ObservableDictionary<ProductDB, int>(_cartService.cart);
                UpdateCart();
            }
            Profile();
        }

        public ICommand CartAdd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectedItem.Key.Quantity > cart[SelectedItem.Key])
                    {
                        int count;
                        cart.TryGetValue(SelectedItem.Key, out count);
                        cart[SelectedItem.Key] = count + 1;
                    }
                    else
                    {
                        MessageBox.Show("Товары кончились");
                    }
                    UpdateCart();
                });
            }
        }

        public ICommand CartRemove
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectedItem.Value > 1)
                    {
                        cart[SelectedItem.Key] = SelectedItem.Value - 1;
                    }
                    else
                    {
                        cart.Remove(SelectedItem.Key);
                    }
                    UpdateCart();
                });
            }
        }

        public void UpdateCart()
        {
            CartCount = cart.Sum(x => x.Value);
            Price = (float?)Math.Round((decimal)cart.Sum(x => x.Key.DisplayedPrice * x.Value), 2);
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
