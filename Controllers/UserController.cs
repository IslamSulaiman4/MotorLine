using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorLine.Data;

namespace MotorLine.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;
		public UserController(ApplicationDbContext context) 
		{ _context = context; }
		public IActionResult Index()
		{
			return Content("User");
		}

	

	
}
}
