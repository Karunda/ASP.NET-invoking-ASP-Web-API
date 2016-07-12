using DCSWebAPI.Helper;
using DCSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCSWebAPI.Controllers
{
    public class BrandController : Controller
    {
        static readonly IServerDataRestClient RestClient = new ServerDataRestClient();
        //
        // GET: /Class/

        public ActionResult Index()
        {
            Brand cl = new Brand();
            cl.type = "Select";
            return View(RestClient.PostBrand(cl));
            //return View();
        }

        public ActionResult Create()
        {
            Brand br = new Brand();
            //Get classes
            Class cl = new Class();
            cl.type = "Select";
            IEnumerable<Class> clreturned = RestClient.PostClass(cl);
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
            br.classes = slt;
            //get types
            DCSWebAPI.Models.Type ty = new DCSWebAPI.Models.Type();
            ty.type = "Select";
            IEnumerable<DCSWebAPI.Models.Type> tyreturned = RestClient.PostType(ty);
            List<System.Web.Mvc.SelectListItem> tyl = new List<System.Web.Mvc.SelectListItem>();
            foreach (DCSWebAPI.Models.Type tytoread in tyreturned)
            {
                SelectListItem sli = new SelectListItem
                {
                    Value = tytoread.type_id.ToString(),
                    Text = tytoread.type_name
                };
                tyl.Add(sli);
            }
            br.types = tyl;
            return View(br);
            //return View();
        }
        [HttpPost]
        public ActionResult Create(Brand cl)
        {
            if (!ModelState.IsValid)
            {
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
                cl.classes = slt;
                //get types
                DCSWebAPI.Models.Type ty = new DCSWebAPI.Models.Type();
                ty.type = "Select";
                IEnumerable<DCSWebAPI.Models.Type> tyreturned = RestClient.PostType(ty);
                List<System.Web.Mvc.SelectListItem> tyl = new List<System.Web.Mvc.SelectListItem>();
                foreach (DCSWebAPI.Models.Type tytoread in tyreturned)
                {
                    SelectListItem sli = new SelectListItem
                    {
                        Value = tytoread.type_id.ToString(),
                        Text = tytoread.type_name
                    };
                    tyl.Add(sli);
                }
                cl.types = tyl;
                ModelState.AddModelError("", "Type brand name is missing");
                return View(cl);
            }
            cl.type = "Insert";
            RestClient.PostBrand(cl);
            return RedirectToAction("Index", "Brand");
            //return View();
        }
        public ActionResult Edit(int id)
        {
            Brand cl = new Brand();
            cl.brand_id = id;
            cl.type = "SelectOne";
            Brand brandview = RestClient.PostBrand(cl).FirstOrDefault();


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
            brandview.classes = slt;
            //get types
            DCSWebAPI.Models.Type ty = new DCSWebAPI.Models.Type();
            ty.type = "Select";
            IEnumerable<DCSWebAPI.Models.Type> tyreturned = RestClient.PostType(ty);
            List<System.Web.Mvc.SelectListItem> tyl = new List<System.Web.Mvc.SelectListItem>();
            foreach (DCSWebAPI.Models.Type tytoread in tyreturned)
            {
                SelectListItem sli = new SelectListItem
                {
                    Value = tytoread.type_id.ToString(),
                    Text = tytoread.type_name
                };
                tyl.Add(sli);
            }
            brandview.types = tyl;


            return View(brandview);
            //return View();
        }
        [HttpPost]
        public ActionResult Edit(Brand cl, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
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
                cl.classes = slt;
                //get types
                DCSWebAPI.Models.Type ty = new DCSWebAPI.Models.Type();
                ty.type = "Select";
                IEnumerable<DCSWebAPI.Models.Type> tyreturned = RestClient.PostType(ty);
                List<System.Web.Mvc.SelectListItem> tyl = new List<System.Web.Mvc.SelectListItem>();
                foreach (DCSWebAPI.Models.Type tytoread in tyreturned)
                {
                    SelectListItem sli = new SelectListItem
                    {
                        Value = tytoread.type_id.ToString(),
                        Text = tytoread.type_name
                    };
                    tyl.Add(sli);
                }
                cl.types = tyl;
                ModelState.AddModelError("", "Type brand name is missing");
                return View(cl);
            }
            cl.type = "Update";
            RestClient.PostBrand(cl);

            return RedirectToAction("Index", "Brand");
            //return View();
        }
        public ActionResult Delete(int id)
        {
            Brand cl = new Brand();
            cl.brand_id = id;
            cl.type = "SelectOne";
            return View(RestClient.PostBrand(cl).FirstOrDefault());
            //return View();
        }
       

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand cl = new Brand();
            cl.brand_id = id;
            cl.type = "Delete";
            RestClient.PostBrand(cl);
            Brand recl = new Brand();
            try
            {
                recl = RestClient.PostBrand(cl).FirstOrDefault();
                if (!recl.deletestatus)
                {
                    ModelState.AddModelError("", "Error during delete. The brand is attached to an existing model");
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
