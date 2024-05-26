using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelBlog.Repositories;
using TravelBlog.Models;

namespace TravelBlog.Controllers
{
    public class CMSController : Controller
    {
        private readonly IGalleryRepository _repository;

        public CMSController(IGalleryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GalleryItem galleryItem)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(galleryItem);
                return RedirectToAction(nameof(Index));
            }
            return View(galleryItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryItem = await _repository.GetByIdAsync(id.Value);
            if (galleryItem == null)
            {
                return NotFound();
            }
            return View(galleryItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GalleryItem galleryItem)
        {
            if (id != galleryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(galleryItem);
                return RedirectToAction(nameof(Index));
            }
            return View(galleryItem);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var galleryItem = await _repository.GetByIdAsync(id.Value);
            if (galleryItem == null)
            {
                return NotFound();
            }

            return View(galleryItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
