using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorLine.Data;

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
			return View("Index",ads); }



    }
}

