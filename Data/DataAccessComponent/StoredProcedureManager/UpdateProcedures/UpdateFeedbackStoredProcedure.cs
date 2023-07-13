

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateFeedbackStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Feedback' object.
    /// </summary>
    public class UpdateFeedbackStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateFeedbackStoredProcedure' object.
        /// </summary>
        public UpdateFeedbackStoredProcedure()
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
                this.ProcedureName = "Feedback_Update";

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
