

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

    #region class FolderMethods
    /// <summary>
    /// This class contains methods for modifying a 'Folder' object.
    /// </summary>
    public class FolderMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'FolderMethods' object.
        /// </summary>
        public FolderMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteFolder(Folder)
            /// <summary>
            /// This method deletes a 'Folder' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Folder' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteFolder(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteFolderStoredProcedure deleteFolderProc = null;

                    // verify the first parameters is a(n) 'Folder'.
                    if (parameters[0].ObjectValue as Folder != null)
                    {
                        // Create Folder
                        Folder folder = (Folder) parameters[0].ObjectValue;

                        // verify folder exists
                        if(folder != null)
                        {
                            // Now create deleteFolderProc from FolderWriter
                            // The DataWriter converts the 'Folder'
                            // to the SqlParameter[] array needed to delete a 'Folder'.
                            deleteFolderProc = FolderWriter.CreateDeleteFolderStoredProcedure(folder);
                        }
                    }

                    // Verify deleteFolderProc exists
                    if(deleteFolderProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.FolderManager.DeleteFolder(deleteFolderProc, dataConnector);

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
            /// This method fetches all 'Folder' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Folder' to delete.
            /// <returns>A PolymorphicObject object with all  'Folders' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Folder> folderListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllFoldersStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get FolderParameter
                    // Declare Parameter
                    Folder paramFolder = null;

                    // verify the first parameters is a(n) 'Folder'.
                    if (parameters[0].ObjectValue as Folder != null)
                    {
                        // Get FolderParameter
                        paramFolder = (Folder) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllFoldersProc from FolderWriter
                    fetchAllProc = FolderWriter.CreateFetchAllFoldersStoredProcedure(paramFolder);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    folderListCollection = this.DataManager.FolderManager.FetchAllFolders(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(folderListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = folderListCollection;
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

            #region FindFolder(Folder)
            /// <summary>
            /// This method finds a 'Folder' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Folder' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindFolder(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Folder folder = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindFolderStoredProcedure findFolderProc = null;

                    // verify the first parameters is a 'Folder'.
                    if (parameters[0].ObjectValue as Folder != null)
                    {
                        // Get FolderParameter
                        Folder paramFolder = (Folder) parameters[0].ObjectValue;

                        // verify paramFolder exists
                        if(paramFolder != null)
                        {
                            // Now create findFolderProc from FolderWriter
                            // The DataWriter converts the 'Folder'
                            // to the SqlParameter[] array needed to find a 'Folder'.
                            findFolderProc = FolderWriter.CreateFindFolderStoredProcedure(paramFolder);
                        }

                        // Verify findFolderProc exists
                        if(findFolderProc != null)
                        {
                            // Execute Find Stored Procedure
                            folder = this.DataManager.FolderManager.FindFolder(findFolderProc, dataConnector);

                            // if dataObject exists
                            if(folder != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = folder;
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

            #region InsertFolder (Folder)
            /// <summary>
            /// This method inserts a 'Folder' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Folder' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertFolder(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Folder folder = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertFolderStoredProcedure insertFolderProc = null;

                    // verify the first parameters is a(n) 'Folder'.
                    if (parameters[0].ObjectValue as Folder != null)
                    {
                        // Create Folder Parameter
                        folder = (Folder) parameters[0].ObjectValue;

                        // verify folder exists
                        if(folder != null)
                        {
                            // Now create insertFolderProc from FolderWriter
                            // The DataWriter converts the 'Folder'
                            // to the SqlParameter[] array needed to insert a 'Folder'.
                            insertFolderProc = FolderWriter.CreateInsertFolderStoredProcedure(folder);
                        }

                        // Verify insertFolderProc exists
                        if(insertFolderProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.FolderManager.InsertFolder(insertFolderProc, dataConnector);
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

            #region UpdateFolder (Folder)
            /// <summary>
            /// This method updates a 'Folder' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Folder' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateFolder(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Folder folder = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateFolderStoredProcedure updateFolderProc = null;

                    // verify the first parameters is a(n) 'Folder'.
                    if (parameters[0].ObjectValue as Folder != null)
                    {
                        // Create Folder Parameter
                        folder = (Folder) parameters[0].ObjectValue;

                        // verify folder exists
                        if(folder != null)
                        {
                            // Now create updateFolderProc from FolderWriter
                            // The DataWriter converts the 'Folder'
                            // to the SqlParameter[] array needed to update a 'Folder'.
                            updateFolderProc = FolderWriter.CreateUpdateFolderStoredProcedure(folder);
                        }

                        // Verify updateFolderProc exists
                        if(updateFolderProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.FolderManager.UpdateFolder(updateFolderProc, dataConnector);

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
