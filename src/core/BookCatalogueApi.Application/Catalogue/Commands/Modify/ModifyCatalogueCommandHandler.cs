using AutoMapper;
using BookCatalogueApi.Application.Exceptions;
using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Application.Catalogue.Commands.Modify
{
    public class ModifyCatalogueCommandHandler : IRequestHandler<ModifyCatalogueCommand, List<CatalogEntity>>
    {
        private readonly ICatalogueService _catalogueService;
        private readonly IMapper _mapper;

        public ModifyCatalogueCommandHandler(ICatalogueService catalogueService, IMapper mapper)
        {
            _catalogueService = catalogueService;
            _mapper = mapper;
        }

        public async Task<List<CatalogEntity>> Handle(ModifyCatalogueCommand deleteCatalogueCommand, CancellationToken cancellationToken)
        {
            var catalogue = _mapper.Map<CatalogEntity>(deleteCatalogueCommand);

            if (await _catalogueService.IsCatalogueExist(catalogue.ISBN, cancellationToken).ConfigureAwait(false))
                return await _catalogueService.Modify(catalogue, cancellationToken).ConfigureAwait(false);
            else
                throw new NotFoundException("NotFound", "Catalogue not found for given ISBN");
        }
    }
}