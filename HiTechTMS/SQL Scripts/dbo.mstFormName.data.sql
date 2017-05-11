CREATE TABLE [dbo].[mstFormName] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [FormName] NVARCHAR (MAX)   NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

Go;
