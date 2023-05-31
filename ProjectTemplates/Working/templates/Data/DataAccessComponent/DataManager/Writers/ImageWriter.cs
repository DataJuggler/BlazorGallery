
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

            #region CreateDeleteImageStoredProcedure(Image image)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteImage'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Image_Delete'.
            /// </summary>
            /// <param name="image">The 'Image' to Delete.</param>
            /// <returns>An instance of a 'DeleteImageStoredProcedure' object.</returns>
            public static new DeleteImageStoredProcedure CreateDeleteImageStoredProcedure(Image image)
            {
                // Initial Value
                DeleteImageStoredProcedure deleteImageStoredProcedure = new DeleteImageStoredProcedure();

                // if image.DeleteByFolderId is true
                if (image.DeleteByFolderId)
                {
                        // Change the procedure name
                        deleteImageStoredProcedure.ProcedureName = "Image_DeleteByFolderId";
                        
                        // Create the @FolderId parameter
                        deleteImageStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@FolderId", image.FolderId);
                }
                else
                {
                    // Now Create Parameters For The DeleteProc
                    deleteImageStoredProcedure.Parameters = CreatePrimaryKeyParameter(image);
                }

                // return value
                return deleteImageStoredProcedure;
            }
            #endregion
            
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
