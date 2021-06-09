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
    public class SongManagmentService
    {
            private MusicDbContext ctx = new MusicDbContext();
            public List<SongDTO> Get()
            {
            using (UnitOfWork uof = new UnitOfWork())
            {
                List<SongDTO> SongDTO = new List<SongDTO>();
                foreach (var item in uof.SongRepository.Get())
                {
                    SongDTO.Add(new SongDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Duration = item.Duration,
                        Author = item.Author,
                        Genre = item.Genre,
                        DOC = item.DOC,
                        PlayListId = item.PlayListId,
                        Link = item.Link,
                        PlayList = new PlayList
                        {
                            Id = item.PlayListId,
                            Name = item.PlayList.Name,
                            Genre = item.PlayList.Genre,
                            Quantity = item.PlayList.Quantity,
                            UserId = item.PlayList.UserId,

                        }


                    });
                }
                return SongDTO;
            }
               
              
            }
            public SongDTO GetById(int id)
            {
            using (UnitOfWork uof = new UnitOfWork())
            {
                Song item = uof.SongRepository.GetByID(id);
                SongDTO songDTO = new SongDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Duration = item.Duration,
                    Author = item.Author,
                    Genre = item.Genre,
                    DOC = item.DOC,
                    PlayListId = item.PlayListId,
                    PlayList = new PlayList
                    {
                        Id = item.PlayListId,
                        Name = item.PlayList.Name,
                        Genre = item.PlayList.Genre,
                        Quantity = item.PlayList.Quantity,
                        UserId = item.PlayList.UserId,

                    }
                };
                return songDTO;
            }
                
            }
            public bool Save(SongDTO songDTO)
            {
            using (UnitOfWork uof = new UnitOfWork())
            {
                if (songDTO.PlayList == null || songDTO.PlayListId == 0)
                {
                    return false;
                }
                //  Nationality nat = new Nationality
                //   {
                //      Id = StudentDTO.NationalityID,
                //      Title = StudentDTO.Nationality.Title
                //  };
                PlayList playList = uof.PlaylistRepository.GetByID(songDTO.PlayListId);

                Song song = new Song
                {
                    Id = songDTO.Id,
                    Name = songDTO.Name,
                    Duration = songDTO.Duration,
                    Author = songDTO.Author,
                    Genre = songDTO.Genre,
                    DOC = songDTO.DOC,
                    PlayListId = songDTO.PlayListId,

                    PlayList = playList

                };
                playList.Song.Add(song);
                playList.Quantity = playList.Quantity + 1;
                try
                {
                    uof.SongRepository.Insert(song);
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
                    Song song = uof.SongRepository.GetByID(id);
                    uof.SongRepository.Delete(song);
                    uof.Save();

                    return true;

                }
                catch
                {
                    return false;
                }
            }
                
            }
        public bool Edit(int id, SongDTO songDTO)
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                try
                {
                    Song song = uof.SongRepository.GetByID(id);
                    song.Name = songDTO.Name;
                    song.Genre = songDTO.Genre;
                    song.Author = songDTO.Author;
                    song.Duration = songDTO.Duration;

                    uof.SongRepository.Update(song);
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
