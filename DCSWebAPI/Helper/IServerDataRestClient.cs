using DCSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCSWebAPI.Helper
{
    public interface IServerDataRestClient
    {
        IEnumerable<Class> PostClass(Class serverDataModel);
        IEnumerable<DCSWebAPI.Models.Type> PostType(DCSWebAPI.Models.Type serverDataModel);
        IEnumerable<Brand> PostBrand(Brand serverDataModel);
        IEnumerable<Model> PostModel(Model serverDataModel);
        IEnumerable<Assets> PostAssets(Assets serverDataModel);
    
    } 
}