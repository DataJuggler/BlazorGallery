

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

    #region class FolderWriterBase
    /// <summary>
    /// This class is used for converting a 'Folder' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FolderWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Folder folder)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='folder'>The 'Folder' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Folder folder)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (folder != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", folder.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteFolderStoredProcedure(Folder folder)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteFolder'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Folder_Delete'.
            /// </summary>
            /// <param name="folder">The 'Folder' to Delete.</param>
            /// <returns>An instance of a 'DeleteFolderStoredProcedure' object.</returns>
            public static DeleteFolderStoredProcedure CreateDeleteFolderStoredProcedure(Folder folder)
            {
                // Initial Value
                DeleteFolderStoredProcedure deleteFolderStoredProcedure = new DeleteFolderStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteFolderStoredProcedure.Parameters = CreatePrimaryKeyParameter(folder);

                // return value
                return deleteFolderStoredProcedure;
            }
            #endregion

            #region CreateFindFolderStoredProcedure(Folder folder)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindFolderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Folder_Find'.
            /// </summary>
            /// <param name="folder">The 'Folder' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindFolderStoredProcedure CreateFindFolderStoredProcedure(Folder folder)
            {
                // Initial Value
                FindFolderStoredProcedure findFolderStoredProcedure = null;

                // verify folder exists
                if(folder != null)
                {
                    // Instanciate findFolderStoredProcedure
                    findFolderStoredProcedure = new FindFolderStoredProcedure();

                    // Now create parameters for this procedure
                    findFolderStoredProcedure.Parameters = CreatePrimaryKeyParameter(folder);
                }

                // return value
                return findFolderStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Folder folder)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new folder.
            /// </summary>
            /// <param name="folder">The 'Folder' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Folder folder)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[4];
                SqlParameter param = null;

                // verify folderexists
                if(folder != null)
                {
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If folder.CreatedDate does not exist.
                    if (folder.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = folder.CreatedDate;
                    }
                    // set parameters[0]
                    parameters[0] = param;

                    // Create [Name] parameter
                    param = new SqlParameter("@Name", folder.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create [Selected] parameter
                    param = new SqlParameter("@Selected", folder.Selected);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create [UserId] parameter
                    param = new SqlParameter("@UserId", folder.UserId);

                    // set parameters[3]
                    parameters[3] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertFolderStoredProcedure(Folder folder)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertFolderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Folder_Insert'.
            /// </summary>
            /// <param name="folder"The 'Folder' object to insert</param>
            /// <returns>An instance of a 'InsertFolderStoredProcedure' object.</returns>
            public static InsertFolderStoredProcedure CreateInsertFolderStoredProcedure(Folder folder)
            {
                // Initial Value
                InsertFolderStoredProcedure insertFolderStoredProcedure = null;

                // verify folder exists
                if(folder != null)
                {
                    // Instanciate insertFolderStoredProcedure
                    insertFolderStoredProcedure = new InsertFolderStoredProcedure();

                    // Now create parameters for this procedure
                    insertFolderStoredProcedure.Parameters = CreateInsertParameters(folder);
                }

                // return value
                return insertFolderStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Folder folder)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing folder.
            /// </summary>
            /// <param name="folder">The 'Folder' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Folder folder)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[5];
                SqlParameter param = null;

                // verify folderexists
                if(folder != null)
                {
                    // Create parameter for [CreatedDate]
                    // Create [CreatedDate] Parameter
                    param = new SqlParameter("@CreatedDate", SqlDbType.DateTime);

                    // If folder.CreatedDate does not exist.
                    if (folder.CreatedDate.Year < 1900)
                    {
                        // Set the value to 1/1/1900
                        param.Value = new DateTime(1900, 1, 1);
                    }
                    else
                    {
                        // Set the parameter value
                        param.Value = folder.CreatedDate;
                    }

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [Name]
                    param = new SqlParameter("@Name", folder.Name);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Selected]
                    param = new SqlParameter("@Selected", folder.Selected);

                    // set parameters[2]
                    parameters[2] = param;

                    // Create parameter for [UserId]
                    param = new SqlParameter("@UserId", folder.UserId);

                    // set parameters[3]
                    parameters[3] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", folder.Id);
                    parameters[4] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateFolderStoredProcedure(Folder folder)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateFolderStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Folder_Update'.
            /// </summary>
            /// <param name="folder"The 'Folder' object to update</param>
            /// <returns>An instance of a 'UpdateFolderStoredProcedure</returns>
            public static UpdateFolderStoredProcedure CreateUpdateFolderStoredProcedure(Folder folder)
            {
                // Initial Value
                UpdateFolderStoredProcedure updateFolderStoredProcedure = null;

                // verify folder exists
                if(folder != null)
                {
                    // Instanciate updateFolderStoredProcedure
                    updateFolderStoredProcedure = new UpdateFolderStoredProcedure();

                    // Now create parameters for this procedure
                    updateFolderStoredProcedure.Parameters = CreateUpdateParameters(folder);
                }

                // return value
                return updateFolderStoredProcedure;
            }
            #endregion

            #region CreateFetchAllFoldersStoredProcedure(Folder folder)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFoldersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Folder_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFoldersStoredProcedure' object.</returns>
            public static FetchAllFoldersStoredProcedure CreateFetchAllFoldersStoredProcedure(Folder folder)
            {
                // Initial value
                FetchAllFoldersStoredProcedure fetchAllFoldersStoredProcedure = new FetchAllFoldersStoredProcedure();

                // return value
                return fetchAllFoldersStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
