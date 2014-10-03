using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyWrapper.Service.WebHelper
{
    public class Response<T> : IResponse<T>
    {
        public T ResponseBody { get; set; }
    }

    public class Response : IRespone
    {
        public Response()
        {
            Headers = new Dictionary<string, string>();
            Cookies = new List<Cookie>();
        }

        public string CharacterSet { get; set; }
        public string ContentEncoding { get; set; }
        public long ContentLength { get; set; }
        public string ContentType { get; set; }
        public bool IsFromCache { get; set; }
        public bool IsMutuallyAuthenticated { get; set; }
        public DateTime LastModified { get; set; }
        public string Method { get; set; }
        public Version ProtocolVersion { get; set; }
        public Uri ResponseUri { get; set; }
        public string Server { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public bool SupportsHeaders { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public ICollection<Cookie> Cookies { get; set; }
        public string ResponseBody { get; set; }
    }
}
