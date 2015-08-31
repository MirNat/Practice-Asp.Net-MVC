using System.Collections.Generic;
using System.Linq;
using PhotoAlbum.Entities.Entities;
using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.DAL.Repository.Context;

namespace PhotoAlbum.DAL.Repository.Implementation
{
    /// <summary>
    /// CategoryRepository Class implements GenericRepository, ICategoryRepository
    /// </summary>
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        /// <summary>
        /// CategoryRepository Constructor.
        /// </summary>
        /// <param name="context"></param>
        public CategoryRepository(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
