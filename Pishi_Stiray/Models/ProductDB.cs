using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.Models
{
    public class ProductDB
    {
        public string Image { get; set; }
        public string DisplayedImage
        {
            get { return $"pack://application:,,,/Resources/Images/{Image}"; }
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public float Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string Article { get; set; }
        public string Category { get; set; }
        public float? DisplayedPrice
        {
            get
            {
                //return Price - (Price * Discount / 100);
                if (Discount != 0)
                    return Price - (Price * Discount / 100);
                else
                    return null;
            }
        }
    }
}
