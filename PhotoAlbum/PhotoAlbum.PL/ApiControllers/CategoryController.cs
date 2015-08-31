using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.Entities.Entities;
using PhotoAlbum.PL.ViewModels;
using System.Collections.Generic;

namespace PhotoAlbum.PL.ApiControllers
{
    [Authorize]
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
         private ICategoryRepository categoryRepository;

        /// <summary>
        /// Inject repository in controller
        /// </summary>
         /// <param name="categoryRepository">injected object</param>
         public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

         /// <summary>
         /// Return collection of CategoryViewModel objects
         /// </summary>
         /// <returns>collection of CategoryViewModel objects</returns>
        [HttpGet]
        [Route("GetAllCategories")]
        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            return categoryRepository.GetAll().Select(c => new CategoryViewModel { Id = c.Id, Name = c.Name });
        }

        /// <summary>
        /// Return CategoryViewModel object by identifier
        /// </summary>
        /// <returns>CategoryViewModel object</returns>
        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public CategoryViewModel GetCategoryById(int id)
        {
            var category = categoryRepository.GetById(id);
            if(category != null)
            {
                return Mapper.Map<CategoryViewModel>(category);
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}
