

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllFeedbackReplysStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'FeedbackReply' objects.
    /// </summary>
    public class FetchAllFeedbackReplysStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllFeedbackReplysStoredProcedure' object.
        /// </summary>
        public FetchAllFeedbackReplysStoredProcedure()
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
                this.ProcedureName = "FeedbackReply_FetchAll";

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
