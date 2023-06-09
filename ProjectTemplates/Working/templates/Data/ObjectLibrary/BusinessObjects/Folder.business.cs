
#region using statements

using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Folder
    [Serializable]
    public partial class Folder
    {

        #region Private Variables
        private bool loadByUserId;
        private List<Image> images;
        private bool findByUserIdAndName;
        private bool findSelectedFolderByUserId;
        #endregion

        #region Constructor
        public Folder()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Folder Clone()
            {
                // Create New Object
                Folder newFolder = (Folder) this.MemberwiseClone();

                // Return Cloned Object
                return newFolder;
            }
        #endregion

            #region ToString()
            /// <summary>
            /// method returns the String
            /// </summary>
            public override string ToString()
            {
                // return the Folder Name when ToString is called (useful for debugging)
                return Name;
            }
            #endregion
            
        #endregion

        #region Properties

            #region FindByUserIdAndName
            /// <summary>
            /// This property gets or sets the value for 'FindByUserIdAndName'.
            /// </summary>
            public bool FindByUserIdAndName
            {
                get { return findByUserIdAndName; }
                set { findByUserIdAndName = value; }
            }
            #endregion

            #region FindSelectedFolderByUserId
            /// <summary>
            /// This property gets or sets the value for 'FindSelectedFolderByUserId'.
            /// </summary>
            public bool FindSelectedFolderByUserId
            {
                get { return findSelectedFolderByUserId; }
                set { findSelectedFolderByUserId = value; }
            }
            #endregion

            #region HasImages
            /// <summary>
            /// This property returns true if this object has an 'Images'.
            /// </summary>
            public bool HasImages
            {
                get
                {
                    // initial value
                    bool hasImages = (this.Images != null);
                    
                    // return value
                    return hasImages;
                }
            }
            #endregion
            
            #region Images
            /// <summary>
            /// This property gets or sets the value for 'Images'.
            /// </summary>
            public List<Image> Images
            {
                get { return images; }
                set { images = value; }
            }
            #endregion
            
            #region ImagesCount
            /// <summary>
            /// This read only property returns the value of Count from the object Images.
            /// </summary>
            public int ImagesCount
            {
                
                get
                {
                    // initial value
                    int imagesCount = 0;
                    
                    // if Images exists
                    if (Images != null)
                    {
                        // set the return value
                        imagesCount = Images.Count;
                    }
                    
                    // return value
                    return imagesCount;
                }
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
