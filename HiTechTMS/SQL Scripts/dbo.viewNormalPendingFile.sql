CREATE VIEW [dbo].[viewNormalPendingFile]
	AS 
	SELECT 
		NW.[ID]                ,
		isnull([Mode],0) as [Mode]          ,
		isnull([Truck],'') as [Truck],
		isnull([ProductCode],'')    as [ProductCode]   ,
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
		NW.IsPending,
		isnull([NetWeight],0) as [NetWeight],
		case when [ProdInOut] = 0 then 'Product In' else 'Product Out' end  as ProdInOut      
	FROM dbo.[transNormalWeight] NW
		left join dbo.Product P
		on NW.ProductCode = P.Code
		left join dbo.mstSupplierTransporter S
		on S.Id = NW.SupplierCode
		left join dbo.mstSupplierTransporter T
		on T.Id = NW.TransporterCode