

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Feedback
    [Serializable]
    public partial class Feedback
    {

        #region Private Variables
        #endregion

        #region Constructor
        public Feedback()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public Feedback Clone()
            {
                // Create New Object
                Feedback newFeedback = (Feedback) this.MemberwiseClone();

                // Return Cloned Object
                return newFeedback;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
