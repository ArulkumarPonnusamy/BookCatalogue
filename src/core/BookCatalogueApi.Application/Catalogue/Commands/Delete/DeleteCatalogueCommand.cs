using AutoMapper;
using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Application.Catalogue.Commands.Delete
{
    public class DeleteCatalogueCommand : CatalogEntity, IRequest<List<CatalogEntity>>
    {
        
    }
}