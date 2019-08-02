--exec [usp_routes_shortestpath]

alter procedure [usp_routes_shortestpath] 
 @x CHAR(5)= 'BRU',
  @y CHAR(5)= 'YYZ'
 AS
 begin
select distinct a.IATA3,a.Latitute,a.Longitude,r.Origin into #torigin
from airports a inner join routes r on a.IATA3 = r.Origin

select distinct a.IATA3,a.Latitute,a.Longitude,r.Destination into #tdestination
from airports a inner join routes r on a.IATA3 = r.Destination;


WITH cte
     AS (

	 
     SELECT CASE
                WHEN r.origin = @x
                THEN r.destination
                ELSE r.origin
            END destination,
          (select dbo.Distance(tor.Latitute,tor.Longitude,tdr.Latitute,tdr.Longitude)) as distance,
            CAST(RTRIM(CASE
                           WHEN r.origin = @x
                           THEN r.origin
                           ELSE r.destination
                       END) AS VARCHAR) AS rt
     FROM routes r
	 inner join #torigin tor on tor.Origin = r.Origin
	 inner join #tdestination tdr on tdr.Destination = r.Destination
     WHERE(r.origin = @x
           OR r.destination = @x)
     UNION ALL
     SELECT a.destination,
	  (select dbo.Distance(tor.Latitute,tor.Longitude,tdr.Latitute,tdr.Longitude))+b.distance distance,
          --  a.distance + b.distance distance,
            CAST(RTRIM(b.rt)+'-'+a.origin AS VARCHAR) rt
     FROM routes a
	 inner join #torigin tor on tor.Origin = a.Origin
	 inner join #tdestination tdr on tdr.Destination = a.Destination
          JOIN cte b ON a.origin = b.destination)
     SELECT id,
            destination,
           distance,
            RTRIM(rt)+'-'+RTRIM(@y)
     FROM
(
    SELECT ROW_NUMBER() OVER(ORDER BY destination) ID,
           *
    FROM cte
    WHERE destination = @y
) a
     WHERE a.ID = 1;

	 end