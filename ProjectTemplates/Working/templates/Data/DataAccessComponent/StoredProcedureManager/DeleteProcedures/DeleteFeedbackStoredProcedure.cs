

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteFeedbackStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Feedback' object.
    /// </summary>
    public class DeleteFeedbackStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteFeedbackStoredProcedure' object.
        /// </summary>
        public DeleteFeedbackStoredProcedure()
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
                this.ProcedureName = "Feedback_Delete";

                // Set tableName
                this.TableName = "Feedback";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
