using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyWrapper.Service.WebHelper;

namespace ThirdPartyWrapper.Service.RequestBuilder
{
    internal abstract class RequestBuilder
    {
        internal abstract HttpWebRequest CreateRequest(IRequest request);
        internal virtual void SetRequestHeader(HttpWebRequest httpWebRequest, IRequest request)
        {
            Func<string, string, string> mapKeyVal = (key, value) =>
            {
                return value;
            };

            if (!string.IsNullOrWhiteSpace(request.AuthorizationHeader))
                httpWebRequest.Headers.Add(request.AuthorizationHeader);


            if (request.CustomHeaders != null && request.CustomHeaders.Count != 0)
            {
                foreach (KeyValuePair<string, string> customHeader in request.CustomHeaders)
                {
                    httpWebRequest.Headers.Add(customHeader.Key, customHeader.Value);
                }
                //httpWebRequest.Headers.Add(
            }
            /*
            if (request.Headers.Count != 0)
            {
                //string existingHeader = string.Join(",", httpWebRequest.Headers.
                string headerValuePair = string.Join(",", request.Headers.Select(kvp => kvp.Key + ":" + mapKeyVal(kvp.Key, kvp.Value)));

                string authHeader = "Authorization: OAuth " +
                "realm=\"yahooapis.com\"" +
                ",oauth_consumer_key=\"cosnKey\"" +
                ",oauth_nonce=\"Nonsens\"" +
                ",oauth_signature_method=\"HMAC-SHA1\"";

                httpWebRequest.Headers.Add(headerValuePair);
            }
            */
            //httpWebRequest.Accept = _accept;
        }
        internal virtual void SetRequestCoockie(HttpWebRequest httpWebRequest, IRequest request)
        {
            httpWebRequest.CookieContainer = new CookieContainer();

            Func<string, string, Cookie> mapKeyVal = (key, value) =>
            {
                return new Cookie(key, value);
            };

            if (request.Cookies.Count != 0)
            {
                foreach (Cookie item in request.Cookies)
                {
                    httpWebRequest.CookieContainer.Add(item);
                }
            }
        }
    }
}
