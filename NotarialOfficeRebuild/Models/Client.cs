using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.Models
{
    public class Client
    {
        public int Id{ get; set; }
        public string FullName { get; set; }
        public string PassportSeries { get; set; }
        public int PassportNumber { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Contract> Contracts { get; set; }

        public Client()
        {
            Contracts = new List<Contract>();
        }
    }
}
