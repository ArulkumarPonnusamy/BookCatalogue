using AutoMapper;
using BookCatalogueApi.Application.Catalogue.Commands.Create;
using BookCatalogueApi.Application.Profiles;
using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace BookCatalogueApi.Persistence.Test
{

    public class CatalogueServiceTest
    {
        private readonly IMapper _mapper;

        private readonly CatalogEntity catalogEntity;
        public CatalogueServiceTest()
        {
            catalogEntity = new CatalogEntity { Author = "Arul", ISBN = "1234567891231", Title = "Sample Program", PublicationDate = DateTime.Today };
        }

        [Fact, TestPriority(1)]
        public async Task Handle_Catalogue_Create()
        {
            //Arragne
            ICatalogueService service = new BookCatalogueApi.Persistence.Services.CatalogueService();

            //Act
            var Result = await service.Create(catalogEntity, CancellationToken.None);

            //Assert
            Result.Should().NotBeNull();
        }

        [Fact, TestPriority(2)]
        public async Task Handle_Catalogue_Modify()
        {
            //Arragne
            ICatalogueService service = new BookCatalogueApi.Persistence.Services.CatalogueService();

            //Act
            var Result = await service.Create(catalogEntity, CancellationToken.None);

            //Assert
            Result.Should().HaveCountGreaterThan(0);
        }
        [Fact, TestPriority(3)]
        public async Task Handle_Catalogue_CheckExist()
        {
            //Arragne
            ICatalogueService service = new BookCatalogueApi.Persistence.Services.CatalogueService();

            //Act
            var Result = await service.IsCatalogueExist(catalogEntity.ISBN, CancellationToken.None);

            //Assert
            Result.Should().BeTrue();
        }
        [Fact, TestPriority(4)]
        public async Task Handle_Catalogue_Delete()
        {
            //Arragne
            ICatalogueService service = new BookCatalogueApi.Persistence.Services.CatalogueService();

            //Act
            var Result = await service.Delete(catalogEntity, CancellationToken.None);

            //Assert
            Result.Should().HaveCount(0);
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestPriorityAttribute : Attribute
    {
        public TestPriorityAttribute(int priority)
        {
            Priority = priority;
        }

        public int Priority { get; private set; }
    }
}
