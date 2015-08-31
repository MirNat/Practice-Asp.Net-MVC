using System.Collections.Generic;

namespace PhotoAlbum.PL.ViewModels
{
    public class UserViewModel
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