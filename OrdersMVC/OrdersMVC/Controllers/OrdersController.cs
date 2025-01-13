using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersMVC.Models;

namespace OrdersMVC.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(OrderModel obj)
        {
            try
            {
                OrderDAL.AddOrder(obj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(List<OrderModel> list)
        {
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(IFormCollection collection)
        {
            try
            {
                List<OrderModel> list = OrderDAL.SearchOrder(collection["searchString"]);
                return Search(list);
            }
            catch
            {
                return View();
            }
        }
    }
}
