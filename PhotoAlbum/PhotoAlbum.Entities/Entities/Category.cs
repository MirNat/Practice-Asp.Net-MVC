using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoAlbum.Entities.Entities
{
    public class Category
    {
        public Category()
        {
            this.Albums = new HashSet<Album>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(200)]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}