

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

    #region class ImageLikeService
    /// <summary>
    /// This is the Service class for managing ImageLike objects.
    /// </summary>
    public class ImageLikeService
    {

        #region Methods

            #region FindImageLike(int id)
            /// <summary>
            /// This method is used to find a ImageLike object by the primary key id.
            /// </summary>
            /// <returns></returns>
            public static Task<ImageLike> FindImageLike(int id)
            {
                // initial value
                ImageLike imageLike = null;
                
                // If the id is set
                if (id > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the imageLike
                    imageLike = gateway.FindImageLike(id);
                }
                
                // return value
                return Task.FromResult(imageLike);
            }
            #endregion
            
            #region GetImageLikeList()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<ImageLike>> GetImageLikeList()
            {
                // initial value
                List<ImageLike> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadImageLikes();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region RemoveImageLike(ImageLike imageLike)
            /// <summary>
            /// This method is used to delete a ImageLike
            /// </summary>
            /// <returns></returns>
            public static Task<bool> RemoveImageLike(ImageLike imageLike)
            {
                // initial value
                bool deleted = false;
                
                // if the imageLike object exists
                if (NullHelper.Exists(imageLike))
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.DeleteImageLike(imageLike.Id);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region SaveImageLike(ref ImageLike imageLike)
            /// <summary>
            /// This method is used to create ImageLike objects
            /// </summary>
            /// <param name="imageLike">Pass in an object of type ImageLike to save</param>
            /// <returns></returns>
            public static Task<bool> SaveImageLike(ref ImageLike imageLike)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveImageLike(ref imageLike);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
