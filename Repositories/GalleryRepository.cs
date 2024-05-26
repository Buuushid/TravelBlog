using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBlog.Data;
using TravelBlog.Models;

namespace TravelBlog.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GalleryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GalleryItem>> GetAllAsync()
        {
            return await _dbContext.GalleryItems.ToListAsync();
        }

        public async Task<GalleryItem> GetByIdAsync(int id)
        {
            return await _dbContext.GalleryItems.FindAsync(id);
        }

        public async Task AddAsync(GalleryItem item)
        {
            _dbContext.GalleryItems.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(GalleryItem item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dbContext.GalleryItems.FindAsync(id);
            _dbContext.GalleryItems.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }

}
