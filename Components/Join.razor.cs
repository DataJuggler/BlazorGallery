﻿

#region using statements

using DataGateway.Services;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.BlazorGallery.Shared;
using DataJuggler.BlazorGallery.Util;
using DataJuggler.Cryptography;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System.Runtime.Versioning;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class Join
    /// <summary>
    /// This class is the code behind for the Index page.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class Join : IBlazorComponent, IBlazorComponentParent, ISpriteSubscriber
    {

        #region Private Variables
        private string userName;
        private string name;
        private string emailAddress;
        private string password;
        private string password2;
        private string validationMessage;
        private ValidationComponent userNameComponent;
        private ValidationComponent nameComponent;
        private ValidationComponent emailAddressComponent;
        private ValidationComponent passwordComponent;
        private ValidationComponent confirmPasswordComponent;
        private IBlazorComponentParent parent;
        private List<IBlazorComponent> children; 
        private bool showProgress;
        private int percent;
        private string percentString;
        private string progressStyle;
        private Sprite invisibleSprite;
        private bool loginInProcess;
        private int extraPercent;
        private int column1Width;
        private int column2Width;
        private int controlWidth;
        #endregion

        #region Consructor
        /// <summary>
        /// Create a new index of an Join page
        /// </summary>
        public Join()
        {
           // Perform initializations for this object
           Init();
        }
        #endregion

        #region Methods

            #region Cancel()
            /// <summary>
            /// This method Cancel
            /// </summary>
            public void Cancel()
            { 
                if (HasParentMainLayout)
                {
                    // Cancel signing up
                    ParentMainLayout.SetupScreen(ScreenTypeEnum.MainScreen);
                }
            }
            #endregion
            
            #region CaptureUser()
            /// <summary>
            /// This method Captures User
            /// </summary>
            public User CaptureUser()
            {
                // Create a new instance of an 'User' object.
                User user = new User();

                // Set the properties
                user.UserName = UserName;
                user.EmailAddress = EmailAddress;
                user.Name = Name;                
                user.CreatedDate = DateTime.Now;
                user.LastLoginDate = DateTime.Now;                
                user.EmailVerified = false;                
                user.IsAdmin = false;
                user.Active = true;
                user.StorageUsed = 0;
                user.TotalLogins = 0;

                // return value
                return user;
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // initial value
                IBlazorComponent child = null;

                // if the value for HasChildren is true
                if (HasChildren)
                {
                    // Iterate the collection of IBlazorComponent objects
                    foreach (IBlazorComponent tempChild in Children)
                    {
                        // if this is the item being sought
                        if (TextHelper.IsEqual(tempChild.Name, name))
                        {
                            // set the return value
                            child = tempChild;

                            // break out of the loop
                            break;
                        }
                    }
                }

                // return value
                return child;
            }
            #endregion
            
            #region Init()
            /// <summary>
            /// This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                // Create a new collection of 'IBlazorComponent' objects.
                Children = new List<IBlazorComponent>();
                Column1Width = 8;
                Column2Width = 16;
                ControlWidth=26;
            }
            #endregion

            #region ProcessNewUserSignUp(object userObject)
            /// <summary>
            /// This method Process New User Sign Up
            /// </summary>
            public async void ProcessNewUserSignUp(object userObject)
            {
                // get the user
                User user = userObject as User;

                try
                {
                    // if the user exists
                    if (NullHelper.Exists(user))
                    {
                        // Get the KeyCode
                        string keyCode = EnvironmentVariableHelper.GetEnvironmentVariableValue("BlazorGalleryKeyCode", EnvironmentVariableTarget.Machine);

                        // If the keyCode string exists
                        if (TextHelper.Exists(keyCode))
                        {
                            // Set the PasswordHash, this takes the longest time
                            user.PasswordHash = CryptographyHelper.GeneratePasswordHash(Password, keyCode, 3);

                            // if the password hash was created
                            if (TextHelper.Exists(user.PasswordHash))
                            {
                                // save the user
                                bool saved = await UserService.SaveUser(ref user);

                                // if saved
                                if ((saved) && (HasParentMainLayout))
                                {
                                    // Create a new instance of a 'Folder' object.
                                    Folder folder = new Folder();

                                    // Set the UserId
                                    folder.UserId = user.Id;

                                    // Set the name
                                    folder.Name = "Home";

                                    // Just created
                                    folder.CreatedDate = DateTime.Now;

                                    // Set to true
                                    folder.Selected = true;

                                    // save the folder async
                                    saved = await FolderService.SaveFolder(ref folder);

                                    // Force the user to login, see if they entered real data
                                    ParentMainLayout.SetupScreen(ScreenTypeEnum.Login, user.EmailAddress);
                                }
                                else
                                {
                                    // if not saved
                                    if (!saved)
                                    {
                                        // Show a messagge
                                        ValidationMessage = "Oops, something went wrong. Save Failed.";
                                    }

                                    // Update the UI
                                    Refresh();
                                }
                            }
                            else
                            {
                                // Show a messagge
                                ValidationMessage = "Oops, something went wrong. Password Hash could not be generated.";

                                // Update the UI
                                Refresh();
                            }
                        }
                        else
                        {
                            // Show a messagge
                            ValidationMessage = "Oops, something went wrong. Keycode does not exist.";

                            // Update the UI
                            Refresh();
                        }
                    }
                }
                catch (Exception error)
                {
                    DebugHelper.WriteDebugError("ProcessNewUserSignup", "Join.razor.cs", error);
                }
                finally
                {
                    // hide the progress bar
                    ShowProgress = false;
                }
            }
            #endregion

            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public async void ReceiveData(Message message)
            {
                // locals
                User user = null;
                bool refreshRequired = false;

                // If the message object exists
                if (NullHelper.Exists(message))
                {
                    // if this is a Check Unique request
                    if (TextHelper.IsEqual(message.Text, "Check Unique"))    
                    {
                        // if there are at least one parameter                        
                        if (ListHelper.HasOneOrMoreItems(message.Parameters))                        
                        {   
                            // if User Name
                            if ((TextHelper.IsEqual(message.Parameters[0].Name, "User Name:")) && (NullHelper.Exists(message.Parameters[0].Value)))
                            {
                                // get the userName
                                string userName = message.Parameters[0].Value.ToString();

                                // attempt to find the UserName
                                user = await UserService.FindUserByUserName(userName);

                                // if the user exists
                                if (HasUserNameComponent)
                                {
                                    // create a response
                                    Message response = new Message();

                                    // if the user exists
                                    if (NullHelper.Exists(user))
                                    {
                                        // set to true
                                        refreshRequired = true;

                                        // Send a response of Taken
                                        response.Text = "Taken";

                                        // Create the parameters
                                        NamedParameter namedParameter = new NamedParameter();

                                        // Set the name
                                        namedParameter.Name = "Validation Message";

                                        // Set the value
                                        namedParameter.Value = "The User Name is already taken. Click the login button if this is you.";

                                        // Set the ValidationMessage
                                        this.ValidationMessage = namedParameter.Value.ToString();

                                        // Add the parameter
                                        response.Parameters.Add(namedParameter);
                                    }
                                    else
                                    {
                                        // Send a response of Taken
                                        response.Text = "Available";
                                    }

                                    // send a message to the user
                                    UserNameComponent.ReceiveData(response);

                                    // Not valid
                                    UserNameComponent.IsValid = false;
                                }
                            }   
                            //if EmailAddress
                            else if ((TextHelper.IsEqual(message.Parameters[0].Name, "Email Address:")) && (NullHelper.Exists(message.Parameters[0].Value)))
                            {
                                // get the email
                                string email = message.Parameters[0].Value.ToString();

                                // attempt to find the UserName
                                user = await UserService.FindUserByEmailAddress(email);

                                // if the value for HasEmailAddressComponent is true
                                if (HasEmailAddressComponent)
                                {
                                    // create a response
                                    Message response = new Message();

                                    // if the user exists
                                    if (NullHelper.Exists(user))
                                    {
                                        // set to true
                                        refreshRequired = true; 

                                        // Send a response of Taken
                                        response.Text = "Taken";

                                        // Create the parameters
                                        NamedParameter namedParameter = new NamedParameter();

                                        // Set the name
                                        namedParameter.Name = "Validation Message";

                                        // Set the value
                                        namedParameter.Value = "This email address is already taken. Click the Login Button if this is you.";

                                        // set the ValidationMessage
                                        this.ValidationMessage = namedParameter.Value.ToString();

                                        // Add the parameter
                                        response.Parameters.Add(namedParameter);

                                        // Not valid
                                        EmailAddressComponent.IsValid = false;
                                    }
                                    else
                                    {
                                        // Send a response of Available
                                        response.Text = "Available";

                                        // Not valid
                                        EmailAddressComponent.IsValid = true;
                                    }

                                    // send a message to the user
                                    EmailAddressComponent.ReceiveData(response);
                                }
                            }   
                        }
                    }
                }

                if (refreshRequired)
                {
                    // update the UI
                    Refresh();
                }
            }
            #endregion
            
            #region Refresh()
            /// <summary>
            /// method Refresh
            /// </summary>
            public void Refresh()
            {
                // if the value for LoginInProcess is true
                if (LoginInProcess)
                {
                    // increment by 1
                    Percent += 1;

                    // go a little past 100 for effect
                    if (Percent >= 100)
                    {
                        // Increment
                        ExtraPercent++;
                    }

                    // if higher than 10
                    if (ExtraPercent >= 10)
                    {
                        // Stop the timer
                        InvisibleSprite.Stop();
                        ShowProgress = false;
                    }
                }

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
                // If the component object exists
                if (NullHelper.Exists(component))
                {
                    // if this is the UserName component
                    if (component.Name == "UserNameComponent")
                    {
                        // Set the component
                        UserNameComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "NameComponent")
                    {
                        // Set the component
                        NameComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "EmailAddressComponent")
                    {
                        // Set the component
                        EmailAddressComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "PasswordComponent")
                    {
                        // Set the component
                        PasswordComponent = component as ValidationComponent;
                    }
                    else if (component.Name == "ConfirmPasswordComponent")
                    {
                        // Set the component
                        ConfirmPasswordComponent = component as ValidationComponent;
                    }

                    // if the Children collection exists
                    if (HasChildren)
                    {
                        // Add this item
                        Children.Add(component);
                    }
                }
            }
            #endregion

            #region Register(Sprite sprite)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(Sprite sprite)
            {
                // Set the InvisibleSprite
                InvisibleSprite = sprite;
            }
            #endregion
            
            #region SignUp()
            /// <summary>
            /// This method Signs Up a User
            /// </summary>
            public void SignUp()
            {
                // validate the user
                bool isValid = ValidateUser();
                
                // if everything is valid
                if (isValid)
                {  
                    // Set to 0 percent
                    Percent = 0;

                    // Process the Login
                    bool started = StartProcessSignUp();
                    
                    // if the InvisiibleSprite exists
                    if (HasInvisibleSprite)
                    {
                        // A login in process is true
                        LoginInProcess = true;

                        // Start the Timer
                        InvisibleSprite.Start();
                    }

                    // Show the ProgressBar
                    ShowProgress = true;                    
                }
            }
            #endregion
            
            #region StartProcessSignUp()
            /// <summary>
            /// This method returns the Process Sign Up
            /// </summary>
            public bool StartProcessSignUp()
            {
                // initial value
                bool started = false;

                // Create a Thread to Process the Signup
                Thread thread = new Thread(ProcessNewUserSignUp);

                // Set the value for the property 'IsBackground' to true                        
                thread.IsBackground = true;

                // Capture the current user
                User user = CaptureUser();

                // Startup the thread and pass in the SignUp model
                thread.Start(user);

                // set to true
                started = true;
                
                // return value
                return started;
            }
            #endregion
            
            #region ValidateUser()
            /// <summary>
            /// This method returns the User
            /// </summary>
            public bool ValidateUser()
            {
                // initial value (default to true)
                bool isValid = true;

                // Erase by default
                ValidationMessage = "";

                // if there is a UserNameComponent
                if (HasUserNameComponent)
                {
                    // validate this control
                    isValid = UserNameComponent.Validate();

                    // if the value for isValid is false
                    if (!isValid)
                    {
                        // Set the Validation Message
                        ValidationMessage = UserNameComponent.InvalidReason;
                    }
                    else
                    {
                        // Set the UserName
                        UserName = UserNameComponent.Text;
                    }
                }

                // if the value for HasNameComponent is true
                if (HasNameComponent)
                {
                    // no validation is required, just capturing the value
                    this.Name = NameComponent.Text;

                    if ((!TextHelper.Exists(Name)) || (Name.Length < 5) || (Name.Length > 20))
                    {
                        // not valid
                        isValid = false;
                        NameComponent.IsValid = false;
                        ValidationMessage = "Name must between 5 and 20 characters.";
                    }
                }
                else
                {
                    // Set to false
                    isValid = false;

                     // Set the Validation Message
                    ValidationMessage = NameComponent.InvalidReason;
                }

                // if still valid
                if ((isValid) && (HasEmailAddressComponent))
                {
                    // is this valid
                    isValid = EmailAddressComponent.Validate();

                    // if not valid
                    if (!isValid)
                    {
                        // Set the InvalidReason
                        ValidationMessage = EmailAddressComponent.InvalidReason;
                    }
                    else
                    {
                        // next we must check if this is a valid email
                        isValid = EmailHelper.CheckValidEmail(EmailAddressComponent.Text);

                        // if not valid
                        if (!isValid)
                        {
                            // Set the text
                            ValidationMessage = "Please enter a valid email address";

                            // set to false
                            EmailAddressComponent.IsValid = false;
                        }
                        else
                        {
                            // Set the EmailAddress
                            EmailAddress = EmailAddressComponent.Text;
                        }
                    }

                    // if the Password exists
                    if ((isValid) && (HasPasswordComponent))
                    {
                        // for debugging only
                        string name = PasswordComponent.Name;

                         // validate this control
                        isValid = PasswordComponent.Validate();

                        // if the value for isValid is false
                        if (!isValid)
                        {
                            // Set the Validation Message
                            ValidationMessage = PasswordComponent.InvalidReason;
                        }
                        else
                        {
                            // Set Password
                            Password = PasswordComponent.Text;
                        }
                    }

                    // if the Confirm Password exists
                    if ((isValid) && (HasConfirmPasswordComponent))
                    {
                         // validate this control
                        isValid = ConfirmPasswordComponent.Validate();

                        // if the value for isValid is false
                        if (!isValid)
                        {
                            // Set the Validation Message
                            ValidationMessage = ConfirmPasswordComponent.InvalidReason;
                        }
                        else
                        {
                            // Set Password2
                            Password2 = ConfirmPasswordComponent.Text;
                        }
                    }

                    // if still valid
                    if (isValid)
                    {
                        // next we must check that the two passwords match
                        if (!TextHelper.IsEqual(Password, Password2, true, true))
                        {
                            // set to false
                            isValid = false;

                            // Set the failed reason
                            ValidationMessage = "The passwords do not match";

                            // verify both components exist
                            if ((HasPasswordComponent) && (HasConfirmPasswordComponent))
                            {
                                // set both to not valid
                                PasswordComponent.IsValid = false;
                                ConfirmPasswordComponent.IsValid = false;
                            }
                        }
                    }
                }
                
                // return value
                return isValid;
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
            
            #region EmailAddress
            /// <summary>
            /// This property gets or sets the value for 'EmailAddress'.
            /// </summary>
            public string EmailAddress
            {
                get { return emailAddress; }
                set { emailAddress = value; }
            }
            #endregion
            
            #region EmailAddressComponent
            /// <summary>
            /// This property gets or sets the value for 'EmailAddressComponent'.
            /// </summary>
            public ValidationComponent EmailAddressComponent
            {
                get { return emailAddressComponent; }
                set { emailAddressComponent = value; }
            }
            #endregion
            
            #region ExtraPercent
            /// <summary>
            /// This property gets or sets the value for 'ExtraPercent'.
            /// </summary>
            public int ExtraPercent
            {
                get { return extraPercent; }
                set { extraPercent = value; }
            }
            #endregion
            
            #region HasChildren
            /// <summary>
            /// This property returns true if this object has a 'Children'.
            /// </summary>
            public bool HasChildren
            {
                get
                {
                    // initial value
                    bool hasChildren = (this.Children != null);
                    
                    // return value
                    return hasChildren;
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
            
            #region HasEmailAddressComponent
            /// <summary>
            /// This property returns true if this object has an 'EmailAddressComponent'.
            /// </summary>
            public bool HasEmailAddressComponent
            {
                get
                {
                    // initial value
                    bool hasEmailAddressComponent = (this.EmailAddressComponent != null);
                    
                    // return value
                    return hasEmailAddressComponent;
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
            
            #region HasName
            /// <summary>
            /// This property returns true if the 'Name' exists.
            /// </summary>
            public bool HasName
            {
                get
                {
                    // initial value
                    bool hasName = (!String.IsNullOrEmpty(this.Name));
                    
                    // return value
                    return hasName;
                }
            }
            #endregion
            
            #region HasNameComponent
            /// <summary>
            /// This property returns true if this object has a 'NameComponent'.
            /// </summary>
            public bool HasNameComponent
            {
                get
                {
                    // initial value
                    bool hasNameComponent = (this.NameComponent != null);
                    
                    // return value
                    return hasNameComponent;
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
            
            #region HasUserNameComponent
            /// <summary>
            /// This property returns true if this object has an 'UserNameComponent'.
            /// </summary>
            public bool HasUserNameComponent
            {
                get
                {
                    // initial value
                    bool hasUserNameComponent = (this.UserNameComponent != null);
                    
                    // return value
                    return hasUserNameComponent;
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
            
            #region JoinButtonStyle
            /// <summary>
            /// This read only property returns the value of JoinButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string JoinButtonStyle
            {
                
                get
                {
                    // initial value
                    string joinButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        joinButtonStyle = ParentMainLayout.JoinButtonStyle;
                    }
                    
                    // return value
                    return joinButtonStyle;
                }
            }
            #endregion
            
            #region LoginInProcess
            /// <summary>
            /// This property gets or sets the value for 'LoginInProcess'.
            /// </summary>
            public bool LoginInProcess
            {
                get { return loginInProcess; }
                set { loginInProcess = value; }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            #endregion
            
            #region NameComponent
            /// <summary>
            /// This property gets or sets the value for 'NameComponent'.
            /// </summary>
            public ValidationComponent NameComponent
            {
                get { return nameComponent; }
                set { nameComponent = value; }
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
                    // set the value
                    parent = value;

                    // if the Parent exists
                    if (HasParent)
                    {
                        // Register with the parent
                        Parent.Register(this);
                    }
                }
            }
            #endregion

            #region ParentMainLayout
            /// <summary>
            /// This read only property returns the value for Parent cast as a MainLayout object
            /// </summary>
            public MainLayout ParentMainLayout
            {
                get
                {
                    // cast the parent as an Index page
                    return this.Parent as MainLayout;
                }
            }
            #endregion
            
            #region Password
            /// <summary>
            /// This property gets or sets the value for 'Password'.
            /// </summary>
            public string Password
            {
                get { return password; }
                set { password = value; }
            }
            #endregion
            
            #region Password2
            /// <summary>
            /// This property gets or sets the value for 'Password2'.
            /// </summary>
            public string Password2
            {
                get { return password2; }
                set { password2 = value; }
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
            
            #region UserName
            /// <summary>
            /// This property gets or sets the value for 'UserName'.
            /// </summary>
            public string UserName
            {
                get { return userName; }
                set { userName = value; }
            }
            #endregion
            
            #region UserNameComponent
            /// <summary>
            /// This property gets or sets the value for 'UserNameComponent'.
            /// </summary>
            public ValidationComponent UserNameComponent
            {
                get { return userNameComponent; }
                set { userNameComponent = value; }
            }
            #endregion
            
            #region ValidationMessage
            /// <summary>
            /// This property gets or sets the value for 'ValidationMessage'.
            /// </summary>
            public string ValidationMessage
            {
                get { return validationMessage; }
                set { validationMessage = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
