

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

    #region class FeedbackManager
    /// <summary>
    /// This class is used to manage a 'Feedback' object.
    /// </summary>
    public class FeedbackManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FeedbackManager' object.
        /// </summary>
        public FeedbackManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteFeedback()
            /// <summary>
            /// This method deletes a 'Feedback' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteFeedback(DeleteFeedbackStoredProcedure deleteFeedbackProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteFeedbackProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllFeedbacks()
            /// <summary>
            /// This method fetches a  'List<Feedback>' object.
            /// This method uses the 'Feedbacks_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<Feedback>'</returns>
            /// </summary>
            public List<Feedback> FetchAllFeedbacks(FetchAllFeedbacksStoredProcedure fetchAllFeedbacksProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<Feedback> feedbackCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allFeedbacksDataSet = this.DataHelper.LoadDataSet(fetchAllFeedbacksProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allFeedbacksDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allFeedbacksDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            feedbackCollection = FeedbackReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return feedbackCollection;
            }
            #endregion

            #region FindFeedback()
            /// <summary>
            /// This method finds a  'Feedback' object.
            /// This method uses the 'Feedback_Find' procedure.
            /// </summary>
            /// <returns>A 'Feedback' object.</returns>
            /// </summary>
            public Feedback FindFeedback(FindFeedbackStoredProcedure findFeedbackProc, DataConnector databaseConnector)
            {
                // Initial Value
                Feedback feedback = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet feedbackDataSet = this.DataHelper.LoadDataSet(findFeedbackProc, databaseConnector);

                    // Verify DataSet Exists
                    if(feedbackDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(feedbackDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load Feedback
                            feedback = FeedbackReader.Load(row);
                        }
                    }
                }

                // return value
                return feedback;
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

            #region InsertFeedback()
            /// <summary>
            /// This method inserts a 'Feedback' object.
            /// This method uses the 'Feedback_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertFeedback(InsertFeedbackStoredProcedure insertFeedbackProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertFeedbackProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateFeedback()
            /// <summary>
            /// This method updates a 'Feedback'.
            /// This method uses the 'Feedback_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateFeedback(UpdateFeedbackStoredProcedure updateFeedbackProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateFeedbackProc, databaseConnector);
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
