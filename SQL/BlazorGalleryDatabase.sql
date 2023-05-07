/****** Object:  Table [dbo].[Folder]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folder](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
	[Selected] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Folder] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FolderId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[FullPath] [nvarchar](255) NOT NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[EmailAddress] [nvarchar](80) NOT NULL,
	[EmailVerified] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Folder_Delete]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Folder_Delete]

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
GO
/****** Object:  StoredProcedure [dbo].[Folder_FetchAll]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Folder_FetchAll]

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
GO
/****** Object:  StoredProcedure [dbo].[Folder_Find]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Folder_Find]

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
GO
/****** Object:  StoredProcedure [dbo].[Folder_Insert]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Folder_Insert]

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
GO
/****** Object:  StoredProcedure [dbo].[Folder_Update]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Folder_Update]

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
GO
/****** Object:  StoredProcedure [dbo].[Image_Delete]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Delete]

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
GO
/****** Object:  StoredProcedure [dbo].[Image_FetchAll]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_FetchAll]

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
GO
/****** Object:  StoredProcedure [dbo].[Image_Find]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Find]

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
GO
/****** Object:  StoredProcedure [dbo].[Image_Insert]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Insert]

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
GO
/****** Object:  StoredProcedure [dbo].[Image_Update]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Update]

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
GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Delete]

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
GO
/****** Object:  StoredProcedure [dbo].[User_FetchAll]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_FetchAll]

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

GO
/****** Object:  StoredProcedure [dbo].[User_Find]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Find]

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
GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Insert]

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
GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 5/7/2023 10:56:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Update]

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
GO
