

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateImageStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Image' object.
    /// </summary>
    public class UpdateImageStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateImageStoredProcedure' object.
        /// </summary>
        public UpdateImageStoredProcedure()
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
                this.ProcedureName = "Image_Update";

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
