using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeTiAPI.Models;
using PeTiAPI.Dtos.Reviews;

namespace PeTiAPI.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            //Source -> Target
            CreateMap<Review, ReviewReadDTO>();
            CreateMap<ReviewCreateDTO, Review>();
            //CreateMap<ReviewUpdateDTO, Review>();
            //CreateMap<Review, ReviewUpdateDTO>();
        }
    }
}