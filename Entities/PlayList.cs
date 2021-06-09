using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisturbedAppsProject.Entities
{
   public class PlayList:BaseEntity
    {

        [Required(ErrorMessage = "Name required")]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string Genre { get; set; }

        public int Quantity { get; set; }
        public DateTime? DOC { get; set; }
        public virtual ICollection<Song> Song { get; set; }
        [Required(ErrorMessage = "User required")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
