using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmandaViagens.Data;
using AmandaViagens.Models;
using Microsoft.AspNetCore.Authorization;

namespace AmandaViagens.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CruzeiroController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CruzeiroController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Cruzeiro
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cruzeiros.ToListAsync());
        }

        // GET: Cruzeiro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cruzeiros == null)
            {
                return NotFound();
            }

            var cruzeiro = await _context.Cruzeiros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cruzeiro == null)
            {
                return NotFound();
            }

            return View(cruzeiro);
        }

        // GET: Cruzeiro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cruzeiro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,Image")] Cruzeiro cruzeiro, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cruzeiro);
                await _context.SaveChangesAsync();

                if (formFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = cruzeiro.Id.ToString() + Path.GetExtension(formFile.FileName);
                    string uploads = Path.Combine(wwwRootPath, @"images\cruzeiros");
                    string newFile = Path.Combine(uploads, fileName);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }

                    cruzeiro.Image = @"/images/cruzeiros/" + fileName;
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(cruzeiro);
        }

        // GET: Cruzeiro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cruzeiros == null)
            {
                return NotFound();
            }

            var cruzeiro = await _context.Cruzeiros.FindAsync(id);
            if (cruzeiro == null)
            {
                return NotFound();
            }
            return View(cruzeiro);
        }

        // POST: Cruzeiro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,Image")] Cruzeiro cruzeiro, IFormFile formFile)
        {
            if (id != cruzeiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (formFile != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        if (cruzeiro.Image != null)
                        {
                            string oldFile = Path.Combine(wwwRootPath, cruzeiro.Image.TrimStart('\\'));
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }

                        string fileName = cruzeiro.Id.ToString() + Path.GetExtension(formFile.FileName);
                        string uploads = Path.Combine(wwwRootPath, @"images\cruzeiros");
                        string newFile = Path.Combine(uploads, fileName);
                        using (var stream = new FileStream(newFile, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        cruzeiro.Image = @"/images/cruzeiros/" + fileName;
                    }

                    _context.Update(cruzeiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CruzeiroExists(cruzeiro.Id))
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
            return View(cruzeiro);
        }

        // GET: Cruzeiro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cruzeiros == null)
            {
                return NotFound();
            }

            var cruzeiro = await _context.Cruzeiros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cruzeiro == null)
            {
                return NotFound();
            }

            return View(cruzeiro);
        }

        // POST: Cruzeiro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cruzeiros == null)
            {
                return Problem("Entity set 'AppDbContext.Cruzeiros'  is null.");
            }
            var cruzeiro = await _context.Cruzeiros.FindAsync(id);
            if (cruzeiro != null)
            {
                _context.Cruzeiros.Remove(cruzeiro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CruzeiroExists(int id)
        {
          return _context.Cruzeiros.Any(e => e.Id == id);
        }
    }
}
