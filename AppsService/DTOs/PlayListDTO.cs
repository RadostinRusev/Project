using DisturbedAppsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsService.DTOs
{
    public class PlayListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public DateTime? DOC { get; set; }

        public int Quantity { get; set; }

       public virtual ICollection<Song> Song { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
