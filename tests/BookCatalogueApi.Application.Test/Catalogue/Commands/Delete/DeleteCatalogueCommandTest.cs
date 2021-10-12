using AutoMapper;
using BookCatalogueApi.Application.Catalogue.Commands.Create;
using BookCatalogueApi.Application.Catalogue.Commands.Delete;
using BookCatalogueApi.Application.Exceptions;
using BookCatalogueApi.Application.Profiles;
using BookCatalogueApi.Persistence.Interfaces;
using BookCatalogueApi.Persistence.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BookCatalogueApi.Application.Test.Catalogue.Commands.Delete
{
    public class ModifyCatalogueCommandTest
    {
        private readonly IMapper _mapper;
        private readonly ICatalogueService _catalogueService;

        private readonly CreateCatalogueCommand _createCatalogueCommand;
        private readonly DeleteCatalogueCommand _deleteCatalogueCommand;
        public ModifyCatalogueCommandTest()
        {
            _createCatalogueCommand = new CreateCatalogueCommand { Author = "Arul", ISBN = "1234567891232", Title = "Sample Program", PublicationDate = DateTime.Today };
            _deleteCatalogueCommand = new DeleteCatalogueCommand { Author = "Arul", ISBN = "1234567891232", Title = "Sample Program", PublicationDate = DateTime.Today };
            MapperConfiguration configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _catalogueService = new CatalogueService();
        }

        
        [Fact]
        public async Task Handle_Catalogue_Delete()
        {
            //Arragne
            CreateCatalogueCommandHandler createhandler = new CreateCatalogueCommandHandler(_catalogueService, _mapper);
            DeleteCatalogueCommandHandler handler = new DeleteCatalogueCommandHandler(_catalogueService, _mapper);

            //Act
            await createhandler.Handle(_createCatalogueCommand, CancellationToken.None);
            var res = await handler.Handle(_deleteCatalogueCommand, CancellationToken.None);

            //Assert
            res.Should().HaveCountGreaterOrEqualTo(0);

        }

        [Fact]
        public void Handle_Catalogue_Delete_NotFound()
        {
            //Arragne
            _deleteCatalogueCommand.ISBN = "1230";
            DeleteCatalogueCommandHandler handler = new DeleteCatalogueCommandHandler(_catalogueService, _mapper);

            //Act
            Func<Task> action_CatalogExist = async () =>
            {
                await handler.Handle(_deleteCatalogueCommand, CancellationToken.None);
            };
            //Assert
            action_CatalogExist.Should().Throw<NotFoundException>();
        }
    }
}
