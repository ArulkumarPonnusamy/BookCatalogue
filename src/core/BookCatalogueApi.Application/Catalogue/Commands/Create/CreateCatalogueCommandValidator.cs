using BookCatalogueApi.Domain.Models;
using FluentValidation;
using System;

namespace BookCatalogueApi.Application.Catalogue.Commands.Create
{
    public class CreateCatalogueCommandValidator : AbstractValidator<CreateCatalogueCommand>
    {
        public CreateCatalogueCommandValidator()
        {
            RuleFor(ctlg => ctlg.Author)
              .NotNull()
              .NotEmpty()
              .WithMessage("{PropertyName} is required");

            RuleFor(ctlg => ctlg.Title)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} is required");

            RuleFor(ctlg => ctlg.ISBN)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} is required");

            RuleFor(ctlg => ctlg.ISBN).Length(13).WithMessage("{PropertyName} should be 13 digit");

            RuleFor(ctlg => ctlg.ISBN).Matches("^[0-9]+$").WithMessage("{PropertyName} should be number");

            RuleFor(ctlg => ctlg.PublicationDate)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .When(ctlg => ctlg.PublicationDate == DateTime.MinValue);
        }
    }
}