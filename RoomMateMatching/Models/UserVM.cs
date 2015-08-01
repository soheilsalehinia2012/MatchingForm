using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomMateMatching.Models
{
    public class UserVM
    {
        [Required]
        public string StdNum { get; set; }
        [Required]
        public string Password { get; set; }
    }
}