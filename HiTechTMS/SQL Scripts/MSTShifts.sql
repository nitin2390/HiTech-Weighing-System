CREATE TABLE [dbo].[mstShifts] (
    [id]         UNIQUEIDENTIFIER NOT NULL,
    [ShiftName]  NVARCHAR (200)   NULL,
    [ShiftValue] INT              NULL,
    CONSTRAINT [PK_MSTShifts] PRIMARY KEY CLUSTERED ([id] ASC)
);

insert into MSTShifts
select NEWID(),'One',1
Union
select NEWID(),'Two',2
Union
select NEWID(),'Three',3