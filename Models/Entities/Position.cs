using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Company.Models.Entities
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Salary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

    }
}
