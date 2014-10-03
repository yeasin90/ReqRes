using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyWrapper.Service.RequestBuilder;

namespace ThirdPartyWrapper.Service.WebHelper
{
    public class HttpWebRequestAdapter : IWebRequest
    {
        private RequestDirector _director;
        private HttpWebRequest _httpWebRequest;
        private HttpWebResponse _httpResponse;

        public HttpWebRequestAdapter()
        {

        }

        public IResponse<T> SendRequest<T>(IRequest request)
        {
            throw new NotImplementedException();
        }

      
        public IRespone SendRequest(IRequest request)
        {
            _director = new RequestDirector(request);

            _httpWebRequest = _director.CreateRequest();
            IRespone response = BuildResponseHTTP(_httpWebRequest);
            
            return response;
        }

        private IRespone BuildResponseHTTP(HttpWebRequest request)
        {
            HttpWebResponse _httpResponse = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(_httpResponse.GetResponseStream());

            IRespone response = new Response();
            response.CharacterSet = _httpResponse.CharacterSet;
            response.ContentEncoding = _httpResponse.ContentEncoding;
            response.ContentLength = _httpResponse.ContentLength;
            response.ContentType = _httpResponse.ContentType;
            response.IsFromCache = _httpResponse.IsFromCache;
            response.IsMutuallyAuthenticated = _httpResponse.IsMutuallyAuthenticated;
            response.LastModified = _httpResponse.LastModified;
            response.Method = _httpResponse.Method;
            response.ProtocolVersion = _httpResponse.ProtocolVersion;
            
            response.ResponseBody = streamReader.ReadToEnd();
            streamReader.Close();

            response.ResponseUri = _httpResponse.ResponseUri;
            response.Server = _httpResponse.Server;
            response.StatusCode = _httpResponse.StatusCode;
            response.StatusDescription = _httpResponse.StatusDescription;
            response.SupportsHeaders = _httpResponse.SupportsHeaders;

            if (_httpResponse.Headers.Count != 0)
            {
                for (int i = 0; i < _httpResponse.Headers.Count; i++)
                {
                    response.Headers.Add(_httpResponse.Headers.Keys[i], _httpResponse.Headers[i]);
                }
            }

            if (_httpResponse.Cookies.Count != 0)
            {
                foreach (Cookie item in _httpResponse.Cookies)
                {
                    response.Cookies.Add(item);
                }
            }
            
            return response;
        }
    }
}
