Use [BlazorGallery]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Admin_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Insert a new Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Insert >>>'

    End

GO

Create PROCEDURE Admin_Insert

    -- Add the parameters for the stored procedure here
    @MaxFolderCount int,
    @MaxStoragePlanFree int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Admin]
    ([MaxFolderCount],[MaxStoragePlanFree])

    -- Begin Values List
    Values(@MaxFolderCount, @MaxStoragePlanFree)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Admin_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Update an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Update >>>'

    End

GO

Create PROCEDURE Admin_Update

    -- Add the parameters for the stored procedure here
    @Id int,
    @MaxFolderCount int,
    @MaxStoragePlanFree int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Admin]

    -- Update Each field
    Set [MaxFolderCount] = @MaxFolderCount,
    [MaxStoragePlanFree] = @MaxStoragePlanFree

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Admin_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Find an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Find >>>'

    End

GO

Create PROCEDURE Admin_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[MaxFolderCount],[MaxStoragePlanFree]

    -- From tableName
    From [Admin]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Admin_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Delete an existing Admin
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_Delete >>>'

    End

GO

Create PROCEDURE Admin_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Admin]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Admin_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Returns all Admin objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Admin_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Admin_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Admin_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Admin_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Admin_FetchAll >>>'

    End

GO

Create PROCEDURE Admin_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[MaxFolderCount],[MaxStoragePlanFree]

    -- From tableName
    From [Admin]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Folder_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Insert a new Folder
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Folder_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Folder_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Folder_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Folder_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Folder_Insert >>>'

    End

GO

Create PROCEDURE Folder_Insert

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @Name nvarchar(40),
    @Selected bit,
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Folder]
    ([CreatedDate],[Name],[Selected],[UserId])

    -- Begin Values List
    Values(@CreatedDate, @Name, @Selected, @UserId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Folder_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Update an existing Folder
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Folder_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Folder_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Folder_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Folder_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Folder_Update >>>'

    End

GO

Create PROCEDURE Folder_Update

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @Id int,
    @Name nvarchar(40),
    @Selected bit,
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Folder]

    -- Update Each field
    Set [CreatedDate] = @CreatedDate,
    [Name] = @Name,
    [Selected] = @Selected,
    [UserId] = @UserId

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Folder_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Find an existing Folder
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Folder_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Folder_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Folder_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Folder_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Folder_Find >>>'

    End

GO

Create PROCEDURE Folder_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[Id],[Name],[Selected],[UserId]

    -- From tableName
    From [Folder]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Folder_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Delete an existing Folder
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Folder_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Folder_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Folder_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Folder_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Folder_Delete >>>'

    End

GO

Create PROCEDURE Folder_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Folder]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Folder_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Returns all Folder objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Folder_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Folder_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Folder_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Folder_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Folder_FetchAll >>>'

    End

GO

Create PROCEDURE Folder_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[Id],[Name],[Selected],[UserId]

    -- From tableName
    From [Folder]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Image_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Insert a new Image
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_Insert >>>'

    End

GO

Create PROCEDURE Image_Insert

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @FileSize int,
    @FolderId int,
    @FullPath nvarchar(255),
    @Height int,
    @Name nvarchar(50),
    @UserId int,
    @Width int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Image]
    ([CreatedDate],[FileSize],[FolderId],[FullPath],[Height],[Name],[UserId],[Width])

    -- Begin Values List
    Values(@CreatedDate, @FileSize, @FolderId, @FullPath, @Height, @Name, @UserId, @Width)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Image_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Update an existing Image
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_Update >>>'

    End

GO

Create PROCEDURE Image_Update

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @FileSize int,
    @FolderId int,
    @FullPath nvarchar(255),
    @Height int,
    @Id int,
    @Name nvarchar(50),
    @UserId int,
    @Width int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Image]

    -- Update Each field
    Set [CreatedDate] = @CreatedDate,
    [FileSize] = @FileSize,
    [FolderId] = @FolderId,
    [FullPath] = @FullPath,
    [Height] = @Height,
    [Name] = @Name,
    [UserId] = @UserId,
    [Width] = @Width

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Image_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Find an existing Image
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_Find >>>'

    End

GO

Create PROCEDURE Image_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[FileSize],[FolderId],[FullPath],[Height],[Id],[Name],[UserId],[Width]

    -- From tableName
    From [Image]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Image_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Delete an existing Image
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_Delete >>>'

    End

GO

Create PROCEDURE Image_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Image]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Image_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Returns all Image objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Image_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Image_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Image_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Image_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Image_FetchAll >>>'

    End

GO

Create PROCEDURE Image_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[FileSize],[FolderId],[FullPath],[Height],[Id],[Name],[UserId],[Width]

    -- From tableName
    From [Image]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Insert a new User
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_Insert >>>'

    End

GO

Create PROCEDURE User_Insert

    -- Add the parameters for the stored procedure here
    @Active bit,
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @EmailVerified bit,
    @IsAdmin bit,
    @LastLoginDate datetime,
    @Name nvarchar(50),
    @PasswordHash nvarchar(255),
    @StorageUsed int,
    @TotalLogins int,
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [User]
    ([Active],[CreatedDate],[EmailAddress],[EmailVerified],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[StorageUsed],[TotalLogins],[UserName])

    -- Begin Values List
    Values(@Active, @CreatedDate, @EmailAddress, @EmailVerified, @IsAdmin, @LastLoginDate, @Name, @PasswordHash, @StorageUsed, @TotalLogins, @UserName)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Update an existing User
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_Update >>>'

    End

GO

Create PROCEDURE User_Update

    -- Add the parameters for the stored procedure here
    @Active bit,
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @EmailVerified bit,
    @Id int,
    @IsAdmin bit,
    @LastLoginDate datetime,
    @Name nvarchar(50),
    @PasswordHash nvarchar(255),
    @StorageUsed int,
    @TotalLogins int,
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [User]

    -- Update Each field
    Set [Active] = @Active,
    [CreatedDate] = @CreatedDate,
    [EmailAddress] = @EmailAddress,
    [EmailVerified] = @EmailVerified,
    [IsAdmin] = @IsAdmin,
    [LastLoginDate] = @LastLoginDate,
    [Name] = @Name,
    [PasswordHash] = @PasswordHash,
    [StorageUsed] = @StorageUsed,
    [TotalLogins] = @TotalLogins,
    [UserName] = @UserName

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Find an existing User
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_Find >>>'

    End

GO

Create PROCEDURE User_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[StorageUsed],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Delete an existing User
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_Delete >>>'

    End

GO

Create PROCEDURE User_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [User]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Returns all User objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_FetchAll >>>'

    End

GO

Create PROCEDURE User_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[StorageUsed],[TotalLogins],[UserName]

    -- From tableName
    From [User]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_FindByEmailAddress
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Find an existing User for the EmailAddress given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_FindByEmailAddress'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_FindByEmailAddress

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_FindByEmailAddress') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_FindByEmailAddress >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_FindByEmailAddress >>>'

    End

GO

Create PROCEDURE User_FindByEmailAddress

    -- Create @EmailAddress Paramater
    @EmailAddress nvarchar(80)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[StorageUsed],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [EmailAddress] = @EmailAddress

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_FindByUserName
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Find an existing User for the UserName given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('User_FindByUserName'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure User_FindByUserName

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.User_FindByUserName') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure User_FindByUserName >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure User_FindByUserName >>>'

    End

GO

Create PROCEDURE User_FindByUserName

    -- Create @UserName Paramater
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[StorageUsed],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [UserName] = @UserName

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Folder_FetchAllForUserId
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/9/2023
-- Description:    Returns all Folder objects for the UserId given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Folder_FetchAllForUserId'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Folder_FetchAllForUserId

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Folder_FetchAllForUserId') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Folder_FetchAllForUserId >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Folder_FetchAllForUserId >>>'

    End

GO

Create PROCEDURE Folder_FetchAllForUserId

    -- Create @UserId Paramater
    @UserId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[Id],[Name],[Selected],[UserId]

    -- From tableName
    From [Folder]

    -- Load Matching Records
    Where [UserId] = @UserId

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

