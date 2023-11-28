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
    public class PontoTuristicoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PontoTuristicoController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: PontoTuristico
        public async Task<IActionResult> Index()
        {
              return View(await _context.PontoTuristicos.ToListAsync());
        }

        // GET: PontoTuristico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PontoTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return View(pontoTuristico);
        }

        // GET: PontoTuristico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PontoTuristico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Icone,Image")] PontoTuristico pontoTuristico, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pontoTuristico);
                await _context.SaveChangesAsync();
                 if (formFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = pontoTuristico.Id.ToString() + Path.GetExtension(formFile.FileName);
                    string uploads = Path.Combine(wwwRootPath, @"images\pontos");
                    string newFile = Path.Combine(uploads, fileName);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    pontoTuristico.Image = @"images/pontos/" + fileName;
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pontoTuristico);
        }

        // GET: PontoTuristico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PontoTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristicos.FindAsync(id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }
            return View(pontoTuristico);
        }

        // POST: PontoTuristico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Icone,Image")] PontoTuristico pontoTuristico, IFormFile formFile)
        {
            if (id != pontoTuristico.Id)
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
                        if (pontoTuristico.Image != null)
                        {
                            string oldFile = Path.Combine(wwwRootPath, pontoTuristico.Image.TrimStart('\\'));
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }

                        string fileName = pontoTuristico.Id.ToString() + Path.GetExtension(formFile.FileName);
                        string uploads = Path.Combine(wwwRootPath, @"images\pontos");
                        string newFile = Path.Combine(uploads, fileName);
                        using (var stream = new FileStream(newFile, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        pontoTuristico.Image = @"images/pontos/" + fileName;
                    }
                    _context.Update(pontoTuristico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PontoTuristicoExists(pontoTuristico.Id))
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
            return View(pontoTuristico);
        }

        // GET: PontoTuristico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PontoTuristicos == null)
            {
                return NotFound();
            }

            var pontoTuristico = await _context.PontoTuristicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pontoTuristico == null)
            {
                return NotFound();
            }

            return View(pontoTuristico);
        }

        // POST: PontoTuristico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PontoTuristicos == null)
            {
                return Problem("Entity set 'AppDbContext.PontoTuristicos'  is null.");
            }
            var pontoTuristico = await _context.PontoTuristicos.FindAsync(id);
            if (pontoTuristico != null)
            {
                _context.PontoTuristicos.Remove(pontoTuristico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PontoTuristicoExists(int id)
        {
          return _context.PontoTuristicos.Any(e => e.Id == id);
        }
    }
}
