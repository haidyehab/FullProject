using ApiCrudClient.Api;
using ApiCrudClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudClient.Controllers
{
    public class CustomerController : Controller
    {

        private readonly APIGateway _aPIGateway;
        public CustomerController(APIGateway aPIGateway)
        {
            _aPIGateway = aPIGateway;
        }

        public IActionResult Index()
        {
            /*List<Customer> customers = new List<Customer>()*/
            List<Customer> customers;
            //api get will come

            customers = _aPIGateway.ListCustomer();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            //do the api create action and send the control to index action
            _aPIGateway.CreateCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int Id)
        {
            Customer customer=new Customer();
            //fetch the customer from the api and show the customer details in the Details view
            customer = _aPIGateway.GetCustomer(Id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //Customer customer = new Customer();
            Customer customer;
            //fetch the customer from the api and show the customer details in Edit view
            customer = _aPIGateway.GetCustomer(Id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            //do the api Edit action and send the control to index action
            _aPIGateway.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //Customer customer = new Customer();
            Customer customer;
             customer= _aPIGateway.GetCustomer(Id);

            //fetch the customer from the api and show the customer details in the Details view
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            //do the api Delete action and send the control to index action
            _aPIGateway.DeleteCustomer(customer.Id);
            return RedirectToAction("Index");

        }

       


    }
}
