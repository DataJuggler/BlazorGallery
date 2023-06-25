

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class MainGalleryView
    public partial class MainGalleryView
    {

        #region Private Variables
        private DateTime createdDate;
        private int folderId;
        private string folderName;
        private string fullPath;
        private int height;
        private int imageId;
        private string imageName;
        private int likes;
        private int minutesOld;
        private string relativePath;
        private int userId;
        private string userName;
        private int width;
        #endregion

        #region Methods


        #endregion

        #region Properties

            #region DateTime CreatedDate
            public DateTime CreatedDate
            {
                get
                {
                    return createdDate;
                }
                set
                {
                    createdDate = value;
                }
            }
            #endregion

            #region int FolderId
            public int FolderId
            {
                get
                {
                    return folderId;
                }
                set
                {
                    folderId = value;
                }
            }
            #endregion

            #region string FolderName
            public string FolderName
            {
                get
                {
                    return folderName;
                }
                set
                {
                    folderName = value;
                }
            }
            #endregion

            #region string FullPath
            public string FullPath
            {
                get
                {
                    return fullPath;
                }
                set
                {
                    fullPath = value;
                }
            }
            #endregion

            #region int Height
            public int Height
            {
                get
                {
                    return height;
                }
                set
                {
                    height = value;
                }
            }
            #endregion

            #region int ImageId
            public int ImageId
            {
                get
                {
                    return imageId;
                }
                set
                {
                    imageId = value;
                }
            }
            #endregion

            #region string ImageName
            public string ImageName
            {
                get
                {
                    return imageName;
                }
                set
                {
                    imageName = value;
                }
            }
            #endregion

            #region int Likes
            public int Likes
            {
                get
                {
                    return likes;
                }
                set
                {
                    likes = value;
                }
            }
            #endregion

            #region int MinutesOld
            public int MinutesOld
            {
                get
                {
                    return minutesOld;
                }
                set
                {
                    minutesOld = value;
                }
            }
            #endregion

            #region string RelativePath
            public string RelativePath
            {
                get
                {
                    return relativePath;
                }
                set
                {
                    relativePath = value;
                }
            }
            #endregion

            #region int UserId
            public int UserId
            {
                get
                {
                    return userId;
                }
                set
                {
                    userId = value;
                }
            }
            #endregion

            #region string UserName
            public string UserName
            {
                get
                {
                    return userName;
                }
                set
                {
                    userName = value;
                }
            }
            #endregion

            #region int Width
            public int Width
            {
                get
                {
                    return width;
                }
                set
                {
                    width = value;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
