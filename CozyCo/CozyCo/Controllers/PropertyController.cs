using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CozyCo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CozyCo.WebUI.Controllers
{
    public class PropertyController : Controller
    {
        private List<Property> Properties = new List<Property>
        {
            new Property { Id = 1, Address = "123 Main Street", City = "Austin", Zipcode = "78777"},
            new Property { Id = 2, Address = "5553 Main Street", City = "Pflugerville", Zipcode = "78788"}
        };

        // property/index
        public IActionResult Index()
        {
            return View(Properties);
        }


        // GET property/add
        public IActionResult Add()
        {
            return View("Form"); 
        }

        [HttpPost] 
        public IActionResult Add(Property newProperty) // -> receive data from form
        {
            Properties.Add(newProperty);
            return View(nameof(Index), Properties);
        }

        public IActionResult Detail(int id) //  -> get id from the URL
        {
            // Need to know what Id to look for
            var property = Properties.Single(p => p.Id == id);
            return View(property);
        }

        public IActionResult Delete(int id)
        {
            var property = Properties.Single(p => p.Id == id);
            Properties.Remove(property);
            return View(nameof(Index), Properties);
        }

        public IActionResult Edit(int id) // --> get id from URL
        {
            var property = Properties.Single(p => p.Id == id);

            return View("Form", property);
        }

        [HttpPost]
        // get id from URL
        // get updated property from FORM
        public IActionResult Edit(int id, Property updatedProperty)
        {
            var oldProperty = Properties.Single(p => p.Id == id);

            oldProperty.Address = updatedProperty.Address;
            oldProperty.Address2 = updatedProperty.Address2;
            oldProperty.City = updatedProperty.City;
            oldProperty.Image = updatedProperty.Image;
            oldProperty.Zipcode = updatedProperty.Zipcode;

            return View(nameof(Index), Properties);
        }
    }
}