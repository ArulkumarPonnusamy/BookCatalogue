using AutoMapper;
using BookCatalogueApi.Application.Exceptions;
using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Application.Catalogue.Commands.Create
{
    public class CreateCatalogueCommandHandler : IRequestHandler<CreateCatalogueCommand, List<CatalogEntity>>
    {
        private readonly ICatalogueService _catalogueService;
        private readonly IMapper _mapper;

        public CreateCatalogueCommandHandler(ICatalogueService catalogueService, IMapper mapper)
        {
            _catalogueService = catalogueService;
            _mapper = mapper;
        }

        public async Task<List<CatalogEntity>> Handle(CreateCatalogueCommand createCatalogueCommand, CancellationToken cancellationToken)
        {
            var catalogue = _mapper.Map<CatalogEntity>(createCatalogueCommand);

            if (await _catalogueService.IsCatalogueExist(catalogue.ISBN, cancellationToken).ConfigureAwait(false))
                throw new ValidationException("Exist", "Catalogue Already Exist for this ISBN");
            else
                return await _catalogueService.Create(catalogue, cancellationToken).ConfigureAwait(false);

        }
    }
}