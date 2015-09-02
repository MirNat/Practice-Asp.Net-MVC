using System.Collections.Generic;

namespace PhotoAlbum.PL.Models
{
    public class User
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        //public IEnumerable<AlbumViewModel> Albums { get; set; }
    }
}