using DCSWebAPI.Helper;
using DCSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCSWebAPI.Controllers
{
    public class TypesController : Controller
    {
        static readonly IServerDataRestClient RestClient = new ServerDataRestClient();
        //
        // GET: /Class/

        public ActionResult Index()
        {
            DCSWebAPI.Models.Type cl = new DCSWebAPI.Models.Type();
            cl.type = "Select";
            return View(RestClient.PostType(cl));
            //return View();
        }
        public ActionResult Create()
        {
            DCSWebAPI.Models.Type ty = new DCSWebAPI.Models.Type();
            Class cl = new Class();
            cl.type = "Select";
            IEnumerable<Class> clreturned= RestClient.PostClass(cl);
            List<System.Web.Mvc.SelectListItem> slt = new List<System.Web.Mvc.SelectListItem>();
            foreach (Class cltoread in clreturned)
            {
                SelectListItem sli = new SelectListItem
                {
                    Value = cltoread.class_id.ToString(),
                    Text = cltoread.class_name
                };
                slt.Add(sli);
            }
            ty.classes = slt;
            return View(ty);
            //return View();
        }
        [HttpPost]
        public ActionResult Create(DCSWebAPI.Models.Type cl)
        {

              if(!ModelState.IsValid)
               {
                   ModelState.AddModelError("", "Type name is missing");
                   return RedirectToAction("Create");
               }

            cl.type = "Insert";
            RestClient.PostType(cl);
            

            return RedirectToAction("Index", "Types");
            //return View();
        }
        public ActionResult Edit(int id)
        {
            DCSWebAPI.Models.Type cl = new DCSWebAPI.Models.Type();
            cl.type_id = id;
            cl.type = "SelectOne";

            DCSWebAPI.Models.Type ty = new DCSWebAPI.Models.Type();
            Class cla = new Class();
            cla.type = "Select";
            IEnumerable<Class> clreturned = RestClient.PostClass(cla);
            List<System.Web.Mvc.SelectListItem> slt = new List<System.Web.Mvc.SelectListItem>();
            foreach (Class cltoread in clreturned)
            {
                SelectListItem sli = new SelectListItem
                {
                    Value = cltoread.class_id.ToString(),
                    Text = cltoread.class_name
                };
                slt.Add(sli);
            }

            DCSWebAPI.Models.Type viewty = RestClient.PostType(cl).FirstOrDefault();
            viewty.classes = slt;
            return View(viewty);
            //return View();
        }
        [HttpPost]
        public ActionResult Edit(DCSWebAPI.Models.Type cl, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Type name is missing");
                return RedirectToAction("Edit");
            }
            cl.type = "Update";
            RestClient.PostType(cl);
            return RedirectToAction("Index", "Types");
            //return View();
        }
        public ActionResult Delete(int id)
        {
            DCSWebAPI.Models.Type cl = new DCSWebAPI.Models.Type();
            cl.type_id = id;
            cl.type = "SelectOne";
            return View(RestClient.PostType(cl).FirstOrDefault());
            //return View();
        }
      
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DCSWebAPI.Models.Type cl = new DCSWebAPI.Models.Type();
            cl.type_id = id;
            cl.type = "Delete";
            RestClient.PostType(cl);

            DCSWebAPI.Models.Type recl = new DCSWebAPI.Models.Type();
            try
            {
                recl = RestClient.PostType(cl).FirstOrDefault();
                if (!recl.deletestatus)
                {
                    ModelState.AddModelError("", "Error during delete. The type is attached to an existing brand");
                    return View(cl);
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }

    }
}
