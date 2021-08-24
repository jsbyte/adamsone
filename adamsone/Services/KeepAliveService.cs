using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Adamsone.Extensions;
using Caliburn.Micro;
using CefSharp;
using CefSharp.Wpf;
using Flurl.Http;

namespace Adamsone.Services
{

    public class KeepAliveService : PropertyChangedBase
    {
        public WebSessionManager SessionManager { get; }

        public bool IsEnabled
        {
            get => _keepAliveTimer.Enabled;
            set
            {
                _keepAliveTimer.Enabled = value;
                NotifyOfPropertyChange(nameof(IsEnabled));
            }
        }

        private readonly Timer _keepAliveTimer;
        private readonly ICookieManager _cookieManager;

        public KeepAliveService(WebSessionManager webSessionManager)
        {
            _keepAliveTimer = new Timer(TimeSpan.FromSeconds(300).TotalMilliseconds);
            _cookieManager = Cef.GetGlobalCookieManager();

            SessionManager = webSessionManager
                .Add(WebsiteCode.Adamson)
                .Add(WebsiteCode.Blackboard);

            _keepAliveTimer.Elapsed += KeepAliveTimer_Elapsed;
            _keepAliveTimer.Start();
        }

        private void KeepAliveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SessionManager.RetrieveCookiesAsync(WebsiteCode.Adamson);
            SessionManager.RetrieveCookiesAsync(WebsiteCode.Blackboard);

            foreach (var item in SessionManager)
            {
                var session = item.Value.Session;
                session.Request().WithCookies(item.Value.Cookies).GetAsync()
                    .ContinueWith(t =>
                {
                    item.Value.SyncCookies(_cookieManager);
                });
            }
        }
    }
}
