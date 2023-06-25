

#region using statements

using ApplicationLogicComponent.Connection;
using DataGateway;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.BlazorGallery.Shared;
using DataJuggler.UltimateHelper;
using Microsoft.AspNetCore.Components;
using ObjectLibrary.BusinessObjects;
using System.Runtime.Versioning;
using System.Text;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class MainGalleryComponent
    /// <summary>
    /// This class is used to display the top 20 images on the MainGallery
    /// </summary>
    [SupportedOSPlatform("windows")]    
    public partial class MainGalleryComponent : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private List<MainGalleryView> images;
        private List<ImageLike> galleryLikes;
        #endregion
        
        #region Methods
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // return the child (not used here)
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
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(Connection.Name);

                    // Load the GalleryLikes for this gallery
                    GalleryLikes = gateway.LoadImageLikesInMainGalleryForUserId(LoggedInUserId);

                    // get the last exception if any
                    // Exception temp = gateway.GetLastException();

                    // Refresh the UI
                    Refresh();
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

            #region Refresh()
            /// <summary>
            /// method Refresh
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

            #region GalleryLikes
            /// <summary>
            /// This property gets or sets the value for 'GalleryLikes'.
            /// </summary>
            public List<ImageLike> GalleryLikes
            {
                get { return galleryLikes; }
                set { galleryLikes = value; }
            }
            #endregion
            
            #region GalleryOwner
            /// <summary>
            /// This read only property returns the value of GalleryOwner from the object ParentMainLayout.
            /// </summary>
            public User GalleryOwner
            {
                
                get
                {
                    // initial value
                    User galleryOwner = null;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        galleryOwner = ParentMainLayout.GalleryOwner;
                    }
                    
                    // return value
                    return galleryOwner;
                }
            }
            #endregion

            #region GalleryOwnerId
            /// <summary>
            /// This read only property returns the value of GalleryOwnerId from the object GalleryOwner.
            /// </summary>
            public int GalleryOwnerId
            {
                
                get
                {
                    // initial value
                    int galleryOwnerId = 0;
                    
                    // if GalleryOwner exists
                    if (GalleryOwner != null)
                    {
                        // set the return value
                        galleryOwnerId = GalleryOwner.Id;
                    }
                    
                    // return value
                    return galleryOwnerId;
                }
            }
            #endregion
            
            #region HasGalleryLikes
            /// <summary>
            /// This property returns true if this object has a 'GalleryLikes'.
            /// </summary>
            public bool HasGalleryLikes
            {
                get
                {
                    // initial value
                    bool hasGalleryLikes = (this.GalleryLikes != null);
                    
                    // return value
                    return hasGalleryLikes;
                }
            }
            #endregion
            
            #region HasGalleryOwner
            /// <summary>
            /// This property returns true if this object has a 'GalleryOwner'.
            /// </summary>
            public bool HasGalleryOwner
            {
                get
                {
                    // initial value
                    bool hasGalleryOwner = (this.GalleryOwner != null);
                    
                    // return value
                    return hasGalleryOwner;
                }
            }
            #endregion
            
            #region HasImages
            /// <summary>
            /// This property returns true if this object has an 'Images'.
            /// </summary>
            public bool HasImages
            {
                get
                {
                    // initial value
                    bool hasImages = (this.Images != null);
                    
                    // return value
                    return hasImages;
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
            
            #region Images
            /// <summary>
            /// This property gets or sets the value for 'Images'.
            /// </summary>
            public List<MainGalleryView> Images
            {
                get { return images; }
                set { images = value; }
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
            /// This read only property returns the value of LoggedInUserId from the object LoggedInUser.
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
                        // register with the parent
                        Parent.Register(this);
                    }
                }
            }

        public List<IBlazorComponent> Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
            
        #endregion

    }
    #endregion

}
