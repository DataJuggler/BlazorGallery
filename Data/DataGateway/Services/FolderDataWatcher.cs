
#region using statements

using DataJuggler.NET8.Enumerations;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class FolderDataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// Folder item, the delegate is notified so the values are saved.
    /// </summary>
    public class FolderDataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                Folder folder = itemChanged as Folder;

                // If the folder object exists
                if (NullHelper.Exists(folder))
                {
                    // perform the saved
                    bool saved = await FolderService.SaveFolder(ref folder);
                }
            }
            #endregion

            #region Watch(List<Folder> folder)
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="folders">The list of Folder objects to set a delegate on.</param>
            public void Watch(List<Folder> folders)
            {
                // If the folders collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(folders))
                {
                    // Iterate the collection of Folder objects
                    foreach (Folder folder in folders)
                    {
                        // Setup the Callback for each item
                       folder.Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
