

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

    #region class TermsOfServiceComponent
    /// <summary>
    /// This class is used to get a user to accept a terms of service before being allowed to continue to the site.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class TermsOfServiceComponent : IBlazorComponent
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
            public void NoClicked()
            {
                // Send the user to Google
                NavManager.NavigateTo("https://google.com");
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
                    user.AcceptedTermsOfServiceDate = DateTime.Now;

                    // Perform the save
                    bool saved = await UserService.SaveUser(ref user);

                    // if the value for saved is true
                    if (saved)
                    {
                        if (LoggedInUser.ProfileVisibility == ProfileVisibilityEnum.NotSelected)
                        {
                            // This forces a reload
                            ParentMainLayout.SetupScreen(ScreenTypeEnum.SetProfileVisibility);
                        }
                        else
                        {
                            // This forces a reload
                            ParentMainLayout.SetupScreen(ScreenTypeEnum.Index);
                        }
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
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
            
        #endregion
        
    }
    #endregion

}
