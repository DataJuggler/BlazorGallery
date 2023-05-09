
#region using statements

using DataJuggler.Net7.Enumerations;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class AdminDataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// Admin item, the delegate is notified so the values are saved.
    /// </summary>
    public class AdminDataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                Admin admin = itemChanged as Admin;

                // If the admin object exists
                if (NullHelper.Exists(admin))
                {
                    // perform the saved
                    bool saved = await AdminService.SaveAdmin(ref admin);
                }
            }
            #endregion

            #region Watch(List<Admin> admin)
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="admins">The list of Admin objects to set a delegate on.</param>
            public void Watch(List<Admin> admins)
            {
                // If the admins collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(admins))
                {
                    // Iterate the collection of Admin objects
                    foreach (Admin admin in admins)
                    {
                        // Setup the Callback for each item
                       admin.Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
