CREATE TABLE [dbo].[Product] (
    [Code] NVARCHAR (200) NOT NULL,
    [Name] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED ([Code] ASC)
);

CREATE TABLE [dbo].[UserRoleType] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [RoleName] NVARCHAR (100)   NOT NULL, 
    CONSTRAINT [PK_UserRoleType] PRIMARY KEY ([Id])
);



CREATE TABLE [dbo].[UserRole] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Code]         INT              NOT NULL,
    [Name]         NVARCHAR (100)   NULL,
    [Password]     NVARCHAR (100)   NOT NULL,
    [UserRoleType] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Code] ASC), 
    CONSTRAINT [FK_UserRole_ToUserRoleType] FOREIGN KEY ([UserRoleType]) REFERENCES [UserRoleType]([ID])
);


CREATE TABLE [dbo].[UserRole] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Code]         INT              NOT NULL,
    [Name]         NVARCHAR (100)   NULL,
    [Password]     NVARCHAR (100)   NOT NULL,
    [UserRoleType] UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY CLUSTERED ([Code] ASC)
);



--INSERT INTO [dbo].[UserRole] ([Id], [Code], [Name], [Password], [UserRoleType]) VALUES (N'72fc2fdc-248c-42e3-ab18-79ebd2b7e927', 1723, N'nitin2390', N'123456', N'2d44ee5e-2ba5-43db-9b3b-9e4073c4cb86')
--INSERT INTO [dbo].[UserRole] ([Id], [Code], [Name], [Password], [UserRoleType]) VALUES (N'b4d3c0d0-ecb0-454c-abd7-9d851468c61b', 4046, N'nitingupta', N'123456', N'6c468931-9f96-4631-94e7-9877b7bcd902')


--alter table UserRoleType add primary key (ID,RoleName)
--alter table UserRole Add foreign key  (UserRoleType) references UserRoleType(ID)

CREATE TABLE [dbo].[EmailMaster] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [EmailID]  NVARCHAR (400)   NOT NULL,
    [IsActive] CHAR (1)         NOT NULL,
    CONSTRAINT [PK_EmailMaster] PRIMARY KEY CLUSTERED ([EmailID] ASC)
);

INSERT INTO [dbo].[EmailMaster] ([Id], [EmailID], [IsActive]) VALUES (newid(), N'ndhsharma14@gmail.com', N'1')
INSERT INTO [dbo].[EmailMaster] ([Id], [EmailID], [IsActive]) VALUES (newid(), N'nitin2390@gmail.com', N'1')
INSERT INTO [dbo].[EmailMaster] ([Id], [EmailID], [IsActive]) VALUES (newid(), N'nitin2390@rediffmail.com', N'1')


CREATE TABLE [dbo].[EmailConfigs] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [EmailID]         NVARCHAR (400)   NOT NULL,
    [Password]        NVARCHAR (50)    NOT NULL,
    [EmailServerPort] INT              NOT NULL,
    [EmailSmtpServer] NVARCHAR (50)    NOT NULL,
    [IsActive]        CHAR (1)         NOT NULL,
    CONSTRAINT [PK_EmailConfigs] PRIMARY KEY CLUSTERED ([EmailID] ASC)
);




insert into EmailConfigs
select 
	newid(),
	'nitin230790@gmail.com',
	HASHBYTES('SHA2_512','1723Mind@1234'),587,'smtp.gmail.com',1
