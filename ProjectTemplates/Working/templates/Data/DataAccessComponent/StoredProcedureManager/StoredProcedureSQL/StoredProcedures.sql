Use [BlazorGallery]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Folder_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/7/2023
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
-- Create Date:   5/7/2023
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
-- Create Date:   5/7/2023
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
-- Create Date:   5/7/2023
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
-- Create Date:   5/7/2023
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
-- Create Date:   5/7/2023
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
    ([CreatedDate],[FolderId],[FullPath],[Height],[Name],[UserId],[Width])

    -- Begin Values List
    Values(@CreatedDate, @FolderId, @FullPath, @Height, @Name, @UserId, @Width)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Image_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/7/2023
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
-- Create Date:   5/7/2023
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
    Select [CreatedDate],[FolderId],[FullPath],[Height],[Id],[Name],[UserId],[Width]

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
-- Create Date:   5/7/2023
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
-- Create Date:   5/7/2023
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
    Select [CreatedDate],[FolderId],[FullPath],[Height],[Id],[Name],[UserId],[Width]

    -- From tableName
    From [Image]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/7/2023
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
    @Id int,
    @Name nvarchar(50),
    @PasswordHash nvarchar(255),
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [User]
    ([Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[Name],[PasswordHash],[UserName])

    -- Begin Values List
    Values(@Active, @CreatedDate, @EmailAddress, @EmailVerified, @Id, @Name, @PasswordHash, @UserName)

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: User_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   5/7/2023
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
    @Name nvarchar(50),
    @PasswordHash nvarchar(255),
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
    [Id] = @Id,
    [Name] = @Name,
    [PasswordHash] = @PasswordHash,
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
-- Create Date:   5/7/2023
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
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[Name],[PasswordHash],[UserName]

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
-- Create Date:   5/7/2023
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
-- Create Date:   5/7/2023
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
    Select [Active],[CreatedDate],[EmailAddress],[EmailVerified],[Id],[Name],[PasswordHash],[UserName]

    -- From tableName
    From [User]

END

-- Thank you for using DataTier.Net.

