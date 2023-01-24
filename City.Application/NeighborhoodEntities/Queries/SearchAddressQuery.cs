﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using City.Application.Common.Interfaces;
using City.Application.Common.Mappings;
using City.Application.Common.Models;
using City.Domain.Entities.Buildings;
using City.Domain.Entities.NeighborhoodEntities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace City.Application.NeighborhoodEntities.Queries
{
	public record SearchAddressQuery : IRequest<PaginatedList<BlockOfFlatsAddressDto>>
	{
		public string? Name { get; set; }
		public string? PostalCode { get; set; }
		public int PageNumber { get; init; } = 1;
		public int PageSize { get; init; } = 10;
	}

	public class SearchAddressQueryHandler : IRequestHandler<SearchAddressQuery, PaginatedList<BlockOfFlatsAddressDto>>
	{
		private readonly ICityContext context;

		public SearchAddressQueryHandler(ICityContext context) 
		{
			this.context = context;
		}
		public async Task<PaginatedList<BlockOfFlatsAddressDto>> Handle(SearchAddressQuery request, CancellationToken cancellationToken)
		{
            PaginatedList<BlockOfFlatsAddressDto> results;

            if (string.IsNullOrEmpty(request.PostalCode))
            {
                results = await (from ne in context.NeighborhoodEntities
                                 join b in context.Buildings on ne.Id equals b.NeighborhoodEntity!.Id
                                 join bf in context.Buildings.OfType<BlockOfFlats>() on b.Id equals bf.Id into bfGroup
                                 from mbf in bfGroup.DefaultIfEmpty()
                                 join h in context.Buildings.OfType<House>() on b.Id equals h.Id into hGroup
                                 from mh in hGroup.DefaultIfEmpty()
                                 where ne.Name.Contains(request.Name!)
                                 group new { ne, mbf, mh } by new { NeighborhoodEntityType = EF.Property<NeighborhoodEntityType>(ne, "Type"), ne.PostalCode, ne.Id, ne.Name } into gr
                                 select new BlockOfFlatsAddressDto
                                 {
                                     Id = gr.Key.Id,
                                     Name = gr.Key.Name,
                                     PostalCode = gr.Key.PostalCode,
                                     NeighborhoodEntityType = gr.Key.NeighborhoodEntityType,
                                     BlockOfFlats = gr.Select(g =>
                                         new BlockOfFlatsDto
                                         {
                                             BlockNumber = g.mbf.BlockNumber,
                                             NumberOfStairs = g.mbf.BlockOfFlatsStairs.Count(),
                                             NumberOfAppartments = g.mbf.BlockOfFlatsStairs.Sum(s => s.NumberOfApartments)
                                         }).Where(v => v.BlockNumber != null).ToList(),

                                     NumberOfBlockOfFlats = gr.Select(g => g.mbf).Where(v => v.BlockNumber != null).Count(),
                                     NumberOfHouses = gr.Select(g => g.mh).Where(v => v.Name != null).Count(),
                                 }).PaginatedListAsync(request.PageNumber, request.PageSize);
            }
            else 
            {
                results = await (from ne in context.NeighborhoodEntities
                                 join b in context.Buildings on ne.Id equals b.NeighborhoodEntity!.Id
                                 join bf in context.Buildings.OfType<BlockOfFlats>() on b.Id equals bf.Id into bfGroup
                                 from mbf in bfGroup.DefaultIfEmpty()
                                 join h in context.Buildings.OfType<House>() on b.Id equals h.Id into hGroup
                                 from mh in hGroup.DefaultIfEmpty()
                                 where ne.PostalCode == request.PostalCode
                                 group new { ne, mbf, mh } by new { NeighborhoodEntityType = EF.Property<NeighborhoodEntityType>(ne, "Type"), ne.PostalCode, ne.Id, ne.Name } into gr
                                 select new BlockOfFlatsAddressDto
                                 {
                                     Id = gr.Key.Id,
                                     Name = gr.Key.Name,
                                     PostalCode = gr.Key.PostalCode,
                                     NeighborhoodEntityType = gr.Key.NeighborhoodEntityType,
                                     BlockOfFlats = gr.Select(g =>
                                         new BlockOfFlatsDto
                                         {
                                             BlockNumber = g.mbf.BlockNumber,
                                             NumberOfStairs = g.mbf.BlockOfFlatsStairs.Count(),
                                             NumberOfAppartments = g.mbf.BlockOfFlatsStairs.Sum(s => s.NumberOfApartments)
                                         }).Where(v => v.BlockNumber != null).ToList(),

                                     NumberOfBlockOfFlats = gr.Select(g => g.mbf).Where(v => v.BlockNumber != null).Count(),
                                     NumberOfHouses = gr.Select(g => g.mh).Where(v => v.Name != null).Count(),
                                 }).PaginatedListAsync(request.PageNumber, request.PageSize);
            }
            

            return results;
		}
	}
}
