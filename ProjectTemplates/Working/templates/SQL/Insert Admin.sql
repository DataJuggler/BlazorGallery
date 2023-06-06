Declare @MaxFolderCount int
Declare @MaxStoragePlanFree int
Declare @MaxImagesPerFolder int
Declare @RequireEmailVerification bit

Set @MaxFolderCount = 5
Set @MaxStoragePlanFree = 100
Set @MaxImagesPerFolder = 20
Set @RequireEmailVerification = 0 -- Change to 1 if you are rolling out with email verification

Exec Admin_Insert @MaxFolderCount, @MaxImagesPerFolder, @MaxStoragePlanFree, @RequireEmailVerification

