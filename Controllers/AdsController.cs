using Microsoft.AspNetCore.Mvc;
using MotorLine.Data;
using MotorLine.Models;

namespace MotorLine.Controllers
{
	public class AdsController : Controller
	{
        private readonly AdsDbContext context;


        public AdsController(AdsDbContext context)
		{ 
            this.context = context;
        }
        public IActionResult Index() 
		{ 
			var ads =  context.Ads.ToList(); 
			if(ads == null) 
			{ return NotFound(); }
			return View(ads); }
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

[HttpPost]
        public IActionResult Create(Ad ad)
        {

            context.Ads.Add(ad);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

