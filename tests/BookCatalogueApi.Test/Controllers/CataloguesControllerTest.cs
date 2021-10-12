using BookCatalogueApi.Application.Catalogue.Commands.Create;
using BookCatalogueApi.Application.Catalogue.Commands.Delete;
using BookCatalogueApi.Application.Catalogue.Commands.Modify;
using BookCatalogueApi.Application.Catalogue.Query;
using BookCatalogueApi.Controllers;
using BookCatalogueApi.Domain.Models;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BookCatalogueApi.Test.Controllers
{
    public class CataloguesControllerTest
    {
        [Fact]
        public void Catalogue_Create()
        {
            //Arrange
            Mock<IMediator> _mediator = new Mock<IMediator>();

            CataloguesController controller = new CataloguesController(_mediator.Object);
            CreateCatalogueCommand catalogcommand = new CreateCatalogueCommand { Author = "Vinoth", ISBN = "2234567891231", Title = "Sample Program", PublicationDate = DateTime.Today };

            //Act
            var response = controller.Create(catalogcommand, CancellationToken.None).Result as OkObjectResult;
            var CatalogList = response.Value.ToString();

            //Assert
            response.StatusCode.Should().Be(200);
            CatalogList.Should().BeEquivalentTo("{ Message = Catalogue Created Successfully }");
        }
        [Fact]
        public void Catalogue_Modify()
        {
            //Arrange
            Mock<IMediator> _mediator = new Mock<IMediator>();
            CataloguesController controller = new CataloguesController(_mediator.Object);
            CreateCatalogueCommand catalogcommandcreate = new CreateCatalogueCommand { Author = "Vinoth", ISBN = "2234567891231", Title = "Sample Program", PublicationDate = DateTime.Today };
            ModifyCatalogueCommand catalogcommand = new ModifyCatalogueCommand { Author = "Arul", ISBN = "2234567891231", Title = "Sample Program", PublicationDate = DateTime.Today };

            //Act
            var res = controller.Create(catalogcommandcreate, CancellationToken.None).Result as OkObjectResult;
            var response = controller.Update(catalogcommand.ISBN, catalogcommand, CancellationToken.None).Result as OkObjectResult;
            var CatalogList = response.Value.ToString();

            //Assert
            response.StatusCode.Should().Be(200);
            CatalogList.Should().BeEquivalentTo("{ Message = Catalogue Modified Successfully }");
        }
        [Fact]
        public void Catalogue_Remove()
        {
            //Arrange
            Mock<IMediator> _mediator = new Mock<IMediator>();
            CataloguesController controller = new CataloguesController(_mediator.Object);
            CreateCatalogueCommand catalogcommandcreate = new CreateCatalogueCommand { Author = "Vinoth", ISBN = "2234567891231", Title = "Sample Program", PublicationDate = DateTime.Today };
            DeleteCatalogueCommand catalogcommand = new DeleteCatalogueCommand { Author = "Arul", ISBN = "2234567891231", Title = "Sample Program", PublicationDate = DateTime.Today };

            //Act
            var res = controller.Create(catalogcommandcreate, CancellationToken.None).Result as OkObjectResult;
            var response = controller.Delete(catalogcommand.ISBN, CancellationToken.None).Result as OkObjectResult;
            var CatalogList = response.Value.ToString();

            //Assert
            response.StatusCode.Should().Be(200);
            CatalogList.Should().BeEquivalentTo("{ Message = Catalogue Deleted Successfully }");
        }
    }
}
