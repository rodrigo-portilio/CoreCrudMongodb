using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreCrudMongodb.Data;
using CoreCrudMongodb.Data.Interfaces.Services;
using CoreCrudMongodb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CoreCrudMongodb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        // GET: Clients
        public ActionResult Index()
        {
            var customers = customerService.GetAll();
            return View(customers);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            var customer = new Customer();
            return View("form", customer);
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("form", customer);
                }

                customerService.Update(customer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("form", customer);
            }
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(string id)
        {
            var customer = customerService.GetById(id);
            return View("form", customer);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                customerService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}