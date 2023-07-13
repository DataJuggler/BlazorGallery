

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;
using ObjectLibrary.BusinessObjects;
using DataGateway.Services;
using DataJuggler.BlazorGallery.Shared;
using ObjectLibrary.Enumerations;
using System.Runtime.Versioning;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class ProfileVisibility
    /// <summary>
    /// This class is used to get a user to accept a terms of service before being allowed to continue to the site.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class ProfileVisibility : IBlazorComponent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private string componentStyle;
        private string prompt;
        #endregion
        
        #region Methods
            
            #region NoClicked()
            /// <summary>
            /// No Clicked
            /// </summary>
            public async void NoClicked()
            {
                // if the value for HasLoggedInUser is true
                if (HasLoggedInUser)
                {
                    // clone the user
                    User user = LoggedInUser.Clone();

                    // set properties
                    user.ProfileVisibility = ProfileVisibilityEnum.Private;

                    // Perform the save
                    bool saved = await UserService.SaveUser(ref user);

                    // if the value for saved is true
                    if (saved)
                    {
                        // This forces a reload
                        ParentMainLayout.SetupScreen(ScreenTypeEnum.Index);
                    }
                }
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
            
            #region YesClicked()
            /// <summary>
            /// Yes Clicked
            /// </summary>
            public async void YesClicked()
            {
                // if the value for HasLoggedInUser is true
                if (HasLoggedInUser)
                {
                    // clone the user
                    User user = LoggedInUser.Clone();

                    // set properties
                    user.ProfileVisibility = ProfileVisibilityEnum.Public;

                    // Perform the save
                    bool saved = await UserService.SaveUser(ref user);

                    // if the value for saved is true
                    if (saved)
                    {
                        // if the value for RequireEmailVerification is true
                        if (RequireEmailVerification)
                        {
                            // Display the email
                            ParentMainLayout.SetupScreen(ScreenTypeEnum.EmailVerification, LoggedInUser.EmailAddress);  
                        }
                        else
                        {
                            // This forces a reload
                            ParentMainLayout.NavigateToUsersGalleries();
                        }
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Admin
            /// <summary>
            /// This read only property returns the value of Admin from the object ParentMainLayout.
            /// </summary>
            public Admin Admin
            {
                
                get
                {
                    // initial value
                    Admin admin = null;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        admin = ParentMainLayout.Admin;
                    }
                    
                    // return value
                    return admin;
                }
            }
            #endregion
            
            #region ComponentStyle
            /// <summary>
            /// This property gets or sets the value for 'ComponentStyle'.
            /// </summary>
            public string ComponentStyle
            {
                get { return componentStyle; }
                set { componentStyle = value; }
            }
            #endregion
            
            #region HasAdmin
            /// <summary>
            /// This read only property returns the value of HasAdmin from the object ParentMainLayout.
            /// </summary>
            public bool HasAdmin
            {
                
                get
                {
                    // initial value
                    bool hasAdmin = false;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        hasAdmin = ParentMainLayout.HasAdmin;
                    }
                    
                    // return value
                    return hasAdmin;
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
            
            #region NoButtonStyle
            /// <summary>
            /// This read only property returns the value of NoButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string NoButtonStyle
            {
                
                get
                {
                    // initial value
                    string noButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        noButtonStyle = ParentMainLayout.NoButtonStyle;
                    }
                    
                    // return value
                    return noButtonStyle;
                }
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

                    // if the value for HasParent is true
                    if (HasParent)
                    {
                        // notify parent 'Hey I am the Terms of Service component'.
                        parent.Register(this);  
                    }
                }
            }
            #endregion

            #region ParentMainLayout
            /// <summary>
            /// This read only property returns the value of ParentMainLayout from the object Parent.
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
            
            #region Prompt
            /// <summary>
            /// This property gets or sets the value for 'Prompt'.
            /// </summary>
            [Parameter]
            public string Prompt
            {
                get { return prompt; }
                set { prompt = value; }
            }
            #endregion
            
            #region RequireEmailVerification
            /// <summary>
            /// This read only property returns the value of RequireEmailVerification from the object Admin.
            /// </summary>
            public bool RequireEmailVerification
            {
                
                get
                {
                    // initial value
                    bool requireEmailVerification = false;
                    
                    // if Admin exists
                    if (HasAdmin)
                    {
                        // set the return value
                        requireEmailVerification = Admin.RequireEmailVerification;
                    }
                    
                    // return value
                    return requireEmailVerification;
                }
            }
            #endregion
            
            #region YesButtonStyle
            /// <summary>
            /// This read only property returns the value of YesButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string YesButtonStyle
            {
                
                get
                {
                    // initial value
                    string yesButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        yesButtonStyle = ParentMainLayout.YesButtonStyle;
                    }
                    
                    // return value
                    return yesButtonStyle;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
