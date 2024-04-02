
#region using statements

using DataJuggler.NET8.Enumerations;
using DataJuggler.UltimateHelper;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;

#endregion

namespace DataGateway.Services
{

    #region class ErrorLogDataWatcher
    /// <summary>
    /// This class is used to hold a delegate so when changes occur in a 
    /// ErrorLog item, the delegate is notified so the values are saved.
    /// </summary>
    public class ErrorLogDataWatcher
    {

        #region Methods

            #region ItemChanged(object itemChanged, ListChangeTypeEnum listChangeType)
            /// <summary>
            /// This method Item Changed
            /// </summary>
            public async void ItemChanged(object itemChanged, ChangeTypeEnum listChangeType)
            {
                // cast the item as a ToDo object
                ErrorLog errorLog = itemChanged as ErrorLog;

                // If the errorLog object exists
                if (NullHelper.Exists(errorLog))
                {
                    // perform the saved
                    bool saved = await ErrorLogService.SaveErrorLog(ref errorLog);
                }
            }
            #endregion

            #region Watch(List<ErrorLog> errorLog)
            /// <summary>
            /// This method watches the current list by setting a delegate for each item.
            /// </summary>
            /// <param name="errorLogs">The list of ErrorLog objects to set a delegate on.</param>
            public void Watch(List<ErrorLog> errorLogs)
            {
                // If the errorLogs collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(errorLogs))
                {
                    // Iterate the collection of ErrorLog objects
                    foreach (ErrorLog errorLog in errorLogs)
                    {
                        // Setup the Callback for each item
                       errorLog.Callback = ItemChanged;
                    }
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
