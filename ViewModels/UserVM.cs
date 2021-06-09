using AppsService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjMVC.ViewModels
{
    public class UserVM
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }

        public string Password { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }

    public bool Online { get; set; }

        public string City { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string Link { get; set; }

        public UserVM() { }

        public UserVM(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Name = userDTO.Name;
            Password = userDTO.Password;
            age = userDTO.age;
            gender = userDTO.gender;
            City = userDTO.City;
            DOB = userDTO.DOB;
               
        }
    }
}