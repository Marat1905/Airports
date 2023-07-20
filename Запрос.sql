
DECLARE @Latitude FLOAT = 55.665520
DECLARE @Longitude FLOAT = 37.729389
DECLARE @distance FLOAT = 20

SELECT * FROM (SELECT * ,(6371.0 * 2.0 * ASIN(SQRT(POWER(SIN(([LatitudeDeg] - ABS(CAST(@Latitude as DECIMAL(25,16)))) * PI() / 180 / 2), 2 ) +COS([LatitudeDeg] * PI() / 180) *
                COS(ABS(CAST(@Latitude as DECIMAL(25,16))) * PI() / 180) *
                POWER(SIN(([LongitudeDeg] - CAST(@Longitude as DECIMAL(25,16))) * PI() / 180 / 2),2)))) as distance
               FROM[dbo].[Airports] ) p where distance < @distance ORDER BY abs(distance), distance desc