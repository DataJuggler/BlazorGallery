

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net7.Delegates;
using DataJuggler.Net7.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ErrorLog
    public partial class ErrorLog
    {

        #region Private Variables
        private DateTime createdDate;
        private string error;
        private int folderId;
        private int id;
        private string message;
        private int userId;
        private ItemChangedCallback callback;
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
                    // local
                    bool hasChanges = (CreatedDate != value);

                    // Set the value
                    createdDate = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string Error
            public string Error
            {
                get
                {
                    return error;
                }
                set
                {
                    // local
                    bool hasChanges = (Error != value);

                    // Set the value
                    error = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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
                    // local
                    bool hasChanges = (FolderId != value);

                    // Set the value
                    folderId = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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

            #region string Message
            public string Message
            {
                get
                {
                    return message;
                }
                set
                {
                    // local
                    bool hasChanges = (Message != value);

                    // Set the value
                    message = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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
                    // local
                    bool hasChanges = (UserId != value);

                    // Set the value
                    userId = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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

            #region ItemChangedCallback Callback
            public ItemChangedCallback Callback
            {
                get
                {
                    return callback;
                }
                set
                {
                    callback = value;
                }
            }
            #endregion

            #region bool HasCallback
            public bool HasCallback
            {
                get
                {
                    // Initial Value
                    bool hasCallback = (this.Callback != null);

                    // return value
                    return hasCallback;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
