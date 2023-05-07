

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllUsersStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'User' objects.
    /// </summary>
    public class FetchAllUsersStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllUsersStoredProcedure' object.
        /// </summary>
        public FetchAllUsersStoredProcedure()
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
                this.ProcedureName = "User_FetchAll";

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
