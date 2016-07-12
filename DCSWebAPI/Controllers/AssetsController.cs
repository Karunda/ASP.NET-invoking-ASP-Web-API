using DCSWebAPI.Helper;
using DCSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCSWebAPI.Controllers
{
    public class AssetsController : Controller
    {
        static readonly IServerDataRestClient RestClient = new ServerDataRestClient();
        //
        // GET: /Class/

        public ActionResult Index()
        {
            Assets cl = new Assets();
            cl.type = "Select";
            return View(RestClient.PostAssets(cl));
            //return View();
        }

        public ActionResult Create()
        {
            Assets asst = new Assets();
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
            asst.classes = slt;

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
            asst.types = tyl;
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
            asst.brands = brl;
            //get model
            Model ml = new Model();
            ml.type = "Select";
            IEnumerable<Model> mlreturned = RestClient.PostModel(ml);
            List<System.Web.Mvc.SelectListItem> mll = new List<System.Web.Mvc.SelectListItem>();
            foreach (Model mltoread in mlreturned)
            {
                SelectListItem sli = new SelectListItem
                {
                    Value = mltoread.model_id.ToString(),
                    Text = mltoread.model_name
                };
                mll.Add(sli);
            }
            asst.models = mll;
            return View(asst);
            //return View();
        }
        [HttpPost]
        public ActionResult Create(Assets cl)
        {
            if (!ModelState.IsValid)
            {
                //Get classes
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
                //get model
                Model ml = new Model();
                ml.type = "Select";
                IEnumerable<Model> mlreturned = RestClient.PostModel(ml);
                List<System.Web.Mvc.SelectListItem> mll = new List<System.Web.Mvc.SelectListItem>();
                foreach (Model mltoread in mlreturned)
                {
                    SelectListItem sli = new SelectListItem
                    {
                        Value = mltoread.model_id.ToString(),
                        Text = mltoread.model_name
                    };
                    mll.Add(sli);
                }
                cl.models = mll;
                return View(cl);
            }
            cl.type = "Insert";
            RestClient.PostAssets(cl);
            return RedirectToAction("Index", "Assets");
            //return View();
        }

        public ActionResult Edit(int id)
        {
            Assets cl = new Assets();
            cl.asset_id = id;
            cl.type = "SelectOne";
            Assets assetview = RestClient.PostAssets(cl).FirstOrDefault();

            //Get classes
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
            assetview.classes = slt;

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
            assetview.types = tyl;
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
            assetview.brands = brl;
            //get model
            Model ml = new Model();
            ml.type = "Select";
            IEnumerable<Model> mlreturned = RestClient.PostModel(ml);
            List<System.Web.Mvc.SelectListItem> mll = new List<System.Web.Mvc.SelectListItem>();
            foreach (Model mltoread in mlreturned)
            {
                SelectListItem sli = new SelectListItem
                {
                    Value = mltoread.model_id.ToString(),
                    Text = mltoread.model_name
                };
                mll.Add(sli);
            }
            assetview.models = mll;


            return View(assetview);
            //return View();
        }
        [HttpPost]
        public ActionResult Edit(Assets cl, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                //Get classes
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
                //get model
                Model ml = new Model();
                ml.type = "Select";
                IEnumerable<Model> mlreturned = RestClient.PostModel(ml);
                List<System.Web.Mvc.SelectListItem> mll = new List<System.Web.Mvc.SelectListItem>();
                foreach (Model mltoread in mlreturned)
                {
                    SelectListItem sli = new SelectListItem
                    {
                        Value = mltoread.model_id.ToString(),
                        Text = mltoread.model_name
                    };
                    mll.Add(sli);
                }
                cl.models = mll;
                return View(cl);
            }
            cl.type = "Update";
            RestClient.PostAssets(cl);
            return RedirectToAction("Index", "Assets");
            //return View();
        }
        public ActionResult Delete(int id)
        {
            Assets cl = new Assets();
            cl.asset_id = id;
            cl.type = "SelectOne";
            return View(RestClient.PostAssets(cl).FirstOrDefault());
            //return View();
        }
    
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Assets cl = new Assets();
            cl.asset_id = id;
            cl.type = "Delete";
            try
            {
                RestClient.PostAssets(cl);
            }
            catch
            {
                ModelState.AddModelError("", "Error during delete. The Asset is attached to another value");
                return View(cl);
            }
            return RedirectToAction("Index");
        }

    }
}
