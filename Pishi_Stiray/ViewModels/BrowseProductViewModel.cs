using DevExpress.Mvvm;
using Pishi_Stiray.Data.Models;
using Pishi_Stiray.Models;
using Pishi_Stiray.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.ViewModels
{
    public class BrowseProductViewModel : ViewModelBase
    {
        public int UserId { get; set; }
        public List<string> UserData { get; set; }
        private readonly UserService _userService;
        private readonly ProductService _productService;
        public List<string> Sorts { get; set; } = new() { "По возрастанию", "По убыванию" };
        public List<string> Filters { get; set; } = new() { "Все диапазоны", "0-5%", "5-9%", "9% и более" };
        public List<ProductDB> products { get; set; }
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

        public BrowseProductViewModel(UserService userService, ProductService productService)
        {
            _userService = userService;
            _productService = productService;
            products = _productService.GetProducts();
        }

        public void UpdateProduct()
        {
            var currentProducts = _productService.GetProducts();
            if (!string.IsNullOrEmpty(Search))
                currentProducts = currentProducts.Where(p => p.Title.ToLower().Contains(Search.ToLower())).ToList();

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
        }
    }
}
