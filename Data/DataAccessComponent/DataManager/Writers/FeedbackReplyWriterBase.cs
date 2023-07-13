

#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Writers
{

    #region class FeedbackReplyWriterBase
    /// <summary>
    /// This class is used for converting a 'FeedbackReply' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FeedbackReplyWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(FeedbackReply feedbackReply)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='feedbackReply'>The 'FeedbackReply' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(FeedbackReply feedbackReply)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (feedbackReply != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", feedbackReply.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteFeedbackReplyStoredProcedure(FeedbackReply feedbackReply)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteFeedbackReply'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FeedbackReply_Delete'.
            /// </summary>
            /// <param name="feedbackReply">The 'FeedbackReply' to Delete.</param>
            /// <returns>An instance of a 'DeleteFeedbackReplyStoredProcedure' object.</returns>
            public static DeleteFeedbackReplyStoredProcedure CreateDeleteFeedbackReplyStoredProcedure(FeedbackReply feedbackReply)
            {
                // Initial Value
                DeleteFeedbackReplyStoredProcedure deleteFeedbackReplyStoredProcedure = new DeleteFeedbackReplyStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteFeedbackReplyStoredProcedure.Parameters = CreatePrimaryKeyParameter(feedbackReply);

                // return value
                return deleteFeedbackReplyStoredProcedure;
            }
            #endregion

            #region CreateFindFeedbackReplyStoredProcedure(FeedbackReply feedbackReply)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindFeedbackReplyStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FeedbackReply_Find'.
            /// </summary>
            /// <param name="feedbackReply">The 'FeedbackReply' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindFeedbackReplyStoredProcedure CreateFindFeedbackReplyStoredProcedure(FeedbackReply feedbackReply)
            {
                // Initial Value
                FindFeedbackReplyStoredProcedure findFeedbackReplyStoredProcedure = null;

                // verify feedbackReply exists
                if(feedbackReply != null)
                {
                    // Instanciate findFeedbackReplyStoredProcedure
                    findFeedbackReplyStoredProcedure = new FindFeedbackReplyStoredProcedure();

                    // Now create parameters for this procedure
                    findFeedbackReplyStoredProcedure.Parameters = CreatePrimaryKeyParameter(feedbackReply);
                }

                // return value
                return findFeedbackReplyStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(FeedbackReply feedbackReply)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new feedbackReply.
            /// </summary>
            /// <param name="feedbackReply">The 'FeedbackReply' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(FeedbackReply feedbackReply)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify feedbackReplyexists
                if(feedbackReply != null)
                {
                    // Create [IsPublic] parameter
                    param = new SqlParameter("@IsPublic", feedbackReply.IsPublic);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [LikesCount] parameter
                    param = new SqlParameter("@LikesCount", feedbackReply.LikesCount);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [RepliedById] parameter
                    param = new SqlParameter("@RepliedById", feedbackReply.RepliedById);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [RepliedDate] Parameter
                    param = new SqlParameter("@RepliedDate", SqlDbType.DateTime);

                    // If feedbackReply.RepliedDate does not exist.
                    if (feedbackReply.RepliedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = feedbackReply.RepliedDate;
                    }
                    // set parameters[3]
                    parameters[3] = param;

                    // Create [ReplyFeedbackId] parameter
                    param = new SqlParameter("@ReplyFeedbackId", feedbackReply.ReplyFeedbackId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [Response] parameter
                    param = new SqlParameter("@Response", feedbackReply.Response);

                    // set parameters[5]
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertFeedbackReplyStoredProcedure(FeedbackReply feedbackReply)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertFeedbackReplyStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FeedbackReply_Insert'.
            /// </summary>
            /// <param name="feedbackReply"The 'FeedbackReply' object to insert</param>
            /// <returns>An instance of a 'InsertFeedbackReplyStoredProcedure' object.</returns>
            public static InsertFeedbackReplyStoredProcedure CreateInsertFeedbackReplyStoredProcedure(FeedbackReply feedbackReply)
            {
                // Initial Value
                InsertFeedbackReplyStoredProcedure insertFeedbackReplyStoredProcedure = null;

                // verify feedbackReply exists
                if(feedbackReply != null)
                {
                    // Instanciate insertFeedbackReplyStoredProcedure
                    insertFeedbackReplyStoredProcedure = new InsertFeedbackReplyStoredProcedure();

                    // Now create parameters for this procedure
                    insertFeedbackReplyStoredProcedure.Parameters = CreateInsertParameters(feedbackReply);
                }

                // return value
                return insertFeedbackReplyStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(FeedbackReply feedbackReply)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing feedbackReply.
            /// </summary>
            /// <param name="feedbackReply">The 'FeedbackReply' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(FeedbackReply feedbackReply)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[7];
                SqlParameter param = null;

                // verify feedbackReplyexists
                if(feedbackReply != null)
                {
                    // Create parameter for [IsPublic]
                    param = new SqlParameter("@IsPublic", feedbackReply.IsPublic);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [LikesCount]
                    param = new SqlParameter("@LikesCount", feedbackReply.LikesCount);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [RepliedById]
                    param = new SqlParameter("@RepliedById", feedbackReply.RepliedById);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [RepliedDate]
                    // Create [RepliedDate] Parameter
                    param = new SqlParameter("@RepliedDate", SqlDbType.DateTime);

                    // If feedbackReply.RepliedDate does not exist.
                    if (feedbackReply.RepliedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = feedbackReply.RepliedDate;
                    }

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [ReplyFeedbackId]
                    param = new SqlParameter("@ReplyFeedbackId", feedbackReply.ReplyFeedbackId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Response]
                    param = new SqlParameter("@Response", feedbackReply.Response);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", feedbackReply.Id);
                    parameters[6] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateFeedbackReplyStoredProcedure(FeedbackReply feedbackReply)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateFeedbackReplyStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FeedbackReply_Update'.
            /// </summary>
            /// <param name="feedbackReply"The 'FeedbackReply' object to update</param>
            /// <returns>An instance of a 'UpdateFeedbackReplyStoredProcedure</returns>
            public static UpdateFeedbackReplyStoredProcedure CreateUpdateFeedbackReplyStoredProcedure(FeedbackReply feedbackReply)
            {
                // Initial Value
                UpdateFeedbackReplyStoredProcedure updateFeedbackReplyStoredProcedure = null;

                // verify feedbackReply exists
                if(feedbackReply != null)
                {
                    // Instanciate updateFeedbackReplyStoredProcedure
                    updateFeedbackReplyStoredProcedure = new UpdateFeedbackReplyStoredProcedure();

                    // Now create parameters for this procedure
                    updateFeedbackReplyStoredProcedure.Parameters = CreateUpdateParameters(feedbackReply);
                }

                // return value
                return updateFeedbackReplyStoredProcedure;
            }
            #endregion

            #region CreateFetchAllFeedbackReplysStoredProcedure(FeedbackReply feedbackReply)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFeedbackReplysStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'FeedbackReply_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFeedbackReplysStoredProcedure' object.</returns>
            public static FetchAllFeedbackReplysStoredProcedure CreateFetchAllFeedbackReplysStoredProcedure(FeedbackReply feedbackReply)
            {
                // Initial value
                FetchAllFeedbackReplysStoredProcedure fetchAllFeedbackReplysStoredProcedure = new FetchAllFeedbackReplysStoredProcedure();

                // return value
                return fetchAllFeedbackReplysStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
