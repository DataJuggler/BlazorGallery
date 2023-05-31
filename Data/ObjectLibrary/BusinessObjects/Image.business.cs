
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Image
    [Serializable]
    public partial class Image
    {

        #region Private Variables
        private bool loadByFolderId;
        private bool deleteByFolderId;
        #endregion

        #region Constructor
        public Image()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Image Clone()
            {
                // Create New Object
                Image newImage = (Image) this.MemberwiseClone();

                // Return Cloned Object
                return newImage;
            }
            #endregion

        #endregion

        #region Properties

            #region DeleteByFolderId
            /// <summary>
            /// This property gets or sets the value for 'DeleteByFolderId'.
            /// </summary>
            public bool DeleteByFolderId
            {
                get { return deleteByFolderId; }
                set { deleteByFolderId = value; }
            }
            #endregion

            #region LoadByFolderId
            /// <summary>
            /// This property gets or sets the value for 'LoadByFolderId'.
            /// </summary>
            public bool LoadByFolderId
            {
                get { return loadByFolderId; }
                set { loadByFolderId = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
