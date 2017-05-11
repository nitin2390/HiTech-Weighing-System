CREATE TABLE [dbo].[Product] (
    [Code] NVARCHAR (5)  NOT NULL,
    [Name] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([Code] ASC)
);


Go;

INSERT INTO [dbo].[Product] ([Code], [Name]) VALUES (N'1', N'Prod-1')
INSERT INTO [dbo].[Product] ([Code], [Name]) VALUES (N'3', N'Prod-3')
INSERT INTO [dbo].[Product] ([Code], [Name]) VALUES (N'4', N'Prod-4')
