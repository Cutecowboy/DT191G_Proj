using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projApp.Data;
using projApp.Model;

namespace projApp.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Schedule
        public async Task<IActionResult> Index()
        {
            return View(await _context.Schedules.ToListAsync());
        }

        // GET: Schedule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleModel = await _context.Schedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduleModel == null)
            {
                return NotFound();
            }

            return View(scheduleModel);
        }

        // GET: Schedule/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Schedule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Therapy,Length,BookedBy,Booked")] ScheduleModel scheduleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduleModel);
        }

        // GET: Schedule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleModel = await _context.Schedules.FindAsync(id);
            if (scheduleModel == null)
            {
                return NotFound();
            }
            return View(scheduleModel);
        }

        // POST: Schedule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Therapy,Length,BookedBy,Booked")] ScheduleModel scheduleModel)
        {
            if (id != scheduleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleModelExists(scheduleModel.Id))
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
            return View(scheduleModel);
        }

        // GET: Schedule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduleModel = await _context.Schedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scheduleModel == null)
            {
                return NotFound();
            }

            return View(scheduleModel);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheduleModel = await _context.Schedules.FindAsync(id);
            if (scheduleModel != null)
            {
                _context.Schedules.Remove(scheduleModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleModelExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}