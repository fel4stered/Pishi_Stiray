using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pishi_Stiray.Data;
using Pishi_Stiray.Services;
using Pishi_Stiray.ViewModels;
using Pishi_Stiray.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pishi_Stiray
{
    internal class ViewModelLocator
    {
        private static ServiceProvider? _provider;

        
        public static void Init()
        {
            var connectionString = "server=localhost;user=root;password=1234;database=new_schema";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));
            var services = new ServiceCollection();
            services.AddDbContext<NewSchemaContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(connectionString, serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );
            

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<AuthorizationViewModel>();
            services.AddTransient<BrowseProductViewModel>();
            services.AddTransient<RegistrationViewModel>();
            services.AddTransient<CartViewModel>();
            services.AddTransient<ClientOrderViewModel>();
            

            services.AddSingleton<PageService>();
            services.AddSingleton<UserService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<CartService>();

            _provider = services.BuildServiceProvider();
        }
        public MainWindowViewModel? MainWindowViewModel => _provider?.GetRequiredService<MainWindowViewModel>();
        public AuthorizationViewModel? AuthorizationViewModel => _provider?.GetRequiredService<AuthorizationViewModel>();
        public BrowseProductViewModel? BrowseProductViewModel => _provider?.GetRequiredService<BrowseProductViewModel>();
        public RegistrationViewModel? RegistrationViewModel => _provider?.GetRequiredService<RegistrationViewModel>();
        public CartViewModel? CartViewModel => _provider?.GetRequiredService<CartViewModel>();
        public ClientOrderViewModel? ClientOrderViewModel => _provider.GetRequiredService<ClientOrderViewModel>();
    }
}
