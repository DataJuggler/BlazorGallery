

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

    #region class ImageLikeController
    /// <summary>
    /// This class controls a(n) 'ImageLike' object.
    /// </summary>
    public class ImageLikeController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ImageLikeController' object.
        /// </summary>
        public ImageLikeController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateImageLikeParameter
            /// <summary>
            /// This method creates the parameter for a 'ImageLike' data operation.
            /// </summary>
            /// <param name='imagelike'>The 'ImageLike' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateImageLikeParameter(ImageLike imageLike)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = imageLike;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(ImageLike tempImageLike)
            /// <summary>
            /// Deletes a 'ImageLike' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'ImageLike_Delete'.
            /// </summary>
            /// <param name='imagelike'>The 'ImageLike' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(ImageLike tempImageLike)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteImageLike";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempimageLike exists before attemptintg to delete
                    if(tempImageLike != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteImageLikeMethod = this.AppController.DataBridge.DataOperations.ImageLikeMethods.DeleteImageLike;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateImageLikeParameter(tempImageLike);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteImageLikeMethod, parameters);

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

            #region FetchAll(ImageLike tempImageLike)
            /// <summary>
            /// This method fetches a collection of 'ImageLike' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ImageLike_FetchAll'.</summary>
            /// <param name='tempImageLike'>A temporary ImageLike for passing values.</param>
            /// <returns>A collection of 'ImageLike' objects.</returns>
            public List<ImageLike> FetchAll(ImageLike tempImageLike)
            {
                // Initial value
                List<ImageLike> imageLikeList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ImageLikeMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateImageLikeParameter(tempImageLike);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ImageLike> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        imageLikeList = (List<ImageLike>) returnObject.ObjectValue;
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
                return imageLikeList;
            }
            #endregion

            #region Find(ImageLike tempImageLike)
            /// <summary>
            /// Finds a 'ImageLike' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'ImageLike_Find'</param>
            /// </summary>
            /// <param name='tempImageLike'>A temporary ImageLike for passing values.</param>
            /// <returns>A 'ImageLike' object if found else a null 'ImageLike'.</returns>
            public ImageLike Find(ImageLike tempImageLike)
            {
                // Initial values
                ImageLike imageLike = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempImageLike != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.ImageLikeMethods.FindImageLike;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateImageLikeParameter(tempImageLike);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as ImageLike != null))
                        {
                            // Get ReturnObject
                            imageLike = (ImageLike) returnObject.ObjectValue;
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
                return imageLike;
            }
            #endregion

            #region Insert(ImageLike imageLike)
            /// <summary>
            /// Insert a 'ImageLike' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'ImageLike_Insert'.</param>
            /// </summary>
            /// <param name='imageLike'>The 'ImageLike' object to insert.</param>
            /// <returns>The id (int) of the new  'ImageLike' object that was inserted.</returns>
            public int Insert(ImageLike imageLike)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If ImageLikeexists
                    if(imageLike != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.ImageLikeMethods.InsertImageLike;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateImageLikeParameter(imageLike);

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

            #region Save(ref ImageLike imageLike)
            /// <summary>
            /// Saves a 'ImageLike' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='imageLike'>The 'ImageLike' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref ImageLike imageLike)
            {
                // Initial value
                bool saved = false;

                // If the imageLike exists.
                if(imageLike != null)
                {
                    // Is this a new ImageLike
                    if(imageLike.IsNew)
                    {
                        // Insert new ImageLike
                        int newIdentity = this.Insert(imageLike);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            imageLike.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update ImageLike
                        saved = this.Update(imageLike);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(ImageLike imageLike)
            /// <summary>
            /// This method Updates a 'ImageLike' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'ImageLike_Update'.</param>
            /// </summary>
            /// <param name='imageLike'>The 'ImageLike' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(ImageLike imageLike)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(imageLike != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.ImageLikeMethods.UpdateImageLike;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateImageLikeParameter(imageLike);
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
