using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CozyCo.Domain.Models;
using CozyCo.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CozyCo.WebUI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // property/index
        public IActionResult Index()
        {
            var properties = _propertyService.GetAllProperties();
            return View(properties);
        }


        // GET property/add
        public IActionResult Add()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Add(Property newProperty) // -> receive data from form
        {
            if (ModelState.IsValid) // all required fields are completed
            {
                // We should be able to add the new property
                _propertyService.Create(newProperty);
                // service receives the new property
                // service sent the new property to repository (saved)

                return RedirectToAction(nameof(Index)); // -> Index(); method above
            }

            return View("Form");
        }

        public IActionResult Detail(int id) //  -> get id from the URL
        {
            // Need to know what Id to look for
            var property = _propertyService.GetById(id);
            return View(property);
        }

        public IActionResult Delete(int id)
        {
            var succeeded = _propertyService.Delete(id);

            if (!succeeded) // when delete fails (false)
                ViewBag.Error = "Sorry, the property could not be deleted, try again later.";

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id) // --> get id from URL
        {
            var property = _propertyService.GetById(id);

            return View("Form", property);
        }

        [HttpPost]
        // get id from URL
        // get updated property from FORM
        public IActionResult Edit(int id, Property updatedProperty)
        {
            if (ModelState.IsValid)
            {
                _propertyService.Update(updatedProperty);

                return RedirectToAction(nameof(Index));
            }

            return View("Form", updatedProperty); // By passing updatedProperty, We trigger the logic
                                                  // for edit within the Form.cshtml
        }
    }
}