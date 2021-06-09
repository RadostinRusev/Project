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
  public  class UserManagmentService
    {
        private MusicDbContext ctx = new MusicDbContext();
        public List<UserDTO> Get()
        {
            List<UserDTO> userDTO = new List<UserDTO>();
           using (UnitOfWork uof = new UnitOfWork())
            {

                foreach(var item in uof.UserRepository.Get())
                {

                    userDTO.Add(new UserDTO {
                        Id = item.Id,
                        Name = item.Name,
                        Password = item.Password,
                        gender = item.gender,
                        City = item.City,
                        DOB = item.DOB,
                        Online = item.Online,
                        age = item.age,
                      
                  //  PlayList = item.PlayList
                        
                    });

                }
            }
       
            return userDTO;
        }

        public UserDTO GetById(int id)
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                User item = uof.UserRepository.GetByID(id);

                UserDTO userDTO = new UserDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Password = item.Password,
                    gender = item.gender,
                    City = item.City,
                    DOB = item.DOB,
                    Online = item.Online,
                    age = item.age
                };



                return userDTO;
            }
        }
            public bool Save(UserDTO userDTO)
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                User user = new User
                {
                    Name = userDTO.Name,
                    Password = userDTO.Password,
                    gender = userDTO.gender,
                    City = userDTO.City,
                    DOB = userDTO.DOB,
                    Online = userDTO.Online,
                    age = userDTO.age,
                    Id = userDTO.Id
                };

                try
                {
                    uof.UserRepository.Insert(user);
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
                    User user = uof.UserRepository.GetByID(id);
                    uof.UserRepository.Delete(user);
                    uof.Save();

                    return true;

                }
                catch
                {
                    return false;
                }
            }
                
        }

        public bool Edit(int id, UserDTO userDTO)
        {
            using (UnitOfWork uof = new UnitOfWork())
            {
                User user = uof.UserRepository.GetByID(id);
                try
                {
                   
                    user.Name = userDTO.Name;
                    user.gender = userDTO.gender;
                    user.Password = userDTO.Password;
                    user.DOB = userDTO.DOB;
                    user.City = userDTO.City;
                    user.age = userDTO.age;
                    uof.UserRepository.Update(user);
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

