namespace City.Domain.Common
{
	public static class ListExtensions
	{
		public static IReadOnlyCollection<TType> OfType<T, TType>(this List<T> list) 
			where T : class
			where TType: T  
		{ 
			var extendedList = list.OfType<TType>().ToList();
			return extendedList.AsReadOnly();		
		}
	}
}
