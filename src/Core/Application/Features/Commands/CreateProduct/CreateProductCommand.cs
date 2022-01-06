using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Repository;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdatedAt { get; set; }
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            private readonly IProductRepository repository;
            private readonly IMapper mapper;

            public CreateProductCommandHandler(IProductRepository repository,IMapper mapper)
            {
                this.repository = repository;
                this.mapper = mapper;
            }
            public async Task<ServiceResponse<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Domain.Entities.Product>(request);
                await repository.AddAsync(product);
                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}