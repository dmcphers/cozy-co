using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CozyCo.Domain.Model;
using CozyCo.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace CozyCo.WebUI.Controllers
{
    public class PropertyController : Controller
    {
        private const string PROPERTYTYPES = "PropertyTypes"; 
        private readonly IPropertyService _propertyService;
        private readonly IPropertyTypeService _propertyTypeService;

        public PropertyController(IPropertyService propertyService,
            IPropertyTypeService propertyTypeService)
        {
            _propertyService = propertyService;
            _propertyTypeService = propertyTypeService;
        }

        // property/index
        public IActionResult Index()
        {
            // check if there is any error in tempdata
            if(TempData["Error"] !=null)
            {
                // pass that error to the viewdata because communicating between action and view
                ViewData.Add("Error", TempData["Error"]);

            }

            var properties = _propertyService.GetAllProperties();
            return View(properties);
        }


        // GET property/add
        public IActionResult Add()
        {
            var propertyTypes = _propertyTypeService.GetAll();
            ViewData.Add("PROPERTYTYPES", propertyTypes);

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
                // using tempdata because we are communicating between actions - from delete to index
                TempData.Add("Error","Sorry, the property could not be deleted, try again later.");

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