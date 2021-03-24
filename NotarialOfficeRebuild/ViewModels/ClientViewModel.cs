using NotarialOfficeRebuild.Models;
using NotarialOfficeRebuild.ViewModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.ViewModels
{
    public class ClientViewModel
    {
        public IEnumerable<Client> Clients { get; set; }
        public ClientFilter ClientFilter { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
