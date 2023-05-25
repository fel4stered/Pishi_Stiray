using CommunityToolkit.Mvvm.DependencyInjection;
using DevExpress.Mvvm;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using NHibernate.Mapping.ByCode;
using Pishi_Stiray.Models;
using Pishi_Stiray.Services;
using Pishi_Stiray.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using static System.Net.Mime.MediaTypeNames;

namespace Pishi_Stiray.ViewModels
{
    public class ClientOrderViewModel : ViewModelBase
    {
        private readonly UserService _userService;
        private readonly CartService _cartService;
        private readonly PageService _pageService;

        public List<OrderModel> order { get; set; } = new List<OrderModel>();

        public string User { get; set; }

        public string OrderSum { get; set; }

        public string OrderSumSale { get; set; }

        public DateTime OrderDate { get; set; }
        public Visual print { get; }

        public ClientOrderViewModel(UserService userService, CartService cartService, PageService pageService)
        {
            _userService = userService;
            _cartService = cartService;
            _pageService = pageService;
            Check_Create();
            
        }

        public void Check_Create()
        {
            User = $"Заказчик: {_userService.UserInfo.UserSurname} {_userService.UserInfo.UserName} {_userService.UserInfo.UserPatronymic}";
            
            foreach(CartModel model in _cartService.cart)
            {
                order.Add(new OrderModel { Article = model.Product.Article, Title = model.Product.Title, Count = model.Count, Price = model.Product.DisplayedPrice });
            }

            OrderSum = Math.Round((decimal)_cartService.cart.Sum(x => x.Product.DisplayedPrice * x.Count), 2).ToString();
            OrderSumSale = Math.Round((decimal)_cartService.cart.Sum(x => x.Product.Price / 100 * x.Product.Discount * x.Count), 2).ToString();
            OrderDate = DateTime.Now;
        }

        public ICommand<UIElement> PrintCommand
        {
            get
            {
                return new DelegateCommand<UIElement>(visual =>
                {
                    double w = visual.RenderSize.Width;
                    double h = visual.RenderSize.Height;
                    double dpiScale = 300.0 / 99.9;
                    double dpiX = 300.0;
                    double dpiY = 300.0;
                    var renderTargetBitmap = new RenderTargetBitmap(Convert.ToInt32((w) * dpiScale), Convert.ToInt32((h) * dpiScale), dpiX, dpiY, PixelFormats.Pbgra32);
                    renderTargetBitmap.Render(visual);
                    MemoryStream stream = new MemoryStream();
                    BitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
                    encoder.Save(stream);

                    Bitmap bitmap = new Bitmap(stream);
                    bitmap = new Bitmap(bitmap, new System.Drawing.Size(bitmap.Width /2, bitmap.Height/2));
                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream("image.pdf", FileMode.Create));
                    doc.Open();
                    iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(bitmap, System.Drawing.Imaging.ImageFormat.Jpeg);
                    doc.Add(pdfImage);
                    doc.Close();
                });
            }
        }
    }
}
