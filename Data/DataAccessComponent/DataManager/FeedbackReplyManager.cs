

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

    #region class FeedbackReplyManager
    /// <summary>
    /// This class is used to manage a 'FeedbackReply' object.
    /// </summary>
    public class FeedbackReplyManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FeedbackReplyManager' object.
        /// </summary>
        public FeedbackReplyManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteFeedbackReply()
            /// <summary>
            /// This method deletes a 'FeedbackReply' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteFeedbackReply(DeleteFeedbackReplyStoredProcedure deleteFeedbackReplyProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteFeedbackReplyProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllFeedbackReplys()
            /// <summary>
            /// This method fetches a  'List<FeedbackReply>' object.
            /// This method uses the 'FeedbackReplys_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<FeedbackReply>'</returns>
            /// </summary>
            public List<FeedbackReply> FetchAllFeedbackReplys(FetchAllFeedbackReplysStoredProcedure fetchAllFeedbackReplysProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<FeedbackReply> feedbackReplyCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allFeedbackReplysDataSet = this.DataHelper.LoadDataSet(fetchAllFeedbackReplysProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allFeedbackReplysDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allFeedbackReplysDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            feedbackReplyCollection = FeedbackReplyReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return feedbackReplyCollection;
            }
            #endregion

            #region FindFeedbackReply()
            /// <summary>
            /// This method finds a  'FeedbackReply' object.
            /// This method uses the 'FeedbackReply_Find' procedure.
            /// </summary>
            /// <returns>A 'FeedbackReply' object.</returns>
            /// </summary>
            public FeedbackReply FindFeedbackReply(FindFeedbackReplyStoredProcedure findFeedbackReplyProc, DataConnector databaseConnector)
            {
                // Initial Value
                FeedbackReply feedbackReply = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet feedbackReplyDataSet = this.DataHelper.LoadDataSet(findFeedbackReplyProc, databaseConnector);

                    // Verify DataSet Exists
                    if(feedbackReplyDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(feedbackReplyDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load FeedbackReply
                            feedbackReply = FeedbackReplyReader.Load(row);
                        }
                    }
                }

                // return value
                return feedbackReply;
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

            #region InsertFeedbackReply()
            /// <summary>
            /// This method inserts a 'FeedbackReply' object.
            /// This method uses the 'FeedbackReply_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertFeedbackReply(InsertFeedbackReplyStoredProcedure insertFeedbackReplyProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertFeedbackReplyProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateFeedbackReply()
            /// <summary>
            /// This method updates a 'FeedbackReply'.
            /// This method uses the 'FeedbackReply_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateFeedbackReply(UpdateFeedbackReplyStoredProcedure updateFeedbackReplyProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateFeedbackReplyProc, databaseConnector);
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
