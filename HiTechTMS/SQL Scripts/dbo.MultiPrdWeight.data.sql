CREATE TABLE [dbo].[MultiPrdWeight] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [TruckID]           UNIQUEIDENTIFIER NOT NULL,
    [UnloadedPrdCode]   NVARCHAR (5)     NULL,
    [UnloadedPrdWeight] DECIMAL (18)     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([TruckID]) REFERENCES [dbo].[transMultiWeight] ([ID])
);


Go;
