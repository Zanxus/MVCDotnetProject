using MVCDotnetProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCDotnetProject.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ViewResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name = "Qu", Id = 1 },
                new Customer { Name = "Mark", Id = 2 }
            };
        }
    }
}