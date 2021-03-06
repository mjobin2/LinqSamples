<Query Kind="Statements">
  <Connection>
    <ID>3add0e85-dd5c-4f31-bdb5-711903b7d7d9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var MostBillsSubquery = from x in Waiters
	//where x.Bills.Count() == (from y in Waiters
	//select y.Bills.Count ()).Max()
	select new{
				Waiter = x.FirstName + " " + x.LastName,
				BillCount = x.Bills.Count ()
	};
MostBillsSubquery.Dump();

//create a dataset which contains the summary bill info by waiter
var WaiterBills = from x in Waiters
				orderby x.LastName, x.FirstName
				select new {
				Name = x.LastName + ", " + x.FirstName,
				BillInfo = (from y in x.Bills
							where y.BillItems.Count () > 0
							select new{
									BillID = y.BillID,
									BillDate = y.BillDate,
									TableID = y.TableID,
									Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
										}
							)
						};
WaiterBills.Dump();