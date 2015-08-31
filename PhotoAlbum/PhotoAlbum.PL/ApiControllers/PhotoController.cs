using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace PhotoAlbum.PL.ApiControllers
{
    [RoutePrefix("api/Album")]
    public class PhotoController : ApiController
    {
        private IPhotoRepository photoRepository;
        private IAlbumRepository albumRepository;

        /// <summary>
        /// Inject repository in controller
        /// </summary>
        /// <param name="photoRepository">injected object</param>
        /// <param name="albumRepository">injected object</param>
        public PhotoController(
            IPhotoRepository photoRepository,
            IAlbumRepository albumRepository)
        {
            this.photoRepository = photoRepository;
            this.albumRepository = albumRepository;
        }

        /// <summary>
        /// Return Photo object by identifier
        /// </summary>
        /// <param name="id">identifier of album</param>
        /// <returns>Group object</returns>
        [HttpGet]
        public Photo GetFullSizePhotoById(int id)
        {
            Photo photo = photoRepository.GetById(id);
            if (photo != null)
            {
                return photo;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Post Photo to server
        /// </summary>
        /// <param name="model"> posted data</param>
        [HttpPost]
        public int CreatePhoto(Photo model)
        {
            if (ModelState.IsValid)
            {
                /// preparation + cloudinary!!!!!
                Photo photo = new Photo()
                {
                    Name = model.Name,
                    AlbumId = model.AlbumId,
                    URL = model.URL,
                    CreationDate = DateTime.Now
                };

                return photo.Id;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Delete existing photo object
        /// </summary>
        /// <param name="id">identifier of photo</param>
        [HttpPost]
        public void DeletePhoto(int id)
        {
            Photo photoToDelete = photoRepository.GetById(id);
            if (photoToDelete!=null && albumRepository.IsUserHaveAccessToManage(User.Identity.GetUserId(), photoToDelete.AlbumId))
            {
                photoRepository.Delete(photoToDelete);
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}
