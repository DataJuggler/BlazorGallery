
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

    #region class ImageWriter
    /// <summary>
    /// This class is used for converting a 'Image' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ImageWriter : ImageWriterBase
    {

        #region Static Methods

            #region CreateFetchAllImagesStoredProcedure(Image image)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllImagesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Image_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllImagesStoredProcedure' object.</returns>
            public static new FetchAllImagesStoredProcedure CreateFetchAllImagesStoredProcedure(Image image)
            {
                // Initial value
                FetchAllImagesStoredProcedure fetchAllImagesStoredProcedure = new FetchAllImagesStoredProcedure();

                // if the image object exists
                if (image != null)
                {
                    // if LoadByFolderId is true
                    if (image.LoadByFolderId)
                    {
                        // Change the procedure name
                        fetchAllImagesStoredProcedure.ProcedureName = "Image_FetchAllForFolderId";
                        
                        // Create the @FolderId parameter
                        fetchAllImagesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@FolderId", image.FolderId);
                    }
                }
                
                // return value
                return fetchAllImagesStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
