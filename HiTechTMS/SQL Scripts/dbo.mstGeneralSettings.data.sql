CREATE TABLE [dbo].[mstGeneralSettings] (
    [Id]                 UNIQUEIDENTIFIER NOT NULL,
    [TransactionNo]      INT              NOT NULL,
    [Mode]               NVARCHAR (3)     NOT NULL,
    [MiniNetWeight]      DECIMAL (18)     NOT NULL,
    [StoreTare]          NVARCHAR (3)     NOT NULL,
    [FirstWeightTkt]     NVARCHAR (3)     NOT NULL,
    [TicketFormat]       NVARCHAR (3)     NOT NULL,
    [ReportFormat]       NVARCHAR (3)     NOT NULL,
    [TktRepPrintingMode] NVARCHAR (3)     NOT NULL,
    [HeaderBlankLine]    INT              NOT NULL,
    [FooterBlankLine]    INT              NOT NULL,
    [AddedDate]          DATETIME         NOT NULL,
    [UpdatedDate]        DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


Go;

INSERT INTO [dbo].[mstGeneralSettings] ([Id], [TransactionNo], [Mode], [MiniNetWeight], [StoreTare], [FirstWeightTkt], [TicketFormat], [ReportFormat], [TktRepPrintingMode], [HeaderBlankLine], [FooterBlankLine], [AddedDate], [UpdatedDate]) VALUES (N'09218352-3fdc-4930-a7d0-6a6d6ce20bb1', 1, N'0', CAST(10 AS Decimal(18, 0)), N'0', N'0', N'0', N'0', N'0', 2, 2, N'2017-05-07 14:25:14', N'2017-05-07 14:25:14')
