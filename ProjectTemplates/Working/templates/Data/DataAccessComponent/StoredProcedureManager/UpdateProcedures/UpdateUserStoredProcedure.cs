

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateUserStoredProcedure
    /// <summary>
    /// This class is used to Update a 'User' object.
    /// </summary>
    public class UpdateUserStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateUserStoredProcedure' object.
        /// </summary>
        public UpdateUserStoredProcedure()
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
                this.ProcedureName = "User_Update";

                // Set tableName
                this.TableName = "User";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
