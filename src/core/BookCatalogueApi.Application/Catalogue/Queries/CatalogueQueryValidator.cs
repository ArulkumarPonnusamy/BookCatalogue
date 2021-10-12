using BookCatalogueApi.Domain.Models;
using FluentValidation;
using System;

namespace BookCatalogueApi.Application.Catalogue.Query
{
    public class CatalogueQueryValidator : AbstractValidator<CatalogEntity>
    {
        public CatalogueQueryValidator()
        {
            RuleFor(ctlg => ctlg.Author)
             .NotNull()
             .NotEmpty()
             .WithMessage("{PropertyName} is required")
             .When(ctlg => !string.IsNullOrEmpty(ctlg.Author));

            RuleFor(ctlg => ctlg.Title)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} is required")
               .When(ctlg => !string.IsNullOrEmpty(ctlg.Title));

            RuleFor(ctlg => ctlg.ISBN)
               .NotNull()
               .NotEmpty()
               .WithMessage("{PropertyName} is required")
               .When(ctlg => !string.IsNullOrEmpty(ctlg.ISBN));

            RuleFor(ctlg => ctlg.PublicationDate)
             .NotNull()
             .NotEmpty()
             .WithMessage("{PropertyName} is required")
             .When(ctlg => ctlg.PublicationDate != DateTime.MinValue);
        }
    }
}