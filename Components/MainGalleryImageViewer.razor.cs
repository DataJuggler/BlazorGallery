

#region using statements

using ObjectLibrary.BusinessObjects;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components;
using DataJuggler.BlazorGallery.Pages;
using Index = DataJuggler.BlazorGallery.Pages.Index;
using Microsoft.AspNetCore.Components;
using System.Runtime.Versioning;
using DataGateway.Services;
using DataJuggler.BlazorGallery.Shared;
using ObjectLibrary.Enumerations;
using DataJuggler.UltimateHelper;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class MainGalleryImageViewer
    /// <summary>
    /// This class is used to display the 20 most recent images uploaded.
    /// remove button.
    /// </summary>
    [SupportedOSPlatform("windows")]    
    public partial class MainGalleryImageViewer : IBlazorComponent
    {
        
        #region Private Variables
        private string imageStyle;
        private string fullScreenButtonStyle;
        private Image image;
        private string name;        
        private string imageContainerStyle;
        private const int MaxWidth = 400;
        private IBlazorComponentParent parent;
        #endregion

        #region Methods
            
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
            
            #region ViewGallery(Image image)
            /// <summary>
            /// View Gallery
            /// </summary>
            public void ViewGallery(Image image)
            {
                // if the value for HasParentMainLayout is true
                if ((HasParentMainLayout) && (NullHelper.Exists(image)))
                {
                    // Navigate to the gallery
                    ParentMainLayout.NavigateToGallery(image.UserName, image.FolderName);
                }
            }
            #endregion
            
            #region ViewImage(Image image)
            /// <summary>
            /// View Image
            /// </summary>
            public void ViewImage(Image image)
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Set the selected image
                    ParentMainLayout.SelectedImage = image;

                    // Setup the screen to show the image
                    ParentMainLayout.SetupScreen(ScreenTypeEnum.ViewImageInMainGallery);
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region FullScreenButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'FullScreenButtonStyle'.
            /// </summary>
            public string FullScreenButtonStyle
            {
                get { return fullScreenButtonStyle; }
                set { fullScreenButtonStyle = value; }
            }
            #endregion
            
            #region HasImage
            /// <summary>
            /// This property returns true if this object has an 'Image'.
            /// </summary>
            public bool HasImage
            {
                get
                {
                    // initial value
                    bool hasImage = (this.Image != null);
                    
                    // return value
                    return hasImage;
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
            
            #region HasParentIndexPage
            /// <summary>
            /// This property returns true if this object has a 'ParentIndexPage'.
            /// </summary>
            public bool HasParentIndexPage
            {
                get
                {
                    // initial value
                    bool hasParentIndexPage = (this.ParentIndexPage != null);
                    
                    // return value
                    return hasParentIndexPage;
                }
            }
            #endregion
            
            #region HasParentMainGallery
            /// <summary>
            /// This property returns true if this object has a 'ParentMainGallery'.
            /// </summary>
            public bool HasParentMainGallery
            {
                get
                {
                    // initial value
                    bool hasParentMainGallery = (this.ParentMainGallery != null);
                    
                    // return value
                    return hasParentMainGallery;
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
            
            #region Image
            /// <summary>
            /// This property gets or sets the value for 'Image'.
            /// </summary>
            [Parameter]
            public Image Image
            {
                get { return image; }
                set { image = value; }
            }
            #endregion
            
            #region ImageContainerStyle
            /// <summary>
            /// This property gets or sets the value for 'ImageContainerStyle'.
            /// </summary>
            public string ImageContainerStyle
            {
                get { return imageContainerStyle; }
                set { imageContainerStyle = value; }
            }
            #endregion
            
            #region ImageRelativePath
            /// <summary>
            /// This read only property returns the value of RelativePath from the object Image.
            /// </summary>
            public string ImageRelativePath
            {
                
                get
                {
                    // initial value
                    string imageRelativePath = "";
                    
                    // if Image exists
                    if (Image != null)
                    {
                        // set the return value
                        imageRelativePath = Image.RelativePath;
                    }
                    
                    // return value
                    return imageRelativePath;
                }
            }
            #endregion
            
            #region ImageStyle
            /// <summary>
            /// This property gets or sets the value for 'ImageStyle'.
            /// </summary>
            public string ImageStyle
            {
                get { return imageStyle; }
                set { imageStyle = value; }
            }

        
        

        #endregion

            #region LoggedInUser
            /// <summary>
            /// This read only property returns the value of LoggedInUser from the object ParentIndexPage.
            /// </summary>
            public User LoggedInUser
            {  
                get
                {
                    // initial value
                    User loggedInUser = null;
                    
                    // if ParentIndexPage exists
                    if (ParentIndexPage != null)
                    {
                        // set the return value
                        loggedInUser = ParentIndexPage.LoggedInUser;
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
                set { parent = value; }
            }
            #endregion
            
            #region ParentIndexPage
            /// <summary>
            /// This read only property returns the value of ParentIndexPage from the object Parent.
            /// </summary>
            public Index ParentIndexPage
            {
                
                get
                {
                    // initial value
                    Index parentIndexPage = null;
                    
                    // if Parent exists
                    if (Parent != null)
                    {
                        // set the return value
                        parentIndexPage = Parent as Index;
                    }
                    
                    // return value
                    return parentIndexPage;
                }
            }
            #endregion
            
            #region ParentMainGallery
            /// <summary>
            /// This read only property returns the value of ParentMainGallery from the object Parent.
            /// </summary>
            public MainGalleryComponent ParentMainGallery
            {
                
                get
                {
                    // initial value
                    MainGalleryComponent parentMainGallery = null;
                    
                    // if Parent exists
                    if (Parent != null)
                    {
                        // set the return value
                        parentMainGallery = Parent as MainGalleryComponent;
                    }
                    
                    // return value
                    return parentMainGallery;
                }
            }
            #endregion
            
            #region ParentMainLayout
            /// <summary>
            /// This read only property returns the value of ParentMainLayout from the object ParentIndexPage.
            /// </summary>
            public MainLayout ParentMainLayout
            {
                
                get
                {
                    // initial value
                    MainLayout parentMainLayout = null;
                    
                    // if the value for HasParent is true
                    if (HasParentMainGallery)
                    {
                        // set the return value
                        parentMainLayout = ParentMainGallery.ParentMainLayout;
                    }
                    
                    // return value
                    return parentMainLayout;
                }
            }
            #endregion
            
            #region ScaledDownWidth
            /// <summary>
            /// This read only property returns the value of ScaledDownWidth from the object Image.
            /// </summary>
            public int ScaledDownWidth
            {
                
                get
                {
                    // initial value
                    int scaledDownWidth = 0;
                    
                    // if Image exists
                    if (Image != null)
                    {  
                        // set the return value
                        double width = Image.Width;
                        double newHeight = 200;
                        double scaledDownRaw = (1 / (Image.Height / newHeight)) * width;
                        scaledDownWidth = (int) Math.Round(scaledDownRaw, 0);

                        // if the width is too big
                        if (scaledDownWidth > MaxWidth)
                        {
                            // Could cause problems
                            scaledDownWidth = MaxWidth;
                        }
                    }
                    
                    // return value
                    return scaledDownWidth;
                }
            }
            #endregion
            
            #region ScaledDownWidthStyle
            /// <summary>
            /// This read only property returns the value of ScaledDownWidthStyle from the object ScaledDownWidth.
            /// </summary>
            public string ScaledDownWidthStyle
            {
                
                get
                {
                    // initial value
                    string scaledDownWidthStyle = ScaledDownWidth + "px";
                    
                    // return value
                    return scaledDownWidthStyle;
                }
            }
            #endregion
            
            #region SelectedFolder
            /// <summary>
            /// This read only property returns the value of SelectedFolder from the object ParentIndexPage.
            /// </summary>
            public Folder SelectedFolder
            {  
                get
                {
                    // initial value
                    Folder selectedFolder = null;
                    
                    // if ParentIndexPage exists
                    if (ParentIndexPage != null)
                    {
                        // set the return value
                        selectedFolder = ParentIndexPage.SelectedFolder;
                    }
                    
                    // return value
                    return selectedFolder;
                }
            }
            #endregion           
            
        #endregion

    }
    #endregion

}
