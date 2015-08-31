using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using PhotoAlbum.Entities.Entities;
using PhotoAlbum.DAL.Repository;
using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.DAL.Repository.Context;

namespace PhotoAlbum.DAL.Repository.Implementation
{
    /// <summary>
    /// AlbumRepository Class implements GenericRepository, IAlbumRepository.
    /// </summary>
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        /// <summary>
        /// AlbumRepository Constructor.
        /// </summary>
        /// <param name="context"></param>
        public AlbumRepository(ApplicationDbContext context)
            : base(context)
        {
        }
        private Expression<Func<Album, bool>> FilterByCategoryName(string categoryName)
        {
            return album => string.IsNullOrEmpty(categoryName) || album.Categories.Any(category => category.Name == categoryName);
        }
        public IQueryable<Album> GetAllByCategoryName(string categoryName)//IEnumerable
        {
            var a = GetAll(FilterByCategoryName(categoryName));
            return a;
        }

        public bool IsUserHaveAccessToManage (string userId, int albumId) {
            var album = GetById(albumId);
            if (album != null)
            {
                return (album.Author.Id == userId);
            }
            return false;
        }
    }
}
