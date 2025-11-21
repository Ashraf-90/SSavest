using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class HeroBannerProfile : Profile
    {
        public HeroBannerProfile()
        {
            CreateMap<HeroBanner, HeroBannerDTo>()
                .ForMember(d => d.Id, op => op.MapFrom(src => src.Id))
                .ForMember(d => d.Text_One, op => op.MapFrom(src => src.Text_One))
                .ForMember(d => d.Text_Two, op => op.MapFrom(src => src.Text_Two))
                .ForMember(d => d.Text_Three, op => op.MapFrom(src => src.Text_Three))
                .ForMember(d => d.Image_One, op => op.MapFrom(src => src.Image_One))
                .ForMember(d => d.Image_Two, op => op.MapFrom(src => src.Image_Two))
                .ForMember(d => d.Image_Three, op => op.MapFrom(src => src.Image_Three))
                .ReverseMap();
        }
    }
}
