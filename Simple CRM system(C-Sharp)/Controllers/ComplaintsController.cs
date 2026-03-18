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
    public class ComplaintsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplaintsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Complaints
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Complaints.Include(c => c.Citizen).Include(c => c.Department);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Complaints/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints
                .Include(c => c.Citizen)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complaint == null)
            {
                return NotFound();
            }

            return View(complaint);
        }

        // GET: Complaints/Create
        public IActionResult Create()
        {
            ViewData["CitizenId"] = new SelectList(_context.Citizens, "Id", "FullName");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Complaint complaint) 
        {
            if (ModelState.IsValid)
            {
              
                if (complaint.EvidenceFile != null && complaint.EvidenceFile.Length > 0)
                {
              
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(complaint.EvidenceFile.FileName);

                  
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                  
                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    string fullPath = Path.Combine(uploadPath, fileName);

                
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await complaint.EvidenceFile.CopyToAsync(fileStream);
                    }

                    
                    complaint.EvidenceFilePath = "/uploads/" + fileName;
                }

                _context.Add(complaint);
                await _context.SaveChangesAsync();

                
                return RedirectToAction(nameof(Index));
            }

            

            return View(complaint);
        }

        // GET: Complaints/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint == null)
            {
                return NotFound();
            }
            ViewData["CitizenId"] = new SelectList(_context.Citizens, "Id", "FullName", complaint.CitizenId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", complaint.DepartmentId);
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,CreatedAt,CitizenId,DepartmentId")] Complaint complaint)
        {
            if (id != complaint.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complaint);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplaintExists(complaint.Id))
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
            ViewData["CitizenId"] = new SelectList(_context.Citizens, "Id", "FullName", complaint.CitizenId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", complaint.DepartmentId);
            return View(complaint);
        }

        // GET: Complaints/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complaint = await _context.Complaints
                .Include(c => c.Citizen)
                .Include(c => c.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (complaint == null)
            {
                return NotFound();
            }

            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complaint = await _context.Complaints.FindAsync(id);
            if (complaint != null)
            {
                _context.Complaints.Remove(complaint);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComplaintExists(int id)
        {
            return _context.Complaints.Any(e => e.Id == id);
        }
    }
}
