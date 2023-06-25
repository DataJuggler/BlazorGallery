

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateImageLikeStoredProcedure
    /// <summary>
    /// This class is used to Update a 'ImageLike' object.
    /// </summary>
    public class UpdateImageLikeStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateImageLikeStoredProcedure' object.
        /// </summary>
        public UpdateImageLikeStoredProcedure()
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
                this.ProcedureName = "ImageLike_Update";

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
