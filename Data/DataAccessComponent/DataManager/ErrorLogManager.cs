

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

    #region class ErrorLogManager
    /// <summary>
    /// This class is used to manage a 'ErrorLog' object.
    /// </summary>
    public class ErrorLogManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ErrorLogManager' object.
        /// </summary>
        public ErrorLogManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteErrorLog()
            /// <summary>
            /// This method deletes a 'ErrorLog' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteErrorLog(DeleteErrorLogStoredProcedure deleteErrorLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteErrorLogProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllErrorLogs()
            /// <summary>
            /// This method fetches a  'List<ErrorLog>' object.
            /// This method uses the 'ErrorLogs_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ErrorLog>'</returns>
            /// </summary>
            public List<ErrorLog> FetchAllErrorLogs(FetchAllErrorLogsStoredProcedure fetchAllErrorLogsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ErrorLog> errorLogCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allErrorLogsDataSet = this.DataHelper.LoadDataSet(fetchAllErrorLogsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allErrorLogsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allErrorLogsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            errorLogCollection = ErrorLogReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return errorLogCollection;
            }
            #endregion

            #region FindErrorLog()
            /// <summary>
            /// This method finds a  'ErrorLog' object.
            /// This method uses the 'ErrorLog_Find' procedure.
            /// </summary>
            /// <returns>A 'ErrorLog' object.</returns>
            /// </summary>
            public ErrorLog FindErrorLog(FindErrorLogStoredProcedure findErrorLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                ErrorLog errorLog = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet errorLogDataSet = this.DataHelper.LoadDataSet(findErrorLogProc, databaseConnector);

                    // Verify DataSet Exists
                    if(errorLogDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(errorLogDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ErrorLog
                            errorLog = ErrorLogReader.Load(row);
                        }
                    }
                }

                // return value
                return errorLog;
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

            #region InsertErrorLog()
            /// <summary>
            /// This method inserts a 'ErrorLog' object.
            /// This method uses the 'ErrorLog_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertErrorLog(InsertErrorLogStoredProcedure insertErrorLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertErrorLogProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateErrorLog()
            /// <summary>
            /// This method updates a 'ErrorLog'.
            /// This method uses the 'ErrorLog_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateErrorLog(UpdateErrorLogStoredProcedure updateErrorLogProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateErrorLogProc, databaseConnector);
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
