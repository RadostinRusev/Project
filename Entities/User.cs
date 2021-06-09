using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisturbedAppsProject.Entities
{
   public class User:BaseEntity
    {
        [Required(ErrorMessage = "Username required")]
        [StringLength(60, MinimumLength =6)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password  required")]
        [StringLength(60,MinimumLength =6)]
        public string Password { get; set; }
      
        public int age { get; set; }
        [StringLength(7)]
        public string gender { get; set; }

       
        public DateTime? DOB { get; set; }

        public bool Online { get; set; }
        [StringLength(40)]
        public string City { get; set; }
        public virtual ICollection<PlayList> PlayList { get; set; }
    }
}
