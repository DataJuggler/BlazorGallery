

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertUserStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'User' object.
    /// </summary>
    public class InsertUserStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertUserStoredProcedure' object.
        /// </summary>
        public InsertUserStoredProcedure()
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
                this.ProcedureName = "User_Insert";

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
