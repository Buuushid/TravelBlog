using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBlogDB1.Data;
using TravelBlogDB1.Models;

public class GalleryItemRepository : IGalleryItemRepository
{
    private readonly ApplicationDbContext _context;

    public GalleryItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<GalleryItem>> GetAllAsync()
    {
        return await _context.GalleryItems.ToListAsync();
    }

    public async Task<GalleryItem> GetByIdAsync(int id)
    {
        return await _context.GalleryItems.FindAsync(id);
    }

    public async Task AddAsync(GalleryItem galleryItem)
    {
        _context.GalleryItems.Add(galleryItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(GalleryItem galleryItem)
    {
        _context.Entry(galleryItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var galleryItem = await _context.GalleryItems.FindAsync(id);
        if (galleryItem != null)
        {
            _context.GalleryItems.Remove(galleryItem);
            await _context.SaveChangesAsync();
        }
    }
}
