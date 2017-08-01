CREATE TABLE [dbo].[mstShiftAllocationInfo] (
    [Id]         uniqueidentifier          NOT NULL,
    [mstShiftsID] uniqueidentifier NOT NULL,
    [StartTime]  TIME (7)     NOT NULL,
    [EndTime]    TIME (7)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

