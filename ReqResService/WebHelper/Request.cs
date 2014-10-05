using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyWrapper.Service.WebHelper
{
    public class Request : IRequest
    {
        public Request()
        {
            CustomHeaders = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
            Cookies = new List<Cookie>();
        }
        public bool? KeepAlive { get; set; }
        public string Method { get; set; }
        public string Accept { get; set; }
        public string ContentType { get; set; }
        public int? TimeOut { get; set; }
        public string UserAgent { get; set; }
        public Uri HostAddress { get; set; }
        public Uri RelaitvePath { get; set; }

        public ICollection<Cookie> Cookies { get; set; }
        public Dictionary<string, string> CustomHeaders { get; set; }
        public string AuthorizationHeader { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public bool IsWebProxy { get; set; }
    }
}
