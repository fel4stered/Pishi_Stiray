using C1.WPF.Pdf;
using CommunityToolkit.Mvvm.DependencyInjection;
using DevExpress.Mvvm;
using Microsoft.Win32;
using NHibernate.Mapping.ByCode;
using Pishi_Stiray.Models;
using Pishi_Stiray.Services;
using Pishi_Stiray.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
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

        public string OrderDate { get; set; }
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
            OrderDate = DateTime.Now.ToString("G");
        }

        public ICommand<FrameworkElement> PrintCommand
        {
            get
            {
                return new DelegateCommand<FrameworkElement>(element =>
                {
                    var dlg = new SaveFileDialog();
                    dlg.DefaultExt = ".pdf";
                    var dr = dlg.ShowDialog();
                    if (!dr.HasValue || !dr.Value)
                    {
                        return;
                    }

                    var pdf = new C1PdfDocument();
                    pdf.PageSize = new System.Windows.Size(element.RenderSize.Width/2, element.RenderSize.Height/2);
                    pdf.Clear();

                    var img = new WriteableBitmap(CreateBitmap(element));

                    pdf.DrawImage(img, pdf.PageRectangle, C1.WPF.Pdf.ContentAlignment.TopCenter, Stretch.Uniform);

                    using (var stream = dlg.OpenFile())
                    {
                        pdf.Save(stream);
                    }
                    MessageBox.Show(dlg.SafeFileName + " чек сохранён!");

                });
            }
        }

        public BitmapSource CreateBitmap(FrameworkElement element)
        {
            int width = (int)Math.Ceiling(element.ActualWidth);
            int height = (int)Math.Ceiling(element.ActualHeight);

            width = width == 0 ? 1 : width;
            height = height == 0 ? 1 : height;

            // render element to image (WPF)  
            RenderTargetBitmap rtbmp = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Default);
            rtbmp.Render(element);
            return rtbmp;
        }

    }
}
