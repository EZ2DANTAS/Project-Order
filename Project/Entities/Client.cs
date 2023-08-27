﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    internal class Client
    {
        public string NameClient { get; set; }

        public string Email { get; set;}

        public DateTime BirthDate { get; set; }


        public Client() { }
        public Client(string name, string email, DateTime birthDate)
        {
            NameClient = name;
            Email = email;
            BirthDate = birthDate;
        }
    }
}
