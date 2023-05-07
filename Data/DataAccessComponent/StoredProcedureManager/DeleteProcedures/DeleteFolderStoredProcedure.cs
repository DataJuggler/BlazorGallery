

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteFolderStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Folder' object.
    /// </summary>
    public class DeleteFolderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteFolderStoredProcedure' object.
        /// </summary>
        public DeleteFolderStoredProcedure()
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
                this.ProcedureName = "Folder_Delete";

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
