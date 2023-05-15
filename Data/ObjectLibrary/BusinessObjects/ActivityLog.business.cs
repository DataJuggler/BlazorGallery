

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ActivityLog
    [Serializable]
    public partial class ActivityLog
    {

        #region Private Variables
        #endregion

        #region Constructor
        public ActivityLog()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public ActivityLog Clone()
            {
                // Create New Object
                ActivityLog newActivityLog = (ActivityLog) this.MemberwiseClone();

                // Return Cloned Object
                return newActivityLog;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
