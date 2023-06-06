using DevExpress.Mvvm;
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
    public class EditProductViewModel : ViewModelBase
    {
        private readonly ProductService _productService;

        public ProductDB SelectedItem { get; set; }

        public EditProductViewModel(ProductService productService)
        {
            _productService = productService;
            SelectedItem = _productService.SelectedItem;
        }

        public ICommand EditCommand
        {
            get => new DelegateCommand(() =>
            {
                _productService.SelectedItem = SelectedItem;
            });
        }
        
    }
}
