CREATE TABLE [dbo].[transNormalWeight] (
    [ID]                UNIQUEIDENTIFIER NOT NULL,
    [Mode]              TINYINT          NOT NULL,
    [Truck]             NVARCHAR (12)    NOT NULL,
    [ProductCode]       NVARCHAR (5)     NULL,
    [SupplierCode]      UNIQUEIDENTIFIER NULL,
    [TransporterCode]   UNIQUEIDENTIFIER NULL,
    [ChallanNumber]     NVARCHAR (25)    NULL,
    [ChallanDate]       DATE             NULL,
    [ChallanWeight]     DECIMAL (18)     NULL,
    [ChallanWeightUnit] TINYINT          NULL,
    [Miscellaneous]     NVARCHAR (50)    NULL,
    [DeliveryNoteN]     NVARCHAR (25)    NULL,
    [DateIn]            DATE             NULL,
    [DateOut]           DATE             NULL,
    [TimeIn]            TIME (7)         NULL,
    [TimeOut]           TIME (7)         NULL,
    [TareWeight]        DECIMAL (18)     NULL,
    [GrossWeight]       DECIMAL (18)     NULL,
    [NetWeight]         DECIMAL (18)     NULL,
    [ProdInOut]         TINYINT          NOT NULL,
    [IsPending]         TINYINT          NOT NULL,
    [AddedDate]         DATETIME         NOT NULL,
    [UpdatedDate]       DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);


Go;

INSERT INTO [dbo].[transNormalWeight] ([ID], [Mode], [Truck], [ProductCode], [SupplierCode], [TransporterCode], [ChallanNumber], [ChallanDate], [ChallanWeight], [ChallanWeightUnit], [Miscellaneous], [DeliveryNoteN], [DateIn], [DateOut], [TimeIn], [TimeOut], [TareWeight], [GrossWeight], [NetWeight], [ProdInOut], [IsPending], [AddedDate], [UpdatedDate]) VALUES (N'84cc0a22-6bba-444e-a39f-19d1e3ab0cea', 0, N'Truck-PO', N'1', N'94a156e0-bea6-4246-9d56-372103caceab', N'c1c7ec36-3cf4-49ad-86be-b181d55612c0', N'321', N'2016-02-02', CAST(1234 AS Decimal(18, 0)), 0, N'eee;eee', N'eee', NULL, NULL, NULL, NULL, CAST(120 AS Decimal(18, 0)), NULL, NULL, 1, 0, N'2017-04-06 00:00:00', N'2017-04-06 00:00:00')
INSERT INTO [dbo].[transNormalWeight] ([ID], [Mode], [Truck], [ProductCode], [SupplierCode], [TransporterCode], [ChallanNumber], [ChallanDate], [ChallanWeight], [ChallanWeightUnit], [Miscellaneous], [DeliveryNoteN], [DateIn], [DateOut], [TimeIn], [TimeOut], [TareWeight], [GrossWeight], [NetWeight], [ProdInOut], [IsPending], [AddedDate], [UpdatedDate]) VALUES (N'8873d2b5-0392-4d75-9046-6abfb92e9483', 0, N'Test-Truck', N'1', N'94a156e0-bea6-4246-9d56-372103caceab', N'c1c7ec36-3cf4-49ad-86be-b181d55612c0', N'Test-Truck', N'2012-12-12', CAST(123 AS Decimal(18, 0)), 0, N'Test-Truck;Test-Truck', N'Test-Truck', NULL, N'2012-12-12', NULL, N'09:01:11', NULL, CAST(120 AS Decimal(18, 0)), NULL, 0, 0, N'2017-04-06 00:00:00', N'2017-04-06 00:00:00')
INSERT INTO [dbo].[transNormalWeight] ([ID], [Mode], [Truck], [ProductCode], [SupplierCode], [TransporterCode], [ChallanNumber], [ChallanDate], [ChallanWeight], [ChallanWeightUnit], [Miscellaneous], [DeliveryNoteN], [DateIn], [DateOut], [TimeIn], [TimeOut], [TareWeight], [GrossWeight], [NetWeight], [ProdInOut], [IsPending], [AddedDate], [UpdatedDate]) VALUES (N'1a9b5d74-16e8-4153-8a89-96b175d40cdb', 0, N'T-PO', N'1', N'94a156e0-bea6-4246-9d56-372103caceab', N'c1c7ec36-3cf4-49ad-86be-b181d55612c0', N'1234', N'2015-01-01', CAST(123 AS Decimal(18, 0)), 0, N'test;test', N'test', NULL, NULL, NULL, NULL, CAST(90 AS Decimal(18, 0)), NULL, NULL, 1, 0, N'2017-04-06 00:00:00', N'2017-04-06 00:00:00')
