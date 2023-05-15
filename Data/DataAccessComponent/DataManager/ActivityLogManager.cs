

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class ActivityLogManager
    /// <summary>
    /// This class is used to manage a 'ActivityLog' object.
    /// </summary>
    public class ActivityLogManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ActivityLogManager' object.
        /// </summary>
        public ActivityLogManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteActivityLog()
            /// <summary>
            /// This method deletes a 'ActivityLog' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteActivityLog(DeleteActivityLogStoredProcedure deleteActivityLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteActivityLogProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllActivityLogs()
            /// <summary>
            /// This method fetches a  'List<ActivityLog>' object.
            /// This method uses the 'ActivityLogs_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ActivityLog>'</returns>
            /// </summary>
            public List<ActivityLog> FetchAllActivityLogs(FetchAllActivityLogsStoredProcedure fetchAllActivityLogsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ActivityLog> activityLogCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allActivityLogsDataSet = this.DataHelper.LoadDataSet(fetchAllActivityLogsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allActivityLogsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allActivityLogsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            activityLogCollection = ActivityLogReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return activityLogCollection;
            }
            #endregion

            #region FindActivityLog()
            /// <summary>
            /// This method finds a  'ActivityLog' object.
            /// This method uses the 'ActivityLog_Find' procedure.
            /// </summary>
            /// <returns>A 'ActivityLog' object.</returns>
            /// </summary>
            public ActivityLog FindActivityLog(FindActivityLogStoredProcedure findActivityLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                ActivityLog activityLog = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet activityLogDataSet = this.DataHelper.LoadDataSet(findActivityLogProc, databaseConnector);

                    // Verify DataSet Exists
                    if(activityLogDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(activityLogDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ActivityLog
                            activityLog = ActivityLogReader.Load(row);
                        }
                    }
                }

                // return value
                return activityLog;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

            #region InsertActivityLog()
            /// <summary>
            /// This method inserts a 'ActivityLog' object.
            /// This method uses the 'ActivityLog_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertActivityLog(InsertActivityLogStoredProcedure insertActivityLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertActivityLogProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateActivityLog()
            /// <summary>
            /// This method updates a 'ActivityLog'.
            /// This method uses the 'ActivityLog_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateActivityLog(UpdateActivityLogStoredProcedure updateActivityLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateActivityLogProc, databaseConnector);
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
