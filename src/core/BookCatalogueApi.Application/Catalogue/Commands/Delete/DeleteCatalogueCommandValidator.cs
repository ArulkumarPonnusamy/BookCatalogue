using BookCatalogueApi.Domain.Models;
using FluentValidation;
using System;

namespace BookCatalogueApi.Application.Catalogue.Commands.Delete
{
    public class DeleteCatalogueCommandValidator : AbstractValidator<DeleteCatalogueCommand>
    {
        public DeleteCatalogueCommandValidator()
        {
            RuleFor(ctlg => ctlg.ISBN)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyName} is required");
        }
    }
}