using AutoMapper;
using BookCatalogueApi.Application.Catalogue.Commands.Create;
using BookCatalogueApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalogueApi.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCatalogueCommand, CatalogEntity>();
        }
    }
}
