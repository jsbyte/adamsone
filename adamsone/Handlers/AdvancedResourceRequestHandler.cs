using CefSharp;

namespace Adamsone.Handlers
{
    public class AdvancedResourceRequestHandler : IResourceRequestHandler
    {
        public void Dispose()
        {

        }

        public ICookieAccessFilter GetCookieAccessFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame,
            IRequest request)
        {
            return null;
        }

        public CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request,
            IRequestCallback callback)
        {
            return CefReturnValue.Continue;
        }

        public IResourceHandler GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            return null;
        }

        public void OnResourceRedirect(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request,
            IResponse response, ref string newUrl)
        {

        }

        public bool OnResourceResponse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request,
            IResponse response)
        {
            return false;
        }

        public IResponseFilter GetResourceResponseFilter(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame,
            IRequest request, IResponse response)
        {
            return null;
        }

        public void OnResourceLoadComplete(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request,
            IResponse response, UrlRequestStatus status, long receivedContentLength)
        {

        }

        public bool OnProtocolExecution(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            return false;
        }
    }
}
