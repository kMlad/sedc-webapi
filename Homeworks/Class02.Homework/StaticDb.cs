using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class01.Homework.Models;

namespace Class01.Homework
{
    public static class StaticDb
    {
        public static List<string> usersList = new List<string>()
        {
            "Goran",
            "Zoran",
            "najjakprogramer123",
            "BakaPrase",
            "choda19a"
        };

        public static List<User> userModelsList = new List<User>()
        {
            new User()
            {
                FirstName = "Goran",
                LastName = "Brat mu na Zoran",
                Id = 1
            },
            new User()
            {
                FirstName = "Zoran",
                LastName = "Brat mu na Goran",
                Id = 2
            },
            new User()
            {
                FirstName = "najjak",
                LastName = "programer",
                Id = 123
            },
            new User()
            {
                FirstName = "Baka",
                LastName = "Prase",
                Id = 4
            },
            new User()
            {
                FirstName = "Choda",
                LastName = "19a",
                Id = 19
            }
        };
    }
}
