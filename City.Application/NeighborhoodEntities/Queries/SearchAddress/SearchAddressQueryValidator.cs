﻿using FluentValidation;

namespace City.Application.NeighborhoodEntities.Queries.SearchAddress
{
    public class SearchAddressQueryValidator : AbstractValidator<SearchAddressQuery>
    {
        public SearchAddressQueryValidator()
        {
            RuleFor(s => s).Must(s => !string.IsNullOrEmpty(s.Name) || !string.IsNullOrEmpty(s.PostalCode));
        }
    }
}
