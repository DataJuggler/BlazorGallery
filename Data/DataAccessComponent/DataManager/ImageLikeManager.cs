

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

    #region class ImageLikeManager
    /// <summary>
    /// This class is used to manage a 'ImageLike' object.
    /// </summary>
    public class ImageLikeManager
    {

        #region Private Variables
        private DataManager dataManager;
        private DataHelper dataHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ImageLikeManager' object.
        /// </summary>
        public ImageLikeManager(DataManager dataManagerArg)
        {
            // Set DataManager
            this.DataManager = dataManagerArg;

            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region DeleteImageLike()
            /// <summary>
            /// This method deletes a 'ImageLike' object.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool DeleteImageLike(DeleteImageLikeStoredProcedure deleteImageLikeProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool deleted = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    deleted = this.DataHelper.DeleteRecord(deleteImageLikeProc, databaseConnector);
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAllImageLikes()
            /// <summary>
            /// This method fetches a  'List<ImageLike>' object.
            /// This method uses the 'ImageLikes_FetchAll' procedure.
            /// </summary>
            /// <returns>A 'List<ImageLike>'</returns>
            /// </summary>
            public List<ImageLike> FetchAllImageLikes(FetchAllImageLikesStoredProcedure fetchAllImageLikesProc, DataConnector databaseConnector)
            {
                // Initial Value
                List<ImageLike> imageLikeCollection = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet allImageLikesDataSet = this.DataHelper.LoadDataSet(fetchAllImageLikesProc, databaseConnector);

                    // Verify DataSet Exists
                    if(allImageLikesDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataTable table = this.DataHelper.ReturnFirstTable(allImageLikesDataSet);

                        // if table exists
                        if(table != null)
                        {
                            // Load Collection
                            imageLikeCollection = ImageLikeReader.LoadCollection(table);
                        }
                    }
                }

                // return value
                return imageLikeCollection;
            }
            #endregion

            #region FindImageLike()
            /// <summary>
            /// This method finds a  'ImageLike' object.
            /// This method uses the 'ImageLike_Find' procedure.
            /// </summary>
            /// <returns>A 'ImageLike' object.</returns>
            /// </summary>
            public ImageLike FindImageLike(FindImageLikeStoredProcedure findImageLikeProc, DataConnector databaseConnector)
            {
                // Initial Value
                ImageLike imageLike = null;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // First Get Dataset
                    DataSet imageLikeDataSet = this.DataHelper.LoadDataSet(findImageLikeProc, databaseConnector);

                    // Verify DataSet Exists
                    if(imageLikeDataSet != null)
                    {
                        // Get DataTable From DataSet
                        DataRow row = this.DataHelper.ReturnFirstRow(imageLikeDataSet);

                        // if row exists
                        if(row != null)
                        {
                            // Load ImageLike
                            imageLike = ImageLikeReader.Load(row);
                        }
                    }
                }

                // return value
                return imageLike;
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

            #region InsertImageLike()
            /// <summary>
            /// This method inserts a 'ImageLike' object.
            /// This method uses the 'ImageLike_Insert' procedure.
            /// </summary>
            /// <returns>The identity value of the new record.</returns>
            /// </summary>
            public int InsertImageLike(InsertImageLikeStoredProcedure insertImageLikeProc, DataConnector databaseConnector)
            {
                // Initial Value
                int newIdentity = -1;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Non Query
                    newIdentity = this.DataHelper.InsertRecord(insertImageLikeProc, databaseConnector);
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region UpdateImageLike()
            /// <summary>
            /// This method updates a 'ImageLike'.
            /// This method uses the 'ImageLike_Update' procedure.
            /// </summary>
            /// <returns>True if successful false if not.</returns>
            /// </summary>
            public bool UpdateImageLike(UpdateImageLikeStoredProcedure updateImageLikeProc, DataConnector databaseConnector)
            {
                // Initial Value
                bool saved = false;

                // Verify database connection is connected
                if ((databaseConnector != null) && (databaseConnector.Connected))
                {
                    // Execute Update.
                    saved = this.DataHelper.UpdateRecord(updateImageLikeProc, databaseConnector);
                }

                // return value
                return saved;
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
