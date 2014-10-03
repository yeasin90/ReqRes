using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyWrapper.Service.WebHelper;

namespace ThirdPartyWrapper.Service.RequestBuilder
{
    public class RequestDirector
    {
        private RequestBuilder _requestBuilder;
        private IRequest _request;
        private HttpWebRequest _httpWebRequest;

        public RequestDirector(IRequest request)
        {
            if (request.Method == "GET")
                _requestBuilder = new GetRequest();
            else if (request.Method == "POST")
                _requestBuilder = new PostRequest();

            _request = request;

        }

        public HttpWebRequest CreateRequest()
        {
            _httpWebRequest = _requestBuilder.CreateRequest(_request);
            _requestBuilder.SetRequestHeader(_httpWebRequest, _request);
            _requestBuilder.SetRequestCoockie(_httpWebRequest, _request);

            return _httpWebRequest;
        }
    }
}
