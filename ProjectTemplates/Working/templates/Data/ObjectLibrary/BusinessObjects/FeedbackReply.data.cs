

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FeedbackReply
    public partial class FeedbackReply
    {

        #region Private Variables
        private int id;
        private bool isPublic;
        private int likesCount;
        private int repliedById;
        private DateTime repliedDate;
        private int replyFeedbackId;
        private string response;
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

            #region bool IsPublic
            public bool IsPublic
            {
                get
                {
                    return isPublic;
                }
                set
                {
                    isPublic = value;
                }
            }
            #endregion

            #region int LikesCount
            public int LikesCount
            {
                get
                {
                    return likesCount;
                }
                set
                {
                    likesCount = value;
                }
            }
            #endregion

            #region int RepliedById
            public int RepliedById
            {
                get
                {
                    return repliedById;
                }
                set
                {
                    repliedById = value;
                }
            }
            #endregion

            #region DateTime RepliedDate
            public DateTime RepliedDate
            {
                get
                {
                    return repliedDate;
                }
                set
                {
                    repliedDate = value;
                }
            }
            #endregion

            #region int ReplyFeedbackId
            public int ReplyFeedbackId
            {
                get
                {
                    return replyFeedbackId;
                }
                set
                {
                    replyFeedbackId = value;
                }
            }
            #endregion

            #region string Response
            public string Response
            {
                get
                {
                    return response;
                }
                set
                {
                    response = value;
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
