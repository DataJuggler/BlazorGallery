
#region using statements

using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using Microsoft.Data.SqlClient;
using ObjectLibrary.BusinessObjects;
using System;
using System.Data;

#endregion

namespace DataAccessComponent.DataManager.Writers
{

    #region class MainGalleryViewWriter
    /// <summary>
    /// This class is used for converting a 'MainGalleryView' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class MainGalleryViewWriter : MainGalleryViewWriterBase
    {

        #region Static Methods

            #region CreateFetchAllMainGalleryViewsStoredProcedure(MainGalleryView mainGalleryView)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllMainGalleryViewsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'MainGalleryView_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllMainGalleryViewsStoredProcedure' object.</returns>
            public static new FetchAllMainGalleryViewsStoredProcedure CreateFetchAllMainGalleryViewsStoredProcedure(MainGalleryView mainGalleryView)
            {
                // Initial value
                FetchAllMainGalleryViewsStoredProcedure fetchAllMainGalleryViewsStoredProcedure = new FetchAllMainGalleryViewsStoredProcedure();

                // If the value for the property mainGalleryView.LoadMostRecent is true
                if (mainGalleryView.LoadMostRecent)
                {
                    // Change the procedure name
                    fetchAllMainGalleryViewsStoredProcedure.ProcedureName = "MainGalleryView_FetchMostRecent"; 
                }

                // return value
                return fetchAllMainGalleryViewsStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
