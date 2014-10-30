using ReqRes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ThirdPartyWrapper.Service.WebHelper;

namespace ReqRes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            HomeModel model = new HomeModel();

            return View();
        }

        public ActionResult Table()
        {
            return View();
        }

        public ActionResult UrlForGithubAuthorization()
        {
            return Redirect("https://github.com/login/oauth/authorize?client_id=44d438b1f78370780086&scope=user,repo");
        }

        public ActionResult GithubAccountInformation(string code)
        {
            IWebRequest _webClient = new HttpWebRequestAdapter();
            IRequest request = new Request();
            JavaScriptSerializer serialize = new JavaScriptSerializer();
            IRespone response;

            if (Session["Github_AccessToken"] == null)
            {
                request.HostAddress = new Uri("https://github.com", UriKind.Absolute);
                request.RelaitvePath = new Uri("/login/oauth/access_token", UriKind.Relative);
                request.Method = "POST";
                request.Parameters.Add("client_id", "44d438b1f78370780086");
                request.Parameters.Add("client_secret", "0e7a8a6d33e73259270dfb20086bce6ff8fc9cc3");
                request.Parameters.Add("code", code);
                request.Accept = "application/json";

                response = _webClient.SendRequest(request);
                GithubAccessToken token = new GithubAccessToken();
                token = serialize.Deserialize<GithubAccessToken>(response.ResponseBody);
                Session["Github_AccessToken"] = token.access_token;
            }
            else
            {
                request.HostAddress = new Uri("https://api.github.com", UriKind.Absolute);
                request.RelaitvePath = new Uri("/user", UriKind.Relative);
                request.Method = "GET";
                request.Parameters.Add("access_token", Session["Github_AccessToken"] as string);
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36";

                response = _webClient.SendRequest(request);
                GithubAuthenticatedData userData = serialize.Deserialize<GithubAuthenticatedData>(response.ResponseBody);

                IRequest req2 = new Request();
                req2.HostAddress = new Uri("https://api.github.com", UriKind.Absolute);
                req2.RelaitvePath = new Uri("/users/yeasin90/repos", UriKind.Relative);
                req2.Method = "GET";
                req2.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.124 Safari/537.36";
                req2.Parameters.Add("client_id", "44d438b1f78370780086");
                req2.Parameters.Add("client_secret", "0e7a8a6d33e73259270dfb20086bce6ff8fc9cc3");

                response = _webClient.SendRequest(req2);

                IRequest req3 = new Request();
                req3.HostAddress = new Uri("https://api.github.com", UriKind.Absolute);
                req3.RelaitvePath = new Uri("repositories", UriKind.Relative);
                req3.Method = "GET";
                req3.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/37.0.2062.120 Safari/537.36";
                req3.Parameters.Add("client_id", "44d438b1f78370780086");
                req3.Parameters.Add("client_secret", "0e7a8a6d33e73259270dfb20086bce6ff8fc9cc3");

                response = _webClient.SendRequest(req3);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GithubRepositories()
        {
            IWebRequest _webClient = new HttpWebRequestAdapter();
            IRequest request = new Request();

            request.HostAddress = new Uri("https://api.github.com", UriKind.Absolute);
            request.RelaitvePath = new Uri("/users/yeasin90/repos", UriKind.Relative);
            request.Method = "GET";

            IRespone response = _webClient.SendRequest(request);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public class GithubAccessToken
        {
            public string access_token { get; set; }
            public string scope { get; set; }
            public string token_type { get; set; }
        }
    }
}
