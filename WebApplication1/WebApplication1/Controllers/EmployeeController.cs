using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DbModels;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
	        var list = new EmployeeService().All();
            return View(list);
        }

		[HttpGet]
	    public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
	    public IActionResult Create(Person p, IFormFile uploadedPhoto)
		{
		    if (uploadedPhoto != null && uploadedPhoto.Length > 0)
		    {
			    using (var memoryStream = new MemoryStream())
			    {
				    uploadedPhoto.CopyTo(memoryStream);
				    p.Photo = memoryStream.ToArray();
			    }
		    }
			var service= new EmployeeService();
		    var result = service.AddOrUpdate(p);
		    if (!result)
		    {
			    TempData["error"] = "Create person error ";
		    }

		    return RedirectToAction("Index");
	    }

	    [HttpGet]
	    public IActionResult Edit(long id)
	    {
			var service = new EmployeeService();
		    var obj = service.GetById(id);
		    return View(obj);
	    }

	    [HttpPost]
	    public IActionResult Edit(Person p, IFormFile uploadedPhoto)
	    {
		    if (uploadedPhoto != null && uploadedPhoto.Length > 0)
		    {
			    using (var memoryStream = new MemoryStream())
			    {
				    uploadedPhoto.CopyTo(memoryStream);
				    p.Photo = memoryStream.ToArray();
			    }
		    }
			var service = new EmployeeService();
		    var result = service.AddOrUpdate(p);
		    if (!result)
		    {
			    TempData["error"] = "Edit person error ";
		    }

		    return RedirectToAction("Index");
	    }


		[HttpGet]
	    public IActionResult Delete(long id)
	    {
			var service = new EmployeeService();
		    var result = service.DeleteById(id);
		    if (!result)
		    {
			    TempData["erorr"] = "Error occured while deleting .";
		    }


		    return RedirectToAction("Index");
	    }


		[HttpGet]
	    public IActionResult Details(long id)
	    {
			var service = new EmployeeService();
		    var obj = service.GetById(id);

		    return View(obj);
	    }
	}
}