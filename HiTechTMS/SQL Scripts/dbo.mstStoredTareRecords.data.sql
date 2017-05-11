CREATE TABLE [dbo].[mstStoredTareRecords] (
    [Id]                       UNIQUEIDENTIFIER NOT NULL,
    [Mode]                     TINYINT          NOT NULL,
    [Truck]                    VARCHAR (12)     NOT NULL,
    [TruckType]                NVARCHAR (20)    NOT NULL,
    [mstSupplierTransporterID] UNIQUEIDENTIFIER NOT NULL,
    [TareWeight]               DECIMAL (18)     NOT NULL,
    [DateIn]                   DATE             NOT NULL,
    [TimeIn]                   TIME (7)         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

Go;
