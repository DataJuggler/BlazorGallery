

#region using statements

using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FeedbackReply
    [Serializable]
    public partial class FeedbackReply
    {

        #region Private Variables
        #endregion

        #region Constructor
        public FeedbackReply()
        {

        }
        #endregion

        #region Methods

            #region Clone()
            public FeedbackReply Clone()
            {
                // Create New Object
                FeedbackReply newFeedbackReply = (FeedbackReply) this.MemberwiseClone();

                // Return Cloned Object
                return newFeedbackReply;
            }
            #endregion

        #endregion

        #region Properties
        #endregion

    }
    #endregion

}
