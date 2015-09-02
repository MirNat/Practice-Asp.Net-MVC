using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PhotoAlbum.DAL.Repository.Interfaces;
using PhotoAlbum.Entities.Entities;
using businessModels = PhotoAlbum.PL.Models;
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
         public List<businessModels.Category> GetAllCategories()
        {
            return categoryRepository.GetAll().ToList().Select(category => Mapper.Map<businessModels.Category>(category)).ToList();
        }

        /// <summary>
        /// Return CategoryViewModel object by identifier
        /// </summary>
        /// <returns>CategoryViewModel object</returns>
        [HttpGet]
        [Route("GetCategoryById/{id}")]
        public businessModels.Category GetCategoryById(int id)
        {
            var category = categoryRepository.GetById(id);
            if(category != null)
            {
                return Mapper.Map<businessModels.Category>(category);
            }
            throw new HttpResponseException(HttpStatusCode.InternalServerError);
        }
    }
}
