using Microsoft.AspNetCore.Mvc.Rendering;
using NotarialOfficeRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.ViewModels.Filters
{
    public class ContractFilter
    {
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? SelectedClientId { get; set; }
        public SelectList Clients { get; set; }

        public ContractFilter(DateTime? subscriptionDate, DateTime? endDate, int? selectedClientId, IList<Client> clients)
        {
            clients.Insert(0, new Client()
            {
                Id = 0,
                FullName = "All"
            });

            SubscriptionDate = subscriptionDate;
            EndDate = endDate;
            SelectedClientId = selectedClientId;
            Clients = new SelectList(clients, "Id", "FullName", selectedClientId);
        }
    }
}
