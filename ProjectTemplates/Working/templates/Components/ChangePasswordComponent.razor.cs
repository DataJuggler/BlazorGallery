

#region using statements

using Azure.Communication.Email;
using DataGateway.Services;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.BlazorGallery.Shared;
using DataJuggler.RandomShuffler;
using DataJuggler.RandomShuffler.Enumerations;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System.Runtime.Versioning;
using DataJuggler.BlazorGallery.Util;
using Timer = System.Timers.Timer;
using System.Drawing;
using DataJuggler.Cryptography;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class ChangePasswordComponent
    /// <summary>
    /// This class is used to change the password for a user. To do this, a user must be sent a code, then
    /// the user must enter the code to be able to enter the code sent to be able to change the password.
    /// </summary>
   [SupportedOSPlatform("windows")]
    public partial class ChangePasswordComponent : IBlazorComponent, IBlazorComponentParent,ISpriteSubscriber
    {

        #region Private Variables
        private bool showProgress;
        private string messageColor;
        private string progressStyle;
        private string percentString;
        private Timer timer;
        private bool verified;
        private int percent;
        private string statusMessage;       
        private string checkMarkContainerStyle;
        private string checkMarkStyle;
        private string checkMarkImage;
        private string name;
        private IBlazorComponentParent parent;
        private Sprite invisibleSprite;
        private double checkMarkTop;
        private string email;
        private ValidationComponent emailComponent;
        private ValidationComponent codeComponent;
        private ValidationComponent passwordComponent;
        private ValidationComponent confirmPasswordComponent;
        private bool emailSendingInProgress;
        private bool enablePasswordControls;
        private int column1Width;
        private int column2Width;
        private int controlWidth;        
        private List<IBlazorComponent> children;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a ChangePasswordComponent object
        /// </summary>

        public ChangePasswordComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion

        #region Events            
            
            #region TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
            /// <summary>
            /// event is fired when Timer Elapsed
            /// </summary>
            private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                // destroy
                Timer.Dispose();
                
                // hide
                CheckMarkImage = "../Images/Transparent.png";

                // if the value for HasEmailComponent is true
                if (HasEmailComponent)
                {
                    // This must be valid
                    EmailComponent.IsValid = true;

                    // Set the Email
                    EmailComponent.SetTextValue(Email);
                }
            }
            #endregion
            
        #endregion

        #region Methods

            #region Cancel()
            /// <summary>
            /// Cancel
            /// </summary>
            public void Cancel()
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Return to the main screen
                    ParentMainLayout.SetupScreen(ScreenTypeEnum.MainScreen);
                }
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // Not used most likely
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // default
                CheckMarkImage = "../Images/Transparent.png";  
                
                // Set the message color
                MessageColor = "black";
                StatusMessage = "Click the Send button to receive your 6 digit code.";

                // Create a new collection of 'IBlazorComponent' objects.
                Children = new List<IBlazorComponent>();
                Column1Width = 8;
                Column2Width = 16;
                ControlWidth=26;
            }
            #endregion

            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// Refresh
            /// </summary>
            public void Refresh()
            {
                // Update the UI
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
            #endregion
            
            #region Register(IBlazorComponent component)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // deteremine the component by the names
                if (component.Name == "EmailComponent")
                {
                    // Store the EmailComponent
                    EmailComponent = component as ValidationComponent;

                    // if the value for HasEmailComponent is true
                    if (HasEmailComponent)
                    {
                        // Set Focus to the textbox
                        EmailComponent.SetFocus();
                    }
                }
                else if (component.Name == "CodeComponent")
                {
                    // Store the CodeComponent
                    CodeComponent = component as ValidationComponent;
                }
                else if (component.Name == "PasswordComponent")
                {
                    // Set the PasswordCompeont
                    PasswordComponent = component as ValidationComponent;
                }
                else if (component.Name == "ConfirmPasswordComponent")
                {
                    // Set the PasswordCompeont
                    ConfirmPasswordComponent = component as ValidationComponent;
                }
            }
            #endregion
            
            #region Register(Sprite sprite)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(Sprite sprite)
            {
                // Set the sprite
                InvisibleSprite = sprite;    
            }
            #endregion

            #region SaveNewPassword()
            /// <summary>
            /// Save New Password
            /// </summary>
            public async void SaveNewPassword()
            {
                // If the PasswordComponent and ConfirmPasswordComponent both exist
                if ((HasPasswordComponent) && (HasPasswordComponent) && (HasEmail))
                {
                    // get both
                    string password = PasswordComponent.Text;
                    string confirm = ConfirmPasswordComponent.Text;

                    // if both passwords exist
                    if ((TextHelper.IsEqual(password, confirm)) && (HasEmail))
                    {
                        // if the password was entered                        
                        if (password.Length >= 8)
                        {
                            // find the user
                            User user = await UserService.FindUserByEmailAddress(Email);

                            // If the user object exists
                            if (NullHelper.Exists(user))
                            {
                                // Get the KeyCode
                                string keyCode = EnvironmentVariableHelper.GetEnvironmentVariableValue("BlazorGalleryKeyCode", EnvironmentVariableTarget.Machine);

                                // If the keyCode string exists
                                if (TextHelper.Exists(keyCode))
                                {
                                    // Set the PasswordHash, this takes the longest time
                                    user.PasswordHash = CryptographyHelper.GeneratePasswordHash(password, keyCode, 3);
                                }

                                // if the password hash was created
                                if (TextHelper.Exists(user.PasswordHash))
                                {
                                    // save the user
                                    bool saved = await UserService.SaveUser(ref user);

                                    // if the value for saved is true
                                    if (saved)
                                    {
                                        // if the value for HasParentMainLayout is true
                                        if (HasParentMainLayout)
                                        {
                                            // Send the user to the login page
                                            ParentMainLayout.SetupScreen(ScreenTypeEnum.Login, Email);
                                        }
                                    }
                                    else
                                    {
                                        // show a message
                                        MessageColor = "red";
                                        StatusMessage = "Oops something went wrong. Try again or try a different password.";
                                    }
                                }
                                else
                                {
                                    // show a message
                                    MessageColor = "red";
                                    StatusMessage = "Oops something went wrong. Try again or try a different password.";
                                }
                            }
                            else
                            {
                                // the user already validated their account with a code, so the user must exist (famous last words)
                            }
                        }
                        else
                        {
                            // Set to false
                            PasswordComponent.IsValid = false;
                            ConfirmPasswordComponent.IsValid = false;

                            // Set the message color
                            MessageColor = "red";
                            StatusMessage = "The passwords must be 8 - 20 characters.";
                        }
                    }
                    else
                    {
                        // Set to false
                        PasswordComponent.IsValid = false;
                        ConfirmPasswordComponent.IsValid = false;

                        // Set the message color
                        MessageColor = "red";
                        StatusMessage = "The passwords do not match.";
                    }
                }
            }
            #endregion
            
            #region SendEmailCode()
            /// <summary>
            /// Send an email with a code.
            /// </summary>
            public async void SendEmailCode()
            {
                // Erase
                StatusMessage = "";

                // if the value for HasEmailComponent is true
                if (HasEmailComponent)
                {
                    // Get the email address entered by the user
                    Email = emailComponent.Text;

                    // is this a valid email
                    bool validEmail = EmailHelper.CheckValidEmail(Email);

                    // if the value for validEmail is true
                    if (validEmail)
                    {
                        // attempt to find this user
                        User user = await UserService.FindUserByEmailAddress(Email);

                        // If the user object exists
                        if (NullHelper.Exists(user))
                        {
                             // Set to true
                            EmailComponent.IsValid = true;

                            // create a shuffler
                            LargeNumberShuffler shuffler = new LargeNumberShuffler(6, 100000, 999999, NumberOutOfRangeOptionEnum.Repull);

                            // Store the code that was emailed
                            user.CodeEmailed = shuffler.PullNumber();
                            user.EmailedCodeDate = DateTime.Now;

                            // save the user
                            bool saved = await UserService.SaveUser(ref user);

                            // if the value for saved is true
                            if (saved)
                            {
                                // if the InvisiibleSprite exists
                                if (HasInvisibleSprite)
                                {
                                    // Start the timer
                                    ShowProgress = true;

                                    // Update the UI
                                    Refresh();

                                    // Start the Timer
                                    InvisibleSprite.Start();
                                }

                                // Send the user an email
                                bool sent = await SendEmail(user.CodeEmailed, email);

                                // if the message was sent
                                if (sent)
                                {
                                    // update
                                    EmailComponent.IsValid = true;
                                    EmailComponent.SetTextValue(Email);

                                    // Stop the Timer
                                    InvisibleSprite.Stop();
                            
                                    // Set the message
                                    StatusMessage = "Please check your email for your 6 digit code.";

                                    // Set the top
                                    CheckMarkTop = 152;

                                    // set to visible
                                    CheckMarkImage = "../Images/Check.png";
                    
                                    // Update the UI
                                    Refresh();
                    
                                    // Start the timer
                                    Timer = new Timer(3000);
                                    Timer.Elapsed += TimerElapsed;
                                    Timer.Start();
                                }
                                else
                                {
                                    // Set the message color
                                    MessageColor = "red";

                                    // Set the message
                                    StatusMessage = "Oops. We could not send you an email at this time. We have logged this error.";
                                }
                            }
                        }
                        else
                        {
                            // Set the message color
                            MessageColor = "red";

                             // Set to true
                            EmailComponent.IsValid = false;
                            EmailComponent.SetTextValue(Email);

                            // Set the message
                            StatusMessage = "We could not find a user with the email address entered.";
                        }
                    }
                    else
                    {
                        // Set the message color
                        MessageColor = "red";

                        // Set to false
                        EmailComponent.IsValid = false;
                        EmailComponent.SetTextValue(Email);
                        
                        // Set the message
                        StatusMessage = "The email address entered is not valid.";
                    }
                }                
            }
            #endregion

            #region SendEmail(int code, string email)
            /// <summary>
            /// Send Email
            /// </summary>
            public async Task<bool> SendEmail(int code, string email)
            {
                // initial value
                bool sent = false;

                try
                {
                    // if the value for HasLoggedInUser is true
                    if ((TextHelper.Exists(email)) && (NumericHelper.IsInRange(code, 100000, 999999)))
                    {
                        // get the connection string for Azure Email Service
                        string emailConnectionString = EnvironmentVariableHelper.GetEnvironmentVariableValue("BlazorGalleryEmail", EnvironmentVariableTarget.Machine);    

                        // If the emailConnectionString string exists
                        if (TextHelper.Exists(emailConnectionString))
                        {
                            // Show Progress
                            ShowProgress = true;

                            // Needed for the timer
                            EmailSendingInProgress = true;

                            // Create a new instance of an 'EmailClient' object.
                            EmailClient emailClient = new EmailClient(emailConnectionString);

                            // Set the subject
                            string subject = "Blazor Gallery Change Password Request.";
                            string htmlContent = "<html><body><h1>Blazor Gallery</h1><br/><h2>Your Code Is: " + code.ToString() + "</h2><br><br>" +
                            "<div>If you did not request this change, you can ignore this message.</div><br><br>" + 
                            "<div>Blazor Gallery is created by Data Juggler and released free and opensource.<br><a href=https://datajuggler.com>https://datajuggler.com</a></div></body></html>";
                            string sender = "DoNotReply@datajuggler.com";
                            string recipient = email;

                            // perform the send
                            EmailSendOperation emailSendOperation = await emailClient.SendAsync(Azure.WaitUntil.Completed, sender, recipient, subject, htmlContent);
                        
                            // Get the StatusMonitor
                            EmailSendResult statusMonitor = emailSendOperation.Value;

                            // Set the value for sent
                            sent = (statusMonitor.Status == EmailSendStatus.Succeeded);
                        }
                    }
                }
                catch (Exception error)
                {
                    // Capture the error
                    ErrorLog log = new ErrorLog();
                    log.Error = error.ToString();
                    log.CreatedDate = DateTime.Now;
                    log.Message = error.Message;
                    log.UserId = LoggedInUserId;
                    bool saved = await ErrorLogService.SaveErrorLog(ref log);
                }
                finally
                {
                    // hide the progress bar
                    ShowProgress = false;
                }

                // return value
                return sent;
            }
            #endregion
            
            #region Verify()
            /// <summary>
            /// Verify
            /// </summary>
            public async void Verify()
            {
                // locals
                string code = "";
                
                // If the value for the property .HasEmailComponent is true
                if ((HasEmailComponent) && (HasCodeComponent))
                {
                    // set code and email
                    code = CodeComponent.Text;
                    email = EmailComponent.Text;
                }

                // Erase
                StatusMessage = "";

                // locals                 
                User user = null;

                // if the value for HasLoggedInUser is true
                if (TextHelper.Exists(code, email))
                { 
                    // is this a valid email
                    bool validEmail = EmailHelper.CheckValidEmail(email);

                    // get the codeValue
                    int codeValue = NumericHelper.ParseInteger(code, 0, -1);

                    // if the code is set
                    if ((NumericHelper.IsInRange(codeValue, 100000, 999999)) && (validEmail))
                    {
                        // find the user by this email
                        user = await UserService.FindUserByEmailAddress(email);

                        // If the user object exists
                        if ((NullHelper.Exists(user)) && (user.CodeEmailed == codeValue))
                        {  
                            // get the current time
                            DateTime now = DateTime.Now;

                            // elapsed
                            TimeSpan elapsed = now.Subtract(user.EmailedCodeDate);

                            // if the total elapsed time is less than 10 minutes
                            if (elapsed.TotalMinutes < 10)
                            {
                                // Codes Match
                                Verified = true;    
                            }  
                            else
                            {
                                // Set the message color
                                MessageColor = "red";

                                // Expired message
                                StatusMessage = "The email or code entered does not match or has expired.";
                            }                            
                        }
                        else
                        {
                            // Set the message color
                            MessageColor = "red";

                            // Expired message
                            StatusMessage = "The email or code entered does not match or has expired.";
                        }
                    }
                    else
                    {
                        // Set the message color
                        MessageColor = "red";

                        // Expired message
                        StatusMessage = "The email or code entered does not match or has expired.";
                    }

                    // if verified
                    if (Verified)
                    {
                        // update
                        EmailComponent.IsValid = true;
                        EmailComponent.SetTextValue(Email);

                        // Update the UI
                        EnablePasswordControls = true;
                    }
                    else
                    {
                        // Set the message color
                        MessageColor = "red";

                        // Show a message
                        StatusMessage = "The email or code entered does not match or has expired.";
                    }
                }
            }
            #endregion

        #endregion

        #region Properties

            #region CancelButtonStyle
            /// <summary>
            /// This read only property returns the value of CancelButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string CancelButtonStyle
            {
                
                get
                {
                    // initial value
                    string cancelButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        cancelButtonStyle = ParentMainLayout.CancelButtonStyle;
                    }
                    
                    // return value
                    return cancelButtonStyle;
                }
            }
            #endregion
            
            #region CheckMarkContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckMarkContainerStyle'.
            /// </summary>
            public string CheckMarkContainerStyle
            {
                get { return checkMarkContainerStyle; }
                set { checkMarkContainerStyle = value; }
            }
            #endregion
            
            #region CheckMarkImage
            /// <summary>
            /// This property gets or sets the value for 'CheckMarkImage'.
            /// </summary>
            public string CheckMarkImage
            {
                get { return checkMarkImage; }
                set { checkMarkImage = value; }
            }
            #endregion

            #region CheckMarkStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckMarkStyle'.
            /// </summary>
            public string CheckMarkStyle
            {
                get { return checkMarkStyle; }
                set { checkMarkStyle = value; }
            }
            #endregion
            
            #region CheckMarkTop
            /// <summary>
            /// This property gets or sets the value for 'CheckMarkTop'.
            /// </summary>
            public double CheckMarkTop
            {
                get { return checkMarkTop; }
                set { checkMarkTop = value; }
            }
            #endregion

            #region CheckMarkTopStyle
            /// <summary>
            /// This read only property returns the value of CheckMarkTopStyle from the object CheckMarkTop.
            /// </summary>
            public string CheckMarkTopStyle
            {
                
                get
                {
                    // initial value
                    string checkMarkTopStyle = CheckMarkTop + "vh";
                    
                    // return value
                    return checkMarkTopStyle;
                }
            }
            #endregion

            #region Children
            /// <summary>
            /// This property gets or sets the value for 'Children'.
            /// </summary>
            public List<IBlazorComponent> Children
            {
                get { return children; }
                set { children = value; }
            }
            #endregion
            
            #region CodeComponent
            /// <summary>
            /// This property gets or sets the value for 'CodeComponent'.
            /// </summary>
            public ValidationComponent CodeComponent
            {
                get { return codeComponent; }
                set { codeComponent = value; }
            }
            #endregion
            
            #region Column1Width
            /// <summary>
            /// This property gets or sets the value for 'Column1Width'.
            /// </summary>
            public int Column1Width
            {
                get { return column1Width; }
                set { column1Width = value; }
            }
            #endregion
            
            #region Column2Width
            /// <summary>
            /// This property gets or sets the value for 'Column2Width'.
            /// </summary>
            public int Column2Width
            {
                get { return column2Width; }
                set { column2Width = value; }
            }
            #endregion
            
            #region ConfirmPasswordComponent
            /// <summary>
            /// This property gets or sets the value for 'ConfirmPasswordComponent'.
            /// </summary>
            public ValidationComponent ConfirmPasswordComponent
            {
                get { return confirmPasswordComponent; }
                set { confirmPasswordComponent = value; }
            }
            #endregion
            
            #region ControlWidth
            /// <summary>
            /// This property gets or sets the value for 'ControlWidth'.
            /// </summary>
            public int ControlWidth
            {
                get { return controlWidth; }
                set { controlWidth = value; }
            }
            #endregion
            
            #region Email
            /// <summary>
            /// This property gets or sets the value for 'Email'.
            /// </summary>
            [Parameter]
            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            #endregion
            
            #region EmailComponent
            /// <summary>
            /// This property gets or sets the value for 'EmailComponent'.
            /// </summary>
            public ValidationComponent EmailComponent
            {
                get { return emailComponent; }
                set { emailComponent = value; }
            }
            #endregion
            
            #region EmailSendingInProgress
            /// <summary>
            /// This property gets or sets the value for 'EmailSendingInProgress'.
            /// </summary>
            public bool EmailSendingInProgress
            {
                get { return emailSendingInProgress; }
                set { emailSendingInProgress = value; }
            }
            #endregion
            
            #region EnablePasswordControls
            /// <summary>
            /// This property gets or sets the value for 'EnablePasswordControls'.
            /// </summary>
            public bool EnablePasswordControls
            {
                get { return enablePasswordControls; }
                set { enablePasswordControls = value; }
            }
            #endregion
            
            #region HasCodeComponent
            /// <summary>
            /// This property returns true if this object has a 'CodeComponent'.
            /// </summary>
            public bool HasCodeComponent
            {
                get
                {
                    // initial value
                    bool hasCodeComponent = (this.CodeComponent != null);
                    
                    // return value
                    return hasCodeComponent;
                }
            }
            #endregion
            
            #region HasConfirmPasswordComponent
            /// <summary>
            /// This property returns true if this object has a 'ConfirmPasswordComponent'.
            /// </summary>
            public bool HasConfirmPasswordComponent
            {
                get
                {
                    // initial value
                    bool hasConfirmPasswordComponent = (this.ConfirmPasswordComponent != null);
                    
                    // return value
                    return hasConfirmPasswordComponent;
                }
            }
            #endregion
            
            #region HasEmail
            /// <summary>
            /// This property returns true if the 'Email' exists.
            /// </summary>
            public bool HasEmail
            {
                get
                {
                    // initial value
                    bool hasEmail = (!String.IsNullOrEmpty(this.Email));
                    
                    // return value
                    return hasEmail;
                }
            }
            #endregion
            
            #region HasEmailComponent
            /// <summary>
            /// This property returns true if this object has an 'EmailComponent'.
            /// </summary>
            public bool HasEmailComponent
            {
                get
                {
                    // initial value
                    bool hasEmailComponent = (this.EmailComponent != null);
                    
                    // return value
                    return hasEmailComponent;
                }
            }
            #endregion
            
            #region HasInvisibleSprite
            /// <summary>
            /// This property returns true if this object has an 'InvisibleSprite'.
            /// </summary>
            public bool HasInvisibleSprite
            {
                get
                {
                    // initial value
                    bool hasInvisibleSprite = (this.InvisibleSprite != null);
                    
                    // return value
                    return hasInvisibleSprite;
                }
            }
            #endregion
            
            #region HasLoggedInUser
            /// <summary>
            /// This property returns true if this object has a 'LoggedInUser'.
            /// </summary>
            public bool HasLoggedInUser
            {
                get
                {
                    // initial value
                    bool hasLoggedInUser = (this.LoggedInUser != null);
                    
                    // return value
                    return hasLoggedInUser;
                }
            }
            #endregion
            
            #region HasParentMainLayout
            /// <summary>
            /// This property returns true if this object has a 'ParentMainLayout'.
            /// </summary>
            public bool HasParentMainLayout
            {
                get
                {
                    // initial value
                    bool hasParentMainLayout = (this.ParentMainLayout != null);
                    
                    // return value
                    return hasParentMainLayout;
                }
            }
            #endregion
            
            #region HasPasswordComponent
            /// <summary>
            /// This property returns true if this object has a 'PasswordComponent'.
            /// </summary>
            public bool HasPasswordComponent
            {
                get
                {
                    // initial value
                    bool hasPasswordComponent = (this.PasswordComponent != null);
                    
                    // return value
                    return hasPasswordComponent;
                }
            }
            #endregion
            
            #region InvisibleSprite
            /// <summary>
            /// This property gets or sets the value for 'InvisibleSprite'.
            /// </summary>
            public Sprite InvisibleSprite
            {
                get { return invisibleSprite; }
                set { invisibleSprite = value; }
            }
            #endregion

            #region LoggedInUser
            /// <summary>
            /// This read only property returns the value of LoggedInUser from the object ParentMainLayout.
            /// </summary>
            public User LoggedInUser
            {
                
                get
                {
                    // initial value
                    User loggedInUser = null;
                    
                    // if ParentMainLayout exists
                    if (HasParentMainLayout)
                    {
                        // set the return value
                        loggedInUser = ParentMainLayout.LoggedInUser;
                    }
                    
                    // return value
                    return loggedInUser;
                }
            }
            #endregion
            
            #region LoggedInUserId
            /// <summary>
            /// This read only property returns the value of Id from the object LoggedInUser.
            /// </summary>
            public int LoggedInUserId
            {
                
                get
                {
                    // initial value
                    int loggedInUserId = 0;
                    
                    // if LoggedInUser exists
                    if (HasLoggedInUser)
                    {
                        // set the return value
                        loggedInUserId = LoggedInUser.Id;
                    }
                    
                    // return value
                    return loggedInUserId;
                }
            }
            #endregion
            
            #region MessageColor
            /// <summary>
            /// This property gets or sets the value for 'MessageColor'.
            /// </summary>
            public string MessageColor
            {
                get { return messageColor; }
                set { messageColor = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            [Parameter]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region Parent
            /// <summary>
            /// This property gets or sets the value for 'Parent'.
            /// </summary>
            [Parameter]
            public IBlazorComponentParent Parent
            {
                get { return parent; }
                set { parent = value; }
            }
            #endregion

            #region ParentMainLayout
            /// <summary>
            /// This read only property returns the Parent of this object cast as a MainLayout object
            /// </summary>
            public MainLayout ParentMainLayout
            {
                
                get
                {
                    // initial value
                    MainLayout parentMainLayout = null;
                    
                    // if Parent exists
                    if (Parent != null)
                    {
                        // set the return value
                        parentMainLayout = Parent as MainLayout;
                    }
                    
                    // return value
                    return parentMainLayout;
                }
            }
            #endregion
            
            #region PasswordComponent
            /// <summary>
            /// This property gets or sets the value for 'PasswordComponent'.
            /// </summary>
            public ValidationComponent PasswordComponent
            {
                get { return passwordComponent; }
                set { passwordComponent = value; }
            }
            #endregion
            
            #region Percent
            /// <summary>
            /// This property gets or sets the value for 'Percent'.
            /// </summary>
            public int Percent
            {
                get { return percent; }
                set { percent = value; }
            }
            #endregion
            
            #region PercentString
            /// <summary>
            /// This property gets or sets the value for 'PercentString'.
            /// </summary>
            public string PercentString
            {
                get { return percentString; }
                set { percentString = value; }
            }
            #endregion
            
            #region ProgressStyle
            /// <summary>
            /// This property gets or sets the value for 'ProgressStyle'.
            /// </summary>
            public string ProgressStyle
            {
                get { return progressStyle; }
                set { progressStyle = value; }
            }
            #endregion

            #region SaveButtonDisabledStyle
            /// <summary>
            /// This read only property returns the value of SaveButtonDisabledStyle from the object ParentMainLayout.
            /// </summary>
            public string SaveButtonDisabledStyle
            {
                
                get
                {
                    // initial value
                    string saveButtonDisabledStyle = "";
                    
                    // if ParentMainLayout exists
                    if (HasParentMainLayout)
                    {
                        // set the return value
                        saveButtonDisabledStyle = ParentMainLayout.SaveButtonDisabledStyle;
                    }
                    
                    // return value
                    return saveButtonDisabledStyle;
                }
            }
            #endregion
            
            #region SaveButtonStyle
            /// <summary>
            /// This read only property returns the value of SaveButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string SaveButtonStyle
            {
                
                get
                {
                    // initial value
                    string saveButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        saveButtonStyle = ParentMainLayout.SaveButtonStyle;
                    }
                    
                    // return value
                    return saveButtonStyle;
                }
            }
            #endregion
            
            #region SendButtonStyle
            /// <summary>
            /// This read only property returns the value of SendButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string SendButtonStyle
            {
                
                get
                {
                    // initial value
                    string sendButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (HasParentMainLayout)
                    {
                        // set the return value
                        sendButtonStyle = ParentMainLayout.SendButtonStyle;
                    }
                    
                    // return value
                    return sendButtonStyle;
                }
            }
            #endregion
            
            #region ShowProgress
            /// <summary>
            /// This property gets or sets the value for 'ShowProgress'.
            /// </summary>
            public bool ShowProgress
            {
                get { return showProgress; }
                set { showProgress = value; }
            }
            #endregion
            
            #region StatusMessage
            /// <summary>
            /// This property gets or sets the value for 'StatusMessage'.
            /// </summary>
            public string StatusMessage
            {
                get { return statusMessage; }
                set { statusMessage = value; }
            }
            #endregion
            
            #region Timer
            /// <summary>
            /// This property gets or sets the value for 'Timer'.
            /// </summary>
            public Timer Timer
            {
                get { return timer; }
                set { timer = value; }
            }
            #endregion
            
            #region Verified
            /// <summary>
            /// This property gets or sets the value for 'Verified'.
            /// </summary>
            public bool Verified
            {
                get { return verified; }
                set { verified = value; }
            }
            #endregion
            
            #region VerifyButtonStyle
            /// <summary>
            /// This read only property returns the value of VerifyButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string VerifyButtonStyle
            {
                
                get
                {
                    // initial value
                    string verifyButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        verifyButtonStyle = ParentMainLayout.VerifyButtonStyle;
                    }
                    
                    // return value
                    return verifyButtonStyle;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
