using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
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
                    var config = IoC.Get<ConfigManager>().Config;
                    switch (Label)
                    {
                        case "AdU":
                            WebBrowser.ExecuteScriptAsyncWhenPageLoaded($"$('#inputUsername').val('{config.StudentId}');$('#inputPassword').val('{config.AdamsonCredential}');$('#btnlogin').click();");
                            WebBrowser.LoadAduLive();
                            break;
                        case "Blackboard":
                            WebBrowser.ExecuteScriptAsyncWhenPageLoaded($"document.getElementById('user_id').value = {config.StudentId};document.getElementById('password').value = '{config.BlackboardCredential}';document.getElementById('entry-login').click();");
                            WebBrowser.LoadBlackboard();
                            break;
                        case "Gmail":
                            WebBrowser.LoadGmail();
                            break;
                        case "Facebook":
                            WebBrowser.LoadFacebook();
                            break;
                        case "Twitter":
                            WebBrowser.LoadTwitter();
                            break;
                    }

                    NotifyOfPropertyChange(nameof(WebBrowser));
                }
            }
        }
    }
}
