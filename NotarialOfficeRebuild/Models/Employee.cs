﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }

        public Position Position { get; set; }

        public ICollection<Contract> Contracts { get; set; }

        public Employee()
        {
            Contracts = new List<Contract>();
        }
    }
}
