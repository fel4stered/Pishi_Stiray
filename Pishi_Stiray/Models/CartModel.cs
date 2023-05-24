using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.Models
{
    public partial class CartModel : ObservableObject
    {
        [ObservableProperty]
        public ProductDB product;
        [ObservableProperty]
        public int count;

        public CartModel(ProductDB product, int count)
        {
            Product = product;
            Count = count;
        }
    }
}
