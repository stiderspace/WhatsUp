using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhatsUp2.Models
{
    public class NewChatModel
    {
        [Required]
        [Display(Name = "Chat Name")]
        public string ChatName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string ChatDesc { get; set; }

        [Required]
        public int participant { get; set; }
    }
}