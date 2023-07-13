

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertFeedbackStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Feedback' object.
    /// </summary>
    public class InsertFeedbackStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertFeedbackStoredProcedure' object.
        /// </summary>
        public InsertFeedbackStoredProcedure()
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
                this.ProcedureName = "Feedback_Insert";

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
