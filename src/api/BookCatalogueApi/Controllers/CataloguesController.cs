using BookCatalogueApi.Application.Catalogue.Commands.Create;
using BookCatalogueApi.Application.Catalogue.Commands.Delete;
using BookCatalogueApi.Application.Catalogue.Commands.Modify;
using BookCatalogueApi.Application.Catalogue.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Controllers
{
    [ControllerName("catalogues")]
    public class CataloguesController : ApiControllerBase
    {
        private readonly IMediator Mediator;
        public CataloguesController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateCatalogueCommand createCatalogueCommand, CancellationToken cancellationToken)
        {
            await Mediator.Send(createCatalogueCommand, cancellationToken).ConfigureAwait(false);
            return Ok(new { Message = "Catalogue Creates Successfully" });
        }

        [HttpPut]
        [Route("{Isbn}")]
        public async Task<ActionResult> Update([FromRoute] string Isbn, [FromBody] ModifyCatalogueCommand modifyCatalogueCommand, CancellationToken cancellationToken)
        {
            modifyCatalogueCommand.ISBN = Isbn;
            await Mediator.Send(modifyCatalogueCommand, cancellationToken).ConfigureAwait(false);
            return Ok(new { Message = "Catalogue Modified Successfully" });
        }

        [HttpDelete]
        [Route("{Isbn}")]
        public async Task<ActionResult> Delete([FromRoute] string Isbn, CancellationToken cancellationToken)
        {
            var deleteCatalogueCommand = new DeleteCatalogueCommand();
            deleteCatalogueCommand.ISBN = Isbn;
            await Mediator.Send(deleteCatalogueCommand, cancellationToken).ConfigureAwait(false);
            return Ok(new { Message = "Catalogue Deleted Successfully" });
        }

        [HttpGet]
        public async Task<ActionResult> SearchAll(CancellationToken cancellationToken)
        {
            var catalogueQuery = new CatalogueQuery(null, null, null);
            var result = await Mediator.Send(catalogueQuery, cancellationToken).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [Route("{Isbn}")]
        public async Task<ActionResult> SearchByIsbn([FromRoute] string Isbn, CancellationToken cancellationToken)
        {
            var catalogueQuery = new CatalogueQuery(Isbn, null, null);
            var result = await Mediator.Send(catalogueQuery, cancellationToken).ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [Route("title/{Title}/author/{Author}")]
        public async Task<ActionResult> SearchByTitle([FromRoute] string Title, string Author, CancellationToken cancellationToken)
        {
            var catalogueQuery = new CatalogueQuery(null, Author, Title);
            var result = await Mediator.Send(catalogueQuery, cancellationToken).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
