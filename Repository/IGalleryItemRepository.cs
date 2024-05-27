using TravelBlogDB1.Models;

public interface IGalleryItemRepository
{
    Task<IEnumerable<GalleryItem>> GetAllAsync();
    Task<GalleryItem> GetByIdAsync(int id);
    Task AddAsync(GalleryItem galleryItem);
    Task UpdateAsync(GalleryItem galleryItem);
    Task DeleteAsync(int id);
}
