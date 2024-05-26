using System.ComponentModel.DataAnnotations;

namespace TravelBlog.Models
{
    public class GalleryItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
