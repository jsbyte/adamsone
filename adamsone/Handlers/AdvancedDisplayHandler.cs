using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.Enums;
using CefSharp.Structs;

namespace Adamsone.Handlers
{
    public class AdvancedDisplayHandler : IDisplayHandler
    {
        public void OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
        {

        }

        public bool OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, Size newSize)
        {
            return true;
        }

        public bool OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
        {
            if (consoleMessageArgs.Source.Contains("meet.google.com") && consoleMessageArgs.Message.Contains("Could not start video source"))
            {
                var text = "Adamsone currently unsupported this feature, please refer link below to use OBS Studio solution instead.";
                var link = "https://www.youtube.com/watch?v=EWdOCEd9yKQ";
                var linkDescription = "OBS VIRTUAL CAMERA FOR GOOGLE MEET";

                var script = $"Array.from(document.querySelectorAll('span')).find(e=>e.textContent.includes('screensharing')).innerHTML=\"{text}<p><a href='{link}' target='_blank'>{linkDescription}</a>\"";

                Task.Factory.StartNew(async () =>
                {
                    await Task.Delay(TimeSpan.FromSeconds(0.5));
                    chromiumWebBrowser.ExecuteScriptAsync(script);
                });
            }

            return true;
        }

        public bool OnCursorChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr cursor, CursorType type, CursorInfo customCursorInfo)
        {
            return true;
        }

        public void OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<string> urls)
        {

        }

        public void OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, IBrowser browser, bool fullscreen)
        {

        }

        public void OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress)
        {

        }

        public void OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
        {

        }

        public void OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
        {

        }

        public bool OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
        {
            return true;
        }
    }
}
