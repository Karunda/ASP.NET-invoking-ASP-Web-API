using DCSWebAPI.Helper;
using DCSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCSWebAPI.Controllers
{
    public class HomeController : Controller
    {
        static readonly IServerDataRestClient RestClient = new ServerDataRestClient();
        //
        // GET: /Class/

        public ActionResult Index()
        {
            Class cl = new Class();
            cl.type = "Select";
            return View(RestClient.PostClass(cl));
            //return View();
        }
    }
}
