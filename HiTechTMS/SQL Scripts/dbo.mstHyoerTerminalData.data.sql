CREATE TABLE [dbo].[mstHyoerTerminalData] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [BaudRate]     INT              NOT NULL,
    [DataBits]     INT              NOT NULL,
    [ReadTimeout]  INT              NOT NULL,
    [WriteTimeout] INT              NOT NULL,
    [PortName]     NVARCHAR (50)    NOT NULL,
    [Handshake]    NVARCHAR (50)    NULL,
    [Name]         NVARCHAR (50)    NOT NULL,
    [DataReceived] NVARCHAR (50)    NULL,
    [sParity]      NVARCHAR (50)    NOT NULL,
    [iStopBits]    INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


Go;

INSERT INTO [dbo].[mstHyoerTerminalData] ([Id], [BaudRate], [DataBits], [ReadTimeout], [WriteTimeout], [PortName], [Handshake], [Name], [DataReceived], [sParity], [iStopBits]) VALUES (N'8d467d26-504f-432f-a700-27a7a94bfe19', 2400, 8, 2000, 2000, N'COM4', N'', N'user', N'', N'none', 1)
