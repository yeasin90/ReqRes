using ReqRes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReqRes.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            TestModel model = new TestModel { Name = "Yeasin Abedin", Salary = 1000, CurrentTime = DateTime.Now };
            return View(model);
        }

        [OutputCache(Duration=60)]
        public PartialViewResult CacheView()
        {
            TestModel model = new TestModel { Name = "Cached Yeasin Abedin", Salary = 10, CurrentTime = DateTime.Now };
            return PartialView(model);
        }
    }
}
