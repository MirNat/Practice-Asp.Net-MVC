using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using AutoMapper;
using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.Entities.Entities;
using businessModels = PhotoAlbum.PL.Models;

namespace PhotoAlbum.PL.ApiControllers
{
    [Authorize]
    [RoutePrefix("api/Album")]
    public class AlbumController : ApiController
    {
        private IAlbumRepository albumRepository;

        private const int NumberOfLatestAlbumsToShow = 20;

        /// <summary>
        /// Inject repository in controller
        /// </summary>
        /// <param name="albumRepository">injected object</param>
        public AlbumController(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        /// <summary>
        /// Return ScrollableAlbumsViewModel object
        /// </summary>
        /// <param name="currentPage">current page number</param>
        /// <param name="recordsPerPage">number of albums in page</param>
        /// <param name="categoryNameForFilter">name of category to filter albums</param>
        /// <returns>Album object</returns>
        [HttpGet]
        //[Route("GetLatestAlbums/{currentPageNumber}/{numberOfRecordsPerPage}/{categoryNameForFilter}")]
        public businessModels.ScrollableAlbums GetAllAlbums(int currentPageNumber, int numberOfRecordsPerPage, string categoryNameForFilter = "")
        {
            var numberOfRecordsToSkip = (currentPageNumber - 1) * numberOfRecordsPerPage;
            var filteredByCategoryNameAlbums = albumRepository.GetAllByCategoryName(categoryNameForFilter);
            var filteredAlbumsModel = new businessModels.ScrollableAlbums();

            filteredAlbumsModel.AlbumsToShow = filteredByCategoryNameAlbums
            .OrderBy(orderingAlbum => orderingAlbum.ModificationDate)
            .Skip(numberOfRecordsToSkip)
            .Take(numberOfRecordsPerPage)
            .ToList()
            .Select(album => Mapper.Map<businessModels.Album>(album)).ToList();

            filteredAlbumsModel.TotalAlbumsCount = filteredByCategoryNameAlbums.Count();

            return filteredAlbumsModel;
        }


        /// <summary>
        /// Return latest albums in form of collection of AlbumViewModel objects
        /// </summary>
        /// <param name="categoryNameForFilter">name of category to filter albums</param>
        /// <returns>Album object</returns>
        [HttpGet]
        [Route("GetLatestAlbums/{categoryNameForFilter}")]
        public List<businessModels.Album> GetLatestAlbums(string categoryNameForFilter)
        {
            if (categoryNameForFilter == "View All")
            {
                categoryNameForFilter = "";
            }
            const int StartPageForLatestPublications = 1;
            return GetAllAlbums(StartPageForLatestPublications, NumberOfLatestAlbumsToShow, categoryNameForFilter).AlbumsToShow.ToList();
        }

        /// <summary>
        /// Return Album object by identifier
        /// </summary>
        /// <param name="id">identifier of album</param>
        /// <returns>Album object</returns>
        [HttpGet]
        [Route("GetAlbumById/{id}")]
        public businessModels.FullAlbum GetAlbumById(int id)
        {
            if (albumRepository.IsUserHaveAccessToManage(User.Identity.GetUserId(), id))
            {
                return Mapper.Map<businessModels.FullAlbum>(albumRepository.GetById(id)); ;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Post album to server
        /// </summary>
        /// <param name="model"> posted data</param>
        [HttpPost]
        [Route("CreateAlbum")]
        public int CreateAlbum(businessModels.FullAlbum model)
        {
            model.AuthorId = User.Identity.GetUserId();
            model.CreationDate = DateTime.Now;
            model.ModificationDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                //creating photos
                var album = Mapper.Map<Album>(model);
                albumRepository.Create(album);
                return album.Id;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Update existing album object
        /// </summary>
        /// <param name="model"> posted data</param>
        [HttpPost]
        [Route("UpdateAlbum")]
        public int UpdateAlbum(businessModels.FullAlbum model)
        {

            if (ModelState.IsValid && albumRepository.IsUserHaveAccessToManage(User.Identity.GetUserId(), model.Id))
            {
                var album = albumRepository.GetById(model.Id);

                album.ModificationDate = DateTime.Now;
                album.Name = model.Name;
                //Album album = albumRepository.GetById(model.Id);
                //album.Name = model.Name;
                //album.Photos = model.Photos;
                //Mapper.CreateMap<businessModels.Category, Category>();
                //album.Categories = (ICollection<Category>)model.Categories.Select(c => Mapper.Map<Category>(c));
                //album.ModificationDate = DateTime.Now;
                //album.Photos = null;
                //model.Categories = null;
                var album1 = Mapper.Map<Album>(model);
                album.Categories = album1.Categories;
                //album.Author = null;
                albumRepository.Update(album);
                return album.Id;
            }

            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Delete existing album object
        /// </summary>
        /// <param name="id">identifier of album</param>
        [HttpPost]
        [Route("DeleteAlbum/{id}")]
        public HttpResponseMessage DeleteAlbum(int id)
        {
            if (albumRepository.IsUserHaveAccessToManage(User.Identity.GetUserId(), id))
            {
                Album album = albumRepository.GetById(id);
                albumRepository.Delete(album);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}
