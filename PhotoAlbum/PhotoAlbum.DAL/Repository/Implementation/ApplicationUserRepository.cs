using PhotoAlbum.Entities.Entities;
using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.DAL.Repository.Context;

namespace PhotoAlbum.DAL.Repository.Implementation
{
    /// <summary>
    /// ApplicationUserRepository Class implements GenericRepository, IApplicationUserRepository.
    /// </summary>
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        /// <summary>
        /// ApplicationUserRepository Constructor.
        /// </summary>
        /// <param name="context"></param>
        public ApplicationUserRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
