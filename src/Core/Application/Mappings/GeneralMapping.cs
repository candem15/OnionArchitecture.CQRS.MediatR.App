using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.Features.Commands.CreateProduct;
using Application.Features.Queries.GetProductById;
using AutoMapper;

namespace Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product,Dtos.ProductReadDto>()
                .ReverseMap();

            CreateMap<Domain.Entities.Product,CreateProductCommand>()
                .ReverseMap();

            CreateMap<Domain.Entities.Product,GetProductByIdViewModel>()
                .ReverseMap();
        }
    }
}