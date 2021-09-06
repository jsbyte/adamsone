using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Adamsone.Extensions;
using Adamsone.Infrastructure;
using Caliburn.Micro;
using CefSharp;
using CefSharp.Wpf;
using MahApps.Metro.IconPacks;

namespace Adamsone.ViewModels
{
    public class BrowserViewModel : MenuPageViewModelBase
    {
        public BrowserViewModel(string label, PackIconBoxIcons icon) : base(label, icon)
        {

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
                    WebBrowser.Name = Label;
                    WebBrowser.UseAdvancedHandlers();
                    WebBrowser.LoadingStateChanged += WebBrowser_LoadingStateChanged;
                    LoadPage(WebBrowser);

                    NotifyOfPropertyChange(nameof(WebBrowser));
                }
            }
        }

        private void WebBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            IsLoading = e.IsLoading;
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                NotifyOfPropertyChange(nameof(IsLoading));
            }
        }

        public static void LoadPage(ChromiumWebBrowser chromiumWebBrowser)
        {
            switch (chromiumWebBrowser.Name)
            {
                case "AdU":
                    chromiumWebBrowser.LoadAduLive();
                    break;
                case "Blackboard":
                    chromiumWebBrowser.LoadBlackboard();
                    break;
                case "Gmail":
                    chromiumWebBrowser.LoadGmail();
                    break;
                case "Facebook":
                    chromiumWebBrowser.LoadFacebook();
                    break;
                case "Twitter":
                    chromiumWebBrowser.LoadTwitter();
                    break;
            }
        }
    }
}
