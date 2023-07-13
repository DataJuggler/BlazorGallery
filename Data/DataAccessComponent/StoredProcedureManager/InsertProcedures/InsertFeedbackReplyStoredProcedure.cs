

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertFeedbackReplyStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'FeedbackReply' object.
    /// </summary>
    public class InsertFeedbackReplyStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertFeedbackReplyStoredProcedure' object.
        /// </summary>
        public InsertFeedbackReplyStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "FeedbackReply_Insert";

                // Set tableName
                this.TableName = "FeedbackReply";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
