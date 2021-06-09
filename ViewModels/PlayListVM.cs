using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjMVC.ViewModels
{
    public class PlayListVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Genre { get; set; }
        [Display(Name = "Date of Creation")]
        [DataType(DataType.Date)]
        public DateTime? DOC { get; set; }

        public int Quantity { get; set; }

     //   public virtual ICollection<Song> Song { get; set; }

        public int UserId { get; set; }
     //   public virtual User User { get; set; }
    }
}