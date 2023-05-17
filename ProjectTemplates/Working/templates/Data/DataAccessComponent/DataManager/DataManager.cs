

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

    #region class DataManager
    /// <summary>
    /// This class manages data operations for this project.
    /// </summary>
    public class DataManager
    {

        #region Private Variables
        private DataConnector dataConnector;
        private string connectionName;
        private ActivityLogManager activitylogManager;
        private AdminManager adminManager;
        private ErrorLogManager errorlogManager;
        private FolderManager folderManager;
        private ImageManager imageManager;
        private UserManager userManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of a(n) 'DataManager' object.
        /// </summary>
        public DataManager(string connectionName = "")
        {
            // Store the ConnectionName arg
            this.ConnectionName = connectionName;

            // Perform Initializations For This Object.
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Perform Initializations For This Object.
            /// Create the DataConnector and the Child Object Managers.
            /// </summary>
            private void Init()
            {
                // Create New DataConnector
                this.DataConnector = new DataConnector();

                // Create Child Object Managers
                this.ActivityLogManager = new ActivityLogManager(this);
                this.AdminManager = new AdminManager(this);
                this.ErrorLogManager = new ErrorLogManager(this);
                this.FolderManager = new FolderManager(this);
                this.ImageManager = new ImageManager(this);
                this.UserManager = new UserManager(this);
            }
            #endregion

        #endregion

        #region Properties

            #region DataConnector
            public DataConnector DataConnector
            {
                get { return dataConnector; }
                set { dataConnector = value; }
            }
            #endregion

            #region ConnectionName
            public string ConnectionName
            {
                get { return connectionName; }
                set { connectionName = value; }
            }
            #endregion

            #region ActivityLogManager
            public ActivityLogManager ActivityLogManager
            {
                get { return activitylogManager; }
                set { activitylogManager = value; }
            }
            #endregion

            #region AdminManager
            public AdminManager AdminManager
            {
                get { return adminManager; }
                set { adminManager = value; }
            }
            #endregion

            #region ErrorLogManager
            public ErrorLogManager ErrorLogManager
            {
                get { return errorlogManager; }
                set { errorlogManager = value; }
            }
            #endregion

            #region FolderManager
            public FolderManager FolderManager
            {
                get { return folderManager; }
                set { folderManager = value; }
            }
            #endregion

            #region ImageManager
            public ImageManager ImageManager
            {
                get { return imageManager; }
                set { imageManager = value; }
            }
            #endregion

            #region UserManager
            public UserManager UserManager
            {
                get { return userManager; }
                set { userManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
