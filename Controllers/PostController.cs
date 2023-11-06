using CheckpointBlog.DataBase;
using CheckpointBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckpointBlog.Controllers
{
    public class PostController : Controller
    {
        private readonly Context _context;

        public PostController(Context context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var posts = await _context.Posts.Include(p => p.Comentarios).ToListAsync();
            return View(posts);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
                _context.Add(post);
                await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p => p.Comentarios).FirstOrDefaultAsync(m => m.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }
                    _context.Update(post);
                    await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: Post/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public IActionResult Search(string searchTerm)
        {
            var posts = _context.Posts
                .Where(p => p.Titulo.Contains(searchTerm))
                .ToList();

            return View(posts);
        }

    }
}