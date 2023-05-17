

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ErrorLog
    [Serializable]
    public partial class ErrorLog
    {

        #region Private Variables
        #endregion

        #region Constructor
        public ErrorLog()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ErrorLog Clone()
            {
                // Create New Object
                ErrorLog newErrorLog = (ErrorLog) this.MemberwiseClone();

                // Return Cloned Object
                return newErrorLog;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
