Use City

/* 
Tema 4 Section 1
*/
Declare @PostalCode nvarchar(50) = '12346'

--Select information for block numbers, number of stairs number of appartments and address type (Market, Boulevard, Street) in a specific Postal Code
SELECT ne.[Type], ne.PostalCode, ne.Id, ne.[Name], bf.BlockNumber, count(bfs.Stair) as NumberOfStairs, Sum(bfs.NumberOfApartments) as NumberOfAppartments
from NeighborhoodEntities as ne 
	inner join Buildings as b on ne.Id = b.NeighborhoodEntityId
	inner join BlockOfFlats as bf on b.Id = bf.Id
	left outer join BlockOfFlatsStairs as bfs on bf.Id = bfs.BlockOfFlatsId
Where ne.PostalCode=@PostalCode
Group By ne.[Type], ne.PostalCode, ne.Id, ne.[Name], bf.BlockNumber
Order By ne.Id

-- select count of block of flats and count of houses in a specific Postal Code
SELECT ne.[Type], ne.PostalCode, ne.Id, ne.[Name], count(bf.Id) as NumberOfBlockOfFlats, count(h.Id) as NumberOfHouses
from NeighborhoodEntities as ne 
	inner join Buildings as b on ne.Id = b.NeighborhoodEntityId
	left outer join BlockOfFlats as bf on b.Id = bf.Id
	left outer join House as h on b.Id = h.Id
Where ne.PostalCode=@PostalCode
Group By ne.[Type], ne.PostalCode, ne.Id, ne.[Name]