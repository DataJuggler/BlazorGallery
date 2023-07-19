
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class User
    [Serializable]
    public partial class User
    {

        #region Private Variables
        private bool findByUserName;
        private bool findByEmailAddress;
        private bool viewOnlyMode;
        private User viewingGalleryOwner;
        #endregion

        #region Constructor
        public User()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public User Clone()
            {
                // Create New Object
                User newUser = (User) this.MemberwiseClone();

                // Return Cloned Object
                return newUser;
            }
            #endregion

        #endregion

        #region Properties

            #region FindByEmailAddress
            /// <summary>
            /// This property gets or sets the value for 'FindByEmailAddress'.
            /// </summary>
            public bool FindByEmailAddress
            {
                get { return findByEmailAddress; }
                set { findByEmailAddress = value; }
            }
            #endregion

            #region FindByUserName
            /// <summary>
            /// This property gets or sets the value for 'FindByUserName'.
            /// </summary>
            public bool FindByUserName
            {
                get { return findByUserName; }
                set { findByUserName = value; }
            }
            #endregion

            #region FoldersTitle
            /// <summary>
            /// This read only property returns the value of FoldersTitle from the object UserName.
            /// </summary>
            public string FoldersTitle
            {
                
                get
                {
                    // initial value
                    string foldersTitle = UserName + "'s Folders";
                    
                    // return value
                    return foldersTitle;
                }
            }
            #endregion
            
            #region HasViewingGalleryOwner
            /// <summary>
            /// This property returns true if this object has a 'ViewingGalleryOwner'.
            /// </summary>
            public bool HasViewingGalleryOwner
            {
                get
                {
                    // initial value
                    bool hasViewingGalleryOwner = (this.ViewingGalleryOwner != null);
                    
                    // return value
                    return hasViewingGalleryOwner;
                }
            }
            #endregion
            
            #region IsGalleryOwner
            /// <summary>
            /// This read only property returns the value of IsGalleryOwner from the object ViewingGalleryOwner.
            /// </summary>
            public bool IsGalleryOwner
            {
                
                get
                {
                    // initial value
                    bool isGalleryOwner = false;
                    
                    // if ViewingGalleryOwner exists
                    if (ViewingGalleryOwner != null)
                    {
                        // set the return value
                        isGalleryOwner = (ViewingGalleryOwner.Id == Id);
                    }
                    
                    // return value
                    return isGalleryOwner;
                }
            }
            #endregion
            
            #region ViewingGalleryOwner
            /// <summary>
            /// This property gets or sets the value for 'ViewingGalleryOwner'.
            /// </summary>
            public User ViewingGalleryOwner
            {
                get { return viewingGalleryOwner; }
                set { viewingGalleryOwner = value; }
            }
            #endregion
            
            #region ViewOnlyMode
            /// <summary>
            /// This property gets or sets the value for 'ViewOnlyMode'.
            /// </summary>
            public bool ViewOnlyMode
            {
                get { return viewOnlyMode; }
                set { viewOnlyMode = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
