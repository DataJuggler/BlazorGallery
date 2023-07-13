

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindFeedbackStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Feedback' object.
    /// </summary>
    public class FindFeedbackStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindFeedbackStoredProcedure' object.
        /// </summary>
        public FindFeedbackStoredProcedure()
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
                this.ProcedureName = "Feedback_Find";

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
