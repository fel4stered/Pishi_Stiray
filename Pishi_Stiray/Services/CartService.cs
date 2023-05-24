
using FluentNHibernate.Utils;
using Pishi_Stiray.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.Services
{
    public class CartService
    {
        public ObservableCollection<CartModel> cart { get; set; }
    }
}
