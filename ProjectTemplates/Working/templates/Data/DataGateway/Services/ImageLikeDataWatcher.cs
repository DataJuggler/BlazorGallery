
#region using statements

using DataJuggler.Net7.Enumerations;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class ImageLikeDataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// ImageLike item, the delegate is notified so the values are saved.
    /// </summary>
    public class ImageLikeDataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                ImageLike imageLike = itemChanged as ImageLike;

                // If the imageLike object exists
                if (NullHelper.Exists(imageLike))
                {
                    // perform the saved
                    bool saved = await ImageLikeService.SaveImageLike(ref imageLike);
                }
            }
            #endregion

            #region Watch(List<ImageLike> imageLike)
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="imageLikes">The list of ImageLike objects to set a delegate on.</param>
            public void Watch(List<ImageLike> imageLikes)
            {
                // If the imageLikes collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(imageLikes))
                {
                    // Iterate the collection of ImageLike objects
                    foreach (ImageLike imageLike in imageLikes)
                    {
                        // Setup the Callback for each item
                       imageLike.Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
