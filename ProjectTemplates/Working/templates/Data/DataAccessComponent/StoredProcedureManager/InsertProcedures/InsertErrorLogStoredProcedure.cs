

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertErrorLogStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'ErrorLog' object.
    /// </summary>
    public class InsertErrorLogStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertErrorLogStoredProcedure' object.
        /// </summary>
        public InsertErrorLogStoredProcedure()
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
                this.ProcedureName = "ErrorLog_Insert";

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
