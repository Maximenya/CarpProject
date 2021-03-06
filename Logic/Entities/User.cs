﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Carp.Logic.Entities
{
    public class User
    {
        /// <summary>
        /// этот конструктор должен испоьзоваться только в тестовых целях
        /// </summary>
        /// <param name="id"></param>
        public User(int id=0)
        {
            Id = id;
        }

        public int Id { get; private set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public int BirthYear { get; set; }

        public Gender Gender { get; set; }

         }
}
