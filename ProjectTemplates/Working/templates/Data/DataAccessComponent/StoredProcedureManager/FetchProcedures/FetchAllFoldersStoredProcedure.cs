

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllFoldersStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Folder' objects.
    /// </summary>
    public class FetchAllFoldersStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllFoldersStoredProcedure' object.
        /// </summary>
        public FetchAllFoldersStoredProcedure()
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
                this.ProcedureName = "Folder_FetchAll";

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
