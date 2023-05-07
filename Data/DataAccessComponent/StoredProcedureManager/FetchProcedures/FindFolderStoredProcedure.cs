

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindFolderStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Folder' object.
    /// </summary>
    public class FindFolderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindFolderStoredProcedure' object.
        /// </summary>
        public FindFolderStoredProcedure()
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
                this.ProcedureName = "Folder_Find";

                // Set tableName
                this.TableName = "Folder";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
