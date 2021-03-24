using NotarialOfficeRebuild.Models;
using NotarialOfficeRebuild.ViewModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.ViewModels
{
    public class ContractViewModel
    {
        public IEnumerable<Contract> Contracts { get; set; }
        public ContractFilter ContractFilter { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
