

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class FeedbackReplyReader
    /// <summary>
    /// This class loads a single 'FeedbackReply' object or a list of type <FeedbackReply>.
    /// </summary>
    public class FeedbackReplyReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'FeedbackReply' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'FeedbackReply' DataObject.</returns>
            public static FeedbackReply Load(DataRow dataRow)
            {
                // Initial Value
                FeedbackReply feedbackReply = new FeedbackReply();

                // Create field Integers
                int idfield = 0;
                int isPublicfield = 1;
                int likesCountfield = 2;
                int repliedByIdfield = 3;
                int repliedDatefield = 4;
                int replyFeedbackIdfield = 5;
                int responsefield = 6;

                try
                {
                    // Load Each field
                    feedbackReply.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    feedbackReply.IsPublic = DataHelper.ParseBoolean(dataRow.ItemArray[isPublicfield], false);
                    feedbackReply.LikesCount = DataHelper.ParseInteger(dataRow.ItemArray[likesCountfield], 0);
                    feedbackReply.RepliedById = DataHelper.ParseInteger(dataRow.ItemArray[repliedByIdfield], 0);
                    feedbackReply.RepliedDate = DataHelper.ParseDate(dataRow.ItemArray[repliedDatefield]);
                    feedbackReply.ReplyFeedbackId = DataHelper.ParseInteger(dataRow.ItemArray[replyFeedbackIdfield], 0);
                    feedbackReply.Response = DataHelper.ParseString(dataRow.ItemArray[responsefield]);
                }
                catch
                {
                }

                // return value
                return feedbackReply;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'FeedbackReply' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A FeedbackReply Collection.</returns>
            public static List<FeedbackReply> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<FeedbackReply> feedbackReplys = new List<FeedbackReply>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'FeedbackReply' from rows
                        FeedbackReply feedbackReply = Load(row);

                        // Add this object to collection
                        feedbackReplys.Add(feedbackReply);
                    }
                }
                catch
                {
                }

                // return value
                return feedbackReplys;
            }
            #endregion

        #endregion

    }
    #endregion

}
