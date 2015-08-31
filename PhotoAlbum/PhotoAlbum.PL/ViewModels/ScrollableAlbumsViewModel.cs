using System.Collections.Generic;

namespace PhotoAlbum.PL.ViewModels
{
    public class ScrollableAlbumsViewModel
    {
        public List<AlbumViewModel> AlbumsToShow { get; set; }

        public int TotalAlbumsCount { get; set; }
    }
}