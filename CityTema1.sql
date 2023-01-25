Use City

/* 
Tema 4 Section 1
*/
Declare @PostalCode nvarchar(50) = '12346'
Declare @Name nvarchar(50) = 'Lib'

--Selects information for block numbers, number of stairs, number of appartments and address type (Market, Boulevard, Street) in a specific Postal Code or address type
Select ne.[Type], ne.PostalCode, ne.Id, ne.[Name], bf.BlockNumber, count(bfs.Stair) as NumberOfStairs, Sum(bfs.NumberOfApartments) as NumberOfAppartments
From NeighborhoodEntities as ne
	inner join Buildings as b on ne.Id = b.NeighborhoodEntityId
	inner join BlockOfFlats as bf on b.Id = bf.Id
	left outer join BlockOfFlatsStairs as bfs on bf.Id = bfs.BlockOfFlatsId
Where ne.PostalCode=@PostalCode Or ne.[Name] LIKE Concat('%',@Name,'%')
Group By ne.[Type], ne.PostalCode, ne.Id, ne.[Name], bf.BlockNumber
Order By ne.PostalCode, ne.Id

-- select count of block of flats and count of houses in a specific Postal Code or address type
Select ne.[Type], ne.PostalCode, ne.Id, ne.[Name], count(bf.Id) as NumberOfBlockOfFlats, count(h.Id) as NumberOfHouses
From NeighborhoodEntities as ne 
	inner join Buildings as b on ne.Id = b.NeighborhoodEntityId
	left outer join BlockOfFlats as bf on b.Id = bf.Id
	left outer join House as h on b.Id = h.Id
Where ne.PostalCode=@PostalCode Or ne.[Name] LIKE Concat('%',@Name,'%')
Group By ne.[Type], ne.PostalCode, ne.Id, ne.[Name]

/* 
Tema 4 Section 2
*/
Select ne.Id, n.[Name] as Neighborhood, ne.[Type], ne.PostalCode, ne.[Name]
From NeighborhoodEntities as ne
	inner join Neighborhoods as n on n.Id = ne.NeighborhoodId
Order By Neighborhood, [Type], PostalCode, [Name]

/* 
Tema 4 Section 3
*/
Select n.[Name] as Neighborhood, ne.[Type], Count(ne.Id) as NumberOfAddressType
From Neighborhoods as n
	inner join NeighborhoodEntities as ne on n.Id = ne.NeighborhoodId
Group By n.[Name], ne.[Type]