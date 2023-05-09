Declare @MaxFolderCount int
Declare @MaxStoragePlanFree int

Set @MaxFolderCount = 5
Set @MaxStoragePlanFree = 100

Exec Admin_Insert @MaxFolderCount, @MaxStoragePlanFree