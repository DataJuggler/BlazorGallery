

#region using statements

using BlazorStyled;

#endregion

using DataJuggler.Blazor.FileUpload;

namespace DataJuggler.BlazorGallery.Pages
{

    #region class Index
    /// <summary>
    /// This class is the main page of this app.
    /// </summary>
    public partial class Index
    {
        
        #region Private Variables
        public const int UploadLimit = 20480000;
        public const string FileTooLargeMessage = "The file must be 20 megs or less.";
        private string blueButton;
        private string resetButton;
        #endregion

        #region Methods

            #region OnFileUploaded(UploadedFileInfo file)
            /// <summary>
            /// This method On File Uploaded
            /// </summary>
            public void OnFileUploaded(UploadedFileInfo file)
            {
                // if the file was uploaded
                if (!file.Aborted)
                {
                   // To Do: Save the uploaded file
                   string fileName = file.Name;

                   // auto reset
                   OnReset();                   
                }
                else
                {
                    // for debugging only
                    if (file.HasException)
                    {
                        // for debugging only
                        string message = file.Exception.Message;
                    }
                }
            }
            #endregion

            #region OnReset()
            /// <summary>
            /// On Reset
            /// </summary>
            public void OnReset()
            {
                
            }
            #endregion
            
        #endregion

        #region Properties

            #region BlueButton
            /// <summary>
            /// This property gets or sets the value for 'BlueButton'.
            /// </summary>
            public string BlueButton
            {
                get { return blueButton; }
                set { blueButton = value; }
            }
            #endregion
            
            #region ResetButton
            /// <summary>
            /// This property gets or sets the value for 'ResetButton'.
            /// </summary>
            public string ResetButton
            {
                get { return resetButton; }
                set { resetButton = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
