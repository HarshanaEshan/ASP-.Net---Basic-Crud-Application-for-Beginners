using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Student_Registration_Crud_Application.Models;

namespace Student_Registration_Crud_Application.Controllers
{
    public class StudentsTablesController : Controller
    {
        private readonly UniversityContext _context;

        public StudentsTablesController(UniversityContext context)
        {
            _context = context;
        }

        // GET: StudentsTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentsTables.ToListAsync());
        }

        // GET: StudentsTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsTable = await _context.StudentsTables
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentsTable == null)
            {
                return NotFound();
            }

            return View(studentsTable);
        }

        // GET: StudentsTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentsTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,FirstName,LastName,Username,Password")] StudentsTable studentsTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentsTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentsTable);
        }

        // GET: StudentsTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsTable = await _context.StudentsTables.FindAsync(id);
            if (studentsTable == null)
            {
                return NotFound();
            }
            return View(studentsTable);
        }

        // POST: StudentsTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,Username,Password")] StudentsTable studentsTable)
        {
            if (id != studentsTable.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentsTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsTableExists(studentsTable.StudentId))
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
            return View(studentsTable);
        }

        // GET: StudentsTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentsTable = await _context.StudentsTables
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (studentsTable == null)
            {
                return NotFound();
            }

            return View(studentsTable);
        }

        // POST: StudentsTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentsTable = await _context.StudentsTables.FindAsync(id);
            if (studentsTable != null)
            {
                _context.StudentsTables.Remove(studentsTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsTableExists(int id)
        {
            return _context.StudentsTables.Any(e => e.StudentId == id);
        }
    }
}
