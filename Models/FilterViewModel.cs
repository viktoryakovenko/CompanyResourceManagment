using Company.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Company.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Position> positions, List<Department> departments, int? position, int? department, string name)
        {
            positions.Insert(0, new Position { Name = "All", Id = 0 });
            Positions = new SelectList(positions, "Id", "Name", position);

            departments.Insert(0, new Department { Name = "All", Id = 0 });
            Departments = new SelectList(departments, "Id", "Name", department);

            SelectedDepartment = department;
            SelectedPosition = position;
            SelectedName = name;
        }
        public SelectList Departments { get; private set; } // список відділів
        public SelectList Positions { get; private set; } // список посад
        public int? SelectedDepartment { get; private set; }   // обраний відділ
        public int? SelectedPosition { get; private set; }   // обрана посада
        public string SelectedName { get; private set; }    // ім'я
    }
}
