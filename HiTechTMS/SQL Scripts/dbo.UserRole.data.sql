CREATE TABLE [dbo].[UserRole] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Code]         INT              NOT NULL,
    [Name]         NVARCHAR (100)   NOT NULL,
    [Password]     NVARCHAR (100)   NOT NULL,
    [UserRoleType] UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY ([UserRoleType]) REFERENCES [dbo].[UserRoleType] ([Id]),
    CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED ([Code] ASC, [Id] ASC)
);


Go;

INSERT INTO [dbo].[UserRole] ([Id], [Code], [Name], [Password], [UserRoleType]) VALUES (N'72fc2fdc-248c-42e3-ab18-79ebd2b7e927', 1723, N'nitin2390', N'fc0iUkg331qk3V8HY6MWvQ==', N'6c468931-9f96-4631-94e7-9877b7bcd902')
INSERT INTO [dbo].[UserRole] ([Id], [Code], [Name], [Password], [UserRoleType]) VALUES (N'b4d3c0d0-ecb0-454c-abd7-9d851468c61b', 4046, N'nitingupta', N'fc0iUkg331qk3V8HY6MWvQ==', N'7d4a2f38-3bf3-4607-ac63-60273df5b53e')
