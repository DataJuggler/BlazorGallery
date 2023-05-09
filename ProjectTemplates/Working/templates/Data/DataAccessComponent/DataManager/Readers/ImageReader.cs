

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class ImageReader
    /// <summary>
    /// This class loads a single 'Image' object or a list of type <Image>.
    /// </summary>
    public class ImageReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Image' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Image' DataObject.</returns>
            public static Image Load(DataRow dataRow)
            {
                // Initial Value
                Image image = new Image();

                // Create field Integers
                int createdDatefield = 0;
                int folderIdfield = 1;
                int fullPathfield = 2;
                int heightfield = 3;
                int idfield = 4;
                int namefield = 5;
                int userIdfield = 6;
                int widthfield = 7;

                try
                {
                    // Load Each field
                    image.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    image.FolderId = DataHelper.ParseInteger(dataRow.ItemArray[folderIdfield], 0);
                    image.FullPath = DataHelper.ParseString(dataRow.ItemArray[fullPathfield]);
                    image.Height = DataHelper.ParseInteger(dataRow.ItemArray[heightfield], 0);
                    image.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    image.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    image.UserId = DataHelper.ParseInteger(dataRow.ItemArray[userIdfield], 0);
                    image.Width = DataHelper.ParseInteger(dataRow.ItemArray[widthfield], 0);
                }
                catch
                {
                }

                // return value
                return image;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Image' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Image Collection.</returns>
            public static List<Image> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Image> images = new List<Image>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Image' from rows
                        Image image = Load(row);

                        // Add this object to collection
                        images.Add(image);
                    }
                }
                catch
                {
                }

                // return value
                return images;
            }
            #endregion

        #endregion

    }
    #endregion

}
