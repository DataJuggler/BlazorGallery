

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
using Timer = System.Timers.Timer;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class EmailVerification
    /// <summary>
    /// This class is used to send and verify an email address
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class EmailVerification : IBlazorComponent, IBlazorComponentParent, ISpriteSubscriber, IDisposable
    {
        
        #region Private Variables
        private IBlazorComponentParent parent;
        private string name;
        private string email;
        private string checkMarkContainerStyle;
        private string checkMarkStyle;      
        private double checkMarkTop;
        private string checkMarkImage;
        private Timer timer;
        private bool verified;
        private string statusMessage;
        private string messageColor;
        private List<IBlazorComponent> children;
        private ValidationComponent emailComponent;
        private ValidationComponent codeComponent;
        private Sprite invisibleSprite;
        private bool showProgress;
        private int percent;
        private string percentString;
        private string progressStyle;
        private bool emailSendingInProgress;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'EmailVerification' object.
        /// </summary>
        public EmailVerification()
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

                // if verified
                if ((HasLoggedInUser) && (LoggedInUser.EmailVerified))
                {
                    // Send the user to the main screen
                    ParentMainLayout.NavigateToUsersGalleries();
                }
                
                // update the UI
                Refresh();
            }
            #endregion
            
        #endregion
        
        #region Methods

            #region Dispose()
            /// <summary>
            /// method Dispose
            /// </summary>
            public void Dispose()
            {
                if ((HasInvisibleSprite) && (NullHelper.Exists(InvisibleSprite.Timer)))
                {
                    // Stop the Timer
                    InvisibleSprite.Timer.Stop();

                    // Dispose of the timer
                    InvisibleSprite.Timer.Dispose();
                }

                // If the Timer object exists
                if (NullHelper.Exists(Timer))
                {
                    // destroy
                    Timer.Stop();
                    Timer.Dispose();
                }

                // destroy
                InvisibleSprite = null;
                Timer = null;

                // VS says do this
                GC.SuppressFinalize(this);
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // return the child, not used here most likely
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
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                
            }
            #endregion
            
            #region Register(Sprite sprite)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(Sprite sprite)
            {
                // register
                InvisibleSprite = sprite;
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
                }
                else if (component.Name == "CodeComponent")
                {
                    // Store the CodeComponent
                    CodeComponent = component as ValidationComponent;
                }
            }
            #endregion
            
            #region SendConfirmation()
            /// <summary>
            /// Send Confirmation Email
            /// </summary>
            public async void SendConfirmation()
            {
                // Erase
                StatusMessage = "";

                // if the LoggedInUser exists
                if (HasLoggedInUser)
                {
                    // create a shuffler
                    LargeNumberShuffler shuffler = new LargeNumberShuffler(6, 100000, 999999, NumberOutOfRangeOptionEnum.Repull);

                    // get a local reference
                    User user = LoggedInUser;

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
                        bool sent = await SendEmail(user.CodeEmailed);

                        // if the message was sent
                        if (sent)
                        {
                            // Stop the Timer
                            InvisibleSprite.Stop();
                            
                            // Set the message
                            StatusMessage = "Please check your email for your 6 digit code.";

                            // Update the LoggedInUser
                            ParentMainLayout.LoggedInUser = user;

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
            }
            #endregion

            #region Refresh()
            /// <summary>
            /// Refresh
            /// </summary>
            public void Refresh()
            {
                try
                {
                    // if the value for EmailSendingInProgress is true
                    if (EmailSendingInProgress)
                    {
                        // increment by 4
                        Percent += 4;

                        // go a little past 100 for effect
                        if (Percent >= 100)
                        {
                            // Stop showing
                            ShowProgress = false;

                            // if the value for HasInvisibleSprite is true
                            if (HasInvisibleSprite)
                            {
                                // Stop the timer
                                InvisibleSprite.Stop();
                            }
                        }
                    }                  

                    // Update the UI
                    InvokeAsync(() =>
                    {
                        StateHasChanged();
                    });
                }
                catch (Exception error)
                {
                    // for debugging only
                    DebugHelper.WriteDebugError("Refresh", "EmailComponent", error);  
                }
            }
            #endregion
            
            #region SendEmail(int code)
            /// <summary>
            /// Send Email
            /// </summary>
            public async Task<bool> SendEmail(int code)
            {
                // initial value
                bool sent = false;

                try
                {
                    // if the value for HasLoggedInUser is true
                    if (HasLoggedInUser)
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
                            string subject = "Welcome to Blazor Gallery.";
                            string htmlContent = "<html><body><h1>Blazor Gallery</h1><br/><h2>Your Code Is: " + code.ToString() + "</h2><br><br>" +
                            "<div>Blazor Gallery is created by Data Juggler and released free and opensource.<br><a href=https://datajuggler.com>https://datajuggler.com</a></div></body></html>";
                            string sender = "DoNotReply@datajuggler.com";
                            string recipient = LoggedInUser.EmailAddress;

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
                    // Hide the progress bar
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
                // Erase
                StatusMessage = "";

                // if the value for HasLoggedInUser is true
                if (HasLoggedInUser)
                {
                    if (HasCodeComponent)
                    {
                        // get the code
                        string code = CodeComponent.Text;

                        // if the code exists
                        if (TextHelper.Exists(code))
                        {
                            // get the codeValue
                            int codeValue = NumericHelper.ParseInteger(code, 0, -1);

                            // if the code is set
                            if ((codeValue > 0) && (LoggedInUser.CodeEmailed > 0) && (LoggedInUser.CodeEmailed == codeValue))
                            {
                                // get the current time
                                DateTime now = DateTime.Now;

                                // elapsed
                                TimeSpan elapsed = now.Subtract(LoggedInUser.EmailedCodeDate);

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
                                    StatusMessage = "The code entered does not match or has expired.";
                                }
                            }
                            else
                            {
                                // Set the message color
                                MessageColor = "red";

                                // Expired message
                                StatusMessage = "The code entered does not match or has expired.";
                            }
                        }
                    }

                    // if verified
                    if (Verified)
                    {
                        // get a local copy
                        User user = LoggedInUser;

                        // The user has verified there email
                        user.EmailVerified = true;

                        // perform the save
                        bool saved = await UserService.SaveUser(ref user);

                        // if saved
                        if (saved)
                        {
                            // Update the LoggedInUser
                            ParentMainLayout.LoggedInUser = user;

                            // Set the top for where the check mark displays
                            CheckMarkTop = 188;

                            // set to visible
                            CheckMarkImage = "../Images/Check.png";

                            // Show a message
                            MessageColor = "black";
                            StatusMessage = "Your code has been verified. Upload permission granted.";
    
                            // Update the UI
                            Refresh();

                            // Start the timer
                            Timer = new Timer(3000);
                            Timer.Elapsed += TimerElapsed;
                            Timer.Start();
                        }
                    }
                    else
                    {
                        // Set the message color
                        MessageColor = "red";

                        // Show a message
                        StatusMessage = "The code does not match";

                        // Update the UI
                        Refresh();
                    }
                }
            }
        #endregion

        #endregion

        #region Properties

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
                    string checkMarkTopStyle = CheckMarkTop + "px";
                    
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
            
            #region HasParent
            /// <summary>
            /// This property returns true if this object has a 'Parent'.
            /// </summary>
            public bool HasParent
            {
                get
                {
                    // initial value
                    bool hasParent = (this.Parent != null);
                    
                    // return value
                    return hasParent;
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
                    if (ParentMainLayout != null)
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
                    if (LoggedInUser != null)
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
                set
                {
                    // store the value
                    parent = value;
                    
                    // If the parent object exists
                    if (HasParent)
                    {
                        // register with the parent
                        parent.Register(this);
                    }
                }
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

            #region Percent
            /// <summary>
            /// This property gets or sets the value for 'Percent'.
            /// </summary>
            public int Percent
            {
                get { return percent; }
                set 
                {
                    // if less than zero
                    if (value < 0)
                    {
                        // set to 0
                        value = 0;
                    }

                    // if greater than 100
                    if (value > 100)
                    {
                        // set to 100
                        value = 100;
                    }

                    // set the value
                    percent = value;

                    // Now set ProgressStyle
                    ProgressStyle = "c100 p[Percent] dark small orange".Replace("[Percent]", percent.ToString());

                    // Set the percentString value
                    PercentString = percent.ToString() + "%";
                }
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
                    if (ParentMainLayout != null)
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
