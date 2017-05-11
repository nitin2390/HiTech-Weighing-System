CREATE VIEW [dbo].[viewMultiPendingFile]
	AS 
	SELECT 
		MW.[ID]                ,
		isnull([Mode],0) as [Mode]          ,
		isnull([Truck],'') as [Truck],
		isnull(P.[Code],'')    as [ProductCode],
		isnull(P.[Name],'')    as [ProductName],
		isnull(S.[SupplierName],'')    as [SupplierName]  ,
		isnull(T.SupplierName,'') as [TransporterCode]   ,
		isnull([ChallanNumber],'')  as [ChallanNumber]   ,
		isnull([ChallanDate],'')     as [ChallanDate]  ,
		isnull([ChallanWeight],0)   as [ChallanWeight]  ,
		isnull([ChallanWeightUnit],'') as [ChallanWeightUnit],
		isnull([Miscellaneous],'')  as [Miscellaneous]   ,
		isnull([DeliveryNoteN],'')   as [DeliveryNoteN]  ,
		isnull([DateIn],'')  as [DateIn]  ,
		isnull([DateOut],'')  as [DateOut]  ,
		isnull([TimeIn],'')  as [TimeIn],
		isnull([TimeOut],'') as [TimeOut],
		isnull([TareWeight],0) as [TareWeight],
		isnull([GrossWeight],0) as [GrossWeight],
		MW.IsPending,
		isnull([NetWeight],0) as [NetWeight],
		case when [ProdInOut] = 0 then 'Product In' else 'Product Out' end  as ProdInOut      
	FROM dbo.[transMultiWeight] MW
		left join dbo.mstSupplierTransporter S
		on S.Id = MW.SupplierCode
		left join dbo.mstSupplierTransporter T
		on T.Id = MW.TransporterCode
		left join MultiPrdWeight MPW
		on MPW.TruckID = MW.ID
		left join dbo.Product P
		on MPW.UnloadedPrdCode = P.Code