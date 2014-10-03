using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyWrapper.Service.WebHelper;

namespace ThirdPartyWrapper.Service.RequestBuilder
{
    internal class PostRequest : RequestBuilder
    {
        private HttpWebRequest _httpWebRequest { get; set; }

        internal override HttpWebRequest CreateRequest(IRequest request)
        {
            _httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(request.HostAddress, request.RelaitvePath));

            _httpWebRequest.Method = request.Method;
            _httpWebRequest.ContentType = request.ContentType;
            _httpWebRequest.Accept = request.Accept;
            _httpWebRequest.UserAgent = request.UserAgent;
            _httpWebRequest.KeepAlive = request.KeepAlive != null ? request.KeepAlive.Value : true;
            _httpWebRequest.Timeout = request.TimeOut != null ? request.TimeOut.Value : 100000;

            Func<string, string, string> mapKeyVal = (key, value) =>
            {
                return value;
            };

            if (request.Parameters.Count != 0)
            {
                string paramValPair = string.Join("&", request.Parameters.Select(kvp => kvp.Key + "=" + mapKeyVal(kvp.Key, kvp.Value)));
                byte[] postFormData = System.Text.Encoding.UTF8.GetBytes(paramValPair.ToString());

                _httpWebRequest.ContentLength = postFormData.Length;
                Stream stream = _httpWebRequest.GetRequestStream();
                stream.Write(postFormData, 0, postFormData.Length);

                stream.Flush();
                stream.Close();
            }

            return _httpWebRequest;
        }
    }
}
