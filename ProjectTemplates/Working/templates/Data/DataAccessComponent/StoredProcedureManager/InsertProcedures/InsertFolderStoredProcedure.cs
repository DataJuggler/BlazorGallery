

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertFolderStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Folder' object.
    /// </summary>
    public class InsertFolderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertFolderStoredProcedure' object.
        /// </summary>
        public InsertFolderStoredProcedure()
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
                this.ProcedureName = "Folder_Insert";

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
