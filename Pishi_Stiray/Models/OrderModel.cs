using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.Models
{
    public class OrderModel
    {
        public string Article { get; set; }
        public string Title { get; set; }
        public int Count { get; set; }
        public float? Price { get; set; }
        public float? Sum
        {
            get { return Price * Count; }
        }
    }
}
