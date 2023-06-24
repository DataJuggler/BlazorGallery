

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllMainGalleryViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'MainGalleryView' objects.
    /// </summary>
    public class FetchAllMainGalleryViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllMainGalleryViewsStoredProcedure' object.
        /// </summary>
        public FetchAllMainGalleryViewsStoredProcedure()
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
                this.ProcedureName = "MainGalleryView_FetchAll";

                // Set tableName
                this.TableName = "MainGalleryView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
