using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plumberz.BL.Extensions;
using Plumberz.BL.ViewModels.Technicals;
using Plumberz.Core.Entities.Technicals;
using Plumberz.DAL.Contexts;

namespace Plumberz.MVC.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [Authorize(Roles = nameof(Admin))]
    public class TechnicalsController(PlumberzDbContext _context, IWebHostEnvironment _env) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Technicals.Include(x => x.Department).Where(x => !x.IsDeleted).ToListAsync());
        }
        public async Task<IActionResult> Create()
        {
            if (ModelState.IsValid)
            {
                ViewBag.Department = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync();
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TechnicalCreateVM vm)
        {
            if (vm.Image is not null)
            {
                if (vm.Image.IsValidType("image")) { ModelState.AddModelError("", "Bu fayl image tipinde deyil"); }
                if (vm.Image.IsValidSize(400)) { ModelState.AddModelError("", "Sekilin olcusu telebolunandan daha coxdur "); }
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Department = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync();
            }
            string fileName = Path.Combine(_env.WebRootPath, "images");
            Technical tech = new Technical
            {
                FullName = vm.FullName,
                ImageUrl = fileName,
                DepartmentId = vm.DepartmentId,
            };
            if (vm.Image is not null)
            {
                tech.ImageUrl = await vm.Image.UploadAsync(fileName);
            }
            await _context.Technicals.AddAsync(tech);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null) return BadRequest();
            var data = await _context.Technicals.Include(x => x.Department).Where(x => x.Id == id).Select(x => new TechnicalUpdateVM
            {
                FullName = x.FullName,
                ImageUrl = x.ImageUrl,
                DepartmentId = x.DepartmentId
            }).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                ViewBag.Department = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, TechnicalUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Department = await _context.Departments.Where(x => !x.IsDeleted).ToListAsync();
            }
            if (vm.Image is not null)
            {
                if (vm.Image.IsValidType("image")) { ModelState.AddModelError("", "Bu fayl image tipinde deyil"); }
                if (vm.Image.IsValidSize(400)) { ModelState.AddModelError("", "Sekilin olcusu telebolunandan daha coxdur "); }
            }
            var data = await _context.Technicals.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
            string fileName = Path.Combine(_env.WebRootPath, "images");

            data.FullName = vm.FullName;
            data.DepartmentId = vm.DepartmentId;
            data.ImageUrl = fileName;
            if (vm.Image is not null)
            {
                data.ImageUrl = await vm.Image.UploadAsync(fileName);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
            var data = await _context.Technicals.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data is null) return NotFound();
            _context.Technicals.Remove(data);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
