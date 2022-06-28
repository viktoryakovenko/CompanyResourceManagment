using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Company.Models.Entities
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
