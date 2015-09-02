using System.Collections.Generic;

namespace PhotoAlbum.PL.Models
{
    public class ScrollableAlbums
    {
        public List<Album> AlbumsToShow { get; set; }

        public int TotalAlbumsCount { get; set; }
    }
}