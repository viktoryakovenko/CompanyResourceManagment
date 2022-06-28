using Company.Models;
using Company.Models.Entities;
using System;

namespace Company.DAL
{
    public class UnitOfWork: IDisposable
    {
        private CompanyContext db;
        private Repository<Employee> employeeRepository;
        private Repository<Position> positionRepository;
        private Repository<Department> departmentRepository;

        public UnitOfWork(CompanyContext context)
        {
            db = context;
        }

        public Repository<Employee> Employees
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new Repository<Employee>(db);
                }
                return employeeRepository;
            }
        }

        public Repository<Position> Positions
        {
            get
            {
                if (positionRepository == null)
                {
                    positionRepository = new Repository<Position>(db);
                }
                return positionRepository;
            }
        }

        public Repository<Department> Departments
        {
            get
            {
                if (departmentRepository == null)
                {
                    departmentRepository = new Repository<Department>(db);
                }
                return departmentRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
