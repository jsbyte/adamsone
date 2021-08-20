using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using Flurl;

namespace Adamsone.Extensions
{
    public static class FlurlExtensions
    {
        public static IFlurlRequest WithCookies(this IFlurlRequest request, List<Cookie> cookies)
        {
            cookies.ForEach(x => request.WithCookie(x.Name, x.Value));
            return request;
        }

        //public static FlurlCookie ConvertToFlurlCookie(this Cookie cookie, string originUrl)
        //{
        //    return new FlurlCookie(cookie.Name, cookie.Value, originUrl)
        //    {
        //        Domain = cookie.Domain,
        //        Path = cookie.Path,
        //        Secure = cookie.Secure,
        //        HttpOnly = cookie.HttpOnly,
        //        Expires = DateTime.SpecifyKind(cookie.Expires ?? DateTime.MaxValue, DateTimeKind.Utc)
        //    };
        //}

        public static Cookie ConvertToCookie(this FlurlCookie flurlCookie)
        {
            var newCookie = new Cookie
            {
                Name = flurlCookie.Name,
                Value = flurlCookie.Value,
                Domain = flurlCookie.Domain,
                Path = flurlCookie.Path,
                Secure = flurlCookie.Secure,
                HttpOnly = flurlCookie.HttpOnly
            };

            if (flurlCookie.Expires.HasValue)
                newCookie.Expires = flurlCookie.Expires.Value.DateTime;

            return newCookie;
        }
    }
}
