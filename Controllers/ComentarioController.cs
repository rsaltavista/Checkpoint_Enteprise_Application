using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CheckpointBlog.DataBase;
using CheckpointBlog.Models;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace CheckpointBlog.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly Context _context;

        public ComentarioController(Context context)
        {
            _context = context;
        }

        // GET: Comentario/Create
        public IActionResult Create(int postId)
        {
            ViewData["PostId"] = postId;
            return View();
        }

        // POST: Comentario/Create
        [HttpPost]
        public async Task<IActionResult> Create(int postId, Comentario comentario)
        {
                comentario.DataComentario = DateTime.Now;
                comentario.PostId = postId;
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                ViewData["PostId"] = postId;
            return RedirectToAction("Index", "Post");
        }

        // GET: Comentario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentario/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Comentario comentario)
        {
            if (id != comentario.Id)
            {
                return NotFound();
            }
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Post", new { id = comentario.PostId });
        }

        // GET: Comentario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);

            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Post", new { id = comentario.PostId });
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(e => e.Id == id);
        }
    }
}

