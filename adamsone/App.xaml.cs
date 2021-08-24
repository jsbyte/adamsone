﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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
            //settings.SetOffScreenRenderingBestPerformanceArgs();
            settings.CefCommandLineArgs.Add("force-device-scale-factor", "1");
            settings.CefCommandLineArgs.Add("off-screen-frame-rate", "60");
            settings.CefCommandLineArgs.Add("enable-media-stream", "1");
            settings.CefCommandLineArgs.Add("enable-gpu", "1");
            settings.CefCommandLineArgs.Add("enable-webgl", "1");
            settings.CefCommandLineArgs.Add("shared-texture-enabled");
            settings.PersistSessionCookies = true;
            settings.PersistUserPreferences = true;
            settings.CachePath = Path.GetFullPath("cache", Environment.CurrentDirectory);
            Cef.Initialize(settings);
            Cef.EnableHighDPISupport();
            base.OnStartup(e);
        }
    }
}
