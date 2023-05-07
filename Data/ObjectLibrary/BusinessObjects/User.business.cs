

#region using statements

using ObjectLibrary.Enumerations;
using System;
using DataJuggler.Net7.Delegates;
using DataJuggler.Net7.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class User
    [Serializable]
    public partial class User
    {

        #region Private Variables
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
        #endregion

    }
    #endregion

}
