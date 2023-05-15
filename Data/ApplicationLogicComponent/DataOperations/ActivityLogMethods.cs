

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

    #region class ActivityLogMethods
    /// <summary>
    /// This class contains methods for modifying a 'ActivityLog' object.
    /// </summary>
    public class ActivityLogMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ActivityLogMethods' object.
        /// </summary>
        public ActivityLogMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteActivityLog(ActivityLog)
            /// <summary>
            /// This method deletes a 'ActivityLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ActivityLog' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteActivityLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteActivityLogStoredProcedure deleteActivityLogProc = null;

                    // verify the first parameters is a(n) 'ActivityLog'.
                    if (parameters[0].ObjectValue as ActivityLog != null)
                    {
                        // Create ActivityLog
                        ActivityLog activityLog = (ActivityLog) parameters[0].ObjectValue;

                        // verify activityLog exists
                        if(activityLog != null)
                        {
                            // Now create deleteActivityLogProc from ActivityLogWriter
                            // The DataWriter converts the 'ActivityLog'
                            // to the SqlParameter[] array needed to delete a 'ActivityLog'.
                            deleteActivityLogProc = ActivityLogWriter.CreateDeleteActivityLogStoredProcedure(activityLog);
                        }
                    }

                    // Verify deleteActivityLogProc exists
                    if(deleteActivityLogProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ActivityLogManager.DeleteActivityLog(deleteActivityLogProc, dataConnector);

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
            /// This method fetches all 'ActivityLog' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ActivityLog' to delete.
            /// <returns>A PolymorphicObject object with all  'ActivityLogs' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ActivityLog> activityLogListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllActivityLogsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ActivityLogParameter
                    // Declare Parameter
                    ActivityLog paramActivityLog = null;

                    // verify the first parameters is a(n) 'ActivityLog'.
                    if (parameters[0].ObjectValue as ActivityLog != null)
                    {
                        // Get ActivityLogParameter
                        paramActivityLog = (ActivityLog) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllActivityLogsProc from ActivityLogWriter
                    fetchAllProc = ActivityLogWriter.CreateFetchAllActivityLogsStoredProcedure(paramActivityLog);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    activityLogListCollection = this.DataManager.ActivityLogManager.FetchAllActivityLogs(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(activityLogListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = activityLogListCollection;
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

            #region FindActivityLog(ActivityLog)
            /// <summary>
            /// This method finds a 'ActivityLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ActivityLog' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindActivityLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ActivityLog activityLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindActivityLogStoredProcedure findActivityLogProc = null;

                    // verify the first parameters is a 'ActivityLog'.
                    if (parameters[0].ObjectValue as ActivityLog != null)
                    {
                        // Get ActivityLogParameter
                        ActivityLog paramActivityLog = (ActivityLog) parameters[0].ObjectValue;

                        // verify paramActivityLog exists
                        if(paramActivityLog != null)
                        {
                            // Now create findActivityLogProc from ActivityLogWriter
                            // The DataWriter converts the 'ActivityLog'
                            // to the SqlParameter[] array needed to find a 'ActivityLog'.
                            findActivityLogProc = ActivityLogWriter.CreateFindActivityLogStoredProcedure(paramActivityLog);
                        }

                        // Verify findActivityLogProc exists
                        if(findActivityLogProc != null)
                        {
                            // Execute Find Stored Procedure
                            activityLog = this.DataManager.ActivityLogManager.FindActivityLog(findActivityLogProc, dataConnector);

                            // if dataObject exists
                            if(activityLog != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = activityLog;
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

            #region InsertActivityLog (ActivityLog)
            /// <summary>
            /// This method inserts a 'ActivityLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ActivityLog' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertActivityLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ActivityLog activityLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertActivityLogStoredProcedure insertActivityLogProc = null;

                    // verify the first parameters is a(n) 'ActivityLog'.
                    if (parameters[0].ObjectValue as ActivityLog != null)
                    {
                        // Create ActivityLog Parameter
                        activityLog = (ActivityLog) parameters[0].ObjectValue;

                        // verify activityLog exists
                        if(activityLog != null)
                        {
                            // Now create insertActivityLogProc from ActivityLogWriter
                            // The DataWriter converts the 'ActivityLog'
                            // to the SqlParameter[] array needed to insert a 'ActivityLog'.
                            insertActivityLogProc = ActivityLogWriter.CreateInsertActivityLogStoredProcedure(activityLog);
                        }

                        // Verify insertActivityLogProc exists
                        if(insertActivityLogProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ActivityLogManager.InsertActivityLog(insertActivityLogProc, dataConnector);
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

            #region UpdateActivityLog (ActivityLog)
            /// <summary>
            /// This method updates a 'ActivityLog' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ActivityLog' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateActivityLog(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ActivityLog activityLog = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateActivityLogStoredProcedure updateActivityLogProc = null;

                    // verify the first parameters is a(n) 'ActivityLog'.
                    if (parameters[0].ObjectValue as ActivityLog != null)
                    {
                        // Create ActivityLog Parameter
                        activityLog = (ActivityLog) parameters[0].ObjectValue;

                        // verify activityLog exists
                        if(activityLog != null)
                        {
                            // Now create updateActivityLogProc from ActivityLogWriter
                            // The DataWriter converts the 'ActivityLog'
                            // to the SqlParameter[] array needed to update a 'ActivityLog'.
                            updateActivityLogProc = ActivityLogWriter.CreateUpdateActivityLogStoredProcedure(activityLog);
                        }

                        // Verify updateActivityLogProc exists
                        if(updateActivityLogProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ActivityLogManager.UpdateActivityLog(updateActivityLogProc, dataConnector);

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
