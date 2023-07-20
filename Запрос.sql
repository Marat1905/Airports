DECLARE @Latitude decimal(25,16) = 55.66552
DECLARE @Longitude decimal(25,16) = 37.729389
DECLARE @distance int = 10



SELECT * FROM (SELECT * ,(6371.0 * 2.0 * ASIN(SQRT(POWER(SIN(([LatitudeDeg] - ABS(CAST( @Latitude as DECIMAL(25,16)))) * PI() / 180 / 2), 2 ) + COS([LatitudeDeg] * PI() / 180) *
                COS(ABS(CAST( @Latitude as DECIMAL(25,16))) * PI() / 180) *
                POWER(SIN(([LongitudeDeg] - CAST(@Longitude as DECIMAL(25,16))) * PI() / 180 / 2),2)))) as distance
               FROM[dbo].[Airports] ) p where distance < @distance ORDER BY abs(distance), distance desc;

SELECT * FROM (SELECT * ,
                (6371.0 * 2.0 * ASIN( 
                 SQRT(
                 POWER(
                SIN(([LatitudeDeg] - ABS(@latitude)) * PI() / 180 / 2), 2 ) +
                COS([LatitudeDeg] * PI() / 180) *
                COS(ABS(@latitude) * PI() / 180) *
                POWER(SIN(([LongitudeDeg] - @longitude) * PI() / 180 / 2),2)))) as distance
                FROM[dbo].[Airports] ) p where distance < @distance ORDER BY abs(distance), distance desc