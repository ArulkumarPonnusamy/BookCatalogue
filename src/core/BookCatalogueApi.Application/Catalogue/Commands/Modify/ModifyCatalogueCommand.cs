using AutoMapper;
using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Application.Catalogue.Commands.Modify
{
    public class ModifyCatalogueCommand : CatalogEntity, IRequest<List<CatalogEntity>>
    {
        
    }
}