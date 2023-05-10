using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using To_Do_App.Data;
using To_Do_App.Models;

namespace To_Do_App.Controllers
{
    public class TaskToDoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskToDoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskToDoes
        public async Task<IActionResult> Index()
        {
              return _context.TaskToDo != null ?
                          View(await _context.TaskToDo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TaskToDo'  is null.");
        }
        //Get: Search form
        public async Task<IActionResult> CallSearchForm()
        {
            return _context.TaskToDo != null ? 
                View():


            Problem("Entity set 'ApplicationDbContext.TaskToDo'  is null.");
        }

        //Post: Search Result
        public async Task<IActionResult> SearchResult(string SearchPhrase)
           
        {
            var resl = await _context.TaskToDo.Where(t => t.Task.Contains(SearchPhrase)).ToListAsync();
            if (resl != null) { return View("Index", resl); }
          
            //Problem("Entity set 'ApplicationDbContext.TaskToDo'  is null.");
            //_context.TaskToDo != null ?
            //else{
            return View("Index1");
        }
        // GET: TaskToDoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TaskToDo == null)
            {
                return NotFound();
            }

            var taskToDo = await _context.TaskToDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskToDo == null)
            {
                return NotFound();
            }

            return View(taskToDo);
        }

        // GET: TaskToDoes/Create
        //[Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskToDoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Task,Description")] TaskToDo taskToDo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskToDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskToDo);
        }

        // GET: TaskToDoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TaskToDo == null)
            {
                return NotFound();
            }

            var taskToDo = await _context.TaskToDo.FindAsync(id);
            if (taskToDo == null)
            {
                return NotFound();
            }
            return View(taskToDo);
        }

        // POST: TaskToDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Task,Description")] TaskToDo taskToDo)
        {
            if (id != taskToDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskToDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskToDoExists(taskToDo.Id))
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
            return View(taskToDo);
        }

        // GET: TaskToDoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TaskToDo == null)
            {
                return NotFound();
            }

            var taskToDo = await _context.TaskToDo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskToDo == null)
            {
                return NotFound();
            }

            return View(taskToDo);
        }

        // POST: TaskToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TaskToDo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TaskToDo'  is null.");
            }
            var taskToDo = await _context.TaskToDo.FindAsync(id);
            if (taskToDo != null)
            {
                _context.TaskToDo.Remove(taskToDo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskToDoExists(int id)
        {
          return (_context.TaskToDo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
