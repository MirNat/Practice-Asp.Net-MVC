using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PhotoAlbum.Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Albums = new HashSet<Album>();
        }
        public string Name { get; set; }

        public string Surname { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(200)]
        public override string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public override string Email { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        [Phone]
        public override string PhoneNumber { get; set; }

        [InverseProperty("Author")]
        public virtual ICollection<Album> Albums { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}