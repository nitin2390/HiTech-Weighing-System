CREATE TABLE [dbo].[transMultiWeight] (
    [ID]                UNIQUEIDENTIFIER NOT NULL,
    [Mode]              TINYINT          NOT NULL,
    [Truck]             NVARCHAR (12)    NOT NULL,
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
