CREATE TABLE [dbo].[mstPermission] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [UserRoleID] UNIQUEIDENTIFIER NOT NULL,
    [FormNameID] UNIQUEIDENTIFIER NOT NULL,
    [IsGrant]    BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

Go;
