CREATE TABLE [dbo].[EmailConfigs] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [EmailID]         NVARCHAR (400)   NOT NULL,
    [Password]        NVARCHAR (50)    NOT NULL,
    [EmailServerPort] INT              NOT NULL,
    [EmailSmtpServer] NVARCHAR (50)    NOT NULL,
    [IsActive]        CHAR (1)         NOT NULL,
    [EmailSubject]    NVARCHAR (MAX)   NOT NULL,
    [EmailBody]       NVARCHAR (MAX)   NOT NULL,
    [EmailRecipient]  NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_EmailConfigs] PRIMARY KEY CLUSTERED ([Id] ASC)
);


Go;

INSERT INTO [dbo].[EmailConfigs] 
([Id], [EmailID], [Password], [EmailServerPort], [EmailSmtpServer], [IsActive], [EmailSubject], [EmailBody], [EmailRecipient]) 
VALUES (N'668fd0c3-1cc5-412f-80cf-edac3c914836', N'nitin230790@gmail.com', 
N'jxWqUprBQjHTNhiE6inALFl3TJyus9EbfL8ycELfytM=', 587, 
N'smtp.gmail.com', N'1', N'HiTech Weighing Pvt. Ltd.', N'FYI
Regards
Nitin Gupta', N'nitin.gupta@nagarro.com')
