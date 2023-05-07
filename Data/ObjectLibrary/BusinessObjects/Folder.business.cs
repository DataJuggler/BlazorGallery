

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net7.Delegates;
using DataJuggler.Net7.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Folder
    [Serializable]
    public partial class Folder
    {

        #region Private Variables
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
        #endregion

    }
    #endregion

}
