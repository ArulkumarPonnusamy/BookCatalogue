using AutoMapper;
using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Application.Catalogue.Commands.Create
{
    public class CreateCatalogueCommand : CatalogEntity, IRequest<List<CatalogEntity>>
    {
        
    }
}