using DevCard_MVC.Data;
using DevCard_MVC.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace DevCard_MVC.Controllers

{
	[Route("Home/Products")]
	//examples
	//localhost:5001/inventory/products/index
	//localhost:5001/inventory/products/contactpage
	public class HomeController : Controller
	{

		private readonly List<Service> _Services = new List<Service>
		{
			new Service(1 , "Silver"),
			new Service(2 , "Golden"),
			new Service(3 , "Platnium"),
			new Service(4 , "Diamond"),
		};

		[Route("MyIndex/{name?}")]
		public IActionResult Index(string name)
		{
			return View();
		}

		public IActionResult ProjectDetails (long id)
		{
			var projects = ProjectStore.GetProjectBy(id);
			return View(projects);
		}


		[HttpGet]
		[Route("ContactPage")]
		public IActionResult Contact(long id)
		{
			var model = new ContactForm
			{
				Services = new SelectList(_Services , "Id" , "Name")
			};
			return View(model);
		}

		//[HttpPost]
		//public JsonResult Contact(IFormCollection form)
		//{
		//    var name = form["name"];
		//    return Json(Ok());
		//}


		[HttpPost]
		public IActionResult Contact(ContactForm model)

		{

			if (!ModelState.IsValid)
			{
				ViewBag.error = "Information that has been entered is wrong , try again please ";
				return View(model);
			}

			//return RedirectToAction("Index");
			ViewBag.success = "Your message has been sent successfully! thank you <3 ";
			return View();
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
