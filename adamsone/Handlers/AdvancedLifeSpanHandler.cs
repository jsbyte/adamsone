using Adamsone.Extensions;
using CefSharp;
using CefSharp.Wpf;

namespace Adamsone.Handlers
{
    public class AdvancedLifeSpanHandler : ILifeSpanHandler
    {
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl,
            string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
            IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            // Set newBrowser to null unless you're attempting to host the popup in a new instance of ChromiumWebBrowser
            //newBrowser = null;


            var advBrowser = new ChromiumWebBrowser(targetUrl);
            advBrowser.UseAdvancedHandlers();
            newBrowser = advBrowser;
            // Return true to cancel the popup creation
            return false;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {

        }

        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return false;
        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {

        }
    }
}
