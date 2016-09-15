<Query Kind="Expression">
  <Connection>
    <ID>7c278a02-ad9c-42bc-92e0-c420b63136a0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//use of aggregates in queries
//Count() count the number of instances of the collection reference
//Sum() totals a specific field/expression, thus you will likely need ot use a delegate
//		to indicate the collection instance attribute to be used
//Average() averages a specific field/expression, thus you will likely need to use a delegate
//		to indicate the collection instance attribute to be used
from x in Albums
orderby x.Title
where x.Tracks.Count() > 0
select new {
				Title = x.Title,
				NumberOfTracks = x.Tracks.Count(),
				TotalAlbumPrice = x.Tracks.Sum(y => y.UnitPrice),
				AverageTrackLengthInSecondsA = (x.Tracks.Average(y => y.Milliseconds))/1000,
				AverageTrackLengthInSecondsB = x.Tracks.Average(y => y.Milliseconds/1000)
}