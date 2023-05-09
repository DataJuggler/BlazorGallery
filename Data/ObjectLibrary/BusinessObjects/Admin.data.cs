

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net7.Delegates;
using DataJuggler.Net7.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Admin
    public partial class Admin
    {

        #region Private Variables
        private int id;
        private int maxFolderCount;
        private int maxImagesPerFolder;
        private int maxStoragePlanFree;
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

            #region int Id
            public int Id
            {
                get
                {
                    return id;
                }
            }
            #endregion

            #region int MaxFolderCount
            public int MaxFolderCount
            {
                get
                {
                    return maxFolderCount;
                }
                set
                {
                    // local
                    bool hasChanges = (MaxFolderCount != value);

                    // Set the value
                    maxFolderCount = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region int MaxImagesPerFolder
            public int MaxImagesPerFolder
            {
                get
                {
                    return maxImagesPerFolder;
                }
                set
                {
                    // local
                    bool hasChanges = (MaxImagesPerFolder != value);

                    // Set the value
                    maxImagesPerFolder = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region int MaxStoragePlanFree
            public int MaxStoragePlanFree
            {
                get
                {
                    return maxStoragePlanFree;
                }
                set
                {
                    // local
                    bool hasChanges = (MaxStoragePlanFree != value);

                    // Set the value
                    maxStoragePlanFree = value;

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
