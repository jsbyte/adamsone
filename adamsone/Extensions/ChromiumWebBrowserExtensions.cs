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
        public static readonly string TwitterUrl = "https://twitter.com/adamson_u";
        public static readonly string FacebookUrl = "https://www.facebook.com/AdamsonUniversity.Official";

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

        public static void LoadTwitter(this ChromiumWebBrowser webBrowser)
        {
            webBrowser.Address = TwitterUrl;
        }

        public static void LoadFacebook(this ChromiumWebBrowser webBrowser)
        {
            webBrowser.Address = FacebookUrl;
        }
    }
}
