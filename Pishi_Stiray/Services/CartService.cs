
using Pishi_Stiray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.Services
{
    public class CartService
    {
        public Dictionary<ProductDB, int> cart { get; set; }
    }
}
