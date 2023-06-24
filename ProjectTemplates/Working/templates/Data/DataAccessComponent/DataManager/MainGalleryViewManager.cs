

#region using statements

using DataAccessComponent.DataManager.Readers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager
{

    #region class MainGalleryViewManager
    /// <summary>
    /// This class is used to manage a 'MainGalleryView' object.
    /// </summary>
    public class MainGalleryViewManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainGalleryViewManager' object.
        /// </summary>
        public MainGalleryViewManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region FetchAllMainGalleryViews()
            /// <summary>
            /// This method fetches a  'List<MainGalleryView>' object.
            /// This method uses the 'MainGalleryViews_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<MainGalleryView>'</returns>
            /// </summary>
            public List<MainGalleryView> FetchAllMainGalleryViews(FetchAllMainGalleryViewsStoredProcedure fetchAllMainGalleryViewsProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<MainGalleryView> mainGalleryViewCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allMainGalleryViewsDataSet = this.DataHelper.LoadDataSet(fetchAllMainGalleryViewsProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allMainGalleryViewsDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allMainGalleryViewsDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            mainGalleryViewCollection = MainGalleryViewReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return mainGalleryViewCollection;
            }
            #endregion

            #region Init()
            /// <summary>
            /// Perorm Initialization For This Object
            /// </summary>
            private void Init()
            {
                // Create DataHelper object
                this.DataHelper = new DataHelper();
            }
            #endregion

        #endregion

        #region Properties

            #region DataHelper
            /// <summary>
            /// This object uses the Microsoft Data
            /// Application Block to execute stored
            /// procedures.
            /// </summary>
            internal DataHelper DataHelper
            {
                get { return dataHelper; }
                set { dataHelper = value; }
            }
            #endregion

            #region DataManager
            /// <summary>
            /// A reference to this objects parent.
            /// </summary>
            internal DataManager DataManager
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
