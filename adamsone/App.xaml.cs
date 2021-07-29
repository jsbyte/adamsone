using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using CefSharp;
using CefSharp.Wpf;

namespace Adamsone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var settings = new CefSettings();
            settings.SetOffScreenRenderingBestPerformanceArgs();
            settings.CefCommandLineArgs.Add("force-device-scale-factor", "1");
            Cef.Initialize(settings);
            Cef.EnableHighDPISupport();
            base.OnStartup(e);
        }
    }
}
