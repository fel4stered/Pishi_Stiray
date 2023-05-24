using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Pishi_Stiray.Data;
using Pishi_Stiray.Models;
using Pishi_Stiray.Services;
using Pishi_Stiray.Views;
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
        public ObservableCollection<CartModel> cart { get; set; }
        public float? Price { get; set; }
        public float Sale { get; set; }
        public CartViewModel(PageService pageService, UserService userService, NewSchemaContext schemaContext, CartService cartService)
        {
            _pageService = pageService;
            _userService = userService;
            _schemaContext = schemaContext;
            _cartService = cartService;
            if(cartService.cart != null)
            {
                cart = new ObservableCollection<CartModel>(_cartService.cart);
                UpdateCart();
            }
            Profile();
        }
        public CartModel? SelectedItem
        {
            get { return GetValue<CartModel>(); }
            set { SetValue(value); }
        }

        public ICommand CartAdd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (SelectedItem.Product.Quantity > cart.SingleOrDefault(x => x.Product == SelectedItem.Product).Count)
                    {
                        cart.SingleOrDefault(x => x.Product == SelectedItem.Product).Count += 1;
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
                    if (cart.SingleOrDefault(x => x.Product == SelectedItem.Product).Count > 1)
                    {
                        cart.SingleOrDefault(x => x.Product == SelectedItem.Product).Count -= 1;

                    }
                    else
                    {
                        cart.Remove(SelectedItem);
                    }
                    UpdateCart();
                });
            }
        }

        public ICommand BackCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _pageService.ChangePage(new BrowseProduct());
                });
            }
        }

        public void UpdateCart()
        {
            _cartService.cart = cart;
            CartCount = cart.Sum(x => x.Count);
            Price = (float)Math.Round((decimal)cart.Sum(x => x.Product.DisplayedPrice * x.Count),2);
            Sale = (float)Math.Round((decimal)cart.Sum(x => x.Product.Price / 100 * x.Product.Discount * x.Count),2);
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
