using AutoMapper;
using MyApp.Context.Contract.CQRS.Commands;
using MyApp.WebApi.Contract.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.WebApi.Mapping
{
    public class RequestMappingProfile:Profile
    {
        public RequestMappingProfile()
        {
            CreateMap<AddProductRequest, AddProductCommand>();
        }
    }
}
