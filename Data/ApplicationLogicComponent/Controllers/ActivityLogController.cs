

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class ActivityLogController
    /// <summary>
    /// This class controls a(n) 'ActivityLog' object.
    /// </summary>
    public class ActivityLogController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ActivityLogController' object.
        /// </summary>
        public ActivityLogController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateActivityLogParameter
            /// <summary>
            /// This method creates the parameter for a 'ActivityLog' data operation.
            /// </summary>
            /// <param name='activitylog'>The 'ActivityLog' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateActivityLogParameter(ActivityLog activityLog)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = activityLog;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ActivityLog tempActivityLog)
            /// <summary>
            /// Deletes a 'ActivityLog' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'ActivityLog_Delete'.
            /// </summary>
            /// <param name='activitylog'>The 'ActivityLog' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(ActivityLog tempActivityLog)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteActivityLog";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempactivityLog exists before attemptintg to delete
                    if(tempActivityLog != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteActivityLogMethod = this.AppController.DataBridge.DataOperations.ActivityLogMethods.DeleteActivityLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateActivityLogParameter(tempActivityLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteActivityLogMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(ActivityLog tempActivityLog)
            /// <summary>
            /// This method fetches a collection of 'ActivityLog' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ActivityLog_FetchAll'.</summary>
            /// <param name='tempActivityLog'>A temporary ActivityLog for passing values.</param>
            /// <returns>A collection of 'ActivityLog' objects.</returns>
            public List<ActivityLog> FetchAll(ActivityLog tempActivityLog)
            {
                // Initial value
                List<ActivityLog> activityLogList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ActivityLogMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateActivityLogParameter(tempActivityLog);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ActivityLog> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        activityLogList = (List<ActivityLog>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return activityLogList;
            }
            #endregion

            #region Find(ActivityLog tempActivityLog)
            /// <summary>
            /// Finds a 'ActivityLog' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ActivityLog_Find'</param>
            /// </summary>
            /// <param name='tempActivityLog'>A temporary ActivityLog for passing values.</param>
            /// <returns>A 'ActivityLog' object if found else a null 'ActivityLog'.</returns>
            public ActivityLog Find(ActivityLog tempActivityLog)
            {
                // Initial values
                ActivityLog activityLog = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempActivityLog != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ActivityLogMethods.FindActivityLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateActivityLogParameter(tempActivityLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ActivityLog != null))
                        {
                            // Get ReturnObject
                            activityLog = (ActivityLog) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return activityLog;
            }
            #endregion

            #region Insert(ActivityLog activityLog)
            /// <summary>
            /// Insert a 'ActivityLog' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ActivityLog_Insert'.</param>
            /// </summary>
            /// <param name='activityLog'>The 'ActivityLog' object to insert.</param>
            /// <returns>The id (int) of the new  'ActivityLog' object that was inserted.</returns>
            public int Insert(ActivityLog activityLog)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ActivityLogexists
                    if(activityLog != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ActivityLogMethods.InsertActivityLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateActivityLogParameter(activityLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref ActivityLog activityLog)
            /// <summary>
            /// Saves a 'ActivityLog' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='activityLog'>The 'ActivityLog' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref ActivityLog activityLog)
            {
                // Initial value
                bool saved = false;

                // If the activityLog exists.
                if(activityLog != null)
                {
                    // Is this a new ActivityLog
                    if(activityLog.IsNew)
                    {
                        // Insert new ActivityLog
                        int newIdentity = this.Insert(activityLog);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            activityLog.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ActivityLog
                        saved = this.Update(activityLog);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ActivityLog activityLog)
            /// <summary>
            /// This method Updates a 'ActivityLog' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ActivityLog_Update'.</param>
            /// </summary>
            /// <param name='activityLog'>The 'ActivityLog' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(ActivityLog activityLog)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(activityLog != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ActivityLogMethods.UpdateActivityLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateActivityLogParameter(activityLog);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
