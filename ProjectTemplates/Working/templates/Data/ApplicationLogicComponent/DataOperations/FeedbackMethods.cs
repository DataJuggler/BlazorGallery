

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

    #region class FeedbackMethods
    /// <summary>
    /// This class contains methods for modifying a 'Feedback' object.
    /// </summary>
    public class FeedbackMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'FeedbackMethods' object.
        /// </summary>
        public FeedbackMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteFeedback(Feedback)
            /// <summary>
            /// This method deletes a 'Feedback' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Feedback' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteFeedback(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteFeedbackStoredProcedure deleteFeedbackProc = null;

                    // verify the first parameters is a(n) 'Feedback'.
                    if (parameters[0].ObjectValue as Feedback != null)
                    {
                        // Create Feedback
                        Feedback feedback = (Feedback) parameters[0].ObjectValue;

                        // verify feedback exists
                        if(feedback != null)
                        {
                            // Now create deleteFeedbackProc from FeedbackWriter
                            // The DataWriter converts the 'Feedback'
                            // to the SqlParameter[] array needed to delete a 'Feedback'.
                            deleteFeedbackProc = FeedbackWriter.CreateDeleteFeedbackStoredProcedure(feedback);
                        }
                    }

                    // Verify deleteFeedbackProc exists
                    if(deleteFeedbackProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.FeedbackManager.DeleteFeedback(deleteFeedbackProc, dataConnector);

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
            /// This method fetches all 'Feedback' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Feedback' to delete.
            /// <returns>A PolymorphicObject object with all  'Feedbacks' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<Feedback> feedbackListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllFeedbacksStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get FeedbackParameter
                    // Declare Parameter
                    Feedback paramFeedback = null;

                    // verify the first parameters is a(n) 'Feedback'.
                    if (parameters[0].ObjectValue as Feedback != null)
                    {
                        // Get FeedbackParameter
                        paramFeedback = (Feedback) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllFeedbacksProc from FeedbackWriter
                    fetchAllProc = FeedbackWriter.CreateFetchAllFeedbacksStoredProcedure(paramFeedback);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    feedbackListCollection = this.DataManager.FeedbackManager.FetchAllFeedbacks(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(feedbackListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = feedbackListCollection;
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

            #region FindFeedback(Feedback)
            /// <summary>
            /// This method finds a 'Feedback' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Feedback' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindFeedback(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Feedback feedback = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindFeedbackStoredProcedure findFeedbackProc = null;

                    // verify the first parameters is a 'Feedback'.
                    if (parameters[0].ObjectValue as Feedback != null)
                    {
                        // Get FeedbackParameter
                        Feedback paramFeedback = (Feedback) parameters[0].ObjectValue;

                        // verify paramFeedback exists
                        if(paramFeedback != null)
                        {
                            // Now create findFeedbackProc from FeedbackWriter
                            // The DataWriter converts the 'Feedback'
                            // to the SqlParameter[] array needed to find a 'Feedback'.
                            findFeedbackProc = FeedbackWriter.CreateFindFeedbackStoredProcedure(paramFeedback);
                        }

                        // Verify findFeedbackProc exists
                        if(findFeedbackProc != null)
                        {
                            // Execute Find Stored Procedure
                            feedback = this.DataManager.FeedbackManager.FindFeedback(findFeedbackProc, dataConnector);

                            // if dataObject exists
                            if(feedback != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = feedback;
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

            #region InsertFeedback (Feedback)
            /// <summary>
            /// This method inserts a 'Feedback' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Feedback' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertFeedback(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Feedback feedback = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertFeedbackStoredProcedure insertFeedbackProc = null;

                    // verify the first parameters is a(n) 'Feedback'.
                    if (parameters[0].ObjectValue as Feedback != null)
                    {
                        // Create Feedback Parameter
                        feedback = (Feedback) parameters[0].ObjectValue;

                        // verify feedback exists
                        if(feedback != null)
                        {
                            // Now create insertFeedbackProc from FeedbackWriter
                            // The DataWriter converts the 'Feedback'
                            // to the SqlParameter[] array needed to insert a 'Feedback'.
                            insertFeedbackProc = FeedbackWriter.CreateInsertFeedbackStoredProcedure(feedback);
                        }

                        // Verify insertFeedbackProc exists
                        if(insertFeedbackProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.FeedbackManager.InsertFeedback(insertFeedbackProc, dataConnector);
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

            #region UpdateFeedback (Feedback)
            /// <summary>
            /// This method updates a 'Feedback' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Feedback' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateFeedback(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                Feedback feedback = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateFeedbackStoredProcedure updateFeedbackProc = null;

                    // verify the first parameters is a(n) 'Feedback'.
                    if (parameters[0].ObjectValue as Feedback != null)
                    {
                        // Create Feedback Parameter
                        feedback = (Feedback) parameters[0].ObjectValue;

                        // verify feedback exists
                        if(feedback != null)
                        {
                            // Now create updateFeedbackProc from FeedbackWriter
                            // The DataWriter converts the 'Feedback'
                            // to the SqlParameter[] array needed to update a 'Feedback'.
                            updateFeedbackProc = FeedbackWriter.CreateUpdateFeedbackStoredProcedure(feedback);
                        }

                        // Verify updateFeedbackProc exists
                        if(updateFeedbackProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.FeedbackManager.UpdateFeedback(updateFeedbackProc, dataConnector);

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
