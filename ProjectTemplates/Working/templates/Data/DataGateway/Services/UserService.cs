

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

    #region class UserService
    /// <summary>
    /// This is the Service class for managing User objects.
    /// </summary>
    public class UserService
    {

        #region Methods

            #region FindUser(int id)
            /// <summary>
            /// This method is used to find a User object by the primary key id.
            /// </summary>
            /// <returns></returns>
            public static Task<User> FindUser(int id)
            {
                // initial value
                User user = null;
                
                // If the id is set
                if (id > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the user
                    user = gateway.FindUser(id);
                }
                
                // return value
                return Task.FromResult(user);
            }
            #endregion

            #region FindUserByEmailAddress(string emailAddress)
            /// <summary>
            /// This method is used to find a User object by emailAddress
            /// </summary>
            /// <returns></returns>
            public static Task<User> FindUserByEmailAddress(string emailAddress)
            {
                // initial value
                User user = null;
                
                // If the id is set
                if (TextHelper.Exists(emailAddress))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the user
                    user = gateway.FindUserByEmailAddress(emailAddress);
                }
                
                // return value
                return Task.FromResult(user);
            }
            #endregion

            #region FindUserByUserName(string userName)
            /// <summary>
            /// This method is used to find a User object by userName
            /// </summary>
            /// <returns></returns>
            public static Task<User> FindUserByUserName(string userName)
            {
                // initial value
                User user = null;
                
                // If the id is set
                if (TextHelper.Exists(userName))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the user
                    user = gateway.FindUserByUserName(userName);
                }
                
                // return value
                return Task.FromResult(user);
            }
            #endregion
            
            #region GetUserList()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<User>> GetUserList()
            {
                // initial value
                List<User> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadUsers();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region RemoveUser(User user)
            /// <summary>
            /// This method is used to delete a User
            /// </summary>
            /// <returns></returns>
            public static Task<bool> RemoveUser(User user)
            {
                // initial value
                bool deleted = false;
                
                // if the user object exists
                if (NullHelper.Exists(user))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.DeleteUser(user.Id);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region SaveUser(ref User user)
            /// <summary>
            /// This method is used to create User objects
            /// </summary>
            /// <param name="user">Pass in an object of type User to save</param>
            /// <returns></returns>
            public static Task<bool> SaveUser(ref User user)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveUser(ref user);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
