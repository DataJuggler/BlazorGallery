

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertImageLikeStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'ImageLike' object.
    /// </summary>
    public class InsertImageLikeStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertImageLikeStoredProcedure' object.
        /// </summary>
        public InsertImageLikeStoredProcedure()
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
                this.ProcedureName = "ImageLike_Insert";

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
