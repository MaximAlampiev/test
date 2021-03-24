using Microsoft.AspNetCore.Mvc.Rendering;
using NotarialOfficeRebuild.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotarialOfficeRebuild.ViewModels.Filters
{
    public class EmployeeFilter
    {
        public int? SelectedPositionId { get; set; }
        public SelectList Positions { get; set; }

        public EmployeeFilter(int? slelectedPositionId, IList<Position> positions)
        {
            positions.Insert(0, new Position()
            {
                Id = 0,
                Name = "All"
            });

            SelectedPositionId = slelectedPositionId;
            Positions = new SelectList(positions, "Id", "Name", slelectedPositionId);
        }
    }
}
