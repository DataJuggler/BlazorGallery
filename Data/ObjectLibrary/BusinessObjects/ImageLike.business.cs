
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class ImageLike
    [Serializable]
    public partial class ImageLike
    {

        #region Private Variables
        private bool loadByGalleryOwnerIdAndUserId;       
        private string imageIds;
        private bool loadByUserId;
        #endregion

        #region Constructor
        public ImageLike()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ImageLike Clone()
            {
                // Create New Object
                ImageLike newImageLike = (ImageLike) this.MemberwiseClone();

                // Return Cloned Object
                return newImageLike;
            }
            #endregion

        #endregion

        #region Properties

            #region ImageIds
            /// <summary>
            /// This property gets or sets the value for 'ImageIds'.
            /// </summary>
            public string ImageIds
            {
                get { return imageIds; }
                set { imageIds = value; }
            }
            #endregion
            
            #region LoadByGalleryOwnerIdAndUserId
            /// <summary>
            /// This property gets or sets the value for 'LoadByGalleryOwnerIdAndUserId'.
            /// </summary>
            public bool LoadByGalleryOwnerIdAndUserId
            {
                get { return loadByGalleryOwnerIdAndUserId; }
                set { loadByGalleryOwnerIdAndUserId = value; }
            }
            #endregion

            #region LoadByUserId
            /// <summary>
            /// This property gets or sets the value for 'LoadByUserId'.
            /// </summary>
            public bool LoadByUserId
            {
                get { return loadByUserId; }
                set { loadByUserId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
