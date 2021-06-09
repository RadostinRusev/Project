using DisturbedAppsProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsService.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DOC { get; set; }
        public string Author { get; set; }
        public float Duration { get; set; }
        public string Genre { get; set; }

        public string Link { get; set; }
        public int PlayListId { get; set; }
        public virtual PlayList PlayList { get; set; }
    }
}
