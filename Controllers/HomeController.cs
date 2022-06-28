using Company.DAL;
using Company.Models;
using Company.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Company.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompanyContext db;
        private UnitOfWork unitOfWork;

        public HomeController(CompanyContext context)
        {
            db = context;
            unitOfWork = new UnitOfWork(db);
        }

        public IActionResult Index(int? position, int? department, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {            
            int pageSize = 5;

            var employees = unitOfWork.Employees.GetList(includeProperties: "Position,Department");

            if (position != null && position != 0 )
            {
                employees = employees.Where(e => e.PositionId == position);
            }

            if (department != null && department != 0)
            {
                employees = employees.Where(e => e.DepartmentId == department);
            }

            if (!String.IsNullOrEmpty(name))
            {
                employees = employees.Where(e => e.Name.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                                 e.Surname.Contains(name, StringComparison.OrdinalIgnoreCase) ||
                                                 e.Patronymic.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    employees = employees.OrderByDescending(e => e.Name);
                    break;
                case SortState.AgeAsc:
                    employees = employees.OrderBy(e => e.Birthdate);
                    break;
                case SortState.AgeDesc:
                    employees = employees.OrderByDescending(s => s.Birthdate);
                    break;
                case SortState.SurnameAsc:
                    employees = employees.OrderBy(s => s.Surname);
                    break;
                case SortState.SurnameDesc:
                    employees = employees.OrderByDescending(s => s.Surname);
                    break;
                case SortState.DepartmentAsc:
                    employees = employees.OrderBy(s => s.Department.Name);
                    break;
                case SortState.DepartmentDesc:
                    employees = employees.OrderByDescending(s => s.Department.Name);
                    break;
                default:
                    employees = employees.OrderBy(s => s.Name);
                    break;
            }

            var count = employees.Count();
            employees = employees.Skip((page - 1) * pageSize).Take(pageSize).ToList();


            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(unitOfWork.Positions.GetList().ToList(), 
                                                      unitOfWork.Departments.GetList().ToList(), 
                                                      position, department, name),
                Employees = employees
            };
            return View(viewModel);
        }

        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            PopulatePositionsDropDownList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Employees.Insert(e);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            PopulatePositionsDropDownList(e.PositionId);
            PopulateDepartmentsDropDownList(e.DepartmentId);

            return View(e);
        }

        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                Employee e = unitOfWork.Employees.GetById(id);
                if (e != null)
                {
                    PopulatePositionsDropDownList(e.PositionId);
                    PopulateDepartmentsDropDownList(e.DepartmentId);
                    return View(e);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Employees.Update(e);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            PopulatePositionsDropDownList(e.PositionId);
            PopulateDepartmentsDropDownList(e.DepartmentId);

            return View(e);
        }

        private void PopulateDepartmentsDropDownList(object selectedDepartment = null)
        {
            var departmentsQuery = unitOfWork.Departments.GetList(
                orderBy: q => q.OrderBy(d => d.Name));
            ViewBag.Departments = new SelectList(departmentsQuery, "Id", "Name", selectedDepartment);
        }

        private void PopulatePositionsDropDownList(object selectedPosition = null)
        {
            var positionsQuery = unitOfWork.Positions.GetList(
                orderBy: q => q.OrderBy(p => p.Name));
            ViewBag.Positions = new SelectList(positionsQuery, "Id", "Name", selectedPosition);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            Employee e = unitOfWork.Employees.GetList(includeProperties: "Position,Department").ToList().FirstOrDefault(e => e.Id == id);

            if (e == null)
            {
                return NotFound(); 
            }
            
            return View(e);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee e = unitOfWork.Employees.GetById(id);
            unitOfWork.Employees.Delete(e);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
