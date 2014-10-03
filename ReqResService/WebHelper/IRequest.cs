using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartyWrapper.Service.WebHelper
{
    public interface IRequest
    {
        /// <summary>
        /// Set this property to true to send a Connection HTTP header with the value Keep-alive. 
        /// An application uses KeepAlive to indicate a preference for persistent connections. 
        /// When the KeepAlive property is true, the application makes persistent connections to the servers that support them.
        /// 
        /// True if the request to the Internet resource should contain a Connection HTTP header with the value Keep-alive; otherwise, false. 
        /// The default is true.
        /// </summary>
        bool? KeepAlive { get; set; }

        /// <summary>
        /// The request method to use to contact the Internet resource. The default value is GET.
        /// </summary>
        string Method { get; set; } 

        /// <summary>
        /// The value of the Accept HTTP header. The default value is null.
        /// 
        /// Other Values : "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8", "application/xml", "image/*" etc
        /// </summary>
        string Accept { get; set; }

        /// <summary>
        /// The value of the Content-type HTTP header. The default value is null.
        /// 
        /// The ContentType property contains the media type of the request. 
        /// Values assigned to the ContentType property replace any existing contents when the request sends the Content-type HTTP header.
        /// For POST request = "application/x-www-form-urlencoded"
        /// </summary>
        string ContentType { get; set; } 

        /// <summary>
        /// The number of milliseconds to wait before the request times out. The default value is 100,000 milliseconds (100 seconds).
        /// 
        /// Timeout is the number of milliseconds that a subsequent synchronous request made with the GetResponse method waits for a response, and the GetRequestStream method waits for a stream. 
        /// The Timeout applies to the entire request and response, not individually to the GetRequestStream and GetResponse method calls. 
        /// If the resource is not returned within the time-out period, the request throws a WebException with the Status property set to WebExceptionStatus.Timeout.
        /// The Timeout property must be set before the GetRequestStream or GetResponse method is called. 
        /// Changing the Timeout property after calling the GetRequestStream or GetResponse method has no effect.
        /// The Timeout property has no effect on asynchronous requests made with the BeginGetResponse or BeginGetRequestStream method.
        /// Caution 
        /// In the case of asynchronous requests, the client application implements its own time-out mechanism. Refer to the example in the BeginGetResponse method.
        /// To specify the amount of time to wait before a read or write operation times out, use the ReadWriteTimeout property.
        /// A Domain Name System (DNS) query may take up to 15 seconds to return or time out. 
        /// If your request contains a host name that requires resolution and you set Timeout to a value less than 15 seconds, it may take 15 seconds or more before a WebException is thrown to indicate a timeout on your request.
        /// </summary>
        int? TimeOut { get; set; }

        /// <summary>
        /// The value of the User-agent HTTP header. The default value is null.
        /// 
        /// In HTTP, the User-Agent string is often used for content negotiation, where the origin server selects suitable content or operating parameters for the response. 
        /// For example, the User-Agent string might be used by a web server to choose variants based on the known capabilities of a particular version of client software.
        /// 
        /// Example : "Microsoft-WNS/6.3"
        ///           "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/35.0.1916.114 Safari/537.36"
        ///           "Mozilla/5.0 (iPad; U; CPU OS 3_2_1 like Mac OS X; en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Mobile/7B405"
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// Rather than passing the whole Url, we will pass absolute paht and relative path.
        /// 
        /// Example : Microsoft contact full api url = https://apis.live.net/v5.0/me/contacts?access_token=1234
        ///           Here we can see, they are providing v5 of this API. After some times it can be changed to v6/7/8 or could be migrated to another host
        ///           So, rather than passing full url, we will user Host address and relative path to make the request.
        ///           Here HostAddress is https://apis.live.net and RelaitvePath is "/v5.0/me/contacts"
        /// </summary>
        /// <remarks>
        /// For more : <see cref="http://sixsic6.wordpress.com/2014/09/19/uri-relative-and-absoule-in-c/"/>
        /// </remarks>
        Uri HostAddress { get; set; }
        /// <summary>
        /// Rather than passing the whole Url, we will pass absolute paht and relative path.
        /// 
        /// Example : Microsoft contact full api url = https://apis.live.net/v5.0/me/contacts?access_token=1234
        ///           Here we can see, they are providing v5 of this API. After some times it can be changed to v6/7/8 or could be migrated to another host
        ///           So, rather than passing full url, we will user Host address and relative path to make the request.
        ///           Here HostAddress is https://apis.live.net and RelaitvePath is "/v5.0/me/contacts"
        /// </summary>
        /// <remarks>
        /// For more : <see cref="http://sixsic6.wordpress.com/2014/09/19/uri-relative-and-absoule-in-c/"/>
        /// </remarks>
        Uri RelaitvePath { get; set; }

        /// <summary>
        /// The CookieContainer property provides an instance of the CookieContainer class that contains the cookies associated with this request.
        /// CookieContainer is null by default. 
        /// You must assign a CookieContainer object to the property to have cookies returned in the Cookies property of the HttpWebResponse returned by the GetResponse method.
        /// </summary>
        /// <seealso cref="http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.cookiecontainer%28v=vs.110%29.aspx"/>
        ICollection<Cookie> Cookies { get; set; }
        Dictionary<string, string> Headers { get; set; }
        string CustomHeader { get; set; }
        Dictionary<string, string> Parameters { get; set; }
        bool IsWebProxy { get; set; }
    }
}
