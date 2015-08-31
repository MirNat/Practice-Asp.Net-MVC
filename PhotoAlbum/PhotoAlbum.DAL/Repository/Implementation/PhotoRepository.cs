using PhotoAlbum.Entities.Entities;
using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.DAL.Repository.Context;

namespace PhotoAlbum.DAL.Repository.Implementation
{
    /// <summary>
    /// PhotoRepository Class implements GenericRepository, IPhotoRepository.
    /// </summary>
    public class PhotoRepository: GenericRepository<Photo>, IPhotoRepository
    {
        /// <summary>
        /// PhotoRepository Constructor.
        /// </summary>
        /// <param name="context"></param>
        public PhotoRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
