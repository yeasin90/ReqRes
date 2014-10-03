using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThirdPartyWrapper.Service.WebHelper;

namespace ReqRes.Models
{
    public class HomeModel
    {
        internal void ProcessRequest()
        {
            //http://uhunt.felix-halim.net/api/ranklist/339/0/0
            IRequest request = new Request();
            request.Method = "GET";
            request.HostAddress = new Uri("http://uhunt.felix-halim.net", UriKind.Absolute);
            request.RelaitvePath = new Uri("/api/ranklist/339/0/0", UriKind.Relative);
            request.Accept = "application/json";
            IWebRequest webRequest = new HttpWebRequestAdapter();

            IRespone response = webRequest.SendRequest(request);
        }
    }
}