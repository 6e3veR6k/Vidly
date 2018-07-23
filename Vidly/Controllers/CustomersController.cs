using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //Hardcoded collection
        //public IEnumerable<Customer> Customers => new List<Customer>
        //{
        //    new Customer {Id=1, ImgPath="/Content/Images/WEB_square.jpg", FirstName="Elam", SecondName="Bonaventure", MiddleName="Schuchardt", RegisteredDate=new DateTime(2001, 1, 15), Email="schuchardt@gmail.com", BirthDate=new DateTime(1985, 4, 2)},
        //    new Customer {Id=2, ImgPath="/Content/Images/Heckman-Darrell-square-e1503328318323.jpg",  FirstName="Hesiodos", SecondName="Hildimar", MiddleName="Essen", RegisteredDate=new DateTime(2002, 3, 1), Email="von_essen@gmail.com", BirthDate=new DateTime(1979, 9, 24)},
        //    new Customer {Id=3, ImgPath="/Content/Images/nT1A9bf6pnHlCYi.jpg",  FirstName="Othmar", SecondName="Winthrop", MiddleName="Sniders", RegisteredDate=new DateTime(2002, 1, 21), Email="sniders@gmail.com", BirthDate=new DateTime(2002, 3, 21)},
        //    new Customer {Id=4, ImgPath="/Content/Images/square.jpg",  FirstName="Lilia", SecondName="Diana", MiddleName="Jewel", RegisteredDate=new DateTime(2001, 11, 4), Email="jewel@gmail.com", BirthDate=new DateTime(1965, 1, 24)},
        //    new Customer {Id=5, ImgPath="/Content/Images/Square_JD.png",  FirstName="Marcel", SecondName="Matylda", MiddleName="Krusen", RegisteredDate=new DateTime(2001, 4, 18), Email="krusen@gmail.com", BirthDate=new DateTime(1984, 10, 22)},
        //};

        private readonly VidlyDbContext _context;

        public CustomersController()
        {
            _context = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //To list provide quering Customers table imedeatle
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes;
            var modelView = new CustomerFromViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", modelView);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var existingCustomer = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(existingCustomer);

                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.BirthDate = customer.BirthDate;
                existingCustomer.Email = customer.Email;
                existingCustomer.MembershipType = customer.MembershipType;
                existingCustomer.MembershipTypeId = customer.MembershipTypeId;
                existingCustomer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFromViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}