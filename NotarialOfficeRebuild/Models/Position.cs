using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Duties { get; set; }
        public string Requirement { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Position()
        {
            Employees = new List<Employee>();
        }
    }
}
