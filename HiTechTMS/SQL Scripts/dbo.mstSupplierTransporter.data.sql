CREATE TABLE [dbo].[mstSupplierTransporter] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [SupplierCode] VARCHAR (5)      NOT NULL,
    [SupplierName] VARCHAR (25)     NULL,
    [Address1]     VARCHAR (25)     NULL,
    [Address2]     VARCHAR (25)     NULL,
    [Address3]     VARCHAR (25)     NULL,
    [Phone]        VARCHAR (20)     NULL,
    [Fax]          VARCHAR (20)     NULL,
    [Email]        VARCHAR (40)     NULL,
    [IsSuplier]    CHAR (1)         NOT NULL,
    CONSTRAINT [PK_mstSupplierTransporter] PRIMARY KEY CLUSTERED ([IsSuplier] ASC, [SupplierCode] ASC)
);


Go;

INSERT INTO [dbo].[mstSupplierTransporter] ([Id], [SupplierCode], [SupplierName], [Address1], [Address2], [Address3], [Phone], [Fax], [Email], [IsSuplier]) VALUES (N'94a156e0-bea6-4246-9d56-372103caceab', N'1234', N'Test01', N'', N'', N'', N'', N'', N'', N'2')
INSERT INTO [dbo].[mstSupplierTransporter] ([Id], [SupplierCode], [SupplierName], [Address1], [Address2], [Address3], [Phone], [Fax], [Email], [IsSuplier]) VALUES (N'c1c7ec36-3cf4-49ad-86be-b181d55612c0', N'4321', N'Test02', N'', N'', N'', N'', N'', N'', N'3')
