using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisturbedAppsProject.Entities
{
  public  class Song:BaseEntity
    {
        [Required(ErrorMessage = "Username required")]
        [StringLength(60, MinimumLength = 2)]
        public string Name { get; set; }
        public DateTime? DOC { get; set; }
        [Required(ErrorMessage = "Author required")]
        public string Author { get; set; }
        [Range(1.00,20.00)]
        public float Duration { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Playlist required")]

        public string Link { get; set; }

        public int PlayListId { get; set; }
        public virtual PlayList PlayList { get; set; }
    }
}
