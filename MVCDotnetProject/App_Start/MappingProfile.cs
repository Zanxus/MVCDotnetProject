﻿using AutoMapper;
using MVCDotnetProject.Dtos;
using MVCDotnetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDotnetProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }



    }
}