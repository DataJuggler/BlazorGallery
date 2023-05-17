

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteActivityLogStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'ActivityLog' object.
    /// </summary>
    public class DeleteActivityLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteActivityLogStoredProcedure' object.
        /// </summary>
        public DeleteActivityLogStoredProcedure()
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
                this.ProcedureName = "ActivityLog_Delete";

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
