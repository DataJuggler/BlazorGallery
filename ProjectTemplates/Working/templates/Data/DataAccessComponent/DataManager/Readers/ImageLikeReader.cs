

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class ImageLikeReader
    /// <summary>
    /// This class loads a single 'ImageLike' object or a list of type <ImageLike>.
    /// </summary>
    public class ImageLikeReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ImageLike' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ImageLike' DataObject.</returns>
            public static ImageLike Load(DataRow dataRow)
            {
                // Initial Value
                ImageLike imageLike = new ImageLike();

                // Create field Integers
                int galleryOwnerIdfield = 0;
                int idfield = 1;
                int imageIdfield = 2;
                int userIdfield = 3;

                try
                {
                    // Load Each field
                    imageLike.GalleryOwnerId = DataHelper.ParseInteger(dataRow.ItemArray[galleryOwnerIdfield], 0);
                    imageLike.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    imageLike.ImageId = DataHelper.ParseInteger(dataRow.ItemArray[imageIdfield], 0);
                    imageLike.UserId = DataHelper.ParseInteger(dataRow.ItemArray[userIdfield], 0);
                }
                catch
                {
                }

                // return value
                return imageLike;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ImageLike' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ImageLike Collection.</returns>
            public static List<ImageLike> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ImageLike> imageLikes = new List<ImageLike>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ImageLike' from rows
                        ImageLike imageLike = Load(row);

                        // Add this object to collection
                        imageLikes.Add(imageLike);
                    }
                }
                catch
                {
                }

                // return value
                return imageLikes;
            }
            #endregion

        #endregion

    }
    #endregion

}
