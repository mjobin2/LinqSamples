<Query Kind="Expression">
  <Connection>
    <ID>cfbc01c3-b6e6-4e81-983c-2b8ae26210d0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//multiple column group
//grouping data placed in a local temp data set for further processing
//.Key allows you to have access to the value(s) in your group key(s)
//if you have multiple group columns they MUST be in an anonymous datatype
//to create a DTO type collection you can use.ToList() on the temp dataset
//you can have a custom anonymous datacollection by using a nested query

from food in Items
	group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	select new{
				MenuCategoryID = tempdataset.Key.MenuCategoryID,
				CurrentPrice = tempdataset.Key.CurrentPrice,
				FoodItems = from x in tempdataset
									select new {
												ItemID = x.ItemID,
												FoodDescription = x.Description
												TimesServed = x.BillItems.count()
									}
				}