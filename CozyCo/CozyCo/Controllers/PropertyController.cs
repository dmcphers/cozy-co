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


    //    // GET property/add
    //    public IActionResult Add()
    //    {
    //        return View("Form"); 
    //    }

    //    [HttpPost] 
    //    public IActionResult Add(Property newProperty) // -> receive data from form
    //    {
    //        if (ModelState.IsValid) // all required fields are completed
    //        {
    //            // We should be able to add the new property
    //            Properties.Add(newProperty);
    //            return View(nameof(Index), Properties);
    //        }

    //        return View("Form");
    //    }

    //    public IActionResult Detail(int id) //  -> get id from the URL
    //    {
    //        // Need to know what Id to look for
    //        var property = Properties.Single(p => p.Id == id);
    //        return View(property);
    //    }

    //    public IActionResult Delete(int id)
    //    {
    //        var property = Properties.Single(p => p.Id == id);
    //        Properties.Remove(property);
    //        return View(nameof(Index), Properties);
    //    }

    //    public IActionResult Edit(int id) // --> get id from URL
    //    {
    //        var property = Properties.Single(p => p.Id == id);

    //        return View("Form", property);
    //    }

    //    [HttpPost]
    //    // get id from URL
    //    // get updated property from FORM
    //    public IActionResult Edit(int id, Property updatedProperty)
    //    {
    //        if (ModelState.IsValid)
    //        {

    //            var oldProperty = Properties.Single(p => p.Id == id);

    //            oldProperty.Address = updatedProperty.Address;
    //            oldProperty.Address2 = updatedProperty.Address2;
    //            oldProperty.City = updatedProperty.City;
    //            oldProperty.Image = updatedProperty.Image;
    //            oldProperty.Zipcode = updatedProperty.Zipcode;

    //            return View(nameof(Index), Properties);
    //        }

    //        return View("Form", updatedProperty); // By passing updatedProperty, We trigger the logic
    //                                              // for edit within the Form.cshtml
    //    }
    }
}