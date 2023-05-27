
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

    #region class ActivityLogWriter
    /// <summary>
    /// This class is used for converting a 'ActivityLog' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ActivityLogWriter : ActivityLogWriterBase
    {

        #region Static Methods

            #region CreateFetchAllActivityLogsStoredProcedure(ActivityLog activityLog)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllActivityLogsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ActivityLog_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllActivityLogsStoredProcedure' object.</returns>
            public static new FetchAllActivityLogsStoredProcedure CreateFetchAllActivityLogsStoredProcedure(ActivityLog activityLog)
            {
                // Initial value
                FetchAllActivityLogsStoredProcedure fetchAllActivityLogsStoredProcedure = new FetchAllActivityLogsStoredProcedure();

                // if the activityLog object exists
                if (activityLog != null)
                {
                    // if LoadByActivityAndUserId is true
                    if (activityLog.LoadByActivityAndUserId)
                    {
                        // Change the procedure name
                        fetchAllActivityLogsStoredProcedure.ProcedureName = "ActivityLog_FetchAllForActivityAndUserId";
                        
                        // Create the ActivityAndUserId field set parameters
                        fetchAllActivityLogsStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Activity", activityLog.Activity, "@UserId", activityLog.UserId);
                    }
                }
                
                // return value
                return fetchAllActivityLogsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
