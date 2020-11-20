using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.ViewModels;

namespace Project.Controllers
{
    public class ProgramsController : Controller
    {
        private readonly ProjectContext _context;

        public ProgramsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Programs
        public async Task<IActionResult> Index(String ProgramDuration, string searchString)
        {
            IQueryable<Programs> programs = _context.Programs.AsQueryable();
            IQueryable<string> genreQuery = _context.Programs.OrderBy(m => m.Duration).Select(m => m.Duration).Distinct();
            if (!string.IsNullOrEmpty(searchString))
            {
                programs = programs.Where(s => s.Name.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(ProgramDuration))
            {
               programs = programs.Where(x => x.Duration== ProgramDuration);
            }
             programs = programs.Include(m => m.Coach)
            .Include(m => m.Enrollments).ThenInclude(m => m.Client);
            var movieGenreVM = new ProgramDurationVM
            {
                Durations = new SelectList(await genreQuery.ToListAsync()),
                Programs = await programs.ToListAsync()
            };
            return View(movieGenreVM);
        }

        // GET: Programs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programs = await _context.Programs
                .Include(p => p.Coach)
                .Include(m => m.Enrollments).ThenInclude(m => m.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // GET: Programs/Create
        public IActionResult Create()
        {
            ViewData["CoachId"] = new SelectList(_context.Coaches, "CoachId", "FullName");
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramID,Name,Payment,Duration,CoachId")] Programs programs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CoachId"] = new SelectList(_context.Coaches, "CoachId", "FullName", programs.CoachId);
            return View(programs);
        }

        // GET: Programs/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var programs = _context.Programs.Where(m => m.Id == id).Include(m => m.Enrollments).First();

            if (programs == null)
            {
                return NotFound();
            }
            ProgramClientVM viewmodel = new ProgramClientVM
            {
                Program = programs,
                ClientsList = new MultiSelectList(_context.Clients.OrderBy(s => s.FullName), "Id", "FullName"),
                SelectedClients = programs.Enrollments.Select(sa => sa.Id)
            };
            ViewData["CoachId"] = new SelectList(_context.Coaches, "CoachId", "FullName", programs.CoachId);
            return View(viewmodel);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProgramClientVM viewmodel)
        {
            if (id != viewmodel.Program.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viewmodel.Program);
                    await _context.SaveChangesAsync();
                    IEnumerable<int> listClients = viewmodel.SelectedClients;
                    IQueryable<ClientProgram> toBeRemoved = _context.ClientProgram.Where(s => !listClients.Contains(s.ClientId) && s.ProgramId == id);
                    _context.ClientProgram.RemoveRange(toBeRemoved);
                    IEnumerable<int> existClients = _context.ClientProgram.Where(s => listClients.Contains(s.ClientId) && s.ProgramId == id).Select(s => s.ClientId);
                    IEnumerable<int> newClients = listClients.Where(s => !existClients.Contains(s));
                    foreach (int actorId in newClients)
                        _context.ClientProgram.Add(new ClientProgram { ClientId = actorId, ProgramId = id });
                    await _context.SaveChangesAsync();
               
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramsExists(viewmodel.Program.Id))
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
            ViewData["CoachId"] = new SelectList(_context.Coaches, "CoachId", "FullName", viewmodel.Program.Id);
            return View(viewmodel);
        }

        // GET: Programs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programs = await _context.Programs
                .Include(p => p.Coach)
                .Include(m => m.Enrollments).ThenInclude(m => m.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programs == null)
            {
                return NotFound();
            }

            return View(programs);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programs = await _context.Programs.FindAsync(id);
            _context.Programs.Remove(programs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramsExists(int id)
        {
            return _context.Programs.Any(e => e.Id == id);
        }
    }
}
