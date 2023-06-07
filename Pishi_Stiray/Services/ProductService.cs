using C1.WPF;
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

        public ProductDB SelectedItem { get; set; }


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
            _schemaContext.ProductCategories.ToList();

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
                    Quantity = item.ProductQuantityInStock,
                    Category = item.ProductCategoryNavigation.CategoryName
                } );
            }
            return products;
        }

        public List<Pname> GetPnames()
        {
            List<Pname> pnames = _schemaContext.Pnames.ToList();
            return pnames;
        }

        public List<ProductCategory> GetCategories()
        {
            List<ProductCategory> categories = _schemaContext.ProductCategories.ToList();
            return categories;
        }

        public List<string> GetCategoriesNames()
        {
            List<ProductCategory> categories = GetCategories();
            List<string> names = new List<string>();
            foreach ( var category in categories )
            {
                names.Add(category.CategoryName);
            }
            return names;
        }

        public void EditProducts(ProductDB productEdit)
        {
            var OldProduct = _schemaContext.Products.FirstOrDefault(x => x.ProductArticleNumber == SelectedItem.Article);
            OldProduct.ProductPhoto = productEdit.Image;
            OldProduct.ProductCategory = _schemaContext.ProductCategories.First(x => x.CategoryName == productEdit.Category).Id;
            OldProduct.ProductDescription = productEdit.Description;
            OldProduct.ProductManufacturer = _schemaContext.Pmanufacturers.First(x => x.ProductManufacturer == productEdit.Manufacturer).PmanufacturerId;
            OldProduct.ProductCost = productEdit.Price;
            OldProduct.ProductDiscountAmount = (sbyte)productEdit.Discount;
            OldProduct.ProductQuantityInStock = productEdit.Quantity;

            //if(product.ProductName == 0)
            //{
            //    _schemaContext.Pnames.Add(new Pname() { ProductName = productEdit.Title });
            //    _schemaContext.SaveChanges();
            //    product.ProductName = _schemaContext.Pnames.First(x => x.ProductName == productEdit.Title).PnameId;
            //}
            _schemaContext.SaveChanges();
        }
    }
}
