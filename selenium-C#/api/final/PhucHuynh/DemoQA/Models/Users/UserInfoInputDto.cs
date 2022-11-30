using System.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoQA.Models.Users
{
    public class UserInfoInputDto
    {
        public string Id {get; set;}
        public string Name {get; set;}
        public string Password {get; set;}
        public UserInfoInputDto(string id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
        }

    }
}