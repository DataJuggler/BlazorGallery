
#region using statements

using DataJuggler.UltimateHelper;
using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class MainGalleryView
    [Serializable]
    public partial class MainGalleryView
    {

        #region Private Variables
        
        private bool loadMostRecent;
        #endregion

        #region Constructor
        public MainGalleryView()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public MainGalleryView Clone()
            {
                // Create New Object
                MainGalleryView newMainGalleryView = (MainGalleryView) this.MemberwiseClone();

                // Return Cloned Object
                return newMainGalleryView;
            }
            #endregion

        #endregion

        #region Properties

            #region Image
            /// <summary>
            /// This read only property returns the value of Image from the object TypeAnythingHere.
            /// </summary>
            public Image Image
            {
                
                get
                {
                    // initial value
                    Image image = new Image();
                    
                    // Set the properties from the view to create an Image
                    image.CreatedDate = CreatedDate;
                    image.FolderId = FolderId;
                    image.FolderName = FolderName;
                    image.FullPath = FullPath;
                    image.Height = Height;
                    image.Name = ImageName;
                    image.RelativePath = RelativePath;
                    image.UserName = UserName;
                    image.Likes = Likes;
                    image.UpdateIdentity(ImageId);
                    image.UserId = UserId;
                    image.Width = Width;
                    
                    // return value
                    return image;
                }
            }
            #endregion

            #region LoadMostRecent
            /// <summary>
            /// This property gets or sets the value for 'LoadMostRecent'.
            /// </summary>
            public bool LoadMostRecent
            {
                get { return loadMostRecent; }
                set { loadMostRecent = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
