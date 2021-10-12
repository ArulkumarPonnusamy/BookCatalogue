using AutoMapper;
using BookCatalogueApi.Application.Catalogue.Commands.Create;
using BookCatalogueApi.Application.Catalogue.Commands.Delete;
using BookCatalogueApi.Application.Catalogue.Commands.Modify;
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

namespace BookCatalogueApi.Application.Test.Catalogue.Commands.Modify
{
    public class ModifyCatalogueCommandTest
    {
        private readonly IMapper _mapper;
        private readonly ICatalogueService _catalogueService;

        private readonly CreateCatalogueCommand _createCatalogueCommand;
        private readonly ModifyCatalogueCommand _ModifyCatalogueCommand;
        public ModifyCatalogueCommandTest()
        {
            _createCatalogueCommand = new CreateCatalogueCommand { Author = "Arul", ISBN = "1234567891233", Title = "Sample Program", PublicationDate = DateTime.Today };
            _ModifyCatalogueCommand = new ModifyCatalogueCommand { Author = "kumar", ISBN = "1234567891233", Title = "Sample Program", PublicationDate = DateTime.Today };
            MapperConfiguration configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _catalogueService = new CatalogueService();
        }


        [Fact]
        public async Task Handle_Catalogue_Modify()
        {
            //Arragne
            CreateCatalogueCommandHandler handlercreate = new CreateCatalogueCommandHandler(_catalogueService, _mapper);
            ModifyCatalogueCommandHandler handler = new ModifyCatalogueCommandHandler(_catalogueService, _mapper);

            //Act
            await handlercreate.Handle(_createCatalogueCommand, CancellationToken.None);
            var res = await handler.Handle(_ModifyCatalogueCommand, CancellationToken.None);

            //Assert
            res.FirstOrDefault(t => t.Author == "kumar").Should().NotBeNull();

        }

        [Fact]
        public void Handle_Catalogue_Modify_NotFound()
        {
            //Arragne
            _ModifyCatalogueCommand.ISBN = "12368";
            ModifyCatalogueCommandHandler handler = new ModifyCatalogueCommandHandler(_catalogueService, _mapper);

            //Act
            Func<Task> action_CatalogExist = async () =>
            {
                await handler.Handle(_ModifyCatalogueCommand, CancellationToken.None);
            };
            //Assert
            action_CatalogExist.Should().Throw<NotFoundException>();
        }
    }
}
