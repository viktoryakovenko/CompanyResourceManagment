using System;
using System.ComponentModel.DataAnnotations;

namespace Company.Models.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Phone]
        public string Phone { get; set; }
        public DateTime Birthdate { get; set; }

       
        [Required]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Required]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
