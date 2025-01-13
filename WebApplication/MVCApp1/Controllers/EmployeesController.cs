using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCApp1.Models;

namespace MVCApp1.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            IEnumerable<Employee> list =  Employee.GetAll();
            return View(list);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            Employee obj = Employee.Get(id);
            return View(obj);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee obj, IFormCollection collection)
        {
            try
            {
                Employee.Insert(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = Employee.Get(id);
            return View(obj);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj, IFormCollection collection)
        {
            try
            {
                Employee.Update(id, obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            Employee obj = Employee.Get(id);
            return View(obj);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
