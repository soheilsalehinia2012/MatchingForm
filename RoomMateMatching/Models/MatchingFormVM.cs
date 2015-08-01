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
        public string StdNum { get; set; }
        [Required]
        public string Answer01 { get; set; }
        [Required]
        public string Answer02 { get; set; }
        [Required]
        public string Answer03 { get; set; }
        [Required]
        public string Answer04 { get; set; }
        [Required]
        public string Answer05 { get; set; }
        [Required]
        public string Answer06 { get; set; }
        [Required]
        public string Answer07 { get; set; }
        [Required]
        public string Answer08 { get; set; }
        [Required]
        public string Answer09 { get; set; }
        [Required]
        public string Answer10 { get; set; }

    }
}