using Microsoft.EntityFrameworkCore;

namespace City.Application.Common.Models
{
	public class PaginatedList<T>
	{
		public List<T> Items { get; }
		public int PageNumber { get; }
        public int PageSize { get; }
		public PaginatedList(List<T> items, int pageNumber, int pageSize)
		{
			PageNumber = pageNumber;
            PageSize = pageSize;
			Items = items;
		}

		public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
		{			
			var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

			return new PaginatedList<T>(items, pageNumber, pageSize);
		}
	}
}
