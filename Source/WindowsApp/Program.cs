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
        static readonly SimpleInjector.Container container;
        static Program()
        {
            container = new SimpleInjector.Container();
            container.RegisterSingleton<IAppConfig, AppConfig>();
            container.RegisterSingleton<ILog, Log>();
            container.Verify();
        }

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
