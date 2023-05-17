

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindErrorLogStoredProcedure
    /// <summary>
    /// This class is used to Find a 'ErrorLog' object.
    /// </summary>
    public class FindErrorLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindErrorLogStoredProcedure' object.
        /// </summary>
        public FindErrorLogStoredProcedure()
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
                this.ProcedureName = "ErrorLog_Find";

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
