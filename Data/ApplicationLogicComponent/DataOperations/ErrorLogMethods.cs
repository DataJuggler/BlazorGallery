

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class ErrorLogMethods
    /// <summary>
    /// This class contains methods for modifying a 'ErrorLog' object.
    /// </summary>
    public class ErrorLogMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ErrorLogMethods' object.
        /// </summary>
        public ErrorLogMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteErrorLog(ErrorLog)
            /// <summary>
            /// This method deletes a 'ErrorLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ErrorLog' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteErrorLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteErrorLogStoredProcedure deleteErrorLogProc = null;

                    // verify the first parameters is a(n) 'ErrorLog'.
                    if (parameters[0].ObjectValue as ErrorLog != null)
                    {
                        // Create ErrorLog
                        ErrorLog errorLog = (ErrorLog) parameters[0].ObjectValue;

                        // verify errorLog exists
                        if(errorLog != null)
                        {
                            // Now create deleteErrorLogProc from ErrorLogWriter
                            // The DataWriter converts the 'ErrorLog'
                            // to the SqlParameter[] array needed to delete a 'ErrorLog'.
                            deleteErrorLogProc = ErrorLogWriter.CreateDeleteErrorLogStoredProcedure(errorLog);
                        }
                    }

                    // Verify deleteErrorLogProc exists
                    if(deleteErrorLogProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ErrorLogManager.DeleteErrorLog(deleteErrorLogProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ErrorLog' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ErrorLog' to delete.
            /// <returns>A PolymorphicObject object with all  'ErrorLogs' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ErrorLog> errorLogListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllErrorLogsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ErrorLogParameter
                    // Declare Parameter
                    ErrorLog paramErrorLog = null;

                    // verify the first parameters is a(n) 'ErrorLog'.
                    if (parameters[0].ObjectValue as ErrorLog != null)
                    {
                        // Get ErrorLogParameter
                        paramErrorLog = (ErrorLog) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllErrorLogsProc from ErrorLogWriter
                    fetchAllProc = ErrorLogWriter.CreateFetchAllErrorLogsStoredProcedure(paramErrorLog);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    errorLogListCollection = this.DataManager.ErrorLogManager.FetchAllErrorLogs(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(errorLogListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = errorLogListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindErrorLog(ErrorLog)
            /// <summary>
            /// This method finds a 'ErrorLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ErrorLog' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindErrorLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ErrorLog errorLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindErrorLogStoredProcedure findErrorLogProc = null;

                    // verify the first parameters is a 'ErrorLog'.
                    if (parameters[0].ObjectValue as ErrorLog != null)
                    {
                        // Get ErrorLogParameter
                        ErrorLog paramErrorLog = (ErrorLog) parameters[0].ObjectValue;

                        // verify paramErrorLog exists
                        if(paramErrorLog != null)
                        {
                            // Now create findErrorLogProc from ErrorLogWriter
                            // The DataWriter converts the 'ErrorLog'
                            // to the SqlParameter[] array needed to find a 'ErrorLog'.
                            findErrorLogProc = ErrorLogWriter.CreateFindErrorLogStoredProcedure(paramErrorLog);
                        }

                        // Verify findErrorLogProc exists
                        if(findErrorLogProc != null)
                        {
                            // Execute Find Stored Procedure
                            errorLog = this.DataManager.ErrorLogManager.FindErrorLog(findErrorLogProc, dataConnector);

                            // if dataObject exists
                            if(errorLog != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = errorLog;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertErrorLog (ErrorLog)
            /// <summary>
            /// This method inserts a 'ErrorLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ErrorLog' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertErrorLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ErrorLog errorLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertErrorLogStoredProcedure insertErrorLogProc = null;

                    // verify the first parameters is a(n) 'ErrorLog'.
                    if (parameters[0].ObjectValue as ErrorLog != null)
                    {
                        // Create ErrorLog Parameter
                        errorLog = (ErrorLog) parameters[0].ObjectValue;

                        // verify errorLog exists
                        if(errorLog != null)
                        {
                            // Now create insertErrorLogProc from ErrorLogWriter
                            // The DataWriter converts the 'ErrorLog'
                            // to the SqlParameter[] array needed to insert a 'ErrorLog'.
                            insertErrorLogProc = ErrorLogWriter.CreateInsertErrorLogStoredProcedure(errorLog);
                        }

                        // Verify insertErrorLogProc exists
                        if(insertErrorLogProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ErrorLogManager.InsertErrorLog(insertErrorLogProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateErrorLog (ErrorLog)
            /// <summary>
            /// This method updates a 'ErrorLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ErrorLog' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateErrorLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ErrorLog errorLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateErrorLogStoredProcedure updateErrorLogProc = null;

                    // verify the first parameters is a(n) 'ErrorLog'.
                    if (parameters[0].ObjectValue as ErrorLog != null)
                    {
                        // Create ErrorLog Parameter
                        errorLog = (ErrorLog) parameters[0].ObjectValue;

                        // verify errorLog exists
                        if(errorLog != null)
                        {
                            // Now create updateErrorLogProc from ErrorLogWriter
                            // The DataWriter converts the 'ErrorLog'
                            // to the SqlParameter[] array needed to update a 'ErrorLog'.
                            updateErrorLogProc = ErrorLogWriter.CreateUpdateErrorLogStoredProcedure(errorLog);
                        }

                        // Verify updateErrorLogProc exists
                        if(updateErrorLogProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ErrorLogManager.UpdateErrorLog(updateErrorLogProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
