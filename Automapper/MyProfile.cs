using AutoMapper;
using ImageProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Automapper
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            //CreateMap<AlbumCategory, AlbumCategoryViewModel>().ReverseMap();
            //CreateMap<AlbumCategory, EditAlbumCategoryViewModel>().ReverseMap();
            //CreateMap<AlbumCategory, CreateAlbumCategoryViewModel>().ReverseMap();
            //CreateMap<AlbumCategory, AlbumCategoryComponentViewModel>();

            //CreateMap<MyMedia, MyMediaEditViewModel>().ReverseMap();
            //CreateMap<MyMedia, MyMediaViewModel>().ForMember(d => d.AlbumCategoryTitle, opt => opt.MapFrom(srce => srce.AlbumCategory.Title));
        }
    }
}
