/****** Script for SelectTopNRows command from SSMS  ******/
SELECT *
  FROM [Guestlogix].[dbo].[airports] where Latitute like '%B%'

 update airports
  set Latitute = '59.89580154',
  Longitude='10.6171999'
  where ID=3192

    update airports
  set Latitute = '30.526331228',
  Longitude='-91.1499994'
  where ID=2782



