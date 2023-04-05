﻿using DevExpress.Mvvm;
using DevExpress.Mvvm.Native;
using Pishi_Stiray.Data;
using Pishi_Stiray.Data.Models;
using Pishi_Stiray.Models;
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
    public class BrowseProductViewModel : ViewModelBase
    {
        public int UserId { get; set; }
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly NewSchemaContext _schemaContext;
        private readonly PageService _pageService;
        public string ProfileButton { get; set; }
        public List<string> Sorts { get; set; } = new() { "По возрастанию", "По убыванию" };
        public List<string> Filters { get; set; } = new() { "Все диапазоны", "0-5%", "5-9%", "9% и более" };
        public List<ProductDB> products { get; set; }
        public List<ProductDB> productsCart { get; set; } = new List<ProductDB>();
        public int CartCount { get; set; } = 0;
        public int ProductsCount { get; set; } = 0;
        public int ProductsAllCount { get; set; } = 0;
        public ProductDB SelectedItem
        {
            get { return GetValue<ProductDB>(); }
            set { SetValue(value); }
        }
        public string SelectedSort
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateProduct); }
        }
        public string SelectedFilter
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateProduct); }
        }
        public string Search
        {
            get { return GetValue<string>(); }
            set { SetValue(value, changedCallback: UpdateProduct); }
        }
        public string ProfileInfo { get; set; }

        public BrowseProductViewModel(UserService userService, ProductService productService, NewSchemaContext schemaContext, PageService pageService)
        {
            _userService = userService;
            _productService = productService;
            _schemaContext = schemaContext;
            _pageService = pageService;
            UpdateProduct();
            Profile();
        }
        public ICommand ProfileExit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if(_userService.UserInfo is not null) _userService.UserInfo = null;
                    _pageService.ChangePage(new Authorization());
                });
            }
        }

        public ICommand CartAdd
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    productsCart.Add(SelectedItem);
                    CartCount = productsCart.Count;
                });
            }
        }
        public void Profile()
        {
            if(_userService.UserInfo is null)
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

        public void UpdateProduct()
        {
            var currentProducts = _productService.GetProducts();
            ProductsAllCount = currentProducts.Count;
            if (!string.IsNullOrEmpty(Search)) currentProducts = currentProducts.Where(p => (p.Title.ToLower() + p.Description.ToLower() + p.Manufacturer.ToLower()).Contains(Search.ToLower())).ToList();

            if (!string.IsNullOrEmpty(SelectedFilter))
            {
                switch (SelectedFilter)
                {
                    case "0-5%":
                        currentProducts = currentProducts.Where(p => p.Discount >= 0 && p.Discount < 5).ToList();
                        break;
                    case "5-9%":
                        currentProducts = currentProducts.Where(p => p.Discount >= 5 && p.Discount < 9).ToList();
                        break;
                    case "9% и более":
                        currentProducts = currentProducts.Where(p => p.Discount >= 9).ToList();
                        break;
                }
            }

            if (!string.IsNullOrEmpty(SelectedSort))
            {
                switch (SelectedSort)
                {
                    case "По возрастанию":
                        currentProducts = currentProducts.OrderBy(p => p.Price).ToList();
                        break;
                    case "По убыванию":
                        currentProducts = currentProducts.OrderByDescending(p => p.Price).ToList();
                        break;
                }
            }

            products = currentProducts;
            ProductsCount = products.Count;
        }
    }
}