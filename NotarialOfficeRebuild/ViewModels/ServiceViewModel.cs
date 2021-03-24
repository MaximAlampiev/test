using NotarialOfficeRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.ViewModels
{
    public class ServiceViewModel
    {
        public IEnumerable<Service> Services { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
