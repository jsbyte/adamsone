using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adamsone.Extensions;
using CefSharp;
using Flurl.Http;

namespace Adamsone.Services
{
    public class CookieStorage
    {
        public CookieSession Session { get; set; }

        public List<Cookie> Cookies { get; set; }

        public static CookieStorage New(string baseUrl)
        {
            return new CookieStorage(baseUrl);
        }

        public CookieStorage(string baseUrl)
        {
            Session = new CookieSession(baseUrl);
            Cookies = new List<Cookie>();
            _baseUrl = baseUrl;
        }

        public void SyncCookies(List<Cookie> cookies)
        {
            Cookies.Clear();
            Cookies.AddRange(cookies);
        }

        private readonly string _baseUrl;
        public void SyncCookies(ICookieManager cookieManager)
        {
            foreach (var cookie in Session.Cookies)
            {
                cookieManager.SetCookieAsync(_baseUrl, cookie.ConvertToCookie());
            }
        }
    }

    public enum WebsiteCode
    {
        None = 0,
        Adamson = 1,
        Blackboard = 2,
        Gmail = 4,
        Facebook = 8,
        Twitter = 16
    }

    public class WebSessionManager : Dictionary<WebsiteCode, CookieStorage>
    {
        public WebSessionManager()
        {
            _cookieManager = Cef.GetGlobalCookieManager();
        }

        public WebSessionManager Add(WebsiteCode code)
        {
            this[code] = CookieStorage.New(WebsiteCodeToUrl(code));
            return this;
        }

        private readonly ICookieManager _cookieManager;
        /// <summary>
        /// Retrieve Cookies from url and sync to <see cref="CookieStorage"/>
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<List<Cookie>> RetrieveCookiesAsync(WebsiteCode code)
        {
            var url = WebsiteCodeToUrl(code);
            return _cookieManager.VisitUrlCookiesAsync(url, true)
                .ContinueWith(task =>
                {
                    if(task.Status == TaskStatus.RanToCompletion)
                        this[code].SyncCookies(task.Result);

                    return task.Result;
                });
        }

        public static string WebsiteCodeToUrl(WebsiteCode code) =>
            code switch
            {
                WebsiteCode.Adamson => "https://learn.adamson.edu.ph/V4/",
                WebsiteCode.Blackboard => "https://adamson.blackboard.com/ultra/",
                WebsiteCode.Gmail => "",
                WebsiteCode.Facebook => "",
                WebsiteCode.Twitter => "",
                _ => string.Empty
            };
    }
}
