Declare @MaxFolderCount int
Declare @MaxStoragePlanFree int
Declare @MaxImagesPerFolder int

Set @MaxFolderCount = 5
Set @MaxStoragePlanFree = 100
Set @MaxImagesPerFolder = 20

Exec Admin_Insert @MaxFolderCount, @MaxImagesPerFolder, @MaxStoragePlanFree

