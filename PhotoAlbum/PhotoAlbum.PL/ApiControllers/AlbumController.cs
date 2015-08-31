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
using PhotoAlbum.PL.ViewModels;

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
        public ScrollableAlbumsViewModel GetAllAlbums(int currentPageNumber, int numberOfRecordsPerPage, string categoryNameForFilter="")
        {
            var numberOfRecordsToSkip = (currentPageNumber - 1) * numberOfRecordsPerPage;
            var filteredByCategoryNameAlbums = albumRepository.GetAllByCategoryName(categoryNameForFilter);
            var filteredAlbumsModel = new ScrollableAlbumsViewModel();
            Mapper.CreateMap<Photo, PhotoViewModel>();
            filteredAlbumsModel.AlbumsToShow = filteredByCategoryNameAlbums
                .OrderBy(orderingAlbum => orderingAlbum.ModificationDate)
                .Skip(numberOfRecordsToSkip)
                .Take(numberOfRecordsPerPage)
                .ToList()
                .Select(filteredAlbum => new AlbumViewModel
                {
                    Id = filteredAlbum.Id,
                    Name = filteredAlbum.Name,
                    AuthorId = filteredAlbum.AuthorId,
                    AuthorUserName = filteredAlbum.Author.UserName,
                    Categories = filteredAlbum.Categories.Select(category => new CategoryViewModel { Id = category.Id, Name = category.Name }).ToList(),
                    CoverPhoto = Mapper.Map<PhotoViewModel>(filteredAlbum.Photos.First())
                }).ToList();

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
        public List<AlbumViewModel> GetLatestAlbums(string categoryNameForFilter)
        {
            if(categoryNameForFilter == "View All"){
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
        public FullAlbumViewModel GetAlbumById(int id)
        {
            if (albumRepository.IsUserHaveAccessToManage(User.Identity.GetUserId(), id))
            {
                Mapper.CreateMap<Album, FullAlbumViewModel>();
                Mapper.CreateMap<Category, CategoryViewModel>();
                var a = Mapper.Map<FullAlbumViewModel>(albumRepository.GetById(id));
                var b = a;
                return a;
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Post album to server
        /// </summary>
        /// <param name="model"> posted data</param>
        [HttpPost]
        public int CreateAlbum(Album model)
        {
            if (ModelState.IsValid && albumRepository.IsUserHaveAccessToManage(User.Identity.GetUserId(), model.Id))
            {
                Album album = new Album()
                    {
                        Name = model.Name,
                        Photos = model.Photos,
                        AuthorId = model.AuthorId,
                        Categories = model.Categories,
                        CreationDate = DateTime.Now,
                        ModificationDate = DateTime.Now
                    };
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
        public int UpdateAlbum(Album model)
        {
            if (ModelState.IsValid)
            {
                if (albumRepository.IsUserHaveAccessToManage(User.Identity.GetUserId(), model.Id))
                {
                    Album album = albumRepository.GetById(model.Id);
                    album.Name = model.Name;
                    album.Photos = model.Photos;
                    album.Categories = model.Categories;
                    album.ModificationDate = DateTime.Now;
                    albumRepository.Update(album);
                    return album.Id;
                }
            }

            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }

        /// <summary>
        /// Delete existing album object
        /// </summary>
        /// <param name="id">identifier of album</param>
        [HttpPost]
        public void DeleteAlbum(int id)
        {
            if (albumRepository.IsUserHaveAccessToManage(User.Identity.GetUserId(), id))
            {
                Album album = albumRepository.GetById(id);
                albumRepository.Delete(album);
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}
