

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

    #region class ErrorLogService
    /// <summary>
    /// This is the Service class for managing ErrorLog objects.
    /// </summary>
    public class ErrorLogService
    {

        #region Methods

            #region FindErrorLog(int id)
            /// <summary>
            /// This method is used to find a ErrorLog object by the primary key id.
            /// </summary>
            /// <returns></returns>
            public static Task<ErrorLog> FindErrorLog(int id)
            {
                // initial value
                ErrorLog errorLog = null;
                
                // If the id is set
                if (id > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the errorLog
                    errorLog = gateway.FindErrorLog(id);
                }
                
                // return value
                return Task.FromResult(errorLog);
            }
            #endregion
            
            #region GetErrorLogList()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<ErrorLog>> GetErrorLogList()
            {
                // initial value
                List<ErrorLog> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadErrorLogs();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region RemoveErrorLog(ErrorLog errorLog)
            /// <summary>
            /// This method is used to delete a ErrorLog
            /// </summary>
            /// <returns></returns>
            public static Task<bool> RemoveErrorLog(ErrorLog errorLog)
            {
                // initial value
                bool deleted = false;
                
                // if the errorLog object exists
                if (NullHelper.Exists(errorLog))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.DeleteErrorLog(errorLog.Id);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region SaveErrorLog(ref ErrorLog errorLog)
            /// <summary>
            /// This method is used to create ErrorLog objects
            /// </summary>
            /// <param name="errorLog">Pass in an object of type ErrorLog to save</param>
            /// <returns></returns>
            public static Task<bool> SaveErrorLog(ref ErrorLog errorLog)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveErrorLog(ref errorLog);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
