

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class ErrorLogReader
    /// <summary>
    /// This class loads a single 'ErrorLog' object or a list of type <ErrorLog>.
    /// </summary>
    public class ErrorLogReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ErrorLog' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ErrorLog' DataObject.</returns>
            public static ErrorLog Load(DataRow dataRow)
            {
                // Initial Value
                ErrorLog errorLog = new ErrorLog();

                // Create field Integers
                int createdDatefield = 0;
                int errorfield = 1;
                int folderIdfield = 2;
                int idfield = 3;
                int messagefield = 4;
                int userIdfield = 5;

                try
                {
                    // Load Each field
                    errorLog.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    errorLog.Error = DataHelper.ParseString(dataRow.ItemArray[errorfield]);
                    errorLog.FolderId = DataHelper.ParseInteger(dataRow.ItemArray[folderIdfield], 0);
                    errorLog.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    errorLog.Message = DataHelper.ParseString(dataRow.ItemArray[messagefield]);
                    errorLog.UserId = DataHelper.ParseInteger(dataRow.ItemArray[userIdfield], 0);
                }
                catch
                {
                }

                // return value
                return errorLog;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ErrorLog' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ErrorLog Collection.</returns>
            public static List<ErrorLog> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ErrorLog> errorLogs = new List<ErrorLog>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ErrorLog' from rows
                        ErrorLog errorLog = Load(row);

                        // Add this object to collection
                        errorLogs.Add(errorLog);
                    }
                }
                catch
                {
                }

                // return value
                return errorLogs;
            }
            #endregion

        #endregion

    }
    #endregion

}
