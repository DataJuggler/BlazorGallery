

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ActivityLog
    public partial class ActivityLog
    {

        #region Private Variables
        private string activity;
        private DateTime createdDate;
        private string detail;
        private int folderId;
        private int id;
        private int userId;
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

            #region string Activity
            public string Activity
            {
                get
                {
                    return activity;
                }
                set
                {
                    activity = value;
                }
            }
            #endregion

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

            #region string Detail
            public string Detail
            {
                get
                {
                    return detail;
                }
                set
                {
                    detail = value;
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

            #region int Id
            public int Id
            {
                get
                {
                    return id;
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
