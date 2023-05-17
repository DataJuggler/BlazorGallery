

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllErrorLogsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ErrorLog' objects.
    /// </summary>
    public class FetchAllErrorLogsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllErrorLogsStoredProcedure' object.
        /// </summary>
        public FetchAllErrorLogsStoredProcedure()
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
                this.ProcedureName = "ErrorLog_FetchAll";

                // Set tableName
                this.TableName = "ErrorLog";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
