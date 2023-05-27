

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net7.Delegates;
using DataJuggler.Net7.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class User
    public partial class User
    {

        #region Private Variables
        private DateTime acceptedTermsOfServiceDate;
        private bool active;
        private DateTime createdDate;
        private string emailAddress;
        private bool emailVerified;
        private int id;
        private bool isAdmin;
        private DateTime lastLoginDate;
        private string name;
        private string passwordHash;
        private ProfileVisibilityEnum profileVisibility;
        private int storageUsed;
        private int totalLogins;
        private string userName;
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

            #region DateTime AcceptedTermsOfServiceDate
            public DateTime AcceptedTermsOfServiceDate
            {
                get
                {
                    return acceptedTermsOfServiceDate;
                }
                set
                {
                    // local
                    bool hasChanges = (AcceptedTermsOfServiceDate != value);

                    // Set the value
                    acceptedTermsOfServiceDate = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region bool Active
            public bool Active
            {
                get
                {
                    return active;
                }
                set
                {
                    // local
                    bool hasChanges = (Active != value);

                    // Set the value
                    active = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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

            #region string EmailAddress
            public string EmailAddress
            {
                get
                {
                    return emailAddress;
                }
                set
                {
                    // local
                    bool hasChanges = (EmailAddress != value);

                    // Set the value
                    emailAddress = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region bool EmailVerified
            public bool EmailVerified
            {
                get
                {
                    return emailVerified;
                }
                set
                {
                    // local
                    bool hasChanges = (EmailVerified != value);

                    // Set the value
                    emailVerified = value;

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

            #region bool IsAdmin
            public bool IsAdmin
            {
                get
                {
                    return isAdmin;
                }
                set
                {
                    // local
                    bool hasChanges = (IsAdmin != value);

                    // Set the value
                    isAdmin = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region DateTime LastLoginDate
            public DateTime LastLoginDate
            {
                get
                {
                    return lastLoginDate;
                }
                set
                {
                    // local
                    bool hasChanges = (LastLoginDate != value);

                    // Set the value
                    lastLoginDate = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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
                    // local
                    bool hasChanges = (Name != value);

                    // Set the value
                    name = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region string PasswordHash
            public string PasswordHash
            {
                get
                {
                    return passwordHash;
                }
                set
                {
                    // local
                    bool hasChanges = (PasswordHash != value);

                    // Set the value
                    passwordHash = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region ProfileVisibilityEnum ProfileVisibility
            public ProfileVisibilityEnum ProfileVisibility
            {
                get
                {
                    return profileVisibility;
                }
                set
                {
                    // local
                    bool hasChanges = (ProfileVisibility != value);

                    // Set the value
                    profileVisibility = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region int StorageUsed
            public int StorageUsed
            {
                get
                {
                    return storageUsed;
                }
                set
                {
                    // local
                    bool hasChanges = (StorageUsed != value);

                    // Set the value
                    storageUsed = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
                }
            }
            #endregion

            #region int TotalLogins
            public int TotalLogins
            {
                get
                {
                    return totalLogins;
                }
                set
                {
                    // local
                    bool hasChanges = (TotalLogins != value);

                    // Set the value
                    totalLogins = value;

                    // if the Callback exists and changes occurred
                    if ((HasCallback) && (hasChanges))
                    {
                        // Notify the Callback changes have occurred
                        Callback(this, ChangeTypeEnum.ItemChanged);
                    }
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
                    // local
                    bool hasChanges = (UserName != value);

                    // Set the value
                    userName = value;

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
