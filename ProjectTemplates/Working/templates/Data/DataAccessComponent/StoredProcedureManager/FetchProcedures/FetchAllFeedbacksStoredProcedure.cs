

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllFeedbacksStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Feedback' objects.
    /// </summary>
    public class FetchAllFeedbacksStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllFeedbacksStoredProcedure' object.
        /// </summary>
        public FetchAllFeedbacksStoredProcedure()
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
                this.ProcedureName = "Feedback_FetchAll";

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
