using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RoomMateMatching.Models;
using SampleDb;

namespace RoomMateMatching.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult GetStdPass(UserVM user)
        {
            List<User> list = DataCollector.GetAllUsers();

            if (ModelState.IsValid)
            {
                if (list.Any(x => x.StdNumber == user.StdNum && x.Pass == user.Password))
                    return GetJsonContentResult(user.StdNum);
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }

        public ContentResult GetJsonContentResult(object data)
        {
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(data, camelCaseFormatter),
                ContentType = "application/json"
            };
            return jsonResult;
        }
	}


}