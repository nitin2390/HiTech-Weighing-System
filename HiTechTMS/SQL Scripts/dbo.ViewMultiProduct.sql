CREATE VIEW [dbo].[ViewMultiProduct]
	AS 
	SELECT 
		MPW.Id, 
		MPW.TruckID ,
		MPW.UnloadedPrdCode as [ProductCode],
		P.Name as [ProductName],
		MPW.UnloadedPrdWeight as [Weight]
	FROM 
		MultiPrdWeight MPW
		left join Product P
		on MPW.UnloadedPrdCode = P.Code