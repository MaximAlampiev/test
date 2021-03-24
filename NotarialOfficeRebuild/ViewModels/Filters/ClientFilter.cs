using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.ViewModels.Filters
{
    public class ClientFilter
    {
        public string Address { get; set; }

        public ClientFilter(string address)
        {
            Address = address;
        }
    }
}
