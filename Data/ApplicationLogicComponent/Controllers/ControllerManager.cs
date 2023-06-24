

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

    #region class ControllerManager
    /// <summary>
    /// This class manages the child controllers for this application.
    /// </summary>
    public class ControllerManager
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        private ActivityLogController activitylogController;
        private AdminController adminController;
        private ErrorLogController errorlogController;
        private FolderController folderController;
        private ImageController imageController;
        private MainGalleryViewController maingalleryviewController;
        private UserController userController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControllerManager' object.
        /// </summary>
        public ControllerManager(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;

            // Create Child Controllers
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child Controllers
            /// </summary>
            private void Init()
            {
                // Create Child Controllers
                this.ActivityLogController = new ActivityLogController(this.ErrorProcessor, this.AppController);
                this.AdminController = new AdminController(this.ErrorProcessor, this.AppController);
                this.ErrorLogController = new ErrorLogController(this.ErrorProcessor, this.AppController);
                this.FolderController = new FolderController(this.ErrorProcessor, this.AppController);
                this.ImageController = new ImageController(this.ErrorProcessor, this.AppController);
                this.MainGalleryViewController = new MainGalleryViewController(this.ErrorProcessor, this.AppController);
                this.UserController = new UserController(this.ErrorProcessor, this.AppController);
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

            #region ActivityLogController
            public ActivityLogController ActivityLogController
            {
                get { return activitylogController; }
                set { activitylogController = value; }
            }
            #endregion

            #region AdminController
            public AdminController AdminController
            {
                get { return adminController; }
                set { adminController = value; }
            }
            #endregion

            #region ErrorLogController
            public ErrorLogController ErrorLogController
            {
                get { return errorlogController; }
                set { errorlogController = value; }
            }
            #endregion

            #region FolderController
            public FolderController FolderController
            {
                get { return folderController; }
                set { folderController = value; }
            }
            #endregion

            #region ImageController
            public ImageController ImageController
            {
                get { return imageController; }
                set { imageController = value; }
            }
            #endregion

            #region MainGalleryViewController
            public MainGalleryViewController MainGalleryViewController
            {
                get { return maingalleryviewController; }
                set { maingalleryviewController = value; }
            }
            #endregion

            #region UserController
            public UserController UserController
            {
                get { return userController; }
                set { userController = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
