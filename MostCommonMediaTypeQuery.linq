<Query Kind="Expression">
  <Connection>
    <ID>7c278a02-ad9c-42bc-92e0-c420b63136a0</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

from x in MediaTypes
where x.Tracks.Count() >= x.Tracks.Count()
select x.Name