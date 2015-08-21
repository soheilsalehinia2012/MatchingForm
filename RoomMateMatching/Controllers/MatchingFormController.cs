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
    public class MatchingFormController : Controller
    {
        // GET: /MatchingForm/
        public ActionResult Insert(MatchingFormVM matchingForm)
        {
            DataCollector.UpdateUser(matchingForm.StdNum, matchingForm.AnswersString, matchingForm.ImportanceString);

            if (ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.Created, "answers added.");
            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        }
    }
	
}