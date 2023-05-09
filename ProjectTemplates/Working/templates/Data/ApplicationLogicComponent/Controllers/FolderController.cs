

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

    #region class FolderController
    /// <summary>
    /// This class controls a(n) 'Folder' object.
    /// </summary>
    public class FolderController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'FolderController' object.
        /// </summary>
        public FolderController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateFolderParameter
            /// <summary>
            /// This method creates the parameter for a 'Folder' data operation.
            /// </summary>
            /// <param name='folder'>The 'Folder' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateFolderParameter(Folder folder)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = folder;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Folder tempFolder)
            /// <summary>
            /// Deletes a 'Folder' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Folder_Delete'.
            /// </summary>
            /// <param name='folder'>The 'Folder' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Folder tempFolder)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteFolder";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempfolder exists before attemptintg to delete
                    if(tempFolder != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteFolderMethod = this.AppController.DataBridge.DataOperations.FolderMethods.DeleteFolder;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFolderParameter(tempFolder);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteFolderMethod, parameters);

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

            #region FetchAll(Folder tempFolder)
            /// <summary>
            /// This method fetches a collection of 'Folder' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Folder_FetchAll'.</summary>
            /// <param name='tempFolder'>A temporary Folder for passing values.</param>
            /// <returns>A collection of 'Folder' objects.</returns>
            public List<Folder> FetchAll(Folder tempFolder)
            {
                // Initial value
                List<Folder> folderList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.FolderMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFolderParameter(tempFolder);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Folder> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        folderList = (List<Folder>) returnObject.ObjectValue;
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
                return folderList;
            }
            #endregion

            #region Find(Folder tempFolder)
            /// <summary>
            /// Finds a 'Folder' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Folder_Find'</param>
            /// </summary>
            /// <param name='tempFolder'>A temporary Folder for passing values.</param>
            /// <returns>A 'Folder' object if found else a null 'Folder'.</returns>
            public Folder Find(Folder tempFolder)
            {
                // Initial values
                Folder folder = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempFolder != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.FolderMethods.FindFolder;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFolderParameter(tempFolder);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Folder != null))
                        {
                            // Get ReturnObject
                            folder = (Folder) returnObject.ObjectValue;
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
                return folder;
            }
            #endregion

            #region Insert(Folder folder)
            /// <summary>
            /// Insert a 'Folder' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Folder_Insert'.</param>
            /// </summary>
            /// <param name='folder'>The 'Folder' object to insert.</param>
            /// <returns>The id (int) of the new  'Folder' object that was inserted.</returns>
            public int Insert(Folder folder)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Folderexists
                    if(folder != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.FolderMethods.InsertFolder;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFolderParameter(folder);

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

            #region Save(ref Folder folder)
            /// <summary>
            /// Saves a 'Folder' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='folder'>The 'Folder' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Folder folder)
            {
                // Initial value
                bool saved = false;

                // If the folder exists.
                if(folder != null)
                {
                    // Is this a new Folder
                    if(folder.IsNew)
                    {
                        // Insert new Folder
                        int newIdentity = this.Insert(folder);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            folder.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Folder
                        saved = this.Update(folder);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Folder folder)
            /// <summary>
            /// This method Updates a 'Folder' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Folder_Update'.</param>
            /// </summary>
            /// <param name='folder'>The 'Folder' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Folder folder)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(folder != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.FolderMethods.UpdateFolder;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFolderParameter(folder);
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
