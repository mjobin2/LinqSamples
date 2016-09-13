<Query Kind="Expression">
  <Connection>
    <ID>f4bd708b-2cbc-4f16-ab9c-e838c8df0241</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from x in Items
where x.CurrentPrice > 5.00m
select new {
		x.Description,
		x.Calories
}