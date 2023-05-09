

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class User
    public partial class User
    {

        #region Private Variables
        private bool active;
        private DateTime createdDate;
        private string emailAddress;
        private bool emailVerified;
        private int id;
        private string name;
        private string passwordHash;
        private string userName;
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

            #region bool Active
            public bool Active
            {
                get
                {
                    return active;
                }
                set
                {
                    active = value;
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

            #region string EmailAddress
            public string EmailAddress
            {
                get
                {
                    return emailAddress;
                }
                set
                {
                    emailAddress = value;
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
                    emailVerified = value;
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
                set
                {
                    id = value;
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

            #region string PasswordHash
            public string PasswordHash
            {
                get
                {
                    return passwordHash;
                }
                set
                {
                    passwordHash = value;
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

        #endregion

    }
    #endregion

}
