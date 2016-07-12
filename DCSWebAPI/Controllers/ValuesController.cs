using DCSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DCSWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        String connString = Properties.Settings.Default.ConnString;
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public Class[] ClassApi([FromBody]Class value)
        {
            
            Class[] resClass= new Class[1];
            resClass[0] = new Class();
            resClass[0].deletestatus = true;
            try
            {
                int classid = value.class_id;
                string classname = value.class_name;
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DCSClass", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CLASS_ID", value.class_id));
                cmd.Parameters.Add(new SqlParameter("@CLASS_NAME", value.class_name));
                cmd.Parameters.Add(new SqlParameter("@StatementType", value.type));
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int rowcount = 0;
                DataTable dt = new DataTable();
                dt.Load(rdr);
                rowcount = dt.Rows.Count;

                resClass = new Class[rowcount];
                int count = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    resClass[count] = new Class();
                    resClass[count].class_id = Int32.Parse(dt.Rows[i]["class_id"].ToString());
                    resClass[count].class_name = dt.Rows[i]["class_name"].ToString();
                    resClass[count].type = value.type;
                    resClass[count].deletestatus = true;
                    count++;
                }
                conn.Close();
            }
            catch { resClass[0].deletestatus = false; }
            return resClass;

        }

        [HttpPost]
        public DCSWebAPI.Models.Type[] TypeApi([FromBody]DCSWebAPI.Models.Type value)
        {

            DCSWebAPI.Models.Type[] resType = new DCSWebAPI.Models.Type[1];
            resType[0] = new DCSWebAPI.Models.Type();
            resType[0].deletestatus = true;
            try
            {
                int typeid = value.type_id;
                string typename = value.type_name;
                int classid = value.class_id;
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DCSType", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TYPE_ID", value.type_id));
                cmd.Parameters.Add(new SqlParameter("@TYPE_NAME", value.type_name));
                cmd.Parameters.Add(new SqlParameter("@CLASS_ID", value.class_id));
                cmd.Parameters.Add(new SqlParameter("@StatementType", value.type));
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int rowcount = 0;
                DataTable dt = new DataTable();
                dt.Load(rdr);
                rowcount = dt.Rows.Count;

                resType = new DCSWebAPI.Models.Type[rowcount];
                int count = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    resType[count] = new DCSWebAPI.Models.Type();
                    resType[count].type_id = Int32.Parse(dt.Rows[i]["type_id"].ToString());
                    resType[count].type_name = dt.Rows[i]["type_name"].ToString();
                    resType[count].class_id = Int32.Parse(dt.Rows[i]["class_id"].ToString());
                    resType[count].type = value.type;
                    resType[count].deletestatus = true;
                    count++;
                }
                conn.Close();
            }
            catch { resType[0].deletestatus = false; }
            return resType;

        }

        [HttpPost]
        public Brand[] BrandApi([FromBody]Brand value)
        {

            Brand[] resBrand = new Brand[1];
            resBrand[0] = new Brand();
            resBrand[0].deletestatus = true;
            try
            {
                int brandid = value.brand_id;
                string brandname = value.brand_name;
                int classid = value.class_id;
                int typeid = value.type_id;
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DCSBrand", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@BRAND_ID", value.brand_id));
                cmd.Parameters.Add(new SqlParameter("@BRAND_NAME", value.brand_name));
                cmd.Parameters.Add(new SqlParameter("@CLASS_ID", value.class_id));
                cmd.Parameters.Add(new SqlParameter("@TYPE_ID", value.type_id));
                cmd.Parameters.Add(new SqlParameter("@StatementType", value.type));
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int rowcount = 0;
                DataTable dt = new DataTable();
                dt.Load(rdr);
                rowcount = dt.Rows.Count;

                resBrand = new Brand[rowcount];
                int count = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    resBrand[count] = new Brand();
                    resBrand[count].brand_id = Int32.Parse(dt.Rows[i]["brand_id"].ToString());
                    resBrand[count].brand_name = dt.Rows[i]["brand_name"].ToString();
                    resBrand[count].class_id = Int32.Parse(dt.Rows[i]["class_id"].ToString());
                    resBrand[count].type_id = Int32.Parse(dt.Rows[i]["type_id"].ToString());
                    resBrand[count].type = value.type;
                    resBrand[0].deletestatus = true;
                    count++;
                }
                conn.Close();
            }
            catch { resBrand[0].deletestatus = false; }
            return resBrand;

        }

        [HttpPost]
        public Model[] ModelApi([FromBody]Model value)
        {

            Model[] resModel=new Model[1];
            resModel[0] = new Model();
            resModel[0].deletestatus = true;
            try
            {
                int modelid = value.model_id;
                string modelname = value.model_name;
                int classid = value.class_id;
                int typeid = value.type_id;
                int brandid = value.brand_id;
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DCSModel", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MODEL_ID", value.model_id));
                cmd.Parameters.Add(new SqlParameter("@MODEL_NAME", value.model_name));
                cmd.Parameters.Add(new SqlParameter("@CLASS_ID", value.class_id));
                cmd.Parameters.Add(new SqlParameter("@TYPE_ID", value.type_id));
                cmd.Parameters.Add(new SqlParameter("@BRAND_ID", value.brand_id));
                cmd.Parameters.Add(new SqlParameter("@StatementType", value.type));
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int rowcount = 0;
                DataTable dt = new DataTable();
                dt.Load(rdr);
                rowcount = dt.Rows.Count;

                resModel = new Model[rowcount];
                int count = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    resModel[count] = new Model();
                    resModel[count].model_id = Int32.Parse(dt.Rows[i]["model_id"].ToString());
                    resModel[count].model_name = dt.Rows[i]["model_name"].ToString();
                    resModel[count].class_id = Int32.Parse(dt.Rows[i]["class_id"].ToString());
                    resModel[count].type_id = Int32.Parse(dt.Rows[i]["type_id"].ToString());
                    resModel[count].brand_id = Int32.Parse(dt.Rows[i]["brand_id"].ToString());
                    resModel[count].type = value.type;
                    resModel[count].deletestatus = true;
                    count++;
                }
                conn.Close();
            }
            catch {
                resModel[0] = new Model();
                resModel[0].deletestatus = false; 
            }
            return resModel;

        }


        [HttpPost]
        public Assets[] AssetsApi([FromBody]Assets value)
        {

            Assets[] resAssets = new Assets[1];
            resAssets[0] = new Assets();
            resAssets[0].deletestatus = true;
            try
            {

                int assetid = value.asset_id;
                string assetname = value.asset_name;
                float assetprice = value.asset_price;
                DateTime install_date = value.installed_date;
                int classid = value.class_id;
                int typeid = value.type_id;
                int brandid = value.brand_id;
                int modelid = value.model_id;
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DCSAssets", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ASSET_ID", value.asset_id));
                cmd.Parameters.Add(new SqlParameter("@ASSET_NAME", value.asset_name));
                cmd.Parameters.Add(new SqlParameter("@ASSET_PRICE", value.asset_price));
                cmd.Parameters.Add(new SqlParameter("@INSTALL_DATE", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@CLASS_ID", value.class_id));
                cmd.Parameters.Add(new SqlParameter("@TYPE_ID", value.type_id));
                cmd.Parameters.Add(new SqlParameter("@BRAND_ID", value.brand_id));
                cmd.Parameters.Add(new SqlParameter("@MODEL_ID", value.model_id));
                cmd.Parameters.Add(new SqlParameter("@StatementType", value.type));
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                int rowcount = 0;
                DataTable dt = new DataTable();
                dt.Load(rdr);
                rowcount = dt.Rows.Count;

                resAssets = new Assets[rowcount];
                int count = 0;
                for (int i = 0; i < rowcount; i++)
                {
                    resAssets[count] = new Assets();
                    resAssets[count].asset_id = Int32.Parse(dt.Rows[i]["asset_id"].ToString());
                    resAssets[count].asset_name = dt.Rows[i]["asset_name"].ToString();
                    resAssets[count].asset_price = float.Parse(dt.Rows[i]["asset_price"].ToString());
                    resAssets[count].installed_date = DateTime.Parse(dt.Rows[i]["installed_date"].ToString());
                    resAssets[count].class_id = Int32.Parse(dt.Rows[i]["class_id"].ToString());
                    resAssets[count].type_id = Int32.Parse(dt.Rows[i]["type_id"].ToString());
                    resAssets[count].brand_id = Int32.Parse(dt.Rows[i]["brand_id"].ToString());
                    resAssets[count].model_id = Int32.Parse(dt.Rows[i]["model_id"].ToString());
                    resAssets[count].type = value.type;
                    resAssets[0].deletestatus = true;
                    count++;
                }
                conn.Close();
            }
            catch { resAssets[0].deletestatus = false; }
            return resAssets;

        }
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}