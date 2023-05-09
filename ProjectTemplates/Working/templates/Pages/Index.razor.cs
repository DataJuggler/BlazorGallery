

#region using statements

using BlazorStyled;
using DataGateway.Services;
using DataJuggler.Blazor.FileUpload;
using DataJuggler.Cryptography;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ObjectLibrary.BusinessObjects;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Util;
using ObjectLibrary.Enumerations;
using DataJuggler.BlazorGallery.Components;
using System.Runtime.Versioning;
using DataJuggler.BlazorGallery.Shared;

#endregion

namespace DataJuggler.BlazorGallery.Pages
{

    #region class Index
    /// <summary>
    /// This class is the main page of this app.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class Index : IBlazorComponent, IBlazorComponentParent, ISpriteSubscriber
    {
        
        #region Private Variables        
        private string name;
        private List<IBlazorComponent> children;
        private IBlazorComponentParent parent;
        private ScreenTypeEnum screenType;
        private Login loginComponent;
        private User loggedInUser;
        #endregion

        #region Methods

            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // if found return the Child by name
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion

            #region Join()
            /// <summary>
            /// Join
            /// </summary>
            public void Join()
            {
                // Setup the ScreenType
                ScreenType = ScreenTypeEnum.SignUp;

                // Update the page
                Refresh();
            }
            #endregion
            
            #region Login()
            /// <summary>
            /// Login
            /// </summary>
            public void Login()
            {
                 // Setup the ScreenType
                ScreenType = ScreenTypeEnum.Login;

                // Update the page
                Refresh();
            }
            #endregion

            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to verify a user
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {
                // if ther is not a logged in user
                if (!HasLoggedInUser && firstRender)
                {
                    // locals
                    string emailAddress = "";
                    string storedPasswordHash = "";
                        
                    try
                    {
                        // get the values from local storage if present
                        var remember = await ProtectedLocalStore.GetAsync<bool>("RememberLogin");

                        // get the value for rememberLogin
                        bool rememberLogin = remember.Value;

                        // if rememberLogin is true
                        if (rememberLogin)
                        {
                            var email = await ProtectedLocalStore.GetAsync<string>("EmailAddress");
                            var hash = await ProtectedLocalStore.GetAsync<string>("PasswordHash");

                            // If the emailAddress string exists
                            if (TextHelper.Exists(email.Value, hash.Value))
                            {
                                // set the value for email
                                emailAddress = email.Value;

                                // get the storedPasswordHash
                                storedPasswordHash = hash.Value;

                                // Attempt to find this user
                                User user = await UserService.FindUserByEmailAddress(emailAddress);

                                // If the user object exists
                                if (NullHelper.Exists(user))
                                {
                                    // get the key
                                    string key = EnvironmentVariableHelper.GetEnvironmentVariableValue("BlazorGalleryKeyCode", EnvironmentVariableTarget.User);

                                    // if the key was found
                                    if (TextHelper.Exists(key))
                                    {
                                        // can this artist be verified
                                        bool isVerified = CryptographyHelper.VerifyHash(storedPasswordHash, key, user.PasswordHash, true);

                                        // if the value for isVerified is true
                                        if (isVerified)
                                        {
                                            // Set the LoggedInuser
                                            LoggedInUser = user;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("OnAfterRenderAsync", "Login.cs", error);
                    }
                }

                // call the base
                await base.OnAfterRenderAsync(firstRender);

                // if the value for HasLoggedInUser is true
                if ((HasLoggedInUser) && (firstRender))
                {
                    // if the value for HasParentMainLayout is true
                    if (HasParentMainLayout)
                    {
                        // Force folders to reload
                        ParentMainLayout.ForceReload = true;

                        // Force update
                        ParentMainLayout.Refresh();
                    }

                    // Refresh the UI
                    Refresh();
                }
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
                
            }
            #endregion

            #region RemovedLocalStoreItems()
            /// <summary>
            /// This method Removed Local Store Items
            /// </summary>
            public async Task<bool> RemovedLocalStoreItems()
            {
                // initial value
                bool removed = false;

                try
                {
                    // if the ProtectedLocalStore exists
                    if (ProtectedLocalStore != null)
                    {
                        // delete doesn't seem to work, so I am setting to false
                        await ProtectedLocalStore.SetAsync("RememberLogin", false);

                        // Remove all items
                        await ProtectedLocalStore.DeleteAsync("RememberPassword");
                        await ProtectedLocalStore.DeleteAsync("EmailAddress");
                        await ProtectedLocalStore.DeleteAsync("PasswordHash");
                    }

                    // set to true
                    removed = true;
                }
                catch (Exception error)
                {   
                    // for debugging only
                    DebugHelper.WriteDebugError("RemoveLocalStoreItems", "Login.cs", error);
                }

                // return value
                return removed;
            }
            #endregion

            #region SetupScreen(ScreenTypeEnum screenType, string emailAddress = "")
            /// <summary>
            /// This method Setup Screen
            /// </summary>
            public void SetupScreen(ScreenTypeEnum screenType, string emailAddress = "")
            {
                // set the ScreenType
                ScreenType = screenType;

                if ((ScreenType == ScreenTypeEnum.Login) && (TextHelper.Exists(emailAddress)) && (HasLoginComponent))
                {
                    // Set the email address
                    LoginComponent.EmailAddress = emailAddress;
                }
                else if (ScreenType == ScreenTypeEnum.MainScreen)
                {
                    // if the parent exists
                    if ((HasLoggedInUser) && (HasParentMainLayout))
                    {
                        // Force a reload
                        ParentMainLayout.ForceReload = true;

                        // Refresh the parent
                        ParentMainLayout.Refresh();
                    }
                }

                // Update the UI
                Refresh();
            }
            #endregion
            
            #region SignOut()
            /// <summary>
            /// Sign Out
            /// </summary>
            public async void SignOut()
            {
                // Erase
                LoggedInUser = null;

                // Remove the items the user has stored in the local browser storage
                await RemovedLocalStoreItems();

                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Force screen to update
                    ParentMainLayout.ForceReload = true;

                    // Update parent
                    ParentMainLayout.Refresh();
                }

                // Update the UI
                Refresh();
            }
            #endregion
            
            #region StoreLocalStoreItems(string emailAddress, string userName, string passwordHash)
            /// <summary>
            /// This method Store Local Store Items
            /// </summary>
            public async Task<bool> StoreLocalStoreItems(string emailAddress, string userName, string passwordHash)
            {
                // initial value
                bool saved = false;

                try
                {
                    // try saving
                    await ProtectedLocalStore.SetAsync("RememberLogin", true);
                    await ProtectedLocalStore.SetAsync("EmailAddress", emailAddress);
                    await ProtectedLocalStore.SetAsync("UserName", userName);
                    await ProtectedLocalStore.SetAsync("PasswordHash", passwordHash);

                    // presumption
                    saved = true;
                }
                catch (Exception error)
                {
                    // for debugging only for now
                    DebugHelper.WriteDebugError("StoreLocalStoreItems", "Index.razor.cs", error);
                }

                // return value
                return saved;
            }

        public void Register(Sprite sprite)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion

        #region Properties

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
            
            #region HasLoginComponent
            /// <summary>
            /// This property returns true if this object has a 'LoginComponent'.
            /// </summary>
            public bool HasLoginComponent
            {
                get
                {
                    // initial value
                    bool hasLoginComponent = (this.LoginComponent != null);
                    
                    // return value
                    return hasLoginComponent;
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
            /// This property gets or sets the value for 'LoggedInUser'.
            /// </summary>
            public User LoggedInUser
            {
                get { return loggedInUser; }
                set { loggedInUser = value; }
            }
            #endregion
            
            #region LoginComponent
            /// <summary>
            /// This property gets or sets the value for 'LoginComponent'.
            /// </summary>
            public Login LoginComponent
            {
                get { return loginComponent; }
                set { loginComponent = value; }
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

                    // if the parent class exists
                    if (parent != null)
                    {
                        // register with the parent
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
            
            #region ScreenType
            /// <summary>
            /// This property gets or sets the value for 'ScreenType'.
            /// </summary>
            public ScreenTypeEnum ScreenType
            {
                get { return screenType; }
                set { screenType = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
