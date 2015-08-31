using System.Collections.Generic;

namespace PhotoAlbum.PL.ViewModels
{
    public class AlbumViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUserName { get; set; }

        public PhotoViewModel CoverPhoto { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}