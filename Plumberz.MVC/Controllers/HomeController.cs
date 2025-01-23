using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plumberz.DAL.Contexts;

namespace Plumberz.MVC.Controllers
{
    public class HomeController(PlumberzDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technicals.Include(x => x.Department).Where(x => !x.IsDeleted).ToListAsync());
        }
    }
}
