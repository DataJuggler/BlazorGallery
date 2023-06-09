

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteImageStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Image' object.
    /// </summary>
    public class DeleteImageStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteImageStoredProcedure' object.
        /// </summary>
        public DeleteImageStoredProcedure()
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
                this.ProcedureName = "Image_Delete";

                // Set tableName
                this.TableName = "Image";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
