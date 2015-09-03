using System.Linq;
using AutoMapper;
using PhotoAlbum.Entities.Entities;
using businessModels = PhotoAlbum.PL.Models;
using System;

namespace PhotoAlbum.PL.AutomapperConfiguration
{
    public class AutomapperConfigurationProfile : Profile
    {
        protected override void Configure()
        {
            Photo defaultCoverPhoto = new Photo() { Id = 0, Name = "DefaultCoverPhoto", AlbumId = 0, CreationDate = DateTime.Now, URL = "http://res.cloudinary.com/duu6ecknj/image/upload/v1441284352/default_cover_with_text_nzpcjo.jpg" };
            Mapper.CreateMap<Category, businessModels.Category>();
            Mapper.CreateMap<Photo, businessModels.Photo>();
            Mapper.CreateMap<ApplicationUser, businessModels.User>();
            Mapper.CreateMap<Album, businessModels.Album>().ForMember(albumViewModel => albumViewModel.CoverPhoto, configurationExpression => configurationExpression.MapFrom(album => album.Photos.Count == 0 ? defaultCoverPhoto : album.Photos.First()));
            Mapper.CreateMap<Album, businessModels.FullAlbum>();

            Mapper.CreateMap<businessModels.Category, Category>();
            Mapper.CreateMap<businessModels.Photo, Photo>();
            Mapper.CreateMap<businessModels.Album, Album>();
            Mapper.CreateMap<businessModels.FullAlbum, Album>();
        }
    }
}