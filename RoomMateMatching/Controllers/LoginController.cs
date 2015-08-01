using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RoomMateMatching.Models;

namespace RoomMateMatching.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult GetStdPass(UserVM user)
        {
            //For Test, We Should have a database of users
            //and check if this user object is in database

            List<UserVM> list = new List<UserVM>()
            {
                new UserVM() {
                    StdNum = "882979",
                    Password = "12345",
                    Role = "user",
                    IsFilledForm = false
                },
                new UserVM() {
                    StdNum = "882970",
                    Password = "54321",
                    Role = "admin",
                    IsFilledForm = true
                }
            };

            if (ModelState.IsValid)
            {
                if (list.Any(x => x.StdNum == user.StdNum && x.Password == user.Password))
                {
                    var u = list.Find(x => x.StdNum == user.StdNum);
                    return GetJsonContentResult(u);

                }
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
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