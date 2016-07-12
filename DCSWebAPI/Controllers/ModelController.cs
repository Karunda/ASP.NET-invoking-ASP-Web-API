using DCSWebAPI.Helper;
using DCSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCSWebAPI.Controllers
{
    public class ModelController : Controller
    {
        static readonly IServerDataRestClient RestClient = new ServerDataRestClient();
        //
        // GET: /Class/

        public ActionResult Index()
        {
            Model cl = new Model();
            cl.type = "Select";
            return View(RestClient.PostModel(cl));
            //return View();
        }
        public ActionResult Create()
        {
            Model ml = new Model();
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
            ml.classes = slt;
           
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
            ml.types = tyl;
            //get brands
            Brand br = new Brand();
            br.type = "Select";
            IEnumerable<Brand> brreturned = RestClient.PostBrand(br);
            List<System.Web.Mvc.SelectListItem> brl = new List<System.Web.Mvc.SelectListItem>();
            foreach (Brand brtoread in brreturned)
            {
                SelectListItem sli = new SelectListItem
                {
                    Value = brtoread.brand_id.ToString(),
                    Text = brtoread.brand_name
                };
                brl.Add(sli);
            }
            ml.brands = brl;
            return View(ml);
            //return View();
        }
        [HttpPost]
        public ActionResult Create(Model cl)
        {
            if (!ModelState.IsValid)
            {
                Class cla = new Class();
                cl.type = "Select";
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
                //get brands
                Brand br = new Brand();
                br.type = "Select";
                IEnumerable<Brand> brreturned = RestClient.PostBrand(br);
                List<System.Web.Mvc.SelectListItem> brl = new List<System.Web.Mvc.SelectListItem>();
                foreach (Brand brtoread in brreturned)
                {
                    SelectListItem sli = new SelectListItem
                    {
                        Value = brtoread.brand_id.ToString(),
                        Text = brtoread.brand_name
                    };
                    brl.Add(sli);
                }
                cl.brands = brl;
                ModelState.AddModelError("", "Type model name is missing");
                return View(cl);
            }
            cl.type = "Insert";
            RestClient.PostModel(cl);
            return RedirectToAction("Index", "Model");
            //return View();
        }

        public ActionResult Edit(int id)
        {
            Model cl = new Model();
            cl.model_id = id;
            cl.type = "SelectOne";
            return View(RestClient.PostModel(cl).FirstOrDefault());
            //return View();
        }
        [HttpPost]
        public ActionResult Edit(Model cl, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                Class cla = new Class();
                cl.type = "Select";
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
                //get brands
                Brand br = new Brand();
                br.type = "Select";
                IEnumerable<Brand> brreturned = RestClient.PostBrand(br);
                List<System.Web.Mvc.SelectListItem> brl = new List<System.Web.Mvc.SelectListItem>();
                foreach (Brand brtoread in brreturned)
                {
                    SelectListItem sli = new SelectListItem
                    {
                        Value = brtoread.brand_id.ToString(),
                        Text = brtoread.brand_name
                    };
                    brl.Add(sli);
                }
                cl.brands = brl;
                ModelState.AddModelError("", "Type model name is missing");
                return View(cl);
            }
            cl.type = "Update";
            RestClient.PostModel(cl);
            return RedirectToAction("Index", "Model");
            //return View();
        }
        public ActionResult Delete(int id)
        {
            Model cl = new Model();
            cl.model_id = id;
            cl.type = "SelectOne";
            return View(RestClient.PostModel(cl).FirstOrDefault());
            //return View();
        }
     
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Model cl = new Model();
            cl.model_id = id;
            cl.type = "Delete";
            RestClient.PostModel(cl);
            Model recl = new Model();
            try
            {
                recl=RestClient.PostModel(cl).FirstOrDefault();
                if (!recl.deletestatus)
                {
                    ModelState.AddModelError("", "Error during delete. The model is attached to an existing asset");
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
