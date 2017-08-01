CREATE VIEW [dbo].[V_T_mstShiftAllocationInfo]
	AS SELECT  [Id],          
			   [mstShiftsID], 
			   [StartTime],  
			   [EndTime]    
			FROM [mstShiftAllocationInfo]