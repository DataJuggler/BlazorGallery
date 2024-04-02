
#region using statements

using DataJuggler.NET8.Enumerations;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class ActivityLogDataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// ActivityLog item, the delegate is notified so the values are saved.
    /// </summary>
    public class ActivityLogDataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                ActivityLog activityLog = itemChanged as ActivityLog;

                // If the activityLog object exists
                if (NullHelper.Exists(activityLog))
                {
                    // perform the saved
                    bool saved = await ActivityLogService.SaveActivityLog(ref activityLog);
                }
            }
            #endregion

            #region Watch(List<ActivityLog> activityLog)
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="activityLogs">The list of ActivityLog objects to set a delegate on.</param>
            public void Watch(List<ActivityLog> activityLogs)
            {
                // If the activityLogs collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(activityLogs))
                {
                    // Iterate the collection of ActivityLog objects
                    foreach (ActivityLog activityLog in activityLogs)
                    {
                        // Setup the Callback for each item
                       activityLog.Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
