using DisturbedAppsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsService.DTOs
{
  public  class UserDTO
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public DateTime? DOB { get; set; }

        public bool Online { get; set; }

        public string City { get; set; }
        public virtual ICollection<PlayList> PlayList { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
     
    }
}
