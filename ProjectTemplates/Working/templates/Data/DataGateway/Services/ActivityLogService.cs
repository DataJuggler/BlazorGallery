

#region using statements

using ApplicationLogicComponent.Connection;
using DataJuggler.UltimateHelper;
using DataGateway;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

#endregion

namespace DataGateway.Services
{

    #region class ActivityLogService
    /// <summary>
    /// This is the Service class for managing ActivityLog objects.
    /// </summary>
    public class ActivityLogService
    {

        #region Methods

            #region FindActivityLog(int id)
            /// <summary>
            /// This method is used to find a ActivityLog object by the primary key id.
            /// </summary>
            /// <returns></returns>
            public static Task<ActivityLog> FindActivityLog(int id)
            {
                // initial value
                ActivityLog activityLog = null;
                
                // If the id is set
                if (id > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the activityLog
                    activityLog = gateway.FindActivityLog(id);
                }
                
                // return value
                return Task.FromResult(activityLog);
            }
            #endregion
            
            #region GetActivityLogList()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<ActivityLog>> GetActivityLogList()
            {
                // initial value
                List<ActivityLog> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadActivityLogs();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region RemoveActivityLog(ActivityLog activityLog)
            /// <summary>
            /// This method is used to delete a ActivityLog
            /// </summary>
            /// <returns></returns>
            public static Task<bool> RemoveActivityLog(ActivityLog activityLog)
            {
                // initial value
                bool deleted = false;
                
                // if the activityLog object exists
                if (NullHelper.Exists(activityLog))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.DeleteActivityLog(activityLog.Id);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region SaveActivityLog(ref ActivityLog activityLog)
            /// <summary>
            /// This method is used to create ActivityLog objects
            /// </summary>
            /// <param name="activityLog">Pass in an object of type ActivityLog to save</param>
            /// <returns></returns>
            public static Task<bool> SaveActivityLog(ref ActivityLog activityLog)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveActivityLog(ref activityLog);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
