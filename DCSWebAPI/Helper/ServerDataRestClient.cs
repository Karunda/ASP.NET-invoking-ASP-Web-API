using DCSWebAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;

namespace DCSWebAPI.Helper
{
    public class ServerDataRestClient : IServerDataRestClient  
    {
        private readonly RestClient _client;
        private readonly string _url = "http://localhost:64916";

        public ServerDataRestClient()
        {
            System.Uri uri = new System.Uri(_url);
            _client = new RestClient { BaseUrl = uri };
        }
        public IEnumerable<Class> PostClass(Class classData)
        {
            var request = new RestRequest("/api/values/ClassApi", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(classData);

            var response = _client.Execute<List<Class>>(request);
            
            return response.Data;
        }
       
        public IEnumerable<DCSWebAPI.Models.Type> PostType(DCSWebAPI.Models.Type typeData)
        {
            var request = new RestRequest("/api/values/TypeApi", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(typeData);

            var response = _client.Execute<List<DCSWebAPI.Models.Type>>(request);

            return response.Data;
        }
        public IEnumerable<Brand> PostBrand(Brand brandData)
        {
            var request = new RestRequest("/api/values/BrandApi", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(brandData);

            var response = _client.Execute<List<Brand>>(request);

            return response.Data;
        }
        public IEnumerable<Model> PostModel(Model modelData)
        {
            var request = new RestRequest("/api/values/ModelApi", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(modelData);

            var response = _client.Execute<List<Model>>(request);

            return response.Data;
        }
        public IEnumerable<Assets> PostAssets(Assets assetData)
        {
            var request = new RestRequest("/api/values/AssetsApi", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(assetData);

            var response = _client.Execute<List<Assets>>(request);

            return response.Data;
        } 
    }
}