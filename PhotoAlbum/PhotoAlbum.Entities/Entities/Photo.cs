using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhotoAlbum.Entities.Entities
{
    [Serializable]
    public class Photo
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public System.DateTime CreationDate { get; set; }

        [Required]
        public int AlbumId { get; set; }

        [JsonIgnore]
        [ForeignKey("AlbumId")]
        public virtual Album Album { get; set; }

        [Required]
        public string URL { get; set; }
    }
}