using Adamsone.Handlers;
using Adamsone.Infrastructure;
using Adamsone.Models;
using Caliburn.Micro;
using CefSharp;
using CefSharp.Handler;
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

        public static readonly Config Config = IoC.Get<ConfigManager>().Config;

        public static void LoadAduLive(this ChromiumWebBrowser webBrowser)
        {
            if (Config.IsAdamsonEnable)
                webBrowser.ExecuteScriptAsyncWhenPageLoaded($"$('#inputUsername').val('{Config.StudentId}');$('#inputPassword').val('{Config.AdamsonCredential}');$('#btnlogin').click()");

            webBrowser.Address = AduLiveUrl;
        }

        public static void LoadBlackboard(this ChromiumWebBrowser webBrowser)
        {
            if (Config.IsBlackboardEnable)
                webBrowser.ExecuteScriptAsyncWhenPageLoaded($"document.getElementById('user_id').value = {Config.StudentId};document.getElementById('password').value = '{Config.BlackboardCredential}';document.getElementById('entry-login').click()");

            webBrowser.ExecuteScriptAsyncWhenPageLoaded("cookieConsent.agree('/webapps/login/?action=logout')");
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

        public static void UseAdvancedHandlers(this ChromiumWebBrowser webBrowser)
        {
            webBrowser.JsDialogHandler = new AdvancedJsDialogHandler();
            webBrowser.LifeSpanHandler = new AdvancedLifeSpanHandler();
            webBrowser.RequestHandler = new AdvancedRequestHandler();
            webBrowser.LoadHandler = new AdvancedLoadHandler();
            webBrowser.MenuHandler = new AdvancedContextMenuHandler();
            webBrowser.ContextMenu = null;
        }
    }
}
