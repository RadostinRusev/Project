using DisturbedAppsProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisturbedAppsProject.Context
{
   public class MusicDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }

        public DbSet<Song> Songs { get; set; }

    }
}
