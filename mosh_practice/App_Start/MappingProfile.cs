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
            CreateMap<Customer, CustomerDto>(); //第一個參數是source,第二個是target
            CreateMap<CustomerDto, Customer>();
        }
    }
}