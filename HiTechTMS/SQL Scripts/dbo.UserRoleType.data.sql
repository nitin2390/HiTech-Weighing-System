CREATE TABLE [dbo].[UserRoleType] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [RoleName] NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_UserRoleType] PRIMARY KEY CLUSTERED ([Id] ASC)
);


Go;

INSERT INTO [dbo].[UserRoleType] ([Id], [RoleName]) VALUES (N'5bd2e068-0e05-4b66-9ee5-4c0832c4d419', N'Supervisor')
INSERT INTO [dbo].[UserRoleType] ([Id], [RoleName]) VALUES (N'7d4a2f38-3bf3-4607-ac63-60273df5b53e', N'SuperAdmin')
INSERT INTO [dbo].[UserRoleType] ([Id], [RoleName]) VALUES (N'6c468931-9f96-4631-94e7-9877b7bcd902', N'Admin')
INSERT INTO [dbo].[UserRoleType] ([Id], [RoleName]) VALUES (N'2d44ee5e-2ba5-43db-9b3b-9e4073c4cb86', N'ApplicationUser')
