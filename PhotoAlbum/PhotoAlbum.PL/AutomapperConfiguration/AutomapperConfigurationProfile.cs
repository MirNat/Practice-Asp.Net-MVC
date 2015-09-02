using System.Linq;
using AutoMapper;
using PhotoAlbum.Entities.Entities;
using businessModels = PhotoAlbum.PL.Models;

namespace PhotoAlbum.PL.AutomapperConfiguration
{
    public class AutomapperConfigurationProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Category, businessModels.Category>();
            Mapper.CreateMap<Photo, businessModels.Photo>();
            Mapper.CreateMap<ApplicationUser, businessModels.User>();
            Mapper.CreateMap<Album, businessModels.Album>().ForMember(albumViewModel => albumViewModel.CoverPhoto, configurationExpression => configurationExpression.MapFrom(album => album.Photos.First()));
            Mapper.CreateMap<Album, businessModels.FullAlbum>();

        }
    }
}