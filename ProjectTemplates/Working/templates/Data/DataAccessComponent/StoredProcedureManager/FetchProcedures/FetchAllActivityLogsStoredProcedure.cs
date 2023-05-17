

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllActivityLogsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ActivityLog' objects.
    /// </summary>
    public class FetchAllActivityLogsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllActivityLogsStoredProcedure' object.
        /// </summary>
        public FetchAllActivityLogsStoredProcedure()
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
                this.ProcedureName = "ActivityLog_FetchAll";

                // Set tableName
                this.TableName = "ActivityLog";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
