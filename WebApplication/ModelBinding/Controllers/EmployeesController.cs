using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> employees = Employee.GetAllEmployees();
            return View(employees);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            //Employee employee = new Employee();
            //employee.EmpNo = id;
            //employee.Name = "Vikram";
            //employee.Basic = 12345;
            //employee.DeptNo = 10;


            Employee employee = Employee.GetSingleEmployee(id);
            return View(employee);
        }

        // GET: EmployeesController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        //uses Model Binding
        public ActionResult Create(Employee obj, IFormCollection collection)
        {
            try
            {
                Employee.Insert(obj);
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.Message;
                return View();
            }
        }
        //uses Binding
        //public ActionResult Create(IFormCollection collection,int EmpNo, string Name, decimal Basic, int DeptNo)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        //uses IFormCollection -contains all submitted values
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        string name = collection["Name"];
        //        string empno = collection["EmpNo"];
        //        string basic = collection["Basic"];
        //        string deptno = collection["DeptNo"];
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = Employee.GetSingleEmployee(id);
            return View(employee);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
                Employee.Update(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee employee = Employee.GetSingleEmployee(id);
            return View(employee);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, Employee obj)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
