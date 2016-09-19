<Query Kind="Statements">
  <Connection>
    <ID>fd148204-200a-4408-a9fb-f3e5f266aeca</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//when you need to use multiple steps 
//to solve a problem, switch your Language
//choice to either Statement(s) or Program

//the results of each query will now be saved in a variable
//the variable can then be used in future queries

var maxcount = (from x in MediaTypes
	select x.Tracks.Count ()).Max();
	
//to display the contents of a variable in LINQPad
//you use the method .Dump()
maxcount.Dump();

//use a value in a preceeding create variable
var popularMediaType = from x in MediaTypes
						where x.Tracks.Count() == maxcount
						select new{
								Type = x.Name,
								TCount = x.Tracks.Count ()
						};
popularMediaType.Dump();

//Can this set of statements be done as one complete query
//the answer is possibly, and in this case yes
//in this example maxcount could be exchanged for the query that
//	actually created the value in the first place
//	this substituted query is a subquery
var popularMediaTypeSubQuery = from x in MediaTypes
						where x.Tracks.Count() == (from y in MediaTypes
													select y.Tracks.Count ()).Max()
						select new{
								Type = x.Name,
								TCount = x.Tracks.Count ()
						};
popularMediaTypeSubQuery.Dump();

//using the method syntax to determine the count value for the where expression
//this demonstrates that queries can be constructed using both query syntax and method syntax


var popularMediaTypeSubMethod = from x in MediaTypes
						where x.Tracks.Count() == MediaTypes.Select (mt => mt.Tracks.Count ()) .Max ()
						select new{
								Type = x.Name,
								TCount = x.Tracks.Count ()
						};
popularMediaTypeSubMethod.Dump();

