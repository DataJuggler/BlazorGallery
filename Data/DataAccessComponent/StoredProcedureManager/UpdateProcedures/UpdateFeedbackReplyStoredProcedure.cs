

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateFeedbackReplyStoredProcedure
    /// <summary>
    /// This class is used to Update a 'FeedbackReply' object.
    /// </summary>
    public class UpdateFeedbackReplyStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateFeedbackReplyStoredProcedure' object.
        /// </summary>
        public UpdateFeedbackReplyStoredProcedure()
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
                this.ProcedureName = "FeedbackReply_Update";

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
