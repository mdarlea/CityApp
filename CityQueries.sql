Use City

Declare @PostalCode nvarchar(50) = '12346'

SELECT ne.[Type], ne.PostalCode, ne.Id, ne.[Name], bf.BlockNumber, count(bfs.Stair) as NumberOfStairs, Sum(bfs.NumberOfApartments) as NumberOfAppartments
from NeighborhoodEntities as ne 
	inner join Buildings as b on ne.Id = b.NeighborhoodEntityId
	inner join BlockOfFlats as bf on b.Id = bf.Id
	left outer join BlockOfFlatsStairs as bfs on bf.Id = bfs.BlockOfFlatsId
--Where ne.PostalCode=@PostalCode
Group By ne.[Type], ne.PostalCode, ne.Id, ne.[Name], bf.BlockNumber
Order By ne.PostalCode, ne.Id

SELECT ne.[Type], ne.PostalCode, ne.Id, ne.[Name], count(bf.Id) as NumberOfBlockOfFlats, count(h.Id) as NumberOfHouses
from NeighborhoodEntities as ne 
	inner join Buildings as b on ne.Id = b.NeighborhoodEntityId
	left outer join BlockOfFlats as bf on b.Id = bf.Id
	left outer join House as h on b.Id = h.Id
Group By ne.[Type], ne.PostalCode, ne.Id, ne.[Name]


SELECT ne.[Type], ne.Id, ne.PostalCode, ne.[Name], h.[name], bf.BlockNumber, bfs.Stair, bfs.NumberOfApartments
from NeighborhoodEntities as ne 
	inner join Buildings as b on ne.Id = b.NeighborhoodEntityId
	left outer join House as h on b.Id = h.Id
	left outer join BlockOfFlats as bf on b.Id = bf.Id
	left outer join BlockOfFlatsStairs as bfs on bf.Id = bfs.BlockOfFlatsId
