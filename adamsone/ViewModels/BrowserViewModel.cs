using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Adamsone.Extensions;
using CefSharp;
using CefSharp.Wpf;
using MahApps.Metro.IconPacks;

namespace Adamsone.ViewModels
{
    public class BrowserViewModel : MenuPageViewModelBase
    {
        public BrowserViewModel(string label, PackIconBoxIcons icon) : base(label, icon)
        {
            //WebBrowser = new ChromiumWebBrowser();
        }

        private ChromiumWebBrowser _webBrowser;

        public ChromiumWebBrowser WebBrowser
        {
            get => _webBrowser;
            set
            {
                _webBrowser = value;
                if (value != null)
                {
                    switch (Label)
                    {
                        case "AdU":
                            WebBrowser.LoadAduLive();
                            break;
                        case "Blackboard":
                            WebBrowser.LoadBlackboard();
                            break;
                        case "Gmail":
                            WebBrowser.LoadGmail();
                            break;
                    }

                    NotifyOfPropertyChange(nameof(WebBrowser));
                }
            }
        }
    }
}
