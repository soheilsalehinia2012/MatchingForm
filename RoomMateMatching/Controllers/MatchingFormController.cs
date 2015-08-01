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
    public class MatchingFormController : Controller
    {
        //
        // GET: /MatchingForm/
        public ActionResult Insert(MatchingFormVM matchingForm)
        {
            //For Test, We Should have a database of users
            //and check if this user object is in database
            List<UserVM> userList = new List<UserVM>()
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
            
            //for test, we should have a database of answers 
            //and insert in it
            List<MatchingFormVM> answersList = new List<MatchingFormVM>();
            
            if (ModelState.IsValid)
            {
                answersList.Add(matchingForm);
                userList.Find(x => x.StdNum == matchingForm.StdNum).IsFilledForm = true;
                return new HttpStatusCodeResult(HttpStatusCode.Created, "answers added.");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        public ContentResult GetJasonContentResult(object data)
        {
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonResult = new ContentResult()
            {
                Content = JsonConvert.SerializeObject(data, camelCaseFormatter),
                ContentType = "application/json"
            };
            return jsonResult;
        }
    }
	
}