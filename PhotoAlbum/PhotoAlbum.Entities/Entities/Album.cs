using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace PhotoAlbum.Entities.Entities
{
    [Serializable]
    public class Album
    {
        public Album()
        {
            this.Photos = new HashSet<Photo>();
            this.Categories = new HashSet<Category>();
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public System.DateTime CreationDate { get; set; }

        [Required]
        public System.DateTime ModificationDate { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }

        [InverseProperty("Album")]
        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}