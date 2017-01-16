SELECT * FROM dbo.Maintenances M WHERE M.MaintenanceTypeId = 6

SELECT * FROM dbo.Maintenances m JOIN dbo.MaintenanceTypes mt 
ON m.MaintenanceTypeId = mt.MaintenanceTypeId
WHERE mt.MaintenanceDescription = 'Car'