using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.Entities.Entities;
using businessModels = PhotoAlbum.PL.Models;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace PhotoAlbum.PL.ApiControllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private IApplicationUserRepository userRepository;

        /// <summary>
        /// Inject repository in controller
        /// </summary>
        /// <param name="categoryRepository">injected object</param>
        public UserController(IApplicationUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [Route("IsCurrentUserOwnerOfProfile/{ownerOfProfileId}")]
        public bool IsUserOwnerOfProfile(string ownerOfProfileId)
        {
            return User.Identity.GetUserId() == ownerOfProfileId;
        }

        /// <summary>
        /// Return UserViewModel object by user identifier
        /// </summary>
        /// <returns>UserViewModel object</returns>
        [HttpGet]
        [Route("GetUserById/{id}")]
        public businessModels.User GetUserById(string id)
        {
            var user = userRepository.GetById(id);
            if (user != null)
            {
                return Mapper.Map<businessModels.User>(user);
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <returns>List of AlbumViewModel objects</returns>
        [HttpGet]
        [Route("GetUserAlbumsById/{id}")]
        public List<businessModels.Album> GetUserAlbumsById(string id)
        {
            var user = userRepository.GetById(id);
            if (user != null)
            {
                return user.Albums.Select(album => Mapper.Map<businessModels.Album>(album)).ToList();
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Return UserViewModel object of current user
        /// </summary>
        /// <returns>UserViewModel object</returns>
        [HttpGet]
        [Route("GetCurrentUser")]
        public businessModels.User GetCurrentUser()
        {
            var user = userRepository.GetById(User.Identity.GetUserId());
            if (user != null)
            {
                return Mapper.Map<businessModels.User>(user);
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <returns>List of AlbumViewModel objects</returns>
        [HttpGet]
        [Route("GetCurrentUserAlbums")]
        public List<businessModels.Album> GetCurrentUserAlbums()
        {
            var user = userRepository.GetById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.Albums.Select(album => Mapper.Map<businessModels.Album>(album)).ToList();
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}
