
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

    #region class FolderWriter
    /// <summary>
    /// This class is used for converting a 'Folder' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class FolderWriter : FolderWriterBase
    {

        #region Static Methods

            #region CreateFetchAllFoldersStoredProcedure(Folder folder)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllFoldersStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Folder_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllFoldersStoredProcedure' object.</returns>
            public static new FetchAllFoldersStoredProcedure CreateFetchAllFoldersStoredProcedure(Folder folder)
            {
                // Initial value
                FetchAllFoldersStoredProcedure fetchAllFoldersStoredProcedure = new FetchAllFoldersStoredProcedure();

                // if the folder object exists
                if (folder != null)
                {
                    // if LoadByUserId is true
                    if (folder.LoadByUserId)
                    {
                        // Change the procedure name
                        fetchAllFoldersStoredProcedure.ProcedureName = "Folder_FetchAllForUserId";
                        
                        // Create the @UserId parameter
                        fetchAllFoldersStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@UserId", folder.UserId);
                    }
                }
                
                // return value
                return fetchAllFoldersStoredProcedure;
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
            public static new FindFolderStoredProcedure CreateFindFolderStoredProcedure(Folder folder)
            {
                // Initial Value
                FindFolderStoredProcedure findFolderStoredProcedure = null;

                // verify folder exists
                if(folder != null)
                {
                    // Instanciate findFolderStoredProcedure
                    findFolderStoredProcedure = new FindFolderStoredProcedure();

                    // if folder.FindByUserIdAndName is true
                    if (folder.FindByUserIdAndName)
                    {
                            // Change the procedure name
                            findFolderStoredProcedure.ProcedureName = "Folder_FindByUserIdAndName";
                            
                            // Create the UserIdAndName field set parameters
                            findFolderStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@Name", folder.Name, "@UserId", folder.UserId);
                    }
                    // if folder.FindSelectedFolderByUserId is true
                    else if (folder.FindSelectedFolderByUserId)
                    {
                        // Change the procedure name
                        findFolderStoredProcedure.ProcedureName = "Folder_FindSelectedFolder";
                        
                        // Create the @UserId parameter
                        findFolderStoredProcedure.Parameters = SqlParameterHelper.CreateSqlParameters("@UserId", folder.UserId);
                    }
                    else
                    {
                        // Now create parameters for this procedure
                        findFolderStoredProcedure.Parameters = CreatePrimaryKeyParameter(folder);
                    }
                }

                // return value
                return findFolderStoredProcedure;
            }
            #endregion
            
        #endregion

    }
    #endregion

}
