using NotarialOfficeRebuild.Models;
using NotarialOfficeRebuild.ViewModels.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public EmployeeFilter EmployeeFilter { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
