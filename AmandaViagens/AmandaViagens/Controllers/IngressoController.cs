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
    public class IngressoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IngressoController(AppDbContext context,  IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Ingresso
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ingressos.ToListAsync());
        }

        // GET: Ingresso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ingressos == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingressos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // GET: Ingresso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingresso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Preco,Image")] Ingresso ingresso, IFormFile formFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingresso);
                await _context.SaveChangesAsync();
                if (formFile != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = ingresso.Id.ToString("00") + Path.GetExtension(formFile.FileName);
                    string uploads = Path.Combine(wwwRootPath, @"images\ingressos");
                    string newFile = Path.Combine(uploads, fileName);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    ingresso.Image = @"\images\ingressos\" + fileName;
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ingresso);
        }

        // GET: Ingresso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ingressos == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingressos.FindAsync(id);
            if (ingresso == null)
            {
                return NotFound();
            }
            return View(ingresso);
        }

        // POST: Ingresso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,Image")] Ingresso ingresso, IFormFile formFile)
        {
            if (id != ingresso.Id)
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
                        if (ingresso.Image != null)
                        {
                            string oldFile = Path.Combine(wwwRootPath, ingresso.Image.TrimStart('\\'));
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }

                        string fileName = ingresso.Id.ToString("00") + Path.GetExtension(formFile.FileName);
                        string uploads = Path.Combine(wwwRootPath, @"images\ingressos");
                        string newFile = Path.Combine(uploads, fileName);
                        using (var stream = new FileStream(newFile, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                        ingresso.Image = @"\images\ingressos\" + fileName;
                    }
                    _context.Update(ingresso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngressoExists(ingresso.Id))
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
            return View(ingresso);
        }

        // GET: Ingresso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ingressos == null)
            {
                return NotFound();
            }

            var ingresso = await _context.Ingressos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingresso == null)
            {
                return NotFound();
            }

            return View(ingresso);
        }

        // POST: Ingresso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ingressos == null)
            {
                return Problem("Entity set 'AppDbContext.Ingressos'  is null.");
            }
            var ingresso = await _context.Ingressos.FindAsync(id);
            if (ingresso != null)
            {
                _context.Ingressos.Remove(ingresso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngressoExists(int id)
        {
          return _context.Ingressos.Any(e => e.Id == id);
        }
    }
}
