using System.Diagnostics;
using FulStudentRecords.Models;
using Microsoft.AspNetCore.Mvc;

namespace FulStudentRecords.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly StudentRecordsContext _context;

		public HomeController(ILogger<HomeController> logger, StudentRecordsContext Context)
		{
			_context = Context;
			_logger = logger;
		}

		public IActionResult Index()
		{

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		public IActionResult Register()
		{
			return View();
		}
		public IActionResult Getregister()
		{
			TempData["success"] = null;
			var data = _context.Records.ToList();
			if (data.Any())
			{
				TempData["success"] = "Items retrieved";
			}
			return View(data);
		}
		public IActionResult Details(int id)
		{
			TempData["success"] = null;
			var data = _context.Records.FirstOrDefault(x => x.Id == id);
			if (data == null)
			{

				return RedirectToAction("GetPlans");
			}
			TempData["success"] = "Items retrieved";
			return View(data);
		}

		public IActionResult Update(Record Record)
		{
			TempData["update"] = null;
			var data = _context.Records.FirstOrDefault(x => x.Id == Record.Id);
			if (data == null)
			{
				TempData["update"] = "false";
				return RedirectToAction("GetPlans");
			}
			data.Name = Record.Name;
			data.Maths = Record.Maths;
			data.Physics = Record.Physics;
			data.Chemistry = Record.Chemistry;
			data.Biology = Record.Biology;
			data.English = Record.English;
			data.Total = Record.Total;
			var save = _context.SaveChanges();
			if (save <= 0)
			{
				TempData["update"] = "false";
				return RedirectToAction("Getregister");
			}

			TempData["update"] = "true";
			return RedirectToAction("Getregister");
		}


		public IActionResult Delete(int id)
		{
			TempData["delete"] = null;
			var data = _context.Records.FirstOrDefault(x => x.Id == id);
			if (data == null)
			{
				TempData["delete"] = "false";
				TempData["delete"] = "false";
				return RedirectToAction("GetPlans");
			}
			_ = _context.Records.Remove(data);
			var save = _context.SaveChanges();
			if (save <= 0)
			{
				TempData["delete"] = "false";
				return RedirectToAction("Getregister");
			}

			TempData["delete"] = "true";
			return RedirectToAction("Getregister");
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
