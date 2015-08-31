using System.Collections.Generic;

namespace PhotoAlbum.PL.ViewModels
{
    public class FullAlbumViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUserName { get; set; }

        public List<PhotoViewModel> Photos { get; set; }

        public List<CategoryViewModel> Categories { get; set; }
    }
}