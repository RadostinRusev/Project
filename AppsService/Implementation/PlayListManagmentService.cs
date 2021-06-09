using AppsService.DTOs;
using DisturbedAppsProject.Context;
using DisturbedAppsProject.Entities;
using Repository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppsService.Implementation
{
  public  class PlayListManagmentService
    {
        private MusicDbContext ctx = new MusicDbContext();
        public List<PlayListDTO> Get()
        {
            List<PlayListDTO> playListDTO = new List<PlayListDTO>();
            using (UnitOfWork uof = new UnitOfWork())
            {

                List<Song> Songs = null;


                foreach (var item in uof.PlaylistRepository.Get())
                {
                    Songs = new List<Song>();
                    foreach (var sing in item.Song)
                    {
                        //    Songs.Add(sing);
                        Songs.Add(uof.SongRepository.GetByID(sing.Id));
                        //probvai repositorytata
                    }
                    playListDTO.Add(new PlayListDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Genre = item.Genre,
                        Quantity = item.Quantity,
                        DOC = item.DOC,
                        UserId = item.UserId,

                      //  Song = Songs,

                        User = new User
                        {
                            Id = item.UserId,
                            Name = item.User.Name,
                            DOB = item.User.DOB,
                            age = item.User.age,
                            City = item.User.City,
                            Online = item.User.Online,

                        }


                    });
                }
            }
                return playListDTO;
          
               
        }
        public PlayListDTO GetById(int id)
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                PlayList item = uof.PlaylistRepository.GetByID(id);
                PlayListDTO playListDTO = new PlayListDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Genre = item.Genre,
                    Quantity = item.Quantity,
                    DOC = item.DOC,
                    UserId = item.UserId,
                    User = new User
                    {
                        Id = item.UserId,
                        Name = item.User.Name,
                        DOB = item.User.DOB,
                        age = item.User.age,
                        City = item.User.City,
                        Online = item.User.Online
                    }
                };
                return playListDTO;
            }
                
        }
        public bool Save(PlayListDTO playListDTO)
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                if (playListDTO.UserId == 0)
                {
                    return false;
                }
                UserManagmentService userManagmentService = new UserManagmentService();

                User user1 = uof.UserRepository.GetByID(playListDTO.UserId);
                UserDTO nat = userManagmentService.GetById(playListDTO.UserId);
                User user = new User
                {
                    Id = playListDTO.UserId,
                    Name = user1.Name,
                    gender = user1.gender,
                    City = user1.City,
                    DOB = user1.DOB,
                    Online = user1.Online,
                    age = user1.age
                };

                PlayList playList = new PlayList
                {
                    Id = playListDTO.Id,
                    Name = playListDTO.Name,
                    Genre = playListDTO.Genre,
                    Quantity = playListDTO.Quantity,
                    DOC = playListDTO.DOC,
                    UserId = playListDTO.UserId,
                    Song = playListDTO.Song,
                    User = user1
                    /*{
                        Id = playListDTO.UserId,
                        Name = user1.Name,
                        gender = user1.gender,
                        City = user1.City,
                        DOB = user1.DOB,
                        Online = user1.Online,
                        age = user1.age
                    }*/



                };
                user1.PlayList.Add(playList);
                try
                {
                    uof.PlaylistRepository.Insert(playList);
                    uof.Save();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
               
        }
        public bool Delete(int id)
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                try
                {
                    PlayList Student = uof.PlaylistRepository.GetByID(id);
                    uof.PlaylistRepository.Delete(Student);
                    uof.Save();

                    return true;

                }
                catch
                {
                    return false;
                }
            }
               
        }
        public bool Edit(int id, PlayListDTO playListDTO)
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                try
                {
                    PlayList playList = uof.PlaylistRepository.GetByID(id);
                    playList.Name = playListDTO.Name;
                    playList.Genre = playListDTO.Genre;
                    
                    uof.PlaylistRepository.Update(playList);
                    uof.Save();

                    return true;

                }
                catch
                {
                    return false;
                }
            }

        }
    }
}
