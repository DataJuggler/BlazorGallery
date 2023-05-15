

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class ActivityLogReader
    /// <summary>
    /// This class loads a single 'ActivityLog' object or a list of type <ActivityLog>.
    /// </summary>
    public class ActivityLogReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ActivityLog' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ActivityLog' DataObject.</returns>
            public static ActivityLog Load(DataRow dataRow)
            {
                // Initial Value
                ActivityLog activityLog = new ActivityLog();

                // Create field Integers
                int activityfield = 0;
                int createdDatefield = 1;
                int detailfield = 2;
                int folderIdfield = 3;
                int idfield = 4;
                int userIdfield = 5;

                try
                {
                    // Load Each field
                    activityLog.Activity = DataHelper.ParseString(dataRow.ItemArray[activityfield]);
                    activityLog.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    activityLog.Detail = DataHelper.ParseString(dataRow.ItemArray[detailfield]);
                    activityLog.FolderId = DataHelper.ParseInteger(dataRow.ItemArray[folderIdfield], 0);
                    activityLog.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    activityLog.UserId = DataHelper.ParseInteger(dataRow.ItemArray[userIdfield], 0);
                }
                catch
                {
                }

                // return value
                return activityLog;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ActivityLog' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ActivityLog Collection.</returns>
            public static List<ActivityLog> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ActivityLog> activityLogs = new List<ActivityLog>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ActivityLog' from rows
                        ActivityLog activityLog = Load(row);

                        // Add this object to collection
                        activityLogs.Add(activityLog);
                    }
                }
                catch
                {
                }

                // return value
                return activityLogs;
            }
            #endregion

        #endregion

    }
    #endregion

}
