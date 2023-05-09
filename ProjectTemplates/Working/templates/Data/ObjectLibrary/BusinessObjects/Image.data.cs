

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Image
    public partial class Image
    {

        #region Private Variables
        private DateTime createdDate;
        private int folderId;
        private string fullPath;
        private int height;
        private int id;
        private string name;
        private int userId;
        private int width;
        #endregion

        #region Methods

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.id = id;
            }
            #endregion

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

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
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

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
