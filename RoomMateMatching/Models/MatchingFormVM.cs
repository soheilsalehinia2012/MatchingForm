using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomMateMatching.Models
{
    public class MatchingFormVM
    {
        [Required]
        public string AnswersString { get; set; }
        [Required]
        public string StdNum { get; set; }
    }
}