using System.Collections.Generic;

namespace PhotoAlbum.PL.Models
{
    public class FullAlbum
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUserName { get; set; }

        public System.DateTime CreationDate { get; set; }

        public System.DateTime ModificationDate { get; set; }

        public List<Photo> Photos { get; set; }

        public List<Category> Categories { get; set; }
    }
}