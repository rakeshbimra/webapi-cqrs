using AutoMapper;
using MyApp.Context.Contract.CQRS.Dtos;
using MyApp.WebApi.Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.WebApi.Mapping
{
    public class ResponseMappingProfile:Profile
    {
        public ResponseMappingProfile()
        {
            CreateMap<ProductDto, ProductResponse>();
        }
    }
}
