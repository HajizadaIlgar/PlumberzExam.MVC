using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Plumberz.BL.ViewModels.Departments;
using Plumberz.Core.Entities.Departments;
using Plumberz.DAL.Contexts;

namespace Plumberz.MVC.Areas.Admin.Controllers;

[Area(nameof(Admin))]
[Authorize(Roles = nameof(Admin))]
public class DepartmentController(PlumberzDbContext _context) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View(await _context.Departments.Where(x => !x.IsDeleted).ToListAsync());
    }
    public async Task<IActionResult> Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(DepartmentVM vm)
    {
        if (!ModelState.IsValid) return View();
        Department depart = new Department
        {
            DepartmentName = vm.DepartmentName,
        };
        await _context.Departments.AddAsync(depart);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int? id)
    {
        if (id is null) return BadRequest();
        var data = await _context.Departments.Where(x => x.Id == id).Select(x => new DepartmentVM
        {
            DepartmentName = x.DepartmentName,
        }).FirstOrDefaultAsync();
        if (data is null) return NotFound();
        return View(data);
    }
    [HttpPost]
    public async Task<IActionResult> Update(int? id, DepartmentVM vm)
    {
        if (id is null) return BadRequest();
        var data = await _context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data is null) return NotFound();
        data.DepartmentName = vm.DepartmentName;
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return BadRequest();
        var data = await _context.Departments.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data is null) return NotFound();
        _context.Departments.Remove(data);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
