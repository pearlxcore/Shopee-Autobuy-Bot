using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopee_Autobuy_Bot.Services;
using Shopee_Autobuy_Bot.Services.Logger;
using Shopee_Autobuy_Bot.Services.Notification;
using Shopee_Autobuy_Bot.Services.Profile;
using System;
using System.Windows.Forms;

namespace Shopee_Autobuy_Bot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Login());
        //}

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Login>());
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<ISeleniumService, SeleniumService>();
                    services.AddTransient<IAutoBuyLoggerService, AutoBuyLoggerService>();
                    services.AddTransient<IAutoBuyService, AutoBuyService>();
                    services.AddTransient<INotificationService, NotificationService>();
                    services.AddTransient<IProfileService, ProfileService>();
                    services.AddSingleton<RichTextBox>();
                    services.AddSingleton<Button>();
                    services.AddTransient<Login>();
                });
        }
    }
}
