

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

    #region class FeedbackController
    /// <summary>
    /// This class controls a(n) 'Feedback' object.
    /// </summary>
    public class FeedbackController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'FeedbackController' object.
        /// </summary>
        public FeedbackController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateFeedbackParameter
            /// <summary>
            /// This method creates the parameter for a 'Feedback' data operation.
            /// </summary>
            /// <param name='feedback'>The 'Feedback' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateFeedbackParameter(Feedback feedback)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = feedback;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Feedback tempFeedback)
            /// <summary>
            /// Deletes a 'Feedback' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Feedback_Delete'.
            /// </summary>
            /// <param name='feedback'>The 'Feedback' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Feedback tempFeedback)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteFeedback";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempfeedback exists before attemptintg to delete
                    if(tempFeedback != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteFeedbackMethod = this.AppController.DataBridge.DataOperations.FeedbackMethods.DeleteFeedback;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFeedbackParameter(tempFeedback);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteFeedbackMethod, parameters);

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

            #region FetchAll(Feedback tempFeedback)
            /// <summary>
            /// This method fetches a collection of 'Feedback' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Feedback_FetchAll'.</summary>
            /// <param name='tempFeedback'>A temporary Feedback for passing values.</param>
            /// <returns>A collection of 'Feedback' objects.</returns>
            public List<Feedback> FetchAll(Feedback tempFeedback)
            {
                // Initial value
                List<Feedback> feedbackList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.FeedbackMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFeedbackParameter(tempFeedback);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Feedback> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        feedbackList = (List<Feedback>) returnObject.ObjectValue;
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
                return feedbackList;
            }
            #endregion

            #region Find(Feedback tempFeedback)
            /// <summary>
            /// Finds a 'Feedback' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Feedback_Find'</param>
            /// </summary>
            /// <param name='tempFeedback'>A temporary Feedback for passing values.</param>
            /// <returns>A 'Feedback' object if found else a null 'Feedback'.</returns>
            public Feedback Find(Feedback tempFeedback)
            {
                // Initial values
                Feedback feedback = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempFeedback != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.FeedbackMethods.FindFeedback;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFeedbackParameter(tempFeedback);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Feedback != null))
                        {
                            // Get ReturnObject
                            feedback = (Feedback) returnObject.ObjectValue;
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
                return feedback;
            }
            #endregion

            #region Insert(Feedback feedback)
            /// <summary>
            /// Insert a 'Feedback' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Feedback_Insert'.</param>
            /// </summary>
            /// <param name='feedback'>The 'Feedback' object to insert.</param>
            /// <returns>The id (int) of the new  'Feedback' object that was inserted.</returns>
            public int Insert(Feedback feedback)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Feedbackexists
                    if(feedback != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.FeedbackMethods.InsertFeedback;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFeedbackParameter(feedback);

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

            #region Save(ref Feedback feedback)
            /// <summary>
            /// Saves a 'Feedback' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='feedback'>The 'Feedback' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Feedback feedback)
            {
                // Initial value
                bool saved = false;

                // If the feedback exists.
                if(feedback != null)
                {
                    // Is this a new Feedback
                    if(feedback.IsNew)
                    {
                        // Insert new Feedback
                        int newIdentity = this.Insert(feedback);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            feedback.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Feedback
                        saved = this.Update(feedback);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Feedback feedback)
            /// <summary>
            /// This method Updates a 'Feedback' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Feedback_Update'.</param>
            /// </summary>
            /// <param name='feedback'>The 'Feedback' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Feedback feedback)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(feedback != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.FeedbackMethods.UpdateFeedback;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateFeedbackParameter(feedback);
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
