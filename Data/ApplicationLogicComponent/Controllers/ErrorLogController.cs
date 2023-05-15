

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

    #region class ErrorLogController
    /// <summary>
    /// This class controls a(n) 'ErrorLog' object.
    /// </summary>
    public class ErrorLogController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ErrorLogController' object.
        /// </summary>
        public ErrorLogController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateErrorLogParameter
            /// <summary>
            /// This method creates the parameter for a 'ErrorLog' data operation.
            /// </summary>
            /// <param name='errorlog'>The 'ErrorLog' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateErrorLogParameter(ErrorLog errorLog)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = errorLog;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ErrorLog tempErrorLog)
            /// <summary>
            /// Deletes a 'ErrorLog' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'ErrorLog_Delete'.
            /// </summary>
            /// <param name='errorlog'>The 'ErrorLog' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(ErrorLog tempErrorLog)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteErrorLog";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify temperrorLog exists before attemptintg to delete
                    if(tempErrorLog != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteErrorLogMethod = this.AppController.DataBridge.DataOperations.ErrorLogMethods.DeleteErrorLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateErrorLogParameter(tempErrorLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteErrorLogMethod, parameters);

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

            #region FetchAll(ErrorLog tempErrorLog)
            /// <summary>
            /// This method fetches a collection of 'ErrorLog' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ErrorLog_FetchAll'.</summary>
            /// <param name='tempErrorLog'>A temporary ErrorLog for passing values.</param>
            /// <returns>A collection of 'ErrorLog' objects.</returns>
            public List<ErrorLog> FetchAll(ErrorLog tempErrorLog)
            {
                // Initial value
                List<ErrorLog> errorLogList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ErrorLogMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateErrorLogParameter(tempErrorLog);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ErrorLog> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        errorLogList = (List<ErrorLog>) returnObject.ObjectValue;
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
                return errorLogList;
            }
            #endregion

            #region Find(ErrorLog tempErrorLog)
            /// <summary>
            /// Finds a 'ErrorLog' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ErrorLog_Find'</param>
            /// </summary>
            /// <param name='tempErrorLog'>A temporary ErrorLog for passing values.</param>
            /// <returns>A 'ErrorLog' object if found else a null 'ErrorLog'.</returns>
            public ErrorLog Find(ErrorLog tempErrorLog)
            {
                // Initial values
                ErrorLog errorLog = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempErrorLog != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ErrorLogMethods.FindErrorLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateErrorLogParameter(tempErrorLog);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ErrorLog != null))
                        {
                            // Get ReturnObject
                            errorLog = (ErrorLog) returnObject.ObjectValue;
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
                return errorLog;
            }
            #endregion

            #region Insert(ErrorLog errorLog)
            /// <summary>
            /// Insert a 'ErrorLog' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ErrorLog_Insert'.</param>
            /// </summary>
            /// <param name='errorLog'>The 'ErrorLog' object to insert.</param>
            /// <returns>The id (int) of the new  'ErrorLog' object that was inserted.</returns>
            public int Insert(ErrorLog errorLog)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ErrorLogexists
                    if(errorLog != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ErrorLogMethods.InsertErrorLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateErrorLogParameter(errorLog);

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

            #region Save(ref ErrorLog errorLog)
            /// <summary>
            /// Saves a 'ErrorLog' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='errorLog'>The 'ErrorLog' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref ErrorLog errorLog)
            {
                // Initial value
                bool saved = false;

                // If the errorLog exists.
                if(errorLog != null)
                {
                    // Is this a new ErrorLog
                    if(errorLog.IsNew)
                    {
                        // Insert new ErrorLog
                        int newIdentity = this.Insert(errorLog);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            errorLog.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ErrorLog
                        saved = this.Update(errorLog);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ErrorLog errorLog)
            /// <summary>
            /// This method Updates a 'ErrorLog' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ErrorLog_Update'.</param>
            /// </summary>
            /// <param name='errorLog'>The 'ErrorLog' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(ErrorLog errorLog)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(errorLog != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ErrorLogMethods.UpdateErrorLog;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateErrorLogParameter(errorLog);
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
