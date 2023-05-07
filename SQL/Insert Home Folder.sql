Declare @CreatedDate datetime
Declare @Name nvarchar(50)
Declare @UserId int
Declare @Selected bit

Set @CreatedDate = GETDATE()
Set @Name = 'Home'
Set @UserId = 1
Set @Selected = 1

Exec Folder_Insert @CreatedDate, @Name, @Selected, @UserId

-- Select * From Folder