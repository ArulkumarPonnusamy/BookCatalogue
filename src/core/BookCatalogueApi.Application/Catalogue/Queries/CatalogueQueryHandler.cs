using AutoMapper;
using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Application.Catalogue.Query
{
    public class CatalogueQueryHandler : IRequestHandler<CatalogueQuery, List<CatalogEntity>>
    {
        private readonly ICatalogueService _catalogueService;
        private readonly IMapper _mapper;

        public CatalogueQueryHandler(ICatalogueService catalogueService, IMapper mapper)
        {
            _catalogueService = catalogueService;
            _mapper = mapper;
        }

        public async Task<List<CatalogEntity>> Handle(CatalogueQuery deleteCatalogueCommand, CancellationToken cancellationToken)
        {
            var catalogue = _mapper.Map<CatalogEntity>(deleteCatalogueCommand);
            return await _catalogueService.Search(catalogue, cancellationToken);
        }
    }
}