using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjMVC.ViewModels.Home
{
    public class LoginVM
    {
        [Required(ErrorMessage = "field required")]
        public string username { get; set; }
        [Required(ErrorMessage = "field required")]
        public string password { get; set; }

        public string grant_type { get; set; }
    }
}