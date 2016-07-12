using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCSWebAPI.Models
{
    public class Class
    {
        [Display(Name = "Class Id")]
        public int class_id { get; set; }
        [Required]
        [Display(Name = "Class Name")]
        public string  class_name { get; set; }
        public string type { get; set; }
        public bool deletestatus { get; set; }
    }

    public class Type
    {
        [Display(Name = "Type Id")]
        public int type_id { get; set; }
        [Required]
        [Display(Name = "Type Name")]
        public string type_name { get; set; }
        [Display(Name = "Class Name")]
        public int class_id { get; set; }
        public string  type { get; set; }
        public bool deletestatus { get; set; }
        public List<System.Web.Mvc.SelectListItem> classes { get; set; }
    }

    public class Brand
    {
        [Display(Name = "Brand Id")]
        public int brand_id { get; set; }
        [Required]
        [Display(Name = "Brand Name")]
        public string brand_name { get; set; }
        [Display(Name = "Class Name")]
        public int class_id { get; set; }
        [Display(Name = "Type Name")]
        public int type_id { get; set; }
        public string type { get; set; }
        public bool deletestatus { get; set; }
        public List<System.Web.Mvc.SelectListItem> classes { get; set; }
        public List<System.Web.Mvc.SelectListItem> types { get; set; }
    }

    public class Model
    {
        [Display(Name = "Model Id")]
        public int model_id { get; set; }
        [Required]
        [Display(Name = "Model Name")]
        public string model_name { get; set; }
        [Display(Name = "Class Name")]
        public int class_id { get; set; }
        [Display(Name = "Type Name")]
        public int type_id { get; set; }
        [Display(Name = "Brand Name")]
        public int brand_id { get; set; }
        public string type { get; set; }
        public bool deletestatus { get; set; }
        public List<System.Web.Mvc.SelectListItem> classes { get; set; }
        public List<System.Web.Mvc.SelectListItem> types { get; set; }
        public List<System.Web.Mvc.SelectListItem> brands { get; set; }
    }
    public class Assets
    {
        [Display(Name = "Asset Id")]
        public int asset_id { get; set; }
        [Required]
        [Display(Name = "Asset Name")]
        public string asset_name { get; set; }
        [Display(Name = "Asset Price")]
        public float asset_price { get; set; }
        [Display(Name = "Installed Date")]
        public DateTime installed_date { get; set; }
        [Display(Name = "Class Name")]
        public int class_id { get; set; }
        [Display(Name = "Type Name")]
        public int type_id { get; set; }
        [Display(Name = "Brand Name")]
        public int brand_id { get; set; }
        [Display(Name = "Model Name")]
        public int model_id { get; set; }
        public string type { get; set; }
        public bool deletestatus { get; set; }
        public List<System.Web.Mvc.SelectListItem> classes { get; set; }
        public List<System.Web.Mvc.SelectListItem> types { get; set; }
        public List<System.Web.Mvc.SelectListItem> brands { get; set; }
        public List<System.Web.Mvc.SelectListItem> models { get; set; }

    }
   
}