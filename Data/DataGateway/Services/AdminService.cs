

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

    #region class AdminService
    /// <summary>
    /// This is the Service class for managing Admin objects.
    /// </summary>
    public class AdminService
    {

        #region Methods

            #region FindAdmin(int id)
            /// <summary>
            /// This method is used to find a Admin object by the primary key id.
            /// </summary>
            /// <returns></returns>
            public static Task<Admin> FindAdmin(int id)
            {
                // initial value
                Admin admin = null;
                
                // If the id is set
                if (id > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the admin
                    admin = gateway.FindAdmin(id);
                }
                
                // return value
                return Task.FromResult(admin);
            }
            #endregion
            
            #region GetAdminList()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<Admin>> GetAdminList()
            {
                // initial value
                List<Admin> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadAdmins();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region RemoveAdmin(Admin admin)
            /// <summary>
            /// This method is used to delete a Admin
            /// </summary>
            /// <returns></returns>
            public static Task<bool> RemoveAdmin(Admin admin)
            {
                // initial value
                bool deleted = false;
                
                // if the admin object exists
                if (NullHelper.Exists(admin))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.DeleteAdmin(admin.Id);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region SaveAdmin(ref Admin admin)
            /// <summary>
            /// This method is used to create Admin objects
            /// </summary>
            /// <param name="admin">Pass in an object of type Admin to save</param>
            /// <returns></returns>
            public static Task<bool> SaveAdmin(ref Admin admin)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveAdmin(ref admin);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
