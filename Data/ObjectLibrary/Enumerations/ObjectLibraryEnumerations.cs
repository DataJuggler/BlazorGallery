

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region enum ProfileVisibilityEnum : int
    /// <summary>
    /// This enum is used to set whether a user shares their profile publicly or not
    /// </summary>
    public enum ProfileVisibilityEnum : int
    {
        NotSelected = 0,
        Public = 1,
        Private = -1
    }
    #endregion

    #region enum ScreenTypeEnum : int
    /// <summary>
    /// What size file can this user upload?
    /// </summary>
    public enum ScreenTypeEnum : int
    {
        MainScreen = 0,
        SignUp = 1,
        Login = 2,
        Index = 3,
        TermsOfservice = 4,
        SetProfileVisibility = 5,
        ViewImage = 6,
        EmailVerification = 7,
        ViewImageInMainGallery = 8,
        ViewingGallery = 9        
    }
    #endregion

}
