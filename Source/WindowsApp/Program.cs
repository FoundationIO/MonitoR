using MonitoR.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoR.Configurator
{
    static class Program
    {
        static readonly SimpleInjector.Container container = new SimpleInjector.Container();
//#pragma warning disable S3963 // "static" fields should be initialized inline
        static Program()
        {
            container.RegisterSingleton<IAppConfig, AppConfig>();
            container.RegisterSingleton<ILog, Log>();
            container.Verify();
        }
//#pragma warning restore S3963 // "static" fields should be initialized inline

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = container.GetInstance<IAppConfig>();
            var log = container.GetInstance<ILog>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(config, log));
        }
    }
}
