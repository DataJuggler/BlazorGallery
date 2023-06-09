USE [BlazorGallery]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 7/13/2023 3:54:49 AM ******/
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
	[FileSize] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[RelativePath] [nvarchar](128) NULL,
	[Likes] [int] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Folder]    Script Date: 7/13/2023 3:54:49 AM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[PasswordHash] [nvarchar](255) NOT NULL,
	[EmailAddress] [nvarchar](80) NOT NULL,
	[EmailVerified] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[TotalLogins] [int] NOT NULL,
	[Active] [bit] NOT NULL,
	[IsAdmin] [bit] NULL,
	[StorageUsed] [int] NULL,
	[AcceptedTermsOfServiceDate] [datetime] NULL,
	[ProfileVisibility] [int] NULL,
	[CodeEmailed] [int] NULL,
	[EmailedCodeDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[MainGalleryView]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [dbo].[MainGalleryView]
AS
SELECT i.Id as ImageId, i.UserId, i.FolderId, i.FullPath, i.Name AS ImageName, i.CreatedDate, i.RelativePath, i.Height, i.Width, i.Likes,           
		  Datediff(MINUTE, i.CreatedDate, getdate()) as MinutesOld, u.UserName,
		  f.Name as FolderName
FROM Image i
Inner Join [User] u on i.UserId = u.Id
Inner Join [Folder] f on f.Id = i.FolderId
Where u.ProfileVisibility = 1
          
GO
/****** Object:  Table [dbo].[ActivityLog]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActivityLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Activity] [nvarchar](40) NOT NULL,
	[Detail] [nvarchar](255) NOT NULL,
	[UserId] [int] NOT NULL,
	[FolderId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaxFolderCount] [int] NOT NULL,
	[MaxStoragePlanFree] [int] NOT NULL,
	[MaxImagesPerFolder] [int] NULL,
	[RequireEmailVerification] [bit] NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FolderId] [int] NOT NULL,
	[Error] [nvarchar](255) NOT NULL,
	[Message] [nvarchar](512) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FeedbackType] [int] NOT NULL,
	[Details] [nvarchar](512) NOT NULL,
	[PermissionToEmail] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Responded] [bit] NOT NULL,
	[RespondedDate] [datetime] NOT NULL,
	[RespondedById] [int] NOT NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackReply]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackReply](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReplyFeedbackId] [int] NOT NULL,
	[RepliedById] [int] NOT NULL,
	[RepliedDate] [datetime] NOT NULL,
	[Response] [nvarchar](512) NOT NULL,
	[IsPublic] [bit] NOT NULL,
	[LikesCount] [int] NOT NULL,
 CONSTRAINT [PK_FeedbackReply] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageLike]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageLike](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GalleryOwnerId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_ImageLike] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [uc_ImageLike] UNIQUE NONCLUSTERED 
(
	[ImageId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ActivityLog_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ActivityLog_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [ActivityLog]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ActivityLog_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ActivityLog_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Activity],[CreatedDate],[Detail],[FolderId],[Id],[UserId]

    -- From tableName
    From [ActivityLog]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ActivityLog_FetchAllForActivityAndUserId]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ActivityLog_FetchAllForActivityAndUserId]

    -- Create @Activity Paramater
    @Activity nvarchar(40),


    -- Create @UserId Paramater
    @UserId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Activity],[CreatedDate],[Detail],[FolderId],[Id],[UserId]

    -- From tableName
    From [ActivityLog]

    -- Load Matching Records
    Where [Activity] = @Activity And [UserId] = @UserId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ActivityLog_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ActivityLog_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Activity],[CreatedDate],[Detail],[FolderId],[Id],[UserId]

    -- From tableName
    From [ActivityLog]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ActivityLog_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ActivityLog_Insert]

    -- Add the parameters for the stored procedure here
    @Activity nvarchar(40),
    @CreatedDate datetime,
    @Detail nvarchar(255),
    @FolderId int,
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [ActivityLog]
    ([Activity],[CreatedDate],[Detail],[FolderId],[UserId])

    -- Begin Values List
    Values(@Activity, @CreatedDate, @Detail, @FolderId, @UserId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ActivityLog_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ActivityLog_Update]

    -- Add the parameters for the stored procedure here
    @Activity nvarchar(40),
    @CreatedDate datetime,
    @Detail nvarchar(255),
    @FolderId int,
    @Id int,
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [ActivityLog]

    -- Update Each field
    Set [Activity] = @Activity,
    [CreatedDate] = @CreatedDate,
    [Detail] = @Detail,
    [FolderId] = @FolderId,
    [UserId] = @UserId

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Delete]

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
GO
/****** Object:  StoredProcedure [dbo].[Admin_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[MaxFolderCount],[MaxImagesPerFolder],[MaxStoragePlanFree],[RequireEmailVerification]

    -- From tableName
    From [Admin]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[MaxFolderCount],[MaxImagesPerFolder],[MaxStoragePlanFree],[RequireEmailVerification]

    -- From tableName
    From [Admin]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Insert]

    -- Add the parameters for the stored procedure here
    @MaxFolderCount int,
    @MaxImagesPerFolder int,
    @MaxStoragePlanFree int,
    @RequireEmailVerification bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Admin]
    ([MaxFolderCount],[MaxImagesPerFolder],[MaxStoragePlanFree],[RequireEmailVerification])

    -- Begin Values List
    Values(@MaxFolderCount, @MaxImagesPerFolder, @MaxStoragePlanFree, @RequireEmailVerification)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Admin_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Admin_Update]

    -- Add the parameters for the stored procedure here
    @Id int,
    @MaxFolderCount int,
    @MaxImagesPerFolder int,
    @MaxStoragePlanFree int,
    @RequireEmailVerification bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Admin]

    -- Update Each field
    Set [MaxFolderCount] = @MaxFolderCount,
    [MaxImagesPerFolder] = @MaxImagesPerFolder,
    [MaxStoragePlanFree] = @MaxStoragePlanFree,
    [RequireEmailVerification] = @RequireEmailVerification

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ErrorLog_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ErrorLog_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [ErrorLog]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ErrorLog_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ErrorLog_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[Error],[FolderId],[Id],[Message],[UserId]

    -- From tableName
    From [ErrorLog]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ErrorLog_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ErrorLog_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[Error],[FolderId],[Id],[Message],[UserId]

    -- From tableName
    From [ErrorLog]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ErrorLog_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ErrorLog_Insert]

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @Error nvarchar(255),
    @FolderId int,
    @Message nvarchar(512),
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [ErrorLog]
    ([CreatedDate],[Error],[FolderId],[Message],[UserId])

    -- Begin Values List
    Values(@CreatedDate, @Error, @FolderId, @Message, @UserId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ErrorLog_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ErrorLog_Update]

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @Error nvarchar(255),
    @FolderId int,
    @Id int,
    @Message nvarchar(512),
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [ErrorLog]

    -- Update Each field
    Set [CreatedDate] = @CreatedDate,
    [Error] = @Error,
    [FolderId] = @FolderId,
    [Message] = @Message,
    [UserId] = @UserId

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Feedback_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Feedback_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Feedback]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Feedback_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Feedback_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[Details],[FeedbackType],[Id],[PermissionToEmail],[Responded],[RespondedById],[RespondedDate],[UserId]

    -- From tableName
    From [Feedback]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Feedback_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Feedback_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[Details],[FeedbackType],[Id],[PermissionToEmail],[Responded],[RespondedById],[RespondedDate],[UserId]

    -- From tableName
    From [Feedback]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Feedback_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Feedback_Insert]

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @Details nvarchar(512),
    @FeedbackType int,
    @PermissionToEmail bit,
    @Responded bit,
    @RespondedById int,
    @RespondedDate datetime,
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Feedback]
    ([CreatedDate],[Details],[FeedbackType],[PermissionToEmail],[Responded],[RespondedById],[RespondedDate],[UserId])

    -- Begin Values List
    Values(@CreatedDate, @Details, @FeedbackType, @PermissionToEmail, @Responded, @RespondedById, @RespondedDate, @UserId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Feedback_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Feedback_Update]

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @Details nvarchar(512),
    @FeedbackType int,
    @Id int,
    @PermissionToEmail bit,
    @Responded bit,
    @RespondedById int,
    @RespondedDate datetime,
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Feedback]

    -- Update Each field
    Set [CreatedDate] = @CreatedDate,
    [Details] = @Details,
    [FeedbackType] = @FeedbackType,
    [PermissionToEmail] = @PermissionToEmail,
    [Responded] = @Responded,
    [RespondedById] = @RespondedById,
    [RespondedDate] = @RespondedDate,
    [UserId] = @UserId

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[FeedbackReply_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[FeedbackReply_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [FeedbackReply]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[FeedbackReply_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[FeedbackReply_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[IsPublic],[LikesCount],[RepliedById],[RepliedDate],[ReplyFeedbackId],[Response]

    -- From tableName
    From [FeedbackReply]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[FeedbackReply_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[FeedbackReply_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Id],[IsPublic],[LikesCount],[RepliedById],[RepliedDate],[ReplyFeedbackId],[Response]

    -- From tableName
    From [FeedbackReply]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[FeedbackReply_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[FeedbackReply_Insert]

    -- Add the parameters for the stored procedure here
    @IsPublic bit,
    @LikesCount int,
    @RepliedById int,
    @RepliedDate datetime,
    @ReplyFeedbackId int,
    @Response nvarchar(512)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [FeedbackReply]
    ([IsPublic],[LikesCount],[RepliedById],[RepliedDate],[ReplyFeedbackId],[Response])

    -- Begin Values List
    Values(@IsPublic, @LikesCount, @RepliedById, @RepliedDate, @ReplyFeedbackId, @Response)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[FeedbackReply_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[FeedbackReply_Update]

    -- Add the parameters for the stored procedure here
    @Id int,
    @IsPublic bit,
    @LikesCount int,
    @RepliedById int,
    @RepliedDate datetime,
    @ReplyFeedbackId int,
    @Response nvarchar(512)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [FeedbackReply]

    -- Update Each field
    Set [IsPublic] = @IsPublic,
    [LikesCount] = @LikesCount,
    [RepliedById] = @RepliedById,
    [RepliedDate] = @RepliedDate,
    [ReplyFeedbackId] = @ReplyFeedbackId,
    [Response] = @Response

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Folder_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Folder_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Folder_FetchAllForUserId]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Folder_FetchAllForUserId]

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

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Folder_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Folder_FindByUserIdAndName]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Folder_FindByUserIdAndName]

    -- Create @Name Paramater
    @Name nvarchar(40),


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

    -- Find Matching Record
    Where [Name] = @Name And [UserId] = @UserId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Folder_FindSelectedFolder]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Folder_FindSelectedFolder]

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

    -- Find Matching Record
    Where [UserId] = @UserId And Selected = 1

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Folder_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Folder_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Image_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
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
/****** Object:  StoredProcedure [dbo].[Image_DeleteByFolderId]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Image_DeleteByFolderId]

    -- Create @FolderId Paramater
    @FolderId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Image]

    -- Write Where Clause
    Where [FolderId] = @FolderId

END
GO
/****** Object:  StoredProcedure [dbo].[Image_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
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
    Select [CreatedDate],[FileSize],[FolderId],[FullPath],[Height],[Id],[Likes],[Name],[RelativePath],[UserId],[Width]

    -- From tableName
    From [Image]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_FetchAllForFolderId]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_FetchAllForFolderId]

    -- Create @FolderId Paramater
    @FolderId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[FileSize],[FolderId],[FullPath],[Height],[Id],[Likes],[Name],[RelativePath],[UserId],[Width]

    -- From tableName
    From [Image]

    -- Load Matching Records
    Where [FolderId] = @FolderId

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

GO
/****** Object:  StoredProcedure [dbo].[Image_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
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
    Select [CreatedDate],[FileSize],[FolderId],[FullPath],[Height],[Id],[Likes],[Name],[RelativePath],[UserId],[Width]

    -- From tableName
    From [Image]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Insert]

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @FileSize int,
    @FolderId int,
    @FullPath nvarchar(255),
    @Height int,
    @Likes int,
    @Name nvarchar(50),
    @RelativePath nvarchar(128),
    @UserId int,
    @Width int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Image]
    ([CreatedDate],[FileSize],[FolderId],[FullPath],[Height],[Likes],[Name],[RelativePath],[UserId],[Width])

    -- Begin Values List
    Values(@CreatedDate, @FileSize, @FolderId, @FullPath, @Height, @Likes, @Name, @RelativePath, @UserId, @Width)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[Image_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Image_Update]

    -- Add the parameters for the stored procedure here
    @CreatedDate datetime,
    @FileSize int,
    @FolderId int,
    @FullPath nvarchar(255),
    @Height int,
    @Id int,
    @Likes int,
    @Name nvarchar(50),
    @RelativePath nvarchar(128),
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
    [Likes] = @Likes,
    [Name] = @Name,
    [RelativePath] = @RelativePath,
    [UserId] = @UserId,
    [Width] = @Width

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageLike_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ImageLike_Delete]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [ImageLike]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageLike_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ImageLike_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [GalleryOwnerId],[Id],[ImageId],[UserId]

    -- From tableName
    From [ImageLike]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageLike_FetchAllForGalleryOwnerIdAndUserId]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ImageLike_FetchAllForGalleryOwnerIdAndUserId]

    -- Create @GalleryOwnerId Paramater
    @GalleryOwnerId int,


    -- Create @UserId Paramater
    @UserId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [GalleryOwnerId],[Id],[ImageId],[UserId]

    -- From tableName
    From [ImageLike]

    -- Load Matching Records
    Where [GalleryOwnerId] = @GalleryOwnerId And [UserId] = @UserId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageLike_FetchAllInMainGalleryForUserId]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ImageLike_FetchAllInMainGalleryForUserId]

    -- Create @UserId Paramater
    @UserId int


AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [GalleryOwnerId],[Id],[ImageId],[UserId]

    -- From tableName
    From [ImageLike]

    -- Load Matching Records
    Where [UserId] = @UserId

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageLike_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ImageLike_Find]

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [GalleryOwnerId],[Id],[ImageId],[UserId]

    -- From tableName
    From [ImageLike]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageLike_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ImageLike_Insert]

    -- Add the parameters for the stored procedure here
    @GalleryOwnerId int,
    @ImageId int,
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [ImageLike]
    ([GalleryOwnerId],[ImageId],[UserId])

    -- Begin Values List
    Values(@GalleryOwnerId, @ImageId, @UserId)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[ImageLike_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[ImageLike_Update]

    -- Add the parameters for the stored procedure here
    @GalleryOwnerId int,
    @Id int,
    @ImageId int,
    @UserId int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [ImageLike]

    -- Update Each field
    Set [GalleryOwnerId] = @GalleryOwnerId,
    [ImageId] = @ImageId,
    [UserId] = @UserId

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[MainGalleryView_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[MainGalleryView_FetchAll]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CreatedDate],[FolderId],[FolderName],[FullPath],[Height],[ImageId],[ImageName],[Likes],[MinutesOld],[RelativePath],[UserId],[UserName],[Width]

    -- From tableName
    From [MainGalleryView]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[MainGalleryView_FetchMostRecent]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[MainGalleryView_FetchMostRecent]

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement    	
	Select Top 20 [CreatedDate],[FolderId],[FolderName],[FullPath],[Height],[ImageId],[ImageName],[Likes],[MinutesOld],[RelativePath],[UserId],[UserName],[Width]

    -- From tableName
    From [MainGalleryView]

	-- Order By 
	Order By MinutesOld

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[UpdateProcPermissions]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateProcPermissions]

	-- parameter for the procedure
	@UserName as varchar(50)

AS

declare @sql as varchar(250)

declare @procName as varchar(100)

DECLARE cursorSP CURSOR FOR

	select name from sysobjects where xtype='P' AND category!=2
		And Name Not Like '%dss%'
		Order By Name

	OPEN cursorSP 

		FETCH NEXT FROM CursorSP

			INTO @procName

			WHILE @@FETCH_STATUS = 0

			BEGIN
     
				set @sql = 'GRANT EXECUTE ON [dbo].[' + @procName + '] TO [' + @UserName + ']'
		
				exec (@sql)
		
				FETCH NEXT FROM CursorSP
			  
				INTO @procName
				
				

			END
			
			close CursorSP

			Deallocate CursorSP


GO
/****** Object:  StoredProcedure [dbo].[User_Delete]    Script Date: 7/13/2023 3:54:49 AM ******/
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
/****** Object:  StoredProcedure [dbo].[User_FetchAll]    Script Date: 7/13/2023 3:54:49 AM ******/
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
    Select [AcceptedTermsOfServiceDate],[Active],[CodeEmailed],[CreatedDate],[EmailAddress],[EmailedCodeDate],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[ProfileVisibility],[StorageUsed],[TotalLogins],[UserName]

    -- From tableName
    From [User]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_Find]    Script Date: 7/13/2023 3:54:49 AM ******/
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
    Select [AcceptedTermsOfServiceDate],[Active],[CodeEmailed],[CreatedDate],[EmailAddress],[EmailedCodeDate],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[ProfileVisibility],[StorageUsed],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_FindByEmailAddress]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_FindByEmailAddress]

    -- Create @EmailAddress Paramater
    @EmailAddress nvarchar(80)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AcceptedTermsOfServiceDate],[Active],[CodeEmailed],[CreatedDate],[EmailAddress],[EmailedCodeDate],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[ProfileVisibility],[StorageUsed],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [EmailAddress] = @EmailAddress

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_FindByUserName]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_FindByUserName]

    -- Create @UserName Paramater
    @UserName nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [AcceptedTermsOfServiceDate],[Active],[CodeEmailed],[CreatedDate],[EmailAddress],[EmailedCodeDate],[EmailVerified],[Id],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[ProfileVisibility],[StorageUsed],[TotalLogins],[UserName]

    -- From tableName
    From [User]

    -- Find Matching Record
    Where [UserName] = @UserName

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_Insert]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Insert]

    -- Add the parameters for the stored procedure here
    @AcceptedTermsOfServiceDate datetime,
    @Active bit,
    @CodeEmailed int,
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @EmailedCodeDate datetime,
    @EmailVerified bit,
    @IsAdmin bit,
    @LastLoginDate datetime,
    @Name nvarchar(50),
    @PasswordHash nvarchar(255),
    @ProfileVisibility int,
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
    ([AcceptedTermsOfServiceDate],[Active],[CodeEmailed],[CreatedDate],[EmailAddress],[EmailedCodeDate],[EmailVerified],[IsAdmin],[LastLoginDate],[Name],[PasswordHash],[ProfileVisibility],[StorageUsed],[TotalLogins],[UserName])

    -- Begin Values List
    Values(@AcceptedTermsOfServiceDate, @Active, @CodeEmailed, @CreatedDate, @EmailAddress, @EmailedCodeDate, @EmailVerified, @IsAdmin, @LastLoginDate, @Name, @PasswordHash, @ProfileVisibility, @StorageUsed, @TotalLogins, @UserName)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[User_Update]    Script Date: 7/13/2023 3:54:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[User_Update]

    -- Add the parameters for the stored procedure here
    @AcceptedTermsOfServiceDate datetime,
    @Active bit,
    @CodeEmailed int,
    @CreatedDate datetime,
    @EmailAddress nvarchar(80),
    @EmailedCodeDate datetime,
    @EmailVerified bit,
    @Id int,
    @IsAdmin bit,
    @LastLoginDate datetime,
    @Name nvarchar(50),
    @PasswordHash nvarchar(255),
    @ProfileVisibility int,
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
    Set [AcceptedTermsOfServiceDate] = @AcceptedTermsOfServiceDate,
    [Active] = @Active,
    [CodeEmailed] = @CodeEmailed,
    [CreatedDate] = @CreatedDate,
    [EmailAddress] = @EmailAddress,
    [EmailedCodeDate] = @EmailedCodeDate,
    [EmailVerified] = @EmailVerified,
    [IsAdmin] = @IsAdmin,
    [LastLoginDate] = @LastLoginDate,
    [Name] = @Name,
    [PasswordHash] = @PasswordHash,
    [ProfileVisibility] = @ProfileVisibility,
    [StorageUsed] = @StorageUsed,
    [TotalLogins] = @TotalLogins,
    [UserName] = @UserName

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[52] 4[22] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Image"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 338
               Right = 254
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 6
               Left = 603
               Bottom = 358
               Right = 932
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Folder"
            Begin Extent = 
               Top = 153
               Left = 404
               Bottom = 366
               Right = 620
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2115
         Alias = 2205
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MainGalleryView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'MainGalleryView'
GO
