

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class MainGalleryViewReader
    /// <summary>
    /// This class loads a single 'MainGalleryView' object or a list of type <MainGalleryView>.
    /// </summary>
    public class MainGalleryViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'MainGalleryView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'MainGalleryView' DataObject.</returns>
            public static MainGalleryView Load(DataRow dataRow)
            {
                // Initial Value
                MainGalleryView mainGalleryView = new MainGalleryView();

                // Create field Integers
                int createdDatefield = 0;
                int folderIdfield = 1;
                int folderNamefield = 2;
                int heightfield = 3;
                int idfield = 4;
                int imageNamefield = 5;
                int likesfield = 6;
                int minutesOldfield = 7;
                int relativePathfield = 8;
                int userIdfield = 9;
                int userNamefield = 10;
                int widthfield = 11;

                try
                {
                    // Load Each field
                    mainGalleryView.CreatedDate = DataHelper.ParseDate(dataRow.ItemArray[createdDatefield]);
                    mainGalleryView.FolderId = DataHelper.ParseInteger(dataRow.ItemArray[folderIdfield], 0);
                    mainGalleryView.FolderName = DataHelper.ParseString(dataRow.ItemArray[folderNamefield]);
                    mainGalleryView.Height = DataHelper.ParseInteger(dataRow.ItemArray[heightfield], 0);
                    mainGalleryView.Id = DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0);
                    mainGalleryView.ImageName = DataHelper.ParseString(dataRow.ItemArray[imageNamefield]);
                    mainGalleryView.Likes = DataHelper.ParseInteger(dataRow.ItemArray[likesfield], 0);
                    mainGalleryView.MinutesOld = DataHelper.ParseInteger(dataRow.ItemArray[minutesOldfield], 0);
                    mainGalleryView.RelativePath = DataHelper.ParseString(dataRow.ItemArray[relativePathfield]);
                    mainGalleryView.UserId = DataHelper.ParseInteger(dataRow.ItemArray[userIdfield], 0);
                    mainGalleryView.UserName = DataHelper.ParseString(dataRow.ItemArray[userNamefield]);
                    mainGalleryView.Width = DataHelper.ParseInteger(dataRow.ItemArray[widthfield], 0);
                }
                catch
                {
                }

                // return value
                return mainGalleryView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'MainGalleryView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A MainGalleryView Collection.</returns>
            public static List<MainGalleryView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<MainGalleryView> mainGalleryViews = new List<MainGalleryView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'MainGalleryView' from rows
                        MainGalleryView mainGalleryView = Load(row);

                        // Add this object to collection
                        mainGalleryViews.Add(mainGalleryView);
                    }
                }
                catch
                {
                }

                // return value
                return mainGalleryViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
