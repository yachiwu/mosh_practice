using AutoMapper;
using mosh_practice.Dtos;
using mosh_practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mosh_practice.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Customer, CustomerDto>(); //第一個參數是source,第二個是target
            CreateMap<Movie, MovieDto>();
            //Dto to Domain
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore()); //tell AutoMapper to ignore Id during mapping of a CustomerDto to Customer.
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore()); //tell AutoMapper to ignore Id during mapping of a MovieDto to Movie.
        }
    }
}