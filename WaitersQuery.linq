<Query Kind="Statements">
  <Connection>
    <ID>f4bd708b-2cbc-4f16-ab9c-e838c8df0241</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//Waiters
var results = from x in Waiters
where x.FirstName.Contains("a")
orderby x.LastName
select x.LastName + ", " + x.FirstName;
results.Dump();


