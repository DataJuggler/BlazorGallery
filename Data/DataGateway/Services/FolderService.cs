

#region using statements

using ApplicationLogicComponent.Connection;
using DataJuggler.UltimateHelper;
using DataGateway;
using ObjectLibrary.BusinessObjects;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;

#endregion

namespace DataGateway.Services
{

    #region class FolderService
    /// <summary>
    /// This is the Service class for managing Folder objects.
    /// </summary>
    public class FolderService
    {

        #region Methods

            #region FindFolder(int id)
            /// <summary>
            /// This method is used to find a Folder object by the primary key id.
            /// </summary>
            /// <returns></returns>
            public static Task<Folder> FindFolder(int id)
            {
                // initial value
                Folder folder = null;
                
                // If the id is set
                if (id > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the folder
                    folder = gateway.FindFolder(id);
                }
                
                // return value
                return Task.FromResult(folder);
            }
            #endregion
            
            #region GetFolderList()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<Folder>> GetFolderList()
            {
                // initial value
                List<Folder> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadFolders();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion

            #region GetFolderListForUserId(int userId)
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<Folder>> GetFolderListForUserId(int userId)
            {
                // initial value
                List<Folder> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadFoldersForUserId(userId);
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region RemoveFolder(Folder folder)
            /// <summary>
            /// This method is used to delete a Folder
            /// </summary>
            /// <returns></returns>
            public static Task<bool> RemoveFolder(Folder folder)
            {
                // initial value
                bool deleted = false;
                
                // if the folder object exists
                if (NullHelper.Exists(folder))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.DeleteFolder(folder.Id);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
            #endregion

            #region SaveFolder(ref Folder folder)
            /// <summary>
            /// This method is used to create Folder objects
            /// </summary>
            /// <param name="folder">Pass in an object of type Folder to save</param>
            /// <returns></returns>
            public static Task<bool> SaveFolder(ref Folder folder)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveFolder(ref folder);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
