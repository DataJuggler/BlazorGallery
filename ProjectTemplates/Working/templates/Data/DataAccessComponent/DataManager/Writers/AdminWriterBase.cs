

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

    #region class AdminWriterBase
    /// <summary>
    /// This class is used for converting a 'Admin' object to
    /// the SqlParameter[] to perform the CRUD methods.
    /// </summary>
    public class AdminWriterBase
    {

        #region Static Methods

            #region CreatePrimaryKeyParameter(Admin admin)
            /// <summary>
            /// This method creates the sql Parameter[] array
            /// that holds the primary key value.
            /// </summary>
            /// <param name='admin'>The 'Admin' to get the primary key of.</param>
            /// <returns>A SqlParameter[] array which contains the primary key value.
            /// to delete.</returns>
            internal static SqlParameter[] CreatePrimaryKeyParameter(Admin admin)
            {
                // Initial Value
                SqlParameter[] parameters = new SqlParameter[1];

                // verify user exists
                if (admin != null)
                {
                    // Create PrimaryKey Parameter
                    SqlParameter @Id = new SqlParameter("@Id", admin.Id);

                    // Set parameters[0] to @Id
                    parameters[0] = @Id;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateDeleteAdminStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of an
            /// 'DeleteAdmin'StoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_Delete'.
            /// </summary>
            /// <param name="admin">The 'Admin' to Delete.</param>
            /// <returns>An instance of a 'DeleteAdminStoredProcedure' object.</returns>
            public static DeleteAdminStoredProcedure CreateDeleteAdminStoredProcedure(Admin admin)
            {
                // Initial Value
                DeleteAdminStoredProcedure deleteAdminStoredProcedure = new DeleteAdminStoredProcedure();

                // Now Create Parameters For The DeleteProc
                deleteAdminStoredProcedure.Parameters = CreatePrimaryKeyParameter(admin);

                // return value
                return deleteAdminStoredProcedure;
            }
            #endregion

            #region CreateFindAdminStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of a
            /// 'FindAdminStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_Find'.
            /// </summary>
            /// <param name="admin">The 'Admin' to use to
            /// get the primary key parameter.</param>
            /// <returns>An instance of an FetchUserStoredProcedure</returns>
            public static FindAdminStoredProcedure CreateFindAdminStoredProcedure(Admin admin)
            {
                // Initial Value
                FindAdminStoredProcedure findAdminStoredProcedure = null;

                // verify admin exists
                if(admin != null)
                {
                    // Instanciate findAdminStoredProcedure
                    findAdminStoredProcedure = new FindAdminStoredProcedure();

                    // Now create parameters for this procedure
                    findAdminStoredProcedure.Parameters = CreatePrimaryKeyParameter(admin);
                }

                // return value
                return findAdminStoredProcedure;
            }
            #endregion

            #region CreateInsertParameters(Admin admin)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// inserting a new admin.
            /// </summary>
            /// <param name="admin">The 'Admin' to insert.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateInsertParameters(Admin admin)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[2];
                SqlParameter param = null;

                // verify adminexists
                if(admin != null)
                {
                    // Create [MaxFolderCount] parameter
                    param = new SqlParameter("@MaxFolderCount", admin.MaxFolderCount);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create [MaxStoragePlanFree] parameter
                    param = new SqlParameter("@MaxStoragePlanFree", admin.MaxStoragePlanFree);

                    // set parameters[1]
                    parameters[1] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateInsertAdminStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of an
            /// 'InsertAdminStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_Insert'.
            /// </summary>
            /// <param name="admin"The 'Admin' object to insert</param>
            /// <returns>An instance of a 'InsertAdminStoredProcedure' object.</returns>
            public static InsertAdminStoredProcedure CreateInsertAdminStoredProcedure(Admin admin)
            {
                // Initial Value
                InsertAdminStoredProcedure insertAdminStoredProcedure = null;

                // verify admin exists
                if(admin != null)
                {
                    // Instanciate insertAdminStoredProcedure
                    insertAdminStoredProcedure = new InsertAdminStoredProcedure();

                    // Now create parameters for this procedure
                    insertAdminStoredProcedure.Parameters = CreateInsertParameters(admin);
                }

                // return value
                return insertAdminStoredProcedure;
            }
            #endregion

            #region CreateUpdateParameters(Admin admin)
            /// <summary>
            /// This method creates the sql Parameters[] needed for
            /// update an existing admin.
            /// </summary>
            /// <param name="admin">The 'Admin' to update.</param>
            /// <returns></returns>
            internal static SqlParameter[] CreateUpdateParameters(Admin admin)
            {
                // Initial Values
                SqlParameter[] parameters = new SqlParameter[3];
                SqlParameter param = null;

                // verify adminexists
                if(admin != null)
                {
                    // Create parameter for [MaxFolderCount]
                    param = new SqlParameter("@MaxFolderCount", admin.MaxFolderCount);

                    // set parameters[0]
                    parameters[0] = param;

                    // Create parameter for [MaxStoragePlanFree]
                    param = new SqlParameter("@MaxStoragePlanFree", admin.MaxStoragePlanFree);

                    // set parameters[1]
                    parameters[1] = param;

                    // Create parameter for [Id]
                    param = new SqlParameter("@Id", admin.Id);
                    parameters[2] = param;
                }

                // return value
                return parameters;
            }
            #endregion

            #region CreateUpdateAdminStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of an
            /// 'UpdateAdminStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_Update'.
            /// </summary>
            /// <param name="admin"The 'Admin' object to update</param>
            /// <returns>An instance of a 'UpdateAdminStoredProcedure</returns>
            public static UpdateAdminStoredProcedure CreateUpdateAdminStoredProcedure(Admin admin)
            {
                // Initial Value
                UpdateAdminStoredProcedure updateAdminStoredProcedure = null;

                // verify admin exists
                if(admin != null)
                {
                    // Instanciate updateAdminStoredProcedure
                    updateAdminStoredProcedure = new UpdateAdminStoredProcedure();

                    // Now create parameters for this procedure
                    updateAdminStoredProcedure.Parameters = CreateUpdateParameters(admin);
                }

                // return value
                return updateAdminStoredProcedure;
            }
            #endregion

            #region CreateFetchAllAdminsStoredProcedure(Admin admin)
            /// <summary>
            /// This method creates an instance of a
            /// 'FetchAllAdminsStoredProcedure' object and
            /// creates the sql parameter[] array needed
            /// to execute the procedure 'Admin_FetchAll'.
            /// </summary>
            /// <returns>An instance of a(n) 'FetchAllAdminsStoredProcedure' object.</returns>
            public static FetchAllAdminsStoredProcedure CreateFetchAllAdminsStoredProcedure(Admin admin)
            {
                // Initial value
                FetchAllAdminsStoredProcedure fetchAllAdminsStoredProcedure = new FetchAllAdminsStoredProcedure();

                // return value
                return fetchAllAdminsStoredProcedure;
            }
            #endregion

        #endregion

    }
    #endregion

}
