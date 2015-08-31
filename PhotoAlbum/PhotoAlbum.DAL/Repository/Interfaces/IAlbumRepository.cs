using PhotoAlbum.Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PhotoAlbum.DAL.Repository.Interfaces
{
    /// <summary>
    /// IAlbumRepository interface implements IRepository
    /// </summary>
    public interface IAlbumRepository : IRepository<Album>
    {
        bool IsUserHaveAccessToManage(string userId, int albumId);
        IQueryable<Album> GetAllByCategoryName(string categoryName);//IEnumerable
    }
}
