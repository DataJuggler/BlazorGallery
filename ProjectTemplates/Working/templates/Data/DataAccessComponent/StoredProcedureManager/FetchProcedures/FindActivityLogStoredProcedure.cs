

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindActivityLogStoredProcedure
    /// <summary>
    /// This class is used to Find a 'ActivityLog' object.
    /// </summary>
    public class FindActivityLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindActivityLogStoredProcedure' object.
        /// </summary>
        public FindActivityLogStoredProcedure()
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
                this.ProcedureName = "ActivityLog_Find";

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
