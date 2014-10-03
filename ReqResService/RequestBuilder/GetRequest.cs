using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyWrapper.Service.WebHelper;

namespace ThirdPartyWrapper.Service.RequestBuilder
{
    internal class GetRequest : RequestBuilder
    {
        private HttpWebRequest _httpWebRequest { get; set; }

        internal override HttpWebRequest CreateRequest(IRequest request)
        {
            Func<string, string, string> mapKeyVal = (key, value) =>
            {
                return value;
            };

            if (request.Parameters.Count != 0)
            {
                string paramValPair = string.Join("&", request.Parameters.Select(kvp => kvp.Key + "=" + mapKeyVal(kvp.Key, kvp.Value)));
                request.RelaitvePath = new Uri(request.RelaitvePath + "?" + paramValPair, UriKind.Relative);
            }

            _httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(request.HostAddress, request.RelaitvePath));

            _httpWebRequest.Method = request.Method;
            _httpWebRequest.ContentType = request.ContentType;
            _httpWebRequest.Accept = request.Accept;
            _httpWebRequest.UserAgent = request.UserAgent;
            _httpWebRequest.KeepAlive = request.KeepAlive != null ? request.KeepAlive.Value : true;
            _httpWebRequest.Timeout = request.TimeOut != null ? request.TimeOut.Value : 100000;

            if (request.IsWebProxy)
            {
                //  Obtain the 'Proxy' of the  Default browser. 
                IWebProxy theProxy = _httpWebRequest.Proxy;
                // Print the Proxy Url to the console.
                if (theProxy != null)
                {
                    // Use the default credentials of the logged on user.
                    theProxy.Credentials = CredentialCache.DefaultCredentials;
                }
            }

            return _httpWebRequest;
        }
    }
}
