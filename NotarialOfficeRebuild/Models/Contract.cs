using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public DateTime SubscriptDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }

        public Employee Employee { get; set; }
        public Client Client { get; set; }
        public Service Service { get; set; }
    }
}
