

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

    #region class ErrorLogWriterBase
    /// <summary>
    /// This class is used for converting a 'ErrorLog' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ErrorLogWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ErrorLog errorLog)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='errorLog'>The 'ErrorLog' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ErrorLog errorLog)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (errorLog != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", errorLog.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteErrorLogStoredProcedure(ErrorLog errorLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteErrorLog'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ErrorLog_Delete'.
            /// </summary>
            /// <param name="errorLog">The 'ErrorLog' to Delete.</param>
            /// <returns>An instance of a 'DeleteErrorLogStoredProcedure' object.</returns>
            public static DeleteErrorLogStoredProcedure CreateDeleteErrorLogStoredProcedure(ErrorLog errorLog)
            {
                // Initial Value
                DeleteErrorLogStoredProcedure deleteErrorLogStoredProcedure = new DeleteErrorLogStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteErrorLogStoredProcedure.Parameters = CreatePrimaryKeyParameter(errorLog);

                // return value
                return deleteErrorLogStoredProcedure;
            }
            #endregion

            #region CreateFindErrorLogStoredProcedure(ErrorLog errorLog)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindErrorLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ErrorLog_Find'.
            /// </summary>
            /// <param name="errorLog">The 'ErrorLog' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindErrorLogStoredProcedure CreateFindErrorLogStoredProcedure(ErrorLog errorLog)
            {
                // Initial Value
                FindErrorLogStoredProcedure findErrorLogStoredProcedure = null;

                // verify errorLog exists
                if(errorLog != null)
                {
                    // Instanciate findErrorLogStoredProcedure
                    findErrorLogStoredProcedure = new FindErrorLogStoredProcedure();

                    // Now create parameters for this procedure
                    findErrorLogStoredProcedure.Parameters = CreatePrimaryKeyParameter(errorLog);
                }

                // return value
                return findErrorLogStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ErrorLog errorLog)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new errorLog.
            /// </summary>
            /// <param name="errorLog">The 'ErrorLog' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ErrorLog errorLog)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify errorLogexists
                if(errorLog != null)
                {
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If errorLog.CreatedDate does not exist.
                    if (errorLog.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = errorLog.CreatedDate;
                    }
                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Error] parameter
                    param = new SqlParameter("@Error", errorLog.Error);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [FolderId] parameter
                    param = new SqlParameter("@FolderId", errorLog.FolderId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [Message] parameter
                    param = new SqlParameter("@Message", errorLog.Message);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create [UserId] parameter
                    param = new SqlParameter("@UserId", errorLog.UserId);

                    // set parameters[4]
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertErrorLogStoredProcedure(ErrorLog errorLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertErrorLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ErrorLog_Insert'.
            /// </summary>
            /// <param name="errorLog"The 'ErrorLog' object to insert</param>
            /// <returns>An instance of a 'InsertErrorLogStoredProcedure' object.</returns>
            public static InsertErrorLogStoredProcedure CreateInsertErrorLogStoredProcedure(ErrorLog errorLog)
            {
                // Initial Value
                InsertErrorLogStoredProcedure insertErrorLogStoredProcedure = null;

                // verify errorLog exists
                if(errorLog != null)
                {
                    // Instanciate insertErrorLogStoredProcedure
                    insertErrorLogStoredProcedure = new InsertErrorLogStoredProcedure();

                    // Now create parameters for this procedure
                    insertErrorLogStoredProcedure.Parameters = CreateInsertParameters(errorLog);
                }

                // return value
                return insertErrorLogStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ErrorLog errorLog)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing errorLog.
            /// </summary>
            /// <param name="errorLog">The 'ErrorLog' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ErrorLog errorLog)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[6];
                SqlParameter param = null;

                // verify errorLogexists
                if(errorLog != null)
                {
                    // Create parameter for [CreatedDate]
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If errorLog.CreatedDate does not exist.
                    if (errorLog.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = errorLog.CreatedDate;
                    }

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Error]
                    param = new SqlParameter("@Error", errorLog.Error);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [FolderId]
                    param = new SqlParameter("@FolderId", errorLog.FolderId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Message]
                    param = new SqlParameter("@Message", errorLog.Message);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [UserId]
                    param = new SqlParameter("@UserId", errorLog.UserId);

                    // set parameters[4]
                    parameters[4] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", errorLog.Id);
                    parameters[5] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateErrorLogStoredProcedure(ErrorLog errorLog)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateErrorLogStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ErrorLog_Update'.
            /// </summary>
            /// <param name="errorLog"The 'ErrorLog' object to update</param>
            /// <returns>An instance of a 'UpdateErrorLogStoredProcedure</returns>
            public static UpdateErrorLogStoredProcedure CreateUpdateErrorLogStoredProcedure(ErrorLog errorLog)
            {
                // Initial Value
                UpdateErrorLogStoredProcedure updateErrorLogStoredProcedure = null;

                // verify errorLog exists
                if(errorLog != null)
                {
                    // Instanciate updateErrorLogStoredProcedure
                    updateErrorLogStoredProcedure = new UpdateErrorLogStoredProcedure();

                    // Now create parameters for this procedure
                    updateErrorLogStoredProcedure.Parameters = CreateUpdateParameters(errorLog);
                }

                // return value
                return updateErrorLogStoredProcedure;
            }
            #endregion

            #region CreateFetchAllErrorLogsStoredProcedure(ErrorLog errorLog)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllErrorLogsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ErrorLog_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllErrorLogsStoredProcedure' object.</returns>
            public static FetchAllErrorLogsStoredProcedure CreateFetchAllErrorLogsStoredProcedure(ErrorLog errorLog)
            {
                // Initial value
                FetchAllErrorLogsStoredProcedure fetchAllErrorLogsStoredProcedure = new FetchAllErrorLogsStoredProcedure();

                // return value
                return fetchAllErrorLogsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
