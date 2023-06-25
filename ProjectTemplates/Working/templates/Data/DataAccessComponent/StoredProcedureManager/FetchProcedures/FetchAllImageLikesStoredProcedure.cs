

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllImageLikesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ImageLike' objects.
    /// </summary>
    public class FetchAllImageLikesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllImageLikesStoredProcedure' object.
        /// </summary>
        public FetchAllImageLikesStoredProcedure()
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
                this.ProcedureName = "ImageLike_FetchAll";

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
