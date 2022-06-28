using Company.Models;
using Company.Models.Entities;
using System.Linq;

namespace Company
{
    public class DatabaseInitializer
    {
        public static void Initialize(CompanyContext db)
        {
            if (!db.Positions.Any())
            {
                db.Positions.AddRange(
                    new Position { Name = "Junior", Salary = 600.0m },
                    new Position { Name = "Middle", Salary = 1600.0m },
                    new Position { Name = "Senior", Salary = 4000.0m }
                );
            }
            db.SaveChanges();

            if (!db.Departments.Any())
            {
                db.Departments.AddRange(
                    new Department { Name = "Analytics" },
                    new Department { Name = "Development" },
                    new Department { Name = "Finance" }
                );
            }
            db.SaveChanges();

            if (!db.Employees.Any())
            {
                db.Employees.AddRange(
                    new Employee
                    {
                        Name = "Georgy",
                        Surname = "Makarov",
                        Patronymic = "Bogdanovich",
                        Phone = "+380671836342",
                        Birthdate = new System.DateTime(1999, 12, 4),
                        DepartmentId = 2,
                        PositionId = 2
                    },
                    new Employee
                    {
                        Name = "Dmitry",
                        Surname = "Maslennikov",
                        Patronymic = "Markovich",
                        Phone = "+380670112983",
                        Birthdate = new System.DateTime(2000, 8, 17),
                        DepartmentId = 2,
                        PositionId = 1
                    },
                    new Employee
                    {
                        Name = "Dmitry",
                        Surname = "Kovalev",
                        Patronymic = "Mikhailovich",
                        Phone = "+380969283169",
                        Birthdate = new System.DateTime(2001, 6, 30),
                        DepartmentId = 3,
                        PositionId = 2
                    },
                    new Employee
                    {
                        Name = "Roman",
                        Surname = "Orlov",
                        Patronymic = "Alexandrovich",
                        Phone = "+380952918189",
                        Birthdate = new System.DateTime(1996, 7, 8),
                        DepartmentId = 2,
                        PositionId = 3
                    },
                    new Employee
                    {
                        Name = "Maxim",
                        Surname = "Mironov",
                        Patronymic = "Mikhailovich",
                        Phone = "+380663028317",
                        Birthdate = new System.DateTime(2001, 8, 12),
                        DepartmentId = 2,
                        PositionId = 1
                    },
                    new Employee
                    {
                        Name = "Vladimir",
                        Surname = "Sidorov",
                        Patronymic = "Arturovich",
                        Phone = "+380976918438",
                        Birthdate = new System.DateTime(1998, 9, 30),
                        DepartmentId = 1,
                        PositionId = 1
                    },
                    new Employee
                    {
                        Name = "Andrey",
                        Surname = "Mikheev",
                        Patronymic = "Yaroslavovich",
                        Phone = "+380676477503",
                        Birthdate = new System.DateTime(2002, 3, 15),
                        DepartmentId = 2,
                        PositionId = 2
                    },
                    new Employee
                    {
                        Name = "Makar",
                        Surname = "Romanov",
                        Patronymic = "Dmitrievich",
                        Phone = "+380679651985",
                        Birthdate = new System.DateTime(1997, 2, 24),
                        DepartmentId = 2,
                        PositionId = 3
                    }
                );
            }
            db.SaveChanges();
        }
    }
}
