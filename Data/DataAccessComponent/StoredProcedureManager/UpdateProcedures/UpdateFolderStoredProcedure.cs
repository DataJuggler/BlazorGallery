

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateFolderStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Folder' object.
    /// </summary>
    public class UpdateFolderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateFolderStoredProcedure' object.
        /// </summary>
        public UpdateFolderStoredProcedure()
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
                this.ProcedureName = "Folder_Update";

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
