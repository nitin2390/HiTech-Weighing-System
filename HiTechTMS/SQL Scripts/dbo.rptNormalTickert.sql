CREATE VIEW [dbo].[rptNormalTicket]
	AS 
	SELECT 
	isnull(cast(NM.ID as nvarchar(max)),'') ID,
	isnull(Nm.Truck,'') Truck,
	isnull(Nm.ProductCode,'') ProductCode,
	isnull(P.[Name],'') [Name],
	isnull(cast(S.SupplierCode as nvarchar(max)),'') SupplierCode,
	isnull(S.SupplierName,'') SupplierName,
	isnull(cast(T.SupplierCode as nvarchar(max)),'') TransporterCode,
	isnull(T.SupplierName,'') TarnsPorterName,
	isnull(Nm.ChallanNumber,'') ChallanNumber,
	isnull(Nm.Miscellaneous,'')Miscellaneous,
	isnull(NM.DeliveryNoteN,'') DeliveryNoteN,
	isnull(cast(NM.ChallanWeight as nvarchar(max)),'') ChallanWeight,
	isnull(cast(NM.ChallanDate as nvarchar(max)),'') ChallanDate,
	isnull(cast(Nm.DateIn as nvarchar(max)),'') DateIn,
	isnull(substring(cast(NM.TimeIn as nvarchar(max)),1,5),'') TimeIn,
	isnull(cast(Nm.DateOut as nvarchar(max)),'')DateOut,
	isnull(substring(cast(Nm.[TimeOut] as nvarchar(max)),1,5),'') [TimeOut],
	isnull(cast(Nm.TareWeight as nvarchar(max)),'') TareWeight,
	isnull(cast(Nm.NetWeight as nvarchar(max)),'') NetWeight,
	isnull(cast(Nm.GrossWeight as nvarchar(max)),'') GrossWeight,
	isnull(NM.ProdInOut,'') ProdInOut
	FROM dbo.transNormalWeight NM 
		left join dbo.Product P
		on P.Code = NM.ProductCode
		left Join dbo.mstSupplierTransporter S
		on S.Id = Nm.SupplierCode
		left Join dbo.mstSupplierTransporter T
		on T.Id = Nm.TransporterCode