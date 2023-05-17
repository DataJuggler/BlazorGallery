

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteErrorLogStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'ErrorLog' object.
    /// </summary>
    public class DeleteErrorLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteErrorLogStoredProcedure' object.
        /// </summary>
        public DeleteErrorLogStoredProcedure()
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
                this.ProcedureName = "ErrorLog_Delete";

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
