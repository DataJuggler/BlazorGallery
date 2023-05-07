

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class FolderReader
    /// <summary>
    /// This class loads a single 'Folder' object or a list of type <Folder>.
    /// </summary>
    public class FolderReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Folder' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Folder' DataObject.</returns>
            public static Folder Load(DataRow dataRow)
            {
                // Initial Value
                Folder folder = new Folder();

                // Create field Integers
                int createdDatefield = 0;
                int idfield = 1;
                int namefield = 2;
                int selectedfield = 3;
                int userIdfield = 4;

                try
                {
                    // Load Each field
                    folder.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    folder.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    folder.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    folder.Selected = DataHelper.ParseBoolean(dataRow.ItemArray[selectedfield], false);
                    folder.UserId = DataHelper.ParseInteger(dataRow.ItemArray[userIdfield], 0);
                }
                catch
                {
                }

                // return value
                return folder;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Folder' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Folder Collection.</returns>
            public static List<Folder> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Folder> folders = new List<Folder>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Folder' from rows
                        Folder folder = Load(row);

                        // Add this object to collection
                        folders.Add(folder);
                    }
                }
                catch
                {
                }

                // return value
                return folders;
            }
            #endregion

        #endregion

    }
    #endregion

}
