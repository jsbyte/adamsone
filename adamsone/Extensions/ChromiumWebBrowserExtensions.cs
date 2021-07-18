using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp.Wpf;

namespace Adamsone.Extensions
{
    public static class ChromiumWebBrowserExtensions
    {
        public static readonly string AduLiveUrl = "https://learn.adamson.edu.ph/V4/";
        public static readonly string BlackboardUrl = "https://adamson.blackboard.com/";
        public static readonly string GmailUrl = "http://mail.adamson.edu.ph/";

        public static void LoadAduLive(this ChromiumWebBrowser webBrowser)
        {
            webBrowser.Address = AduLiveUrl;
        }
        public static void LoadBlackboard(this ChromiumWebBrowser webBrowser)
        {
            webBrowser.Address = BlackboardUrl;
        }
        public static void LoadGmail(this ChromiumWebBrowser webBrowser)
        {
            webBrowser.Address = GmailUrl;
        }
    }
}
