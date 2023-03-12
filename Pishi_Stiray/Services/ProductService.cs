using Pishi_Stiray.Data;
using Pishi_Stiray.Data.Models;
using Pishi_Stiray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pishi_Stiray.Services
{
    public class ProductService
    {
        private readonly NewSchemaContext _schemaContext;

        public ProductService(NewSchemaContext schemaContext)
        {
            _schemaContext = schemaContext;
        }

        public List<ProductDB> GetProducts()
        {
            List<ProductDB> products = new List<ProductDB>();
            var Product = _schemaContext.Products.ToList();
            _schemaContext.Pnames.ToList();
            _schemaContext.Pmanufacturers.ToList();

            foreach ( var item in Product )
            {
                products.Add( new ProductDB
                {
                    Image = item.ProductPhoto == string.Empty ? "picture.png" : item.ProductPhoto,
                    Title = item.ProductNameNavigation.ProductName,
                    Description = item.ProductDescription,
                    Manufacturer = item.ProductManufacturerNavigation.ProductManufacturer,
                    Price = item.ProductCost,
                    Discount = item.ProductDiscountAmount.Value,
                    Article = item.ProductArticleNumber,
                    Quantity = item.ProductQuantityInStock
                } );
            }
            return products;
        }
    }
}
