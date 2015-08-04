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
            //for test, we should have a database of answers 
            //and insert in it
            List<MatchingFormVM> list = new List<MatchingFormVM>();
            
            if (ModelState.IsValid)
            {
                list.Add(matchingForm);
                return new HttpStatusCodeResult(HttpStatusCode.Created, "answers added.");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
	
}