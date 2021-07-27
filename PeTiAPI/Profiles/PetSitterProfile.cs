using AutoMapper;
using Newtonsoft.Json;
using PeTiAPI.Dtos;
using PeTiAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PeTiAPI.Profiles
{
    public class PetSitterProfile : Profile
    {
        public PetSitterProfile()
        {
            //Source -> Target
            CreateMap<PetSitter, PetSitterReadDTO>();
            CreateMap<PetSitterCreateDTO, PetSitter>();
            CreateMap<PetSitterUpdateDTO, PetSitter>();
            CreateMap<PetSitter, PetSitterUpdateDTO>();
        }
    }
}
