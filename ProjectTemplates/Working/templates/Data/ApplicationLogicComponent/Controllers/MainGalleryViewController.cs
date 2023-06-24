

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

    #region class MainGalleryViewController
    /// <summary>
    /// This class controls a(n) 'MainGalleryView' object.
    /// </summary>
    public class MainGalleryViewController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'MainGalleryViewController' object.
        /// </summary>
        public MainGalleryViewController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateMainGalleryViewParameter
            /// <summary>
            /// This method creates the parameter for a 'MainGalleryView' data operation.
            /// </summary>
            /// <param name='maingalleryview'>The 'MainGalleryView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateMainGalleryViewParameter(MainGalleryView mainGalleryView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = mainGalleryView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(MainGalleryView tempMainGalleryView)
            /// <summary>
            /// This method fetches a collection of 'MainGalleryView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'MainGalleryView_FetchAll'.</summary>
            /// <param name='tempMainGalleryView'>A temporary MainGalleryView for passing values.</param>
            /// <returns>A collection of 'MainGalleryView' objects.</returns>
            public List<MainGalleryView> FetchAll(MainGalleryView tempMainGalleryView)
            {
                // Initial value
                List<MainGalleryView> mainGalleryViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.MainGalleryViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateMainGalleryViewParameter(tempMainGalleryView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<MainGalleryView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        mainGalleryViewList = (List<MainGalleryView>) returnObject.ObjectValue;
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
                return mainGalleryViewList;
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
