

#region using statements

using ObjectLibrary.BusinessObjects;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components;
using DataJuggler.BlazorGallery.Pages;
using DataJuggler.PixelDatabase;
using Index = DataJuggler.BlazorGallery.Pages.Index;
using Microsoft.AspNetCore.Components;
using System.Runtime.Versioning;
using DataGateway.Services;
using DataJuggler.BlazorGallery.Shared;
using ObjectLibrary.Enumerations;
using Timer = System.Timers.Timer;
using DataJuggler.UltimateHelper;
using System.Drawing;
using Image = ObjectLibrary.BusinessObjects.Image;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class ImageViewer
    /// <summary>
    /// This class is used to display an almost full screen view image.
    /// There is also a button to return to the Selected Folder.
    /// This class also has back and next buttons to allow a slide show feature.
    /// </summary>
    [SupportedOSPlatform("windows")]    
    public partial class FullScreenImageViewer : IBlazorComponent
    {
        
        #region Private Variables
        private string imageStyle;
        private string checkMarkImage;
        private Image image;
        private string name;        
        private double imageHeight;
        private Timer timer;
        private string checkMarkContainerStyle;
        private string checkMarkStyle;        
        private IBlazorComponentParent parent;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a FullScreenImageViewer
        /// </summary>
        public FullScreenImageViewer()
        {
            // Set the ImageHeight default
            ImageHeight = 83.333;

             // default
            CheckMarkImage = "../Images/Transparent.png";
        }
        #endregion

        #region Methods
            
            #region CopyDirectLink()
            /// <summary>
            /// Copy Direct Link
            /// </summary>
            public  void CopyDirectLink()
            {
                // if the value for HasImage is true
                if ((HasImage) && (HasParentMainLayout))
                {
                    // gget the relative path
                    string imageUrl = Image.RelativePath;

                    // get the root
                    string root = EnvironmentVariableHelper.GetEnvironmentVariableValue("BlazorGalleryURL", EnvironmentVariableTarget.Machine);

                    // get the fullPath
                    string fullPath = root + "/" + imageUrl.Replace("../", "");

                    // Copy the direct link
                    ParentMainLayout.CopyDirectLink(fullPath);

                    // set to visible
                    CheckMarkImage = "../Images/Check.png"; 

                    // update the UI
                    Refresh();

                    // Start the timer
                    Timer = new Timer(3000);
                    Timer.Elapsed += TimerElapsed;
                    Timer.Start();
                }
            }
            #endregion
            
            #region GoBack()
            /// <summary>
            /// Go Back
            /// </summary>
            public void GoBack()
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Go back to the previous screen type
                    ParentMainLayout.RestoreScreenType();
                }
            }
            #endregion
            
            #region GoToNext()
            /// <summary>
            /// Go To Next
            /// </summary>
            public void GoToNext()
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Select the next image in this folder
                    ParentMainLayout.SelectNextImage();
                }
            }
            #endregion
            
            #region GoToPrevious()
            /// <summary>
            /// Go To Previous
            /// </summary>
            public void GoToPrevious()
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Select the next image in this folder
                    ParentMainLayout.SelectPreviousImage();
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
                
                // update the UI
                Refresh();
            }
            #endregion
            
        #endregion

        #region Properties

            #region CanMoveNext
            /// <summary>
            /// This read only property returns the value of CanMoveNext from the object ParentMainLayout.
            /// </summary>
            public bool CanMoveNext
            {
                
                get
                {
                    // initial value
                    bool canMoveNext = false;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        canMoveNext = ParentMainLayout.CanMoveNext;
                    }
                    
                    // return value
                    return canMoveNext;
                }
            }
            #endregion
            
            #region CanMovePrevious
            /// <summary>
            /// This read only property returns the value of CanMovePrevious from the object ParentMainLayout.
            /// </summary>
            public bool CanMovePrevious
            {
                
                get
                {
                    // initial value
                    bool canMovePrevious = false;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        canMovePrevious = ParentMainLayout.CanMovePrevious;
                    }
                    
                    // return value
                    return canMovePrevious;
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
            
            #region HasTimer
            /// <summary>
            /// This property returns true if this object has a 'Timer'.
            /// </summary>
            public bool HasTimer
            {
                get
                {
                    // initial value
                    bool hasTimer = (this.Timer != null);
                    
                    // return value
                    return hasTimer;
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
            
            #region ImageHeight
            /// <summary>
            /// This property gets or sets the value for 'ImageHeight'.
            /// </summary>
            public double ImageHeight
            {
                get { return imageHeight; }
                set 
                { 
                    imageHeight = value;
                }
            }
            #endregion
            
            #region ImageHeightStyle
            /// <summary>
            /// This read only property returns the value of ImageHeightStyle from the object ImageHeight.
            /// </summary>
            public string ImageHeightStyle
            {
                
                get
                {
                    // initial value
                    string imageHeightStyle = ImageHeight + "vh";
                    
                    // return value
                    return imageHeightStyle;
                }
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
                    
                    // if the value for HasParentMainLayout is true
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
            
            #region ScaledDownWidth
            /// <summary>
            /// This read only property returns the value of ScaledDownWidth from the object Image.
            /// </summary>
            public double ScaledDownWidth
            {
                
                get
                {
                    // initial value
                    double scaledDownWidth = 0;

                    // local
                    double ratio = 0;
                    
                    // if Image exists
                    if (HasImage)
                    {
                        double zoom = 1920 / ScreenWidth;

                        if (Image.Width == Image.Height)
                        {
                            ImageHeight = 83.333;
                            scaledDownWidth = 46.875;
                        }
                        else if (Image.Height > Image.Width)
                        {
                            // Determine the ratio
                            ratio = (double) 83.333 / (double) Image.Height; 

                            ImageHeight = 83.333;
                            scaledDownWidth = Math.Round(Image.Width * ratio, 2);
                        }
                        else
                        {
                            // width is wider than height

                            // Determine the ratio
                            ratio = (double) 72 / (double) Image.Width;

                            scaledDownWidth = 72;
                            ImageHeight = Math.Round((Image.Height / ScreenHeight * ScreenWidth) * ratio, 2);
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
                    string scaledDownWidthStyle = ScaledDownWidth + "vw";
                    
                    // return value
                    return scaledDownWidthStyle;
                }
            }
            #endregion
            
            #region ScreenHeight
            /// <summary>
            /// This read only property returns the value of ScreenHeight from the object ParentMainLayout.
            /// </summary>
            public double ScreenHeight
            {
                
                get
                {
                    // initial value
                    double screenHeight = 0;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        screenHeight = ParentMainLayout.ScreenHeight;
                    }
                    
                    // return value
                    return screenHeight;
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
            
            #region ScreenWidth
            /// <summary>
            /// This read only property returns the value of ScreenWidth from the object ParentMainLayout.
            /// </summary>
            public double ScreenWidth
            {
                
                get
                {
                    // initial value
                    double screenWidth = 0;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        screenWidth = ParentMainLayout.ScreenWidth;
                    }
                    
                    // return value
                    return screenWidth;
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
                    
                    // if the value for HasParentMainLayout is true
                    if (HasParentMainLayout)
                    {
                        // set the return value
                        selectedFolder = ParentMainLayout.SelectedFolder;
                    }
                    
                    // return value
                    return selectedFolder;
                }
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
            
        #endregion

    }
    #endregion

}
