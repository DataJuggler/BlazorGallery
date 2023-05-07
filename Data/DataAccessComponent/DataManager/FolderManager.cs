

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

    #region class FolderManager
    /// <summary>
    /// This class is used to manage a 'Folder' object.
    /// </summary>
    public class FolderManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FolderManager' object.
        /// </summary>
        public FolderManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteFolder()
            /// <summary>
            /// This method deletes a 'Folder' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteFolder(DeleteFolderStoredProcedure deleteFolderProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteFolderProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllFolders()
            /// <summary>
            /// This method fetches a  'List<Folder>' object.
            /// This method uses the 'Folders_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Folder>'</returns>
            /// </summary>
            public List<Folder> FetchAllFolders(FetchAllFoldersStoredProcedure fetchAllFoldersProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Folder> folderCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allFoldersDataSet = this.DataHelper.LoadDataSet(fetchAllFoldersProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allFoldersDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allFoldersDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            folderCollection = FolderReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return folderCollection;
            }
            #endregion

            #region FindFolder()
            /// <summary>
            /// This method finds a  'Folder' object.
            /// This method uses the 'Folder_Find' procedure.
            /// </summary>
            /// <returns>A 'Folder' object.</returns>
            /// </summary>
            public Folder FindFolder(FindFolderStoredProcedure findFolderProc, DataConnector databaseConnector)
            {
                // Initial Value
                Folder folder = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet folderDataSet = this.DataHelper.LoadDataSet(findFolderProc, databaseConnector);

                    // Verify DataSet Exists
                    if(folderDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(folderDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Folder
                            folder = FolderReader.Load(row);
                        }
                    }
                }

                // return value
                return folder;
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

            #region InsertFolder()
            /// <summary>
            /// This method inserts a 'Folder' object.
            /// This method uses the 'Folder_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertFolder(InsertFolderStoredProcedure insertFolderProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertFolderProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateFolder()
            /// <summary>
            /// This method updates a 'Folder'.
            /// This method uses the 'Folder_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateFolder(UpdateFolderStoredProcedure updateFolderProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateFolderProc, databaseConnector);
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
