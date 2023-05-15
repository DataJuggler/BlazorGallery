

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

    #region class ActivityLogWriterBase
    /// <summary>
    /// This class is used for converting a 'ActivityLog' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ActivityLogWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ActivityLog activityLog)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='activityLog'>The 'ActivityLog' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ActivityLog activityLog)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (activityLog != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", activityLog.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteActivityLogStoredProcedure(ActivityLog activityLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteActivityLog'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ActivityLog_Delete'.
            /// </summary>
            /// <param name="activityLog">The 'ActivityLog' to Delete.</param>
            /// <returns>An instance of a 'DeleteActivityLogStoredProcedure' object.</returns>
            public static DeleteActivityLogStoredProcedure CreateDeleteActivityLogStoredProcedure(ActivityLog activityLog)
            {
                // Initial Value
                DeleteActivityLogStoredProcedure deleteActivityLogStoredProcedure = new DeleteActivityLogStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteActivityLogStoredProcedure.Parameters = CreatePrimaryKeyParameter(activityLog);

                // return value
                return deleteActivityLogStoredProcedure;
            }
            #endregion

            #region CreateFindActivityLogStoredProcedure(ActivityLog activityLog)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindActivityLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ActivityLog_Find'.
            /// </summary>
            /// <param name="activityLog">The 'ActivityLog' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindActivityLogStoredProcedure CreateFindActivityLogStoredProcedure(ActivityLog activityLog)
            {
                // Initial Value
                FindActivityLogStoredProcedure findActivityLogStoredProcedure = null;

                // verify activityLog exists
                if(activityLog != null)
                {
                    // Instanciate findActivityLogStoredProcedure
                    findActivityLogStoredProcedure = new FindActivityLogStoredProcedure();

                    // Now create parameters for this procedure
                    findActivityLogStoredProcedure.Parameters = CreatePrimaryKeyParameter(activityLog);
                }

                // return value
                return findActivityLogStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ActivityLog activityLog)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new activityLog.
            /// </summary>
            /// <param name="activityLog">The 'ActivityLog' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ActivityLog activityLog)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify activityLogexists
                if(activityLog != null)
                {
                    // Create [Activity] parameter
                    param = new SqlParameter("@Activity", activityLog.Activity);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If activityLog.CreatedDate does not exist.
                    if (activityLog.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = activityLog.CreatedDate;
                    }
                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Detail] parameter
                    param = new SqlParameter("@Detail", activityLog.Detail);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [FolderId] parameter
                    param = new SqlParameter("@FolderId", activityLog.FolderId);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [UserId] parameter
                    param = new SqlParameter("@UserId", activityLog.UserId);

                    // set parameters[4]
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertActivityLogStoredProcedure(ActivityLog activityLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertActivityLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ActivityLog_Insert'.
            /// </summary>
            /// <param name="activityLog"The 'ActivityLog' object to insert</param>
            /// <returns>An instance of a 'InsertActivityLogStoredProcedure' object.</returns>
            public static InsertActivityLogStoredProcedure CreateInsertActivityLogStoredProcedure(ActivityLog activityLog)
            {
                // Initial Value
                InsertActivityLogStoredProcedure insertActivityLogStoredProcedure = null;

                // verify activityLog exists
                if(activityLog != null)
                {
                    // Instanciate insertActivityLogStoredProcedure
                    insertActivityLogStoredProcedure = new InsertActivityLogStoredProcedure();

                    // Now create parameters for this procedure
                    insertActivityLogStoredProcedure.Parameters = CreateInsertParameters(activityLog);
                }

                // return value
                return insertActivityLogStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ActivityLog activityLog)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing activityLog.
            /// </summary>
            /// <param name="activityLog">The 'ActivityLog' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ActivityLog activityLog)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify activityLogexists
                if(activityLog != null)
                {
                    // Create parameter for [Activity]
                    param = new SqlParameter("@Activity", activityLog.Activity);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [CreatedDate]
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If activityLog.CreatedDate does not exist.
                    if (activityLog.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = activityLog.CreatedDate;
                    }

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Detail]
                    param = new SqlParameter("@Detail", activityLog.Detail);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [FolderId]
                    param = new SqlParameter("@FolderId", activityLog.FolderId);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [UserId]
                    param = new SqlParameter("@UserId", activityLog.UserId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", activityLog.Id);
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateActivityLogStoredProcedure(ActivityLog activityLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateActivityLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ActivityLog_Update'.
            /// </summary>
            /// <param name="activityLog"The 'ActivityLog' object to update</param>
            /// <returns>An instance of a 'UpdateActivityLogStoredProcedure</returns>
            public static UpdateActivityLogStoredProcedure CreateUpdateActivityLogStoredProcedure(ActivityLog activityLog)
            {
                // Initial Value
                UpdateActivityLogStoredProcedure updateActivityLogStoredProcedure = null;

                // verify activityLog exists
                if(activityLog != null)
                {
                    // Instanciate updateActivityLogStoredProcedure
                    updateActivityLogStoredProcedure = new UpdateActivityLogStoredProcedure();

                    // Now create parameters for this procedure
                    updateActivityLogStoredProcedure.Parameters = CreateUpdateParameters(activityLog);
                }

                // return value
                return updateActivityLogStoredProcedure;
            }
            #endregion

            #region CreateFetchAllActivityLogsStoredProcedure(ActivityLog activityLog)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllActivityLogsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ActivityLog_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllActivityLogsStoredProcedure' object.</returns>
            public static FetchAllActivityLogsStoredProcedure CreateFetchAllActivityLogsStoredProcedure(ActivityLog activityLog)
            {
                // Initial value
                FetchAllActivityLogsStoredProcedure fetchAllActivityLogsStoredProcedure = new FetchAllActivityLogsStoredProcedure();

                // return value
                return fetchAllActivityLogsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
