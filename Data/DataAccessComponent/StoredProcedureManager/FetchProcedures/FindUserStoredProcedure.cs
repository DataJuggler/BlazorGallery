

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindUserStoredProcedure
    /// <summary>
    /// This class is used to Find a 'User' object.
    /// </summary>
    public class FindUserStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindUserStoredProcedure' object.
        /// </summary>
        public FindUserStoredProcedure()
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
                this.ProcedureName = "User_Find";

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
