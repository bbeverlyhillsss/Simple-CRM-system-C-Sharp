using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Simple_CRM_system_C_Sharp_.Data;
using Simple_CRM_system_C_Sharp_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_CRM_system_C_Sharp_.Controllers
{
    [Authorize]
    public class HeadOfdepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeadOfdepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HeadOfdepartments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DepartmentHeads.Include(h => h.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HeadOfdepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headOfdepartment = await _context.DepartmentHeads
                .Include(h => h.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headOfdepartment == null)
            {
                return NotFound();
            }

            return View(headOfdepartment);
        }

        // GET: HeadOfdepartments/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: HeadOfdepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rank,DepartmentId")] HeadOfdepartment headOfdepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headOfdepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", headOfdepartment.DepartmentId);
            return View(headOfdepartment);
        }

        // GET: HeadOfdepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headOfdepartment = await _context.DepartmentHeads.FindAsync(id);
            if (headOfdepartment == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", headOfdepartment.DepartmentId);
            return View(headOfdepartment);
        }

        // POST: HeadOfdepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rank,DepartmentId")] HeadOfdepartment headOfdepartment)
        {
            if (id != headOfdepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headOfdepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadOfdepartmentExists(headOfdepartment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", headOfdepartment.DepartmentId);
            return View(headOfdepartment);
        }

        // GET: HeadOfdepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headOfdepartment = await _context.DepartmentHeads
                .Include(h => h.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (headOfdepartment == null)
            {
                return NotFound();
            }

            return View(headOfdepartment);
        }

        // POST: HeadOfdepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var headOfdepartment = await _context.DepartmentHeads.FindAsync(id);
            if (headOfdepartment != null)
            {
                _context.DepartmentHeads.Remove(headOfdepartment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeadOfdepartmentExists(int id)
        {
            return _context.DepartmentHeads.Any(e => e.Id == id);
        }
    }
}
