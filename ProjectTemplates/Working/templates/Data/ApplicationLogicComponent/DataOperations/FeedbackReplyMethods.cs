

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

    #region class FeedbackReplyMethods
    /// <summary>
    /// This class contains methods for modifying a 'FeedbackReply' object.
    /// </summary>
    public class FeedbackReplyMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'FeedbackReplyMethods' object.
        /// </summary>
        public FeedbackReplyMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteFeedbackReply(FeedbackReply)
            /// <summary>
            /// This method deletes a 'FeedbackReply' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FeedbackReply' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteFeedbackReply(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteFeedbackReplyStoredProcedure deleteFeedbackReplyProc = null;

                    // verify the first parameters is a(n) 'FeedbackReply'.
                    if (parameters[0].ObjectValue as FeedbackReply != null)
                    {
                        // Create FeedbackReply
                        FeedbackReply feedbackReply = (FeedbackReply) parameters[0].ObjectValue;

                        // verify feedbackReply exists
                        if(feedbackReply != null)
                        {
                            // Now create deleteFeedbackReplyProc from FeedbackReplyWriter
                            // The DataWriter converts the 'FeedbackReply'
                            // to the SqlParameter[] array needed to delete a 'FeedbackReply'.
                            deleteFeedbackReplyProc = FeedbackReplyWriter.CreateDeleteFeedbackReplyStoredProcedure(feedbackReply);
                        }
                    }

                    // Verify deleteFeedbackReplyProc exists
                    if(deleteFeedbackReplyProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.FeedbackReplyManager.DeleteFeedbackReply(deleteFeedbackReplyProc, dataConnector);

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
            /// This method fetches all 'FeedbackReply' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FeedbackReply' to delete.
            /// <returns>A PolymorphicObject object with all  'FeedbackReplys' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<FeedbackReply> feedbackReplyListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllFeedbackReplysStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get FeedbackReplyParameter
                    // Declare Parameter
                    FeedbackReply paramFeedbackReply = null;

                    // verify the first parameters is a(n) 'FeedbackReply'.
                    if (parameters[0].ObjectValue as FeedbackReply != null)
                    {
                        // Get FeedbackReplyParameter
                        paramFeedbackReply = (FeedbackReply) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllFeedbackReplysProc from FeedbackReplyWriter
                    fetchAllProc = FeedbackReplyWriter.CreateFetchAllFeedbackReplysStoredProcedure(paramFeedbackReply);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    feedbackReplyListCollection = this.DataManager.FeedbackReplyManager.FetchAllFeedbackReplys(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(feedbackReplyListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = feedbackReplyListCollection;
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

            #region FindFeedbackReply(FeedbackReply)
            /// <summary>
            /// This method finds a 'FeedbackReply' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FeedbackReply' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindFeedbackReply(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FeedbackReply feedbackReply = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindFeedbackReplyStoredProcedure findFeedbackReplyProc = null;

                    // verify the first parameters is a 'FeedbackReply'.
                    if (parameters[0].ObjectValue as FeedbackReply != null)
                    {
                        // Get FeedbackReplyParameter
                        FeedbackReply paramFeedbackReply = (FeedbackReply) parameters[0].ObjectValue;

                        // verify paramFeedbackReply exists
                        if(paramFeedbackReply != null)
                        {
                            // Now create findFeedbackReplyProc from FeedbackReplyWriter
                            // The DataWriter converts the 'FeedbackReply'
                            // to the SqlParameter[] array needed to find a 'FeedbackReply'.
                            findFeedbackReplyProc = FeedbackReplyWriter.CreateFindFeedbackReplyStoredProcedure(paramFeedbackReply);
                        }

                        // Verify findFeedbackReplyProc exists
                        if(findFeedbackReplyProc != null)
                        {
                            // Execute Find Stored Procedure
                            feedbackReply = this.DataManager.FeedbackReplyManager.FindFeedbackReply(findFeedbackReplyProc, dataConnector);

                            // if dataObject exists
                            if(feedbackReply != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = feedbackReply;
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

            #region InsertFeedbackReply (FeedbackReply)
            /// <summary>
            /// This method inserts a 'FeedbackReply' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FeedbackReply' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertFeedbackReply(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FeedbackReply feedbackReply = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertFeedbackReplyStoredProcedure insertFeedbackReplyProc = null;

                    // verify the first parameters is a(n) 'FeedbackReply'.
                    if (parameters[0].ObjectValue as FeedbackReply != null)
                    {
                        // Create FeedbackReply Parameter
                        feedbackReply = (FeedbackReply) parameters[0].ObjectValue;

                        // verify feedbackReply exists
                        if(feedbackReply != null)
                        {
                            // Now create insertFeedbackReplyProc from FeedbackReplyWriter
                            // The DataWriter converts the 'FeedbackReply'
                            // to the SqlParameter[] array needed to insert a 'FeedbackReply'.
                            insertFeedbackReplyProc = FeedbackReplyWriter.CreateInsertFeedbackReplyStoredProcedure(feedbackReply);
                        }

                        // Verify insertFeedbackReplyProc exists
                        if(insertFeedbackReplyProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.FeedbackReplyManager.InsertFeedbackReply(insertFeedbackReplyProc, dataConnector);
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

            #region UpdateFeedbackReply (FeedbackReply)
            /// <summary>
            /// This method updates a 'FeedbackReply' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FeedbackReply' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateFeedbackReply(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FeedbackReply feedbackReply = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateFeedbackReplyStoredProcedure updateFeedbackReplyProc = null;

                    // verify the first parameters is a(n) 'FeedbackReply'.
                    if (parameters[0].ObjectValue as FeedbackReply != null)
                    {
                        // Create FeedbackReply Parameter
                        feedbackReply = (FeedbackReply) parameters[0].ObjectValue;

                        // verify feedbackReply exists
                        if(feedbackReply != null)
                        {
                            // Now create updateFeedbackReplyProc from FeedbackReplyWriter
                            // The DataWriter converts the 'FeedbackReply'
                            // to the SqlParameter[] array needed to update a 'FeedbackReply'.
                            updateFeedbackReplyProc = FeedbackReplyWriter.CreateUpdateFeedbackReplyStoredProcedure(feedbackReply);
                        }

                        // Verify updateFeedbackReplyProc exists
                        if(updateFeedbackReplyProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.FeedbackReplyManager.UpdateFeedbackReply(updateFeedbackReplyProc, dataConnector);

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
