using System.ComponentModel.DataAnnotations;

namespace MangaWebApp.Models
{
    public class Category
    {
        []
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
