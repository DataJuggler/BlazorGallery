

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Feedback
    public partial class Feedback
    {

        #region Private Variables
        private DateTime createdDate;
        private string details;
        private FeedbackTypeEnum feedbackType;
        private int id;
        private bool permissionToEmail;
        private bool responded;
        private int respondedById;
        private DateTime respondedDate;
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

            #region string Details
            public string Details
            {
                get
                {
                    return details;
                }
                set
                {
                    details = value;
                }
            }
            #endregion

            #region FeedbackTypeEnum FeedbackType
            public FeedbackTypeEnum FeedbackType
            {
                get
                {
                    return feedbackType;
                }
                set
                {
                    feedbackType = value;
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

            #region bool PermissionToEmail
            public bool PermissionToEmail
            {
                get
                {
                    return permissionToEmail;
                }
                set
                {
                    permissionToEmail = value;
                }
            }
            #endregion

            #region bool Responded
            public bool Responded
            {
                get
                {
                    return responded;
                }
                set
                {
                    responded = value;
                }
            }
            #endregion

            #region int RespondedById
            public int RespondedById
            {
                get
                {
                    return respondedById;
                }
                set
                {
                    respondedById = value;
                }
            }
            #endregion

            #region DateTime RespondedDate
            public DateTime RespondedDate
            {
                get
                {
                    return respondedDate;
                }
                set
                {
                    respondedDate = value;
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
