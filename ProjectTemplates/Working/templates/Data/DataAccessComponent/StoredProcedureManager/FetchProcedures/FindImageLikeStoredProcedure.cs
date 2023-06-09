

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindImageLikeStoredProcedure
    /// <summary>
    /// This class is used to Find a 'ImageLike' object.
    /// </summary>
    public class FindImageLikeStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindImageLikeStoredProcedure' object.
        /// </summary>
        public FindImageLikeStoredProcedure()
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
                this.ProcedureName = "ImageLike_Find";

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
