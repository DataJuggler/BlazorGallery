

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteImageLikeStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'ImageLike' object.
    /// </summary>
    public class DeleteImageLikeStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteImageLikeStoredProcedure' object.
        /// </summary>
        public DeleteImageLikeStoredProcedure()
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
                this.ProcedureName = "ImageLike_Delete";

                // Set tableName
                this.TableName = "ImageLike";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
