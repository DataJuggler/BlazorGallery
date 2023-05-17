

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateErrorLogStoredProcedure
    /// <summary>
    /// This class is used to Update a 'ErrorLog' object.
    /// </summary>
    public class UpdateErrorLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateErrorLogStoredProcedure' object.
        /// </summary>
        public UpdateErrorLogStoredProcedure()
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
                this.ProcedureName = "ErrorLog_Update";

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
