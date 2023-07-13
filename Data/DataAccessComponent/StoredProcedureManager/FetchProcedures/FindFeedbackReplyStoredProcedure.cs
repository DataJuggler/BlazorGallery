

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindFeedbackReplyStoredProcedure
    /// <summary>
    /// This class is used to Find a 'FeedbackReply' object.
    /// </summary>
    public class FindFeedbackReplyStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindFeedbackReplyStoredProcedure' object.
        /// </summary>
        public FindFeedbackReplyStoredProcedure()
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
                this.ProcedureName = "FeedbackReply_Find";

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
