using AutoMapper;
using BookCatalogueApi.Application.Catalogue.Commands.Create;
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

namespace BookCatalogueApi.Application.Test.Catalogue.Commands.Create
{
    public class CreateCatalogueCommandTest
    {
        private readonly IMapper _mapper;
        private readonly ICatalogueService _catalogueService;

        private readonly CreateCatalogueCommand _createCatalogueCommand;
        public CreateCatalogueCommandTest()
        {
            _createCatalogueCommand = new CreateCatalogueCommand { Author = "Arul", ISBN = "1234567891231", Title = "Sample Program", PublicationDate = DateTime.Today };

            MapperConfiguration configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _catalogueService = new CatalogueService();
        }

        [Fact]
        public async Task Handle_Catalogue_CreateCatalogue()
        {
            //Arragne
            CreateCatalogueCommandHandler handler = new CreateCatalogueCommandHandler(_catalogueService, _mapper);

            //Act
            var result = await handler.Handle(_createCatalogueCommand, CancellationToken.None);

            //Assert
            result.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        public void Handle_Catalogue_ExistError()
        {
            //Arragne
            CreateCatalogueCommandHandler handler = new CreateCatalogueCommandHandler(_catalogueService, _mapper);

            //Act
            Func<Task> action_CatalogExist1 = async () =>
            {
                await handler.Handle(_createCatalogueCommand, CancellationToken.None);
            };
            //Assert
            action_CatalogExist1.Should().Throw<ValidationException>();

        }

        [Fact]
        public void Handle_Catalogue_ISBN_Length()
        {
            //Arragne
            CreateCatalogueCommand _create = new CreateCatalogueCommand { Author = "Arul", ISBN = "1234", Title = "Sample Program", PublicationDate = DateTime.Today };

            //Act
            CreateCatalogueCommandValidator validations = new CreateCatalogueCommandValidator();
            var res = validations.Validate(_create);

            //Assert
            res.Errors.Should().HaveCount(1);
        }

        [Fact]
        public void Handle_Catalogue_NullValueCheck()
        {
            //Arragne
            _createCatalogueCommand.Author = null;
            _createCatalogueCommand.ISBN = null;
            _createCatalogueCommand.Title = null;

            //Act
            CreateCatalogueCommandValidator validations = new CreateCatalogueCommandValidator();
            var res = validations.Validate(_createCatalogueCommand);

            //Assert
            res.Errors.Should().HaveCount(6);
        }
    }
}
