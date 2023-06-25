

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

    #region class ImageLikeWriterBase
    /// <summary>
    /// This class is used for converting a 'ImageLike' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class ImageLikeWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(ImageLike imageLike)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='imageLike'>The 'ImageLike' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(ImageLike imageLike)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (imageLike != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", imageLike.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteImageLikeStoredProcedure(ImageLike imageLike)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteImageLike'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ImageLike_Delete'.
            /// </summary>
            /// <param name="imageLike">The 'ImageLike' to Delete.</param>
            /// <returns>An instance of a 'DeleteImageLikeStoredProcedure' object.</returns>
            public static DeleteImageLikeStoredProcedure CreateDeleteImageLikeStoredProcedure(ImageLike imageLike)
            {
                // Initial Value
                DeleteImageLikeStoredProcedure deleteImageLikeStoredProcedure = new DeleteImageLikeStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteImageLikeStoredProcedure.Parameters = CreatePrimaryKeyParameter(imageLike);

                // return value
                return deleteImageLikeStoredProcedure;
            }
            #endregion

            #region CreateFindImageLikeStoredProcedure(ImageLike imageLike)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindImageLikeStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ImageLike_Find'.
            /// </summary>
            /// <param name="imageLike">The 'ImageLike' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindImageLikeStoredProcedure CreateFindImageLikeStoredProcedure(ImageLike imageLike)
            {
                // Initial Value
                FindImageLikeStoredProcedure findImageLikeStoredProcedure = null;

                // verify imageLike exists
                if(imageLike != null)
                {
                    // Instanciate findImageLikeStoredProcedure
                    findImageLikeStoredProcedure = new FindImageLikeStoredProcedure();

                    // Now create parameters for this procedure
                    findImageLikeStoredProcedure.Parameters = CreatePrimaryKeyParameter(imageLike);
                }

                // return value
                return findImageLikeStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(ImageLike imageLike)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new imageLike.
            /// </summary>
            /// <param name="imageLike">The 'ImageLike' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(ImageLike imageLike)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify imageLikeexists
                if(imageLike != null)
                {
                    // Create [GalleryOwnerId] parameter
                    param = new SqlParameter("@GalleryOwnerId", imageLike.GalleryOwnerId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [ImageId] parameter
                    param = new SqlParameter("@ImageId", imageLike.ImageId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [UserId] parameter
                    param = new SqlParameter("@UserId", imageLike.UserId);

                    // set parameters[2]
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertImageLikeStoredProcedure(ImageLike imageLike)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertImageLikeStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ImageLike_Insert'.
            /// </summary>
            /// <param name="imageLike"The 'ImageLike' object to insert</param>
            /// <returns>An instance of a 'InsertImageLikeStoredProcedure' object.</returns>
            public static InsertImageLikeStoredProcedure CreateInsertImageLikeStoredProcedure(ImageLike imageLike)
            {
                // Initial Value
                InsertImageLikeStoredProcedure insertImageLikeStoredProcedure = null;

                // verify imageLike exists
                if(imageLike != null)
                {
                    // Instanciate insertImageLikeStoredProcedure
                    insertImageLikeStoredProcedure = new InsertImageLikeStoredProcedure();

                    // Now create parameters for this procedure
                    insertImageLikeStoredProcedure.Parameters = CreateInsertParameters(imageLike);
                }

                // return value
                return insertImageLikeStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(ImageLike imageLike)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing imageLike.
            /// </summary>
            /// <param name="imageLike">The 'ImageLike' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(ImageLike imageLike)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify imageLikeexists
                if(imageLike != null)
                {
                    // Create parameter for [GalleryOwnerId]
                    param = new SqlParameter("@GalleryOwnerId", imageLike.GalleryOwnerId);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [ImageId]
                    param = new SqlParameter("@ImageId", imageLike.ImageId);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [UserId]
                    param = new SqlParameter("@UserId", imageLike.UserId);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", imageLike.Id);
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateImageLikeStoredProcedure(ImageLike imageLike)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateImageLikeStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ImageLike_Update'.
            /// </summary>
            /// <param name="imageLike"The 'ImageLike' object to update</param>
            /// <returns>An instance of a 'UpdateImageLikeStoredProcedure</returns>
            public static UpdateImageLikeStoredProcedure CreateUpdateImageLikeStoredProcedure(ImageLike imageLike)
            {
                // Initial Value
                UpdateImageLikeStoredProcedure updateImageLikeStoredProcedure = null;

                // verify imageLike exists
                if(imageLike != null)
                {
                    // Instanciate updateImageLikeStoredProcedure
                    updateImageLikeStoredProcedure = new UpdateImageLikeStoredProcedure();

                    // Now create parameters for this procedure
                    updateImageLikeStoredProcedure.Parameters = CreateUpdateParameters(imageLike);
                }

                // return value
                return updateImageLikeStoredProcedure;
            }
            #endregion

            #region CreateFetchAllImageLikesStoredProcedure(ImageLike imageLike)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllImageLikesStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'ImageLike_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllImageLikesStoredProcedure' object.</returns>
            public static FetchAllImageLikesStoredProcedure CreateFetchAllImageLikesStoredProcedure(ImageLike imageLike)
            {
                // Initial value
                FetchAllImageLikesStoredProcedure fetchAllImageLikesStoredProcedure = new FetchAllImageLikesStoredProcedure();

                // return value
                return fetchAllImageLikesStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
