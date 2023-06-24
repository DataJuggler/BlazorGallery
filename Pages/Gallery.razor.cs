

#region using statements

using BlazorStyled;
using DataGateway.Services;
using DataJuggler.Blazor.FileUpload;
using DataJuggler.Cryptography;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
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

    #region class Gallery
    /// <summary>
    /// This class is used for viewing the images of a gallery not owned by you.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class Gallery : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables        
        private string name;
        private List<IBlazorComponent> children;
        private IBlazorComponentParent parent;
        private string userName;
        private string folderName;
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

            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to verify a user
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {
                // call the base
                await base.OnAfterRenderAsync(firstRender);

                // if the value for HasLoggedInUser is true
                if ((HasLoggedInUser) && (firstRender))
                {
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
            
            #region FolderName
            /// <summary>
            /// This property gets or sets the value for 'FolderName'.
            /// </summary>
            [Parameter]
            public string FolderName
            {
                get { return folderName; }
                set { folderName = value; }
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
            
            #region HasSelectedFolder
            /// <summary>
            /// This property returns true if this object has a 'SelectedFolder'.
            /// </summary>
            public bool HasSelectedFolder
            {
                get
                {
                    // initial value
                    bool hasSelectedFolder = (this.SelectedFolder != null);
                    
                    // return value
                    return hasSelectedFolder;
                }
            }
            #endregion
            
            #region HasUserName
            /// <summary>
            /// This property returns true if the 'UserName' exists.
            /// </summary>
            public bool HasUserName
            {
                get
                {
                    // initial value
                    bool hasUserName = (!String.IsNullOrEmpty(this.UserName));
                    
                    // return value
                    return hasUserName;
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
            /// This read only property returns the value of ScreenType from the object ParentMainLayout.
            /// </summary>
            public ScreenTypeEnum ScreenType
            {
                
                get
                {
                    // initial value
                    ScreenTypeEnum screenType = ScreenTypeEnum.MainScreen;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        screenType = ParentMainLayout.ScreenType;
                    }
                    
                    // return value
                    return screenType;
                }
            }
            #endregion
            
            #region SelectedFolder
            /// <summary>
            /// This read only property returns the value of SelectedFolder from the object Parent.
            /// </summary>
            public Folder SelectedFolder
            {
                
                get
                {
                    // initial value
                    Folder selectedFolder = null;
                    
                    // if Parent exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        selectedFolder = ParentMainLayout.SelectedFolder;
                    }
                    
                    // return value
                    return selectedFolder;
                }
            }
            #endregion
            
            #region UserName
            /// <summary>
            /// This property gets or sets the value for 'UserName'.
            /// </summary>
            [Parameter]
            public string UserName { get; set; }
            #endregion
            
        #endregion

    }
    #endregion

}
