using MonitoR.Common.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoR.Configurator
{
    internal static class Program
    {
        private static readonly SimpleInjector.Container container = new SimpleInjector.Container();

        static Program()
        {
            container.RegisterSingleton<IAppConfig, AppConfig>();
            container.RegisterSingleton<ILog, Log>();
            container.Verify();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var config = container.GetInstance<IAppConfig>();
            var log = container.GetInstance<ILog>();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var mainForm = new MainForm(config, log))
            {
                Application.Run(mainForm);
            }
        }
    }
}
