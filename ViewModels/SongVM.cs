using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjMVC.ViewModels
{
    public class SongVM
    {
        public int Id { get; set; }


        public int SearchId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date of Creation")]
        [DataType(DataType.Date)]
        public DateTime? DOC { get; set; }
        public string Author { get; set; }

        public string Link { get; set; }
        public float Duration { get; set; }
        public string Genre { get; set; }

        public int PlayListId { get; set; }
    //    public virtual PlayList PlayList { get; set; }
    }
}