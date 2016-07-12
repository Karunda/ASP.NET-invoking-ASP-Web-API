using DCSWebAPI.Helper;
using DCSWebAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCSWebAPI.Controllers
{
    public class ClassController : Controller
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
        
        public ActionResult Create()
        {        
            return View();
            //return View();
        }
        [HttpPost]
        public ActionResult Create(Class cl)
        {
            cl.type = "Insert";
            RestClient.PostClass(cl);
            return RedirectToAction("Index", "Class");
            //return View();
        }
        public ActionResult Edit(int id)
        {
            Class cl = new Class();
            cl.class_id = id;
            cl.type = "SelectOne";
            return View(RestClient.PostClass(cl).FirstOrDefault());
            //return View();
        }
        [HttpPost]
        public ActionResult Edit(Class cl, string returnUrl)
        {
            
            cl.type = "Update";
            RestClient.PostClass(cl);
            return RedirectToAction("Index", "Class");
            //return View();
        }
        public ActionResult Delete(int id)
        {
            Class cl = new Class();
            cl.class_id = id;
            cl.type = "SelectOne";
            return View(RestClient.PostClass(cl).FirstOrDefault());
            //return View();
        }
       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Class cl = new Class();
            cl.class_id = id;
            cl.type = "Delete";
            RestClient.PostClass(cl);
            Class recl = new Class();
            try
            {
                recl = RestClient.PostClass(cl).FirstOrDefault();
                if (!recl.deletestatus)
                {
                    ModelState.AddModelError("", "Error during delete. The class is attached to an existing type");
                    return View(cl);
                }
            }
            catch
            {
                return RedirectToAction("Index", "Class");
            }
           
            return RedirectToAction("Index", "Class");
        }

    }
}
