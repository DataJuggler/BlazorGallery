
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

    #region class ImageLikeWriter
    /// <summary>
    /// This class is used for converting a 'ImageLike' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ImageLikeWriter : ImageLikeWriterBase
    {

        #region Static Methods

            #region CreateFetchAllImageLikesStoredProcedure(ImageLike imageLike)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllImageLikesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ImageLike_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllImageLikesStoredProcedure' object.</returns>
            public static new FetchAllImageLikesStoredProcedure CreateFetchAllImageLikesStoredProcedure(ImageLike imageLike)
            {
                // Initial value
                FetchAllImageLikesStoredProcedure fetchAllImageLikesStoredProcedure = new FetchAllImageLikesStoredProcedure();

                // if the imageLike object exists
                if (imageLike != null)
                {
                    // if LoadByGalleryOwnerIdAndUserId is true
                    if (imageLike.LoadByGalleryOwnerIdAndUserId)
                    {
                        // Change the procedure name
                        fetchAllImageLikesStoredProcedure.ProcedureName = "ImageLike_FetchAllForGalleryOwnerIdAndUserId";
                        
                        // Create the GalleryOwnerIdAndUserId field set parameters
                        fetchAllImageLikesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@GalleryOwnerId", imageLike.GalleryOwnerId, "@UserId", imageLike.UserId);
                    }                   
                    // if imageLike.LoadByUserId is true
                    else if (imageLike.LoadByUserId)
                    {
                        // Change the procedure name
                        fetchAllImageLikesStoredProcedure.ProcedureName = "ImageLike_FetchAllInMainGalleryForUserId";
                        
                        // Create the @UserId parameter
                        fetchAllImageLikesStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@UserId", imageLike.UserId);
                    }
                }
                
                // return value
                return fetchAllImageLikesStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
