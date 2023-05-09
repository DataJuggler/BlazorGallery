
#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion

namespace ObjectLibrary.BusinessObjects
{

    #region class Folder
    [Serializable]
    public partial class Folder
    {

        #region Private Variables
        private bool loadByUserId;
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

        #endregion

        #region Properties

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
