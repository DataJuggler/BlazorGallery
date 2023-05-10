

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

    #region class ImageService
    /// <summary>
    /// This is the Service class for managing Image objects.
    /// </summary>
    public class ImageService
    {

        #region Methods

            #region FindImage(int id)
            /// <summary>
            /// This method is used to find a Image object by the primary key id.
            /// </summary>
            /// <returns></returns>
            public static Task<Image> FindImage(int id)
            {
                // initial value
                Image image = null;
                
                // If the id is set
                if (id > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the image
                    image = gateway.FindImage(id);
                }
                
                // return value
                return Task.FromResult(image);
            }
            #endregion

            #region GetImageList()
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<Image>> GetImageList()
            {
                // initial value
                List<Image> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadImages();
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion

            #region GetImageListForFolder(int folderId)
            /// <summary>
            /// This method is used to load the Site 
            /// </summary>
            /// <returns></returns>
            public static Task<List<Image>> GetImageListForFolder(int folderId)
            {
                // initial value
                List<Image> list = null;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                list = gateway.LoadImagesForFolderId(folderId);
                
                // return the list
                return Task.FromResult(list);
            }
            #endregion
            
            #region RemoveImage(int imageId)
            /// <summary>
            /// This method is used to delete a Image
            /// </summary>
            /// <returns></returns>
            public static Task<bool> RemoveImage(int imageId)
            {
                // initial value
                bool deleted = false;
                
                // if the image object exists
                if (imageId > 0)
                {
                    // Create a new instance of a 'Gateway' object, and set the connectionName
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // load the sites
                    deleted = gateway.DeleteImage(imageId);
                }
                
                // return the value of deleted
                return Task.FromResult(deleted);
            }
        #endregion

            #region SaveImage(ref Image image)
            /// <summary>
            /// This method is used to create Image objects
            /// </summary>
            /// <param name="image">Pass in an object of type Image to save</param>
            /// <returns></returns>
            public static Task<bool> SaveImage(ref Image image)
            {
                // initial value
                bool saved = false;
                
                // Create a new instance of a 'Gateway' object, and set the connectionName
                Gateway gateway = new Gateway(Connection.Name);
                
                // load the sites
                saved = gateway.SaveImage(ref image);
                
                // return the value of saved
                return Task.FromResult(saved);
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
