

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateActivityLogStoredProcedure
    /// <summary>
    /// This class is used to Update a 'ActivityLog' object.
    /// </summary>
    public class UpdateActivityLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateActivityLogStoredProcedure' object.
        /// </summary>
        public UpdateActivityLogStoredProcedure()
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
                this.ProcedureName = "ActivityLog_Update";

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
