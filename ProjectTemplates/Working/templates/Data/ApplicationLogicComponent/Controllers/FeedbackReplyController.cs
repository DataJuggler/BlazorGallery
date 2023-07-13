

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

    #region class FeedbackReplyController
    /// <summary>
    /// This class controls a(n) 'FeedbackReply' object.
    /// </summary>
    public class FeedbackReplyController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'FeedbackReplyController' object.
        /// </summary>
        public FeedbackReplyController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateFeedbackReplyParameter
            /// <summary>
            /// This method creates the parameter for a 'FeedbackReply' data operation.
            /// </summary>
            /// <param name='feedbackreply'>The 'FeedbackReply' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateFeedbackReplyParameter(FeedbackReply feedbackReply)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = feedbackReply;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(FeedbackReply tempFeedbackReply)
            /// <summary>
            /// Deletes a 'FeedbackReply' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'FeedbackReply_Delete'.
            /// </summary>
            /// <param name='feedbackreply'>The 'FeedbackReply' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(FeedbackReply tempFeedbackReply)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteFeedbackReply";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempfeedbackReply exists before attemptintg to delete
                    if(tempFeedbackReply != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteFeedbackReplyMethod = this.AppController.DataBridge.DataOperations.FeedbackReplyMethods.DeleteFeedbackReply;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFeedbackReplyParameter(tempFeedbackReply);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteFeedbackReplyMethod, parameters);

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

            #region FetchAll(FeedbackReply tempFeedbackReply)
            /// <summary>
            /// This method fetches a collection of 'FeedbackReply' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'FeedbackReply_FetchAll'.</summary>
            /// <param name='tempFeedbackReply'>A temporary FeedbackReply for passing values.</param>
            /// <returns>A collection of 'FeedbackReply' objects.</returns>
            public List<FeedbackReply> FetchAll(FeedbackReply tempFeedbackReply)
            {
                // Initial value
                List<FeedbackReply> feedbackReplyList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.FeedbackReplyMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFeedbackReplyParameter(tempFeedbackReply);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<FeedbackReply> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        feedbackReplyList = (List<FeedbackReply>) returnObject.ObjectValue;
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
                return feedbackReplyList;
            }
            #endregion

            #region Find(FeedbackReply tempFeedbackReply)
            /// <summary>
            /// Finds a 'FeedbackReply' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'FeedbackReply_Find'</param>
            /// </summary>
            /// <param name='tempFeedbackReply'>A temporary FeedbackReply for passing values.</param>
            /// <returns>A 'FeedbackReply' object if found else a null 'FeedbackReply'.</returns>
            public FeedbackReply Find(FeedbackReply tempFeedbackReply)
            {
                // Initial values
                FeedbackReply feedbackReply = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempFeedbackReply != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.FeedbackReplyMethods.FindFeedbackReply;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFeedbackReplyParameter(tempFeedbackReply);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as FeedbackReply != null))
                        {
                            // Get ReturnObject
                            feedbackReply = (FeedbackReply) returnObject.ObjectValue;
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
                return feedbackReply;
            }
            #endregion

            #region Insert(FeedbackReply feedbackReply)
            /// <summary>
            /// Insert a 'FeedbackReply' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'FeedbackReply_Insert'.</param>
            /// </summary>
            /// <param name='feedbackReply'>The 'FeedbackReply' object to insert.</param>
            /// <returns>The id (int) of the new  'FeedbackReply' object that was inserted.</returns>
            public int Insert(FeedbackReply feedbackReply)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If FeedbackReplyexists
                    if(feedbackReply != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.FeedbackReplyMethods.InsertFeedbackReply;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFeedbackReplyParameter(feedbackReply);

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

            #region Save(ref FeedbackReply feedbackReply)
            /// <summary>
            /// Saves a 'FeedbackReply' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='feedbackReply'>The 'FeedbackReply' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref FeedbackReply feedbackReply)
            {
                // Initial value
                bool saved = false;

                // If the feedbackReply exists.
                if(feedbackReply != null)
                {
                    // Is this a new FeedbackReply
                    if(feedbackReply.IsNew)
                    {
                        // Insert new FeedbackReply
                        int newIdentity = this.Insert(feedbackReply);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            feedbackReply.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update FeedbackReply
                        saved = this.Update(feedbackReply);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(FeedbackReply feedbackReply)
            /// <summary>
            /// This method Updates a 'FeedbackReply' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'FeedbackReply_Update'.</param>
            /// </summary>
            /// <param name='feedbackReply'>The 'FeedbackReply' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(FeedbackReply feedbackReply)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(feedbackReply != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.FeedbackReplyMethods.UpdateFeedbackReply;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFeedbackReplyParameter(feedbackReply);
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
