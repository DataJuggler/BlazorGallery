

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertActivityLogStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'ActivityLog' object.
    /// </summary>
    public class InsertActivityLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertActivityLogStoredProcedure' object.
        /// </summary>
        public InsertActivityLogStoredProcedure()
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
                this.ProcedureName = "ActivityLog_Insert";

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
