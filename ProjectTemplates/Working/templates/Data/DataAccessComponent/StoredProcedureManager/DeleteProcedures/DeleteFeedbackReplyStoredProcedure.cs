

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteFeedbackReplyStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'FeedbackReply' object.
    /// </summary>
    public class DeleteFeedbackReplyStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteFeedbackReplyStoredProcedure' object.
        /// </summary>
        public DeleteFeedbackReplyStoredProcedure()
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
                this.ProcedureName = "FeedbackReply_Delete";

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
