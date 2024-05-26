using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelBlog.Models
{
    public interface IGalleryRepository
    {
        Task<List<GalleryItem>> GetAllAsync();
        Task<GalleryItem> GetByIdAsync(int id);
        Task AddAsync(GalleryItem item);
        Task UpdateAsync(GalleryItem item);
        Task DeleteAsync(int id);
    }
}
