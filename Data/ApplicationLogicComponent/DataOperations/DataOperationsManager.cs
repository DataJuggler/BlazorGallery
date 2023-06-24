

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

    #region class DataOperationsManager
    /// <summary>
    /// This class manages DataOperations for this project.
    /// </summary>
    public class DataOperationsManager
    {

        #region Private Variables
        private DataManager dataManager;
        private SystemMethods systemMethods;
        private ActivityLogMethods activitylogMethods;
        private AdminMethods adminMethods;
        private ErrorLogMethods errorlogMethods;
        private FolderMethods folderMethods;
        private ImageMethods imageMethods;
        private MainGalleryViewMethods maingalleryviewMethods;
        private UserMethods userMethods;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DataOperationsManager' object.
        /// </summary>
        public DataOperationsManager(DataManager dataManagerArg)
        {
            // Save Arguments
            this.DataManager = dataManagerArg;

            // Create Child DataOperationMethods
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child DataOperationMethods
            /// </summary>
            private void Init()
            {
                // Create Child DataOperatonMethods
                this.SystemMethods = new SystemMethods();
                this.ActivityLogMethods = new ActivityLogMethods(this.DataManager);
                this.AdminMethods = new AdminMethods(this.DataManager);
                this.ErrorLogMethods = new ErrorLogMethods(this.DataManager);
                this.FolderMethods = new FolderMethods(this.DataManager);
                this.ImageMethods = new ImageMethods(this.DataManager);
                this.MainGalleryViewMethods = new MainGalleryViewMethods(this.DataManager);
                this.UserMethods = new UserMethods(this.DataManager);
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

            #region SystemMethods
            public SystemMethods SystemMethods
            {
                get { return systemMethods; }
                set { systemMethods = value; }
            }
            #endregion

            #region ActivityLogMethods
            public ActivityLogMethods ActivityLogMethods
            {
                get { return activitylogMethods; }
                set { activitylogMethods = value; }
            }
            #endregion

            #region AdminMethods
            public AdminMethods AdminMethods
            {
                get { return adminMethods; }
                set { adminMethods = value; }
            }
            #endregion

            #region ErrorLogMethods
            public ErrorLogMethods ErrorLogMethods
            {
                get { return errorlogMethods; }
                set { errorlogMethods = value; }
            }
            #endregion

            #region FolderMethods
            public FolderMethods FolderMethods
            {
                get { return folderMethods; }
                set { folderMethods = value; }
            }
            #endregion

            #region ImageMethods
            public ImageMethods ImageMethods
            {
                get { return imageMethods; }
                set { imageMethods = value; }
            }
            #endregion

            #region MainGalleryViewMethods
            public MainGalleryViewMethods MainGalleryViewMethods
            {
                get { return maingalleryviewMethods; }
                set { maingalleryviewMethods = value; }
            }
            #endregion

            #region UserMethods
            public UserMethods UserMethods
            {
                get { return userMethods; }
                set { userMethods = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
