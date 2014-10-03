using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyWrapper.Service.WebHelper
{
    public interface IResponse<T>
    {
        T ResponseBody { get; set; }
    }

    public interface IRespone
    {
        /// <summary>
        /// The CharacterSet property contains a value that describes the character set of the response. 
        /// This character set information is taken from the header returned with the response.
        /// 
        /// Exception
        ///     ObjectDisposedException	  The current instance has been disposed. 
        /// </summary>
        string CharacterSet { get; set; }

        /// <summary>
        /// The ContentEncoding property contains the value of the Content-Encoding header returned with the response.
        /// 
        /// Exception
        ///     ObjectDisposedException	  The current instance has been disposed. 
        /// </summary>
        string ContentEncoding { get; set; }

        /// <summary>
        /// The ContentLength property contains the value of the Content-Length header returned with the response. 
        /// If the Content-Length header is not set in the response, ContentLength is set to the value -1.
        /// 
        /// Exception
        ///     ObjectDisposedException	  The current instance has been disposed.
        /// </summary>
        long ContentLength { get; set; }

        /// <summary>
        /// The ContentType property contains the value of the Content-Type header returned with the response.
        /// 
        /// Exception
        ///     ObjectDisposedException	  The current instance has been disposed.
        /// </summary>
        string ContentType { get; set; }

        /// <summary>
        /// The current cache policy and the presence of the requested resource in the cache determine whether a response can be retrieved from the cache. 
        /// Using cached responses usually improves application performance, but there is a risk that the response in the cache does not match the response on the server. 
        /// Use the CachePolicy property to set and the RequestCachePolicy class to enumerate the current caching policy.
        /// </summary>
        bool IsFromCache { get; set; }

        /// <summary>
        /// You can specify mutual authentication using the AuthenticationLevel property.
        /// 
        /// <see cref="http://msdn.microsoft.com/en-us/library/system.net.webrequest.authenticationlevel%28v=vs.110%29.aspx"/>
        /// </summary>
        bool IsMutuallyAuthenticated { get; set; }

        /// <summary>
        /// The LastModified property contains the value of the Last-Modified header received with the response. The date and time are assumed to be local time.
        /// 
        /// Exception
        ///    ObjectDisposedException	  The current instance has been disposed.
        /// </summary>
        DateTime LastModified { get; set; }

        /// <summary>
        /// Method returns the method that is used to return the response. Common HTTP methods are GET, HEAD, POST, PUT, and DELETE.
        /// 
        /// Exception
        ///    ObjectDisposedException	  The current instance has been disposed.
        /// </summary>
        string Method { get; set; }

        /// <summary>
        /// The ProtocolVersion property contains the HTTP protocol version number of the response sent by the Internet resource.
        /// 
        /// Exception
        ///    ObjectDisposedException	  The current instance has been disposed.
        /// </summary>
        Version ProtocolVersion { get; set; }

        /// <summary>
        /// The ResponseUri property contains the URI of the Internet resource that actually responded to the request. 
        /// This URI might not be the same as the originally requested URI, if the original server redirected the request.
        /// The ResponseUri property will use the Content-Location header if present.
        /// Applications that need to access the last redirected ResponseUri should use the HttpWebRequest.
        /// Address property rather than ResponseUri, since the use of ResponseUri property may open security vulnerabilities.
        /// 
        /// Exception
        ///    ObjectDisposedException	  The current instance has been disposed.
        /// </summary>
        Uri ResponseUri { get; set; }

        /// <summary>
        /// The Server property contains the value of the Server header returned with the response.
        /// 
        /// Exception
        ///    ObjectDisposedException	  The current instance has been disposed.
        /// </summary>
        string Server { get; set; }

        /// <summary>
        /// he StatusCode parameter is a number that indicates the status of the HTTP response. 
        /// The expected values for status are defined in the HttpStatusCode class.
        /// </summary>
        /// <seealso cref="http://msdn.microsoft.com/en-us/library/system.net.httpstatuscode%28v=vs.110%29.aspx"/>
        HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets the status description returned with the response. A common status message is OK.
        /// 
        /// <remarks>
        /// Exception : ObjectDisposedException = The current instance has been disposed. 
        /// </remarks>
        /// </summary>
        string StatusDescription { get; set; }

        /// <summary>
        /// This property is always true for .NET Framework 4.5.
        /// </summary>
        bool SupportsHeaders { get; set; }

        Dictionary<string, string> Headers { get; set; }
        ICollection<Cookie> Cookies { get; set; }
        string ResponseBody { get; set; }
    }
}
