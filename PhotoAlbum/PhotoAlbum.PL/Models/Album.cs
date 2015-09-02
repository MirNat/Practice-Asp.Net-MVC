using System.Collections.Generic;

namespace PhotoAlbum.PL.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUserName { get; set; }

        public System.DateTime CreationDate { get; set; }

        public System.DateTime ModificationDate { get; set; }

        public Photo CoverPhoto { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}