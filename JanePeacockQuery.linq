<Query Kind="Expression">
  <Connection>
    <ID>7c278a02-ad9c-42bc-92e0-c420b63136a0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//sample for entity subset
//sample of entity navvigation from child to parent on Where
//reminder that code is C# and thus appropriate methods can be used .Equals()
from x in Customers
where x.SupportRepIdEmployee.FirstName.Equals("Jane") && x.SupportRepIdEmployee.LastName.Equals("Peacock")
select new{
			Name = x.LastName + ", " + x.FirstName,
			City = x.City,
			State = x.State,
			Phone = x.Phone,
			Email = x.Email
          }