using DevExpress.Mvvm;
using Microsoft.Win32;
using Pishi_Stiray.Data.Models;
using Pishi_Stiray.Models;
using Pishi_Stiray.Services;
using Pishi_Stiray.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Pishi_Stiray.ViewModels
{
    public class EditProductViewModel : ViewModelBase
    {
        private readonly ProductService _productService;

        public ProductDB SelectedItem { get; set; }

        public List<string> Categories { get; set; }

        public EditProductViewModel(ProductService productService)
        {
            _productService = productService;
            SelectedItem = _productService.SelectedItem;
            Categories = _productService.GetCategoriesNames();
        }

        public ICommand EditCommand
        {
            get => new DelegateCommand(() =>
            {
                _productService.EditProducts(SelectedItem);
            });
        }
        public ICommand EditImageCommand
        {
            get => new DelegateCommand(() =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Files | *.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    string path = openFileDialog.FileName;
                    string filename = Path.GetFileName(path);
                    File.Copy(path, @$"C:\\Users\\МОиБД\\source\\repos\\fel4stered\\Pishi_Stiray\\Pishi_Stiray\\Resources\\Images\\{filename}");
                    SelectedItem.Image = filename;
                }
            });
        }
    }
}
