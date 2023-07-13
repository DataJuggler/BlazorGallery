

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

    #region class FeedbackWriterBase
    /// <summary>
    /// This class is used for converting a 'Feedback' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FeedbackWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Feedback feedback)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='feedback'>The 'Feedback' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Feedback feedback)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (feedback != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", feedback.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteFeedbackStoredProcedure(Feedback feedback)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteFeedback'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Feedback_Delete'.
            /// </summary>
            /// <param name="feedback">The 'Feedback' to Delete.</param>
            /// <returns>An instance of a 'DeleteFeedbackStoredProcedure' object.</returns>
            public static DeleteFeedbackStoredProcedure CreateDeleteFeedbackStoredProcedure(Feedback feedback)
            {
                // Initial Value
                DeleteFeedbackStoredProcedure deleteFeedbackStoredProcedure = new DeleteFeedbackStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteFeedbackStoredProcedure.Parameters = CreatePrimaryKeyParameter(feedback);

                // return value
                return deleteFeedbackStoredProcedure;
            }
            #endregion

            #region CreateFindFeedbackStoredProcedure(Feedback feedback)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindFeedbackStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Feedback_Find'.
            /// </summary>
            /// <param name="feedback">The 'Feedback' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindFeedbackStoredProcedure CreateFindFeedbackStoredProcedure(Feedback feedback)
            {
                // Initial Value
                FindFeedbackStoredProcedure findFeedbackStoredProcedure = null;

                // verify feedback exists
                if(feedback != null)
                {
                    // Instanciate findFeedbackStoredProcedure
                    findFeedbackStoredProcedure = new FindFeedbackStoredProcedure();

                    // Now create parameters for this procedure
                    findFeedbackStoredProcedure.Parameters = CreatePrimaryKeyParameter(feedback);
                }

                // return value
                return findFeedbackStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Feedback feedback)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new feedback.
            /// </summary>
            /// <param name="feedback">The 'Feedback' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Feedback feedback)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[8];
                SqlParameter param = null;

                // verify feedbackexists
                if(feedback != null)
                {
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If feedback.CreatedDate does not exist.
                    if (feedback.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = feedback.CreatedDate;
                    }
                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Details] parameter
                    param = new SqlParameter("@Details", feedback.Details);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [FeedbackType] parameter
                    param = new SqlParameter("@FeedbackType", feedback.FeedbackType);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [PermissionToEmail] parameter
                    param = new SqlParameter("@PermissionToEmail", feedback.PermissionToEmail);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [Responded] parameter
                    param = new SqlParameter("@Responded", feedback.Responded);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create [RespondedById] parameter
                    param = new SqlParameter("@RespondedById", feedback.RespondedById);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create [RespondedDate] Parameter
                    param = new SqlParameter("@RespondedDate", SqlDbType.DateTime);

                    // If feedback.RespondedDate does not exist.
                    if (feedback.RespondedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = feedback.RespondedDate;
                    }
                    // set parameters[6]
                    parameters[6] = param;

                    // Create [UserId] parameter
                    param = new SqlParameter("@UserId", feedback.UserId);

                    // set parameters[7]
                    parameters[7] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertFeedbackStoredProcedure(Feedback feedback)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertFeedbackStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Feedback_Insert'.
            /// </summary>
            /// <param name="feedback"The 'Feedback' object to insert</param>
            /// <returns>An instance of a 'InsertFeedbackStoredProcedure' object.</returns>
            public static InsertFeedbackStoredProcedure CreateInsertFeedbackStoredProcedure(Feedback feedback)
            {
                // Initial Value
                InsertFeedbackStoredProcedure insertFeedbackStoredProcedure = null;

                // verify feedback exists
                if(feedback != null)
                {
                    // Instanciate insertFeedbackStoredProcedure
                    insertFeedbackStoredProcedure = new InsertFeedbackStoredProcedure();

                    // Now create parameters for this procedure
                    insertFeedbackStoredProcedure.Parameters = CreateInsertParameters(feedback);
                }

                // return value
                return insertFeedbackStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Feedback feedback)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing feedback.
            /// </summary>
            /// <param name="feedback">The 'Feedback' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Feedback feedback)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[9];
                SqlParameter param = null;

                // verify feedbackexists
                if(feedback != null)
                {
                    // Create parameter for [CreatedDate]
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If feedback.CreatedDate does not exist.
                    if (feedback.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = feedback.CreatedDate;
                    }

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Details]
                    param = new SqlParameter("@Details", feedback.Details);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [FeedbackType]
                    param = new SqlParameter("@FeedbackType", feedback.FeedbackType);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [PermissionToEmail]
                    param = new SqlParameter("@PermissionToEmail", feedback.PermissionToEmail);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Responded]
                    param = new SqlParameter("@Responded", feedback.Responded);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [RespondedById]
                    param = new SqlParameter("@RespondedById", feedback.RespondedById);

                    // set parameters[5]
                    parameters[5] = param;

                    // Create parameter for [RespondedDate]
                    // Create [RespondedDate] Parameter
                    param = new SqlParameter("@RespondedDate", SqlDbType.DateTime);

                    // If feedback.RespondedDate does not exist.
                    if (feedback.RespondedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = feedback.RespondedDate;
                    }

                    // set parameters[6]
                    parameters[6] = param;

                    // Create parameter for [UserId]
                    param = new SqlParameter("@UserId", feedback.UserId);

                    // set parameters[7]
                    parameters[7] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", feedback.Id);
                    parameters[8] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateFeedbackStoredProcedure(Feedback feedback)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateFeedbackStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Feedback_Update'.
            /// </summary>
            /// <param name="feedback"The 'Feedback' object to update</param>
            /// <returns>An instance of a 'UpdateFeedbackStoredProcedure</returns>
            public static UpdateFeedbackStoredProcedure CreateUpdateFeedbackStoredProcedure(Feedback feedback)
            {
                // Initial Value
                UpdateFeedbackStoredProcedure updateFeedbackStoredProcedure = null;

                // verify feedback exists
                if(feedback != null)
                {
                    // Instanciate updateFeedbackStoredProcedure
                    updateFeedbackStoredProcedure = new UpdateFeedbackStoredProcedure();

                    // Now create parameters for this procedure
                    updateFeedbackStoredProcedure.Parameters = CreateUpdateParameters(feedback);
                }

                // return value
                return updateFeedbackStoredProcedure;
            }
            #endregion

            #region CreateFetchAllFeedbacksStoredProcedure(Feedback feedback)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFeedbacksStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Feedback_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFeedbacksStoredProcedure' object.</returns>
            public static FetchAllFeedbacksStoredProcedure CreateFetchAllFeedbacksStoredProcedure(Feedback feedback)
            {
                // Initial value
                FetchAllFeedbacksStoredProcedure fetchAllFeedbacksStoredProcedure = new FetchAllFeedbacksStoredProcedure();

                // return value
                return fetchAllFeedbacksStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
