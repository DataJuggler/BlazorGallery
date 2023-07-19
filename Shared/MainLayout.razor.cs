

#region using statements

using DataGateway;
using DataGateway.Services;
using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using DataJuggler.Blazor.FileUpload;
using DataJuggler.BlazorGallery.Components;
using DataJuggler.Cryptography;
using DataJuggler.PixelDatabase;
using DataJuggler.UltimateHelper;
using DataJuggler.UltimateHelper.Objects;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System.Runtime.Versioning;
using ApplicationLogicComponent.Connection;
using Timer = System.Timers.Timer;
using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components;
using System.Linq;

#endregion

namespace DataJuggler.BlazorGallery.Shared
{

    #region class MainLayout
    /// <summary>
    /// This class is the main layout of this application.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class MainLayout : IBlazorComponentParent, ISpriteSubscriber
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;
        private string blueButton;
        private Pages.Index indexPage;
        private List<Folder> folders;
        private Folder selectedFolder;
        private User loggedInUser;
        private User galleryOwner;
        private bool addFolderMode;
        private bool renameFolderMode;
        private Folder folderBeingRenamed;
        private FileUpload fileUpload;
        private ValidationComponent newFolderNameComponent;        
        private double top;
        private bool forceReload;        
        private Admin admin;
        private ConfirmationComponent confirmationComponent;
        private bool showConfirmation;
        private int folderToDeleteId; 
        private ScreenTypeEnum screenType;
        private ScreenTypeEnum previousScreenType;
        private Sprite sprite;
        private bool initialized;
        private string saveButtonStyle;
        private string saveButtonDisabledStyle;
        private Login loginComponent;  
        private string validationMessage;
        private string userUrl;
        private string checkMarkStyle;
        private double checkMarkTop;
        private string checkMarkImage;
        private string checkMarkContainerStyle;
        private Timer timer;
        private Image selectedImage;
        private MainGalleryComponent mainGalleryComponent;
        private List<MainGalleryView> mainGalleryImages;
        private string addButtonStyle;
        private double addButtonTop;
        private string newFolderStyle;
        private BrowserWindowSize browser;
        private string newUserEmailAddress;       
        private const int AdminId = 1;
        public const int FolderHeight = 7;
        private bool isSmallMedia;
        private double screenWidth;
        private double screenHeight;
        private const double UploadTopBase = 15.6;
        public const int UploadLimit = 20480000;
        private string loginButtonStyle;
        private string joinButtonStyle;
        private string cancelButtonStyle;
        private string noButtonStyle;
        private string verifyButtonStyle;
        private string yesButtonStyle;
        private string signOutButtonStyle;
        private string sendButtonStyle;
        public const string FileTooLargeMessage = "The file must be 20 megs or less.";      
        public const int FolderTop = 14;       
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a MainLayout object
        /// </summary>
        public MainLayout()
        {
            // default
            CheckMarkImage = "../Images/Transparent.png";
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
                
                // update the UI
                Refresh();
            }
            #endregion
            
        #endregion

        #region Methods
            
            #region AddFolder()
            /// <summary>
            /// Add Folder
            /// </summary>
            public void AddFolder()
            {
                // set to true
                AddFolderMode = true;

                // This is needed to set focus to the component when it rerenders
                ForceReload = true;

                // Update
                Refresh();
            }
            #endregion
            
            #region CopyDirectLink(string imageUrl)
            /// <summary>
            /// Copy Direct Link
            /// </summary>
            public async void CopyDirectLink(string imageUrl)
            {
                await BlazorJSBridge.CopyToClipboard(JSRuntime, imageUrl);
            }
            #endregion
            
            #region CopyFolder(int folderId, int buttonNumber)
            /// <summary>
            /// Copy Folder
            /// </summary>
            public async void CopyFolder(int folderId)
            {
                // find the folder
                Folder folder = await FolderService.FindFolder(folderId);
                
                // if the folder exists and the LoggedInUser exists
                if ((NullHelper.Exists(folder)) && (HasLoggedInUser) && (HasFolders))
                { 
                    // Find the index of this folder
                    int folderIndex = FindFolderIndex(folderId);

                    // Set the buttonNumber
                    int buttonNumber = folderIndex + 1;
                    int reverseButtonNumber = Folders.Count - buttonNumber;

                    // Set the top
                    CheckMarkTop = 15.6 + (buttonNumber * FolderHeight);

                    // set the top, which sets the Upload button top
                    Top = UploadTopBase + ((Folders.Count + 1) * FolderHeight);

                    string root = EnvironmentVariableHelper.GetEnvironmentVariableValue("BlazorGalleryURL", EnvironmentVariableTarget.Machine);
                    string gallery = root + "/Gallery/" + LoggedInUser.UserName + "/" + folder.Name.Replace(" ", "%20");
                    
                    await BlazorJSBridge.CopyToClipboard(JSRuntime, gallery);

                    // set to visible
                    CheckMarkImage = "../Images/Check.png";
                    
                    // Update the UI
                    Refresh();
                    
                    // Start the timer
                    Timer = new Timer(3000);
                    Timer.Elapsed += TimerElapsed;
                    Timer.Start();
                }
            }
            #endregion
            
            #region DeleteFolder(int folderId)
            /// <summary>
            /// Delete Folder
            /// </summary>
            public async void DeleteFolder(int folderId)
            {
                // first we need to find this folder
                Folder folder = await FolderService.FindFolder(folderId);

                // If the folder object exists
                if (NullHelper.Exists(folder))
                {
                    // Set the Id of the folder to be deleted
                    FolderToDeleteId = folder.Id;

                    // Show the Confirmation Component
                    ShowConfirmation = true;

                    // Update the UI
                    Refresh();

                    // if the value for HasConfirmationComponent is true
                    if (HasConfirmationComponent)
                    {
                        // Set the prompt to send
                        string prompt = "Confirm Delete Folder " + folder.Name + "?";

                        // Setup the Prompt
                        ConfirmationComponent.SetPrompt(prompt);
                    }
                }
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method Find Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // return the child object if one exists with this name
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion

            #region FindFolderIndex(int folderId)
            /// <summary>
            /// returns the Folder Index
            /// </summary>
            public int FindFolderIndex(int folderId)
            {
                // initial value
                int index = -1;

                // local 
                int tempIndex = -1;

                // Iterate the collection of Folder objects
                foreach (Folder folder in Folders)
                {   
                    // Increment the value for tempIndex
                    tempIndex++;

                    // if this is the folder being sought
                    if (folder.Id == folderId)
                    {
                        // set the return value
                        index = tempIndex;

                        // exit loop
                        break;
                    }
                }
                
                // return value
                return index;
            }
            #endregion
            
            #region FindHomeFolder()
            /// <summary>
            /// returns the Home Folder
            /// </summary>
            public Folder FindHomeFolder()
            {
                // initial value
                Folder homeFolder = null;

                // if the value for HasFolders is true
                if (HasFolders)
                {
                    // Iterate the collection of Folder objects
                    foreach (Folder folder in Folders)
                    {
                        if (folder.Name == "Home")
                        {
                            // Set the folderName
                            homeFolder = folder;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return homeFolder;
            }
            #endregion
            
            #region FolderSelected(int folderId)
            /// <summary>
            /// Folder Selected
            /// </summary>
            public async void FolderSelected(int folderId)
            {  
                // Set the SelectedFolder
                SelectedFolder = await FolderService.FindFolder(folderId);

                // if the value for HasSelectedFolder is true
                if (HasSelectedFolder)
                {
                    // If this user is the owner                    
                    if (SelectedFolder.UserId == LoggedInUserId)
                    {
                        // Set owner
                        GalleryOwner = LoggedInUser;
                        LoggedInUser.ViewingGalleryOwner = GalleryOwner;
                    }

                    if ((HasLoggedInUser) && (LoggedInUser.IsGalleryOwner))
                    {
                        // Make sure you are on the Index page
                        SetupScreen(ScreenTypeEnum.Index);
                    }
                    else if (HasGalleryOwner)
                    {
                        // Select in Viewing Mode
                        SetupScreen(ScreenTypeEnum.ViewingGallery);
                    }

                    // Set Selectd to true
                    SelectedFolder.Selected = true;

                    // if HasFolders is true
                    if (HasFolders)
                    {
                        // Iterate the collection of Folder objects
                        foreach (Folder folder in Folders)
                        {
                            // if this is the SelectedFolder
                            if (folder.Id == SelectedFolder.Id)
                            {
                                // Select this folder so it displays properly (red)
                                folder.Selected = true;
                            }
                            else
                            {
                                folder.Selected = false;
                            }
                        }
                    }

                    // load the images here
                    SelectedFolder.Images = await ImageService.GetImageListForFolder(SelectedFolder.Id);

                    // Set the url
                     string url = "/";

                    // if there is a LoggedInUser and the LoggedInUser is the owner of this Folder and the LoggedInUser is not in ViewOnlyMode.
                    if ((HasLoggedInUser) && (LoggedInUser.Id == SelectedFolder.UserId) && (!LoggedInUser.ViewOnlyMode))
                    {
                        // perform the file save
                        await FolderService.SaveFolder(ref selectedFolder);

                        // The GalleryOwner is also the LoggedInUser
                        LoggedInUser.ViewingGalleryOwner = LoggedInUser;

                        // Get the url                        
                        url = "/User/" + LoggedInUser.UserName + "/" + SelectedFolder.Name;
                    }
                    else if ((HasLoggedInUser) && (LoggedInUser.ViewOnlyMode) && (HasSelectedFolder))
                    {
                        // Set the Url (Display Purposes only)
                        url = "/Gallery/" + LoggedInUser.UserName + "/" + SelectedFolder.Name;
                    }
                    else if (HasGalleryOwner)
                    {
                        // Set the Url (Display Purposes only)
                        url = "/Gallery/" + GalleryOwner.UserName + "/" + SelectedFolder.Name;
                    }
                    
                    // Unselect all other folders
                    UnselectFolders(folderId);

                    // Get the current uri (again possibly)
                    var uri = Navigation.ToAbsoluteUri(Navigation.Uri);

                    // if we are at the same url
                    if (uri.ToString().Contains(url))
                    {
                        // do nothing
                        
                    }
                    else if ((uri.ToString().Contains(UserUrl)) && (!Initialized))
                    {
                        // do nothing
                    }
                    else
                    {
                        // This is for display only
                        Navigation.NavigateTo(url, replace: true);
                    }

                    // erase
                    UserUrl = "";

                    // Force Reload
                    ForceReload = true;

                    // Redisplay
                    Refresh();
                }
            }
            #endregion

            #region GiveFeedback()
            /// <summary>
            /// Give Feedback
            /// </summary>
            public void GiveFeedback()
            {
                // Give feedback
                SetupScreen(ScreenTypeEnum.Feedback, "", false);
            }
            #endregion
            
            #region Join()
            /// <summary>
            /// Join
            /// </summary>
            public void Join()
            {  
                // Setup the ScreenType
                SetupScreen(ScreenTypeEnum.SignUp, "", false);                
            }
            #endregion

            #region Login()
            /// <summary>
            /// Login
            /// </summary>
            public void Login()
            { 
                // Setup the ScreenType
                SetupScreen(ScreenTypeEnum.Login);
            }
            #endregion
            
            #region NavigateToGallery(string galleryUserName, string folderName)
            /// <summary>
            /// Navigate To Gallery
            /// </summary>
            public async void NavigateToGallery(string galleryUserName, string folderName)
            {
                // Setup the screen type
                SetupScreen(ScreenTypeEnum.ViewingGallery);

                // If the strings galleryUserName and folderName both exist
                if (TextHelper.Exists(galleryUserName, folderName))
                {
                    // Find the user
                    GalleryOwner = await UserService.FindUserByUserName(galleryUserName);

                    // If the value for the property .HasGalleryOwner is true
                    if ((HasGalleryOwner) && (HasLoggedInUser))
                    {
                        // Assign the ViewingGalleryOwner
                        LoggedInUser.ViewingGalleryOwner = GalleryOwner;

                        // If both User's exist, we are in ViewOnlyMode unless the LoggedInUser is the GalleryOwner
                        LoggedInUser.ViewOnlyMode = !LoggedInUser.IsGalleryOwner;

                        // Find the SelectedFolde
                        SelectedFolder = await FolderService.FindFolderByUserIdAndFolderName(GalleryOwnerId, folderName);
                    }
                    else if (HasGalleryOwner)
                    {
                        // Always read only mode if not a logged in user
                        GalleryOwner.ViewOnlyMode = true;

                        // Find the SelectedFolde
                        SelectedFolder = await FolderService.FindFolderByUserIdAndFolderName(GalleryOwnerId, folderName);
                    }
                    else
                    {
                        // Show a not found message
                        ValidationMessage = "Gallery Not Found.";
                    }

                    // if has selected folder
                    if (HasSelectedFolder)
                    {  
                        // Here you are viewing someone else's gallery in ViewOnlyMode.
                        SetupScreen(ScreenTypeEnum.ViewingGallery);                    
                        
                        // Load the images for this folder
                        SelectedFolder.Images = await ImageService.GetImageListForFolder(SelectedFolder.Id);

                        // Get the root
                        string root = EnvironmentVariableHelper.GetEnvironmentVariableValue("BlazorGalleryURL", EnvironmentVariableTarget.Machine);

                        // Set the GalleryName and the Folder
                        string galleryURL = root + "/Gallery/" + galleryUserName + "/" + folderName.Replace(" ", "%20");

                        // Set the GalleryURL
                        Navigation.NavigateTo(galleryURL);
                    }
                    else
                    {
                        // Show a not found message
                        ValidationMessage = "Gallery Not Found.";
                    }
                }
            }
            #endregion
            
            #region NavigateToMain()
            /// <summary>
            /// Navigate To Main
            /// </summary>
            public void NavigateToMain()
            {
                // Erase the current gallery owner and SelectedFolder
                GalleryOwner = null;
                SelectedFolder = null;
                if (HasLoggedInUser)
                {
                    // erase
                    LoggedInUser.ViewingGalleryOwner = null;
                }

                // View the MainGallery
                SetupScreen(ScreenTypeEnum.MainScreen);
            }
            #endregion
            
            #region NavigateToUsersGalleries()
            /// <summary>
            /// Navigate To The User's Folders (Home Folder or a SelectedFolder if there is one.
            /// </summary>
            public void NavigateToUsersGalleries()
            {
                // if the value for HasLoggedInUser is true
                if (HasLoggedInUser)
                {
                    // Set the GalleryOwner to himself
                    GalleryOwner = LoggedInUser;
                }

                // Go to the users home
                SetupScreen(ScreenTypeEnum.Index);
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
                if (firstRender)
                {
                    // Add the Onresized event to listen for
                    Listener.OnResized += WindowResized;
                }

                 // if ther is not a logged in user
                if (!HasLoggedInUser && firstRender)
                {
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
                                string emailAddress = email.Value;

                                // get the storedPasswordHash
                                string storedPasswordHash = hash.Value;

                                // Attempt to find this user
                                User user = await UserService.FindUserByEmailAddress(emailAddress);

                                // If the user object exists
                                if (NullHelper.Exists(user))
                                {
                                    // get the key
                                    string key = EnvironmentVariableHelper.GetEnvironmentVariableValue("BlazorGalleryKeyCode", EnvironmentVariableTarget.Machine);

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

                                             // if the value for HasAdmin is false
                                            if (!HasAdmin)
                                            {
                                                // Load the Admin  
                                                Admin = await AdminService.FindAdmin(AdminId);
                                            }

                                            // If the user has not accepted yet
                                            if (LoggedInUser.AcceptedTermsOfServiceDate.Year < 2000)
                                            {
                                                // Setup the screen
                                                SetupScreen(ScreenTypeEnum.TermsOfservice);
                                            }
                                            else if (LoggedInUser.ProfileVisibility == ProfileVisibilityEnum.NotSelected)
                                            {
                                                // Setup the screen
                                                SetupScreen(ScreenTypeEnum.SetProfileVisibility);
                                            }
                                            else if ((!LoggedInUser.EmailVerified) && (HasAdmin) && (Admin.RequireEmailVerification))
                                            {
                                                // Send a confirmation email code
                                                SetupScreen(ScreenTypeEnum.EmailVerification);
                                            }
                                            else
                                            {
                                                // get the list of folders
                                                List<Folder> folders = await FolderService.GetFolderListForUserId(LoggedInUserId);

                                                // If the folders collection exists and has one or more items
                                                if (ListHelper.HasOneOrMoreItems(folders))
                                                {
                                                    // find the selected folder
                                                    SelectedFolder = folders.FirstOrDefault(x => x.Selected == true);

                                                    // Select this folder
                                                    FolderSelected(selectedFolder.Id);
                                                }

                                                // Show the user's galleries
                                                NavigateToUsersGalleries();
                                            }
                                        }
                                    }
                                }
                            }
                        }                       
                    }
                    catch (Exception error)
                    {
                        // for debugging only
                        DebugHelper.WriteDebugError("OnAfterRenderAsync", "MainLayout.razor.cs", error);
                    }
                }

                // if firstRender
                if ((firstRender) || (ForceReload))
                {
                    if (ScreenType == ScreenTypeEnum.ViewingGallery)
                    {
                        // if the value for HasLoggedInUser is true
                        if (HasGalleryOwner)
                        {
                           // get the folders
                           Folders = await FolderService.GetFolderListForUserId(GalleryOwnerId);
                        }
                    }
                    else
                    {
                        // if the value for HasLoggedInUser is true
                        if (HasLoggedInUser)
                        {
                           // get the folders
                           Folders = await FolderService.GetFolderListForUserId(LoggedInUser.Id);
                        }
                    }

                   // If the Folders collection exists and has one or more items
                   if (ListHelper.HasOneOrMoreItems(Folders))
                   {   
                        // unselect the rest
                        foreach(Folder folder in Folders)
                        {
                            if ((HasLoggedInUser) && (LoggedInUser.ViewOnlyMode))
                            {
                                if (HasSelectedFolder)
                                {
                                    // if the SelectedFolder exists and this is the folder id
                                    if (SelectedFolder.Id != folder.Id)
                                    {
                                        // unselect
                                        folder.Selected = false;
                                    }
                                    else if (!folder.HasImages)
                                    {
                                        // Select this folder
                                        FolderSelected(folder.Id);
                                    }
                                }                                
                            }
                            else if (ScreenType == ScreenTypeEnum.Index)
                            {
                                // if this is the SelectedFolder and we do not have a selected folder yet
                                if ((folder.Selected) && (!HasSelectedFolder))
                                {
                                    // Select this folder
                                    FolderSelected(folder.Id);
                                }
                                else if ((HasSelectedFolder) && (SelectedFolder.Id == folder.Id))
                                {
                                    if (!folder.Selected)
                                    {
                                        // Select this folder
                                        FolderSelected(folder.Id);
                                    }
                                }
                                else
                                {
                                    // just for in memory use, not saved to the database
                                    folder.Selected = false;
                                }
                            }                      
                        }

                        // This is not needed for ScreenType.ViewingGallery
                        if (ScreenType == ScreenTypeEnum.Index)
                        {
                            // Set the Top                        
                            Top = UploadTopBase + ((Folders.Count + 1) * FolderHeight);

                            // if the value for AddFolderMode is true
                            if (AddFolderMode)
                            {
                                // Need to add 1 more folder height to not be in the way of the textbox
                                Top += FolderHeight;
                            }

                            // Set the Add Button Top
                            AddButtonTop = Top;
                        }
                   }
                }

                // call base method
                await base.OnAfterRenderAsync(firstRender);

                // if firstRender or ForceReload
                if (firstRender || ForceReload)
                {
                    // only force reload once
                    ForceReload = false;

                    // Update the UI
                    Refresh();
                }
            }
            #endregion

            #region OnInitialized()
            /// <summary>
            /// Initializing so the LocationChanged event can be set
            /// </summary>

            protected async override void OnInitialized()
            {
                // if the value for HasAdmin is false
                if (!HasAdmin)
                {
                    // Load the admin object
                    Admin = await AdminService.FindAdmin(AdminId);
                }

                // test if there is a uri
                var uri = Navigation.ToAbsoluteUri(Navigation.Uri);
                string queryString = uri.ToString();
                
                // If the queryString string exists
                if (TextHelper.Exists(queryString))
                {
                    // get the index of the quesiton mark
                    int index = queryString.IndexOf("/Gallery");

                    // Defaut value
                    UserUrl = "NotSet";

                    // If the value for index is greater than zero
                    if (index > 0)
                    {
                        // get the substring
                        string temp = queryString.Substring(index);

                        // If the temp string exists
                        if (TextHelper.Exists(temp))
                        {
                            char[] delimiterChars = { '/' };

                            // get the words
                            List<Word> words = TextHelper.GetWords(temp, delimiterChars);

                            // if there are two or more words
                            if (ListHelper.HasXOrMoreItems(words, 2))
                            {
                                // get the first word (should be gallery
                                string word1 = words[0].Text;
                                string userName = words[1].Text;
                                string folderName = "Home";

                                // if there are 3 or more words
                                if (ListHelper.HasXOrMoreItems(words, 3))
                                {   
                                    // Set the FolderName
                                    folderName = words[2].Text.Replace("%20", "");
                                }
                                else
                                {
                                    // Set the HomeUrl
                                    UserUrl = "/Gallery" + "/" + userName;
                                }
                                
                                // if we are opening a Gallery
                                if (word1 == "Gallery")
                                {   
                                    // Find the user
                                    User user = await UserService.FindUserByUserName(userName);

                                    // If the user object exists
                                    if (NullHelper.Exists(user))
                                    {
                                        // Find the SelectedFolde
                                        SelectedFolder = await FolderService.FindFolderByUserIdAndFolderName(user.Id, folderName);

                                        // if the value for HasSelectedFolder is true
                                        if (HasSelectedFolder)
                                        {
                                            // Set the GalleryOwner
                                            GalleryOwner = user;

                                            // Unselect all other folders for this user (not saved)
                                            UnselectFolders(SelectedFolder.Id);

                                            // Select this folder
                                            FolderSelected(SelectedFolder.Id);

                                             // Set the ScreenType
                                            SetupScreen(ScreenTypeEnum.ViewingGallery);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Set to true
                Initialized = true;

                base.OnInitialized();
            }
            #endregion

            #region OnFileUploaded(UploadedFileInfo file)
            /// <summary>
            /// This method On File Uploaded
            /// </summary>
            public async void OnFileUploaded(UploadedFileInfo file)
            {
                // Erase
                ValidationMessage = "";

                // if the file was uploaded
                if (!file.Aborted)
                {
                   // To Do: Save the uploaded file
                   string fileName = file.Name;

                   // If the LoggedInUser exists and SelectedFolder exists
                   if ((HasLoggedInUser) && (HasSelectedFolder))
                   {
                        // load the pixelDatabase
                        DataJuggler.PixelDatabase.PixelDatabase pixelDatabase = PixelDatabaseLoader.LoadPixelDatabase(file.FullPath, null);

                        // Create a new instance of an 'Image' object.
                        Image image = new Image();

                        // Create a new instance of a 'FileInfo' object.
                        FileInfo fileInfo = new FileInfo(file.FullPath);

                        // Set the size
                        image.FileSize = (int) file.Size;
                        image.Name = fileInfo.Name;
                        image.UserId = LoggedInUser.Id;
                        image.Height = pixelDatabase.Height;
                        image.Width = pixelDatabase.Width;
                        image.FolderId = SelectedFolder.Id;
                        image.CreatedDate = DateTime.Now;
                        image.FullPath = file.FullPath;
                        image.RelativePath = "../Upload/" + System.Web.HttpUtility.UrlPathEncode(fileInfo.Name);
                        
                        // perform the save
                        bool saved = await ImageService.SaveImage(ref image);

                        // if the value for saved is true
                        if (saved)
                        {
                            // Create a new instance of an 'ActivityLog' object.
                            ActivityLog activityLog = new ActivityLog();
                            activityLog.Activity = "Upload Image";
                            activityLog.CreatedDate = DateTime.Now;
                            activityLog.FolderId = SelectedFolder.Id;
                            activityLog.Detail = fileInfo.Name + " " +  image.FileSize;
                            activityLog.UserId = LoggedInUserId;

                            // perform the save
                            await ActivityLogService.SaveActivityLog(ref activityLog);

                            // set the storage used
                            LoggedInUser.StorageUsed += image.FileSize;
                            
                            // Save the logged in user
                            await UserService.SaveUser(ref loggedInUser);

                            // Load the imagess
                            SelectedFolder.Images = await ImageService.GetImageListForFolder(SelectedFolder.Id);

                            // need to sure in single files, this is true and in a batch, handle this being set to true for the last file.
                            if (file.LastFileInBatch)
                            {
                                // update the UI
                                Refresh();

                                // if the value for HasFileUpload is true
                                if (HasFileUpload)
                                {
                                    // Reset so the button shows again
                                    FileUpload.Reset();
                                }
                            }
                        }
                   }
                }
                else
                {
                    // for debugging only
                    if (file.HasException)
                    {
                        if (file.Exception.Message == "The file uploaded was too large.")
                        {
                            // for debugging only
                            ValidationMessage = "Uploaded files must be under 20 megs.";
                        }
                        else
                        {
                            // for debugging only
                            ValidationMessage = file.Exception.Message;
                        }
                    }
                }
            }
            #endregion

            #region OnReset()
            /// <summary>
            /// On Reset
            /// </summary>
            public void OnReset()
            {
                
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public async void ReceiveData(Message message)
            {
                if (message.Sender.Name == "NewFolderNameComponent")
                {
                    // if EscapePressed
                    if (message.Text == "EscapePressed")
                    {  
                        // no longer editing
                        AddFolderMode = false;

                        // Exit edit mode
                        Refresh();
                    }
                    else if (message.Text == "EnterPressed")
                    {
                        // if the LoggedInUser exists
                        if (HasLoggedInUser)
                        {
                            // Handle the save
                            Folder folder = new Folder();
                            folder.Name = NewFolderNameComponent.Text;
                            folder.Selected = true;
                            folder.CreatedDate = DateTime.Now;

                            // LoggedInUser.UserId
                            folder.UserId = LoggedInUser.Id;

                            // Perform the save
                            bool saved = await FolderService.SaveFolder(ref folder);

                            // if the value for saved is true
                            if (saved)
                            {  
                                // Set the SelectedFolder
                                SelectedFolder = folder;

                                if ((HasLoggedInUser) && (LoggedInUser.Id == SelectedFolder.UserId))
                                {
                                    // Unselect all other folders
                                    UnselectFolders(folder.Id);
                                }

                                // hide the textbox
                                AddFolderMode = false;

                                // Force a Reload
                                ForceReload = true;

                                // Update the UI
                                Refresh();
                            }
                        }
                    }
                }
                else if (message.Sender.Name == "ConfirmationComponent")
                {
                    if (message.Text == "YesClicked")
                    {
                        // If the value for FolderToDeleteId is greater than zero
                        if (FolderToDeleteId > 0)
                        {
                            // Find the folder
                            Folder folder = await FolderService.FindFolder(FolderToDeleteId);

                            // if the folder exists
                            if (NullHelper.Exists(folder))
                            {
                                // if the folder is selected
                                if (folder.Selected)
                                {
                                    // we need to find the home folder for this user
                                    SelectedFolder = FindHomeFolder();

                                    // if the SelectedFolder exists
                                    if (HasSelectedFolder)
                                    {
                                        // Load the images for the selected folder
                                        SelectedFolder.Images = await ImageService.GetImageListForFolder(SelectedFolder.Id);

                                        // Set the selected folder
                                        SelectedFolder.Selected = true;

                                        // perform the save
                                        bool saved = await FolderService.SaveFolder(ref selectedFolder);

                                        // if saved
                                        if (saved)
                                        {
                                            // perform the delete
                                            bool removed = await FolderService.RemoveFolder(folder);

                                            // if the value for removed is true
                                            if (removed)
                                            {
                                                // remove the images from the database and file system
                                                await ImageService.RemoveImagesForFolder(folder.Id);

                                                // Update the UI
                                                ForceReload = true;
                                                Refresh();
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // perform the delete
                                    bool removed = await FolderService.RemoveFolder(folder);

                                    // if the value for removed is true
                                    if (removed)
                                    {
                                        // Update the UI
                                        ForceReload = true;
                                        Refresh();
                                    }
                                }
                            }
                        }

                        // Hide
                        ShowConfirmation = false;

                        // Update the UI
                        Refresh();
                    }
                    else if (message.Text == "NoClicked")
                    {
                        // Erase
                        FolderToDeleteId = 0;

                        // Hide
                        ShowConfirmation = false;

                        // Update the UI
                        Refresh();
                    }                    
                }
                else if (message.Sender.Name == "RenameFolderTextBox")
                {
                    // if EscapePressed
                    if (message.Text == "EscapePressed")
                    {  
                        // no longer editing
                        if (NullHelper.Exists(FolderBeingRenamed))
                        {
                            // remove
                            RenameFolderMode = false;

                            // destroy
                            FolderBeingRenamed = null;

                            // Exit edit mode
                            Refresh();
                        }
                    }
                    else if (message.Text == "EnterPressed")
                    {
                        // no longer editing
                        if (HasFolderBeingRenamed)
                        {
                            // if the message has parameters
                            if (message.HasParameters)
                            {
                                // Set the new name
                                FolderBeingRenamed.Name = message.Parameters[0].Value.ToString();
                            }

                            // no longer being renamed
                            RenameFolderMode = false;

                            // if the folder being renamed is not the selected folder
                            if (SelectedFolder.Id != FolderBeingRenamed.Id)
                            {
                                // Unselect all other folders
                                UnselectFolders(FolderBeingRenamed.Id);
                            }

                            // Select this folder
                            FolderBeingRenamed.Selected = true;

                            // perform the save
                            bool saved = await FolderService.SaveFolder(ref folderBeingRenamed);

                            // if saved
                            if (saved)
                            {
                                // Update the SelectedFolder
                                SelectedFolder = FolderBeingRenamed;

                                // Reload the images
                                SelectedFolder.Images = await ImageService.GetImageListForFolder(SelectedFolder.Id);

                                // Reload
                                ForceReload = true;

                                // Exit edit mode
                                Refresh();
                            }
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
                // Update the UI
                InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            }
            #endregion
            
            #region Register(Sprite sprite)
            /// <summary>
            /// method returns the
            /// </summary>
            public void Register(Sprite sprite)
            {
                // Set the sprite
                Sprite = sprite;
            }
            #endregion
            
            #region Register(IBlazorComponent component)
            /// <summary>
            /// method Register
            /// </summary>
            public void Register(IBlazorComponent component)
            {
                // if the component is an Index page
                if (component is Pages.Index)
                {
                    // Set the IndexPage
                    IndexPage = component as Pages.Index;
                }
                else if (component is MainGalleryComponent)
                {
                    // Store
                    MainGalleryComponent = component as MainGalleryComponent;

                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(Connection.Name);

                    // Load the MainGalleryImages
                    MainGalleryImages = gateway.MainGalleryViews_LoadMostRecent();

                    // Set the images
                    MainGalleryComponent.Images = MainGalleryImages;

                    // Update the UI
                    MainGalleryComponent.Refresh();
                }
                else if (component is ValidationComponent)
                {
                    if (component.Name == "NewFolderNameComponent")
                    {
                        // set the NewFolderNameComponent
                        NewFolderNameComponent = component as ValidationComponent;

                        // Set Focus
                        NewFolderNameComponent.SetFocus();
                    }                    
                }
                else if (component is FileUpload)
                {
                    // store the file upload
                    FileUpload = component as FileUpload;
                }
                else if (component is ConfirmationComponent)
                {
                    // store the ConfirmationComponent
                    ConfirmationComponent = component as ConfirmationComponent;      
                    
                    // Start off hidden
                    ConfirmationComponent.SetVisible(false);
                }
                else if (component is Login)
                {
                    // Store the Login
                    LoginComponent = component as Login;

                    // if the EmailAddress component exists
                    if (HasLoginComponent)
                    {
                        // Prepopulate the EmailAddress for the user
                        LoginComponent.EmailAddress = NewUserEmailAddress;
                    }
                }
                else if (component is Join)
                {
                    
                }                
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
                    DebugHelper.WriteDebugError("RemoveLocalStoreItems", "MainLayout.cs", error);
                }

                // return value
                return removed;
            }
            #endregion

            #region RenameFolder(Folder folder)
            /// <summary>
            /// Rename a Folder
            /// </summary>
            public void RenameFolder(Folder folder)
            {
                // If the folder object exists
                if (NullHelper.Exists(folder))
                {
                    // Set to true
                    RenameFolderMode = true;
                    
                    // Set the FolderBeingRenamed
                    FolderBeingRenamed = folder;

                    // This is needed to set focus to the component when it rerenders
                    ForceReload = true;

                    // Update
                    Refresh();
                }
            }
            #endregion
            
            #region RestoreScreenType()
            /// <summary>
            /// Restore Screen Type
            /// </summary>
            public void RestoreScreenType()
            {
                // Setup the screen
                SetupScreen(PreviousScreenType, "", false);
            }
            #endregion
            
            #region SelectNextImage()
            /// <summary>
            /// Select Next Image
            /// </summary>
            public void SelectNextImage()
            {
                // local
                bool nextImage = false;

                // if the value for HasSelectedImage is true
                if (HasSelectedImage)
                {
                    if (ScreenType == ScreenTypeEnum.ViewImageInMainGallery)
                    {
                        // if the value for HasMainGalleryImages is true
                        if (HasMainGalleryImages)
                        {
                            // Iterate the collection of Image objects
                            foreach (MainGalleryView image in MainGalleryImages)
                            {
                                // if this is our image
                                if (image.ImageId == SelectedImage.Id)
                                {
                                    // set to true
                                    nextImage = true;
                                }
                                else if (nextImage)
                                {
                                    // Set the selected image
                                    SelectedImage = image.Image;

                                    // required
                                    break;
                                }
                            }

                            // Update the UI
                            Refresh();
                        }
                    }
                    else if (ScreenType == ScreenTypeEnum.ViewImage)
                    {
                        // if the SelectedFolder.Images and the SelectedImage exists
                        if ((HasSelectedFolder) && (SelectedFolder.HasImages))
                        {
                            // Iterate the collection of Image objects
                            foreach (Image image in SelectedFolder.Images)
                            {
                                // if this is our image
                                if (image.Id == SelectedImage.Id)
                                {
                                    // set to true
                                    nextImage = true;
                                }
                                else if (nextImage)
                                {
                                    // Set the selected image
                                    SelectedImage = image;

                                    // required
                                    break;                            
                                }
                            }
                        }

                        // Update the UI
                        Refresh();
                    }
                }
            }
            #endregion
            
            #region SelectPreviousImage()
            /// <summary>
            /// Select Previous Image
            /// </summary>
            public void SelectPreviousImage()
            {
                // local
               Image previousImage = null;

               // if the value for HasSelectedImage is true
               if (HasSelectedImage)
               {
                    // if the value for HasMainGalleryImages is true
                    if (HasMainGalleryImages)
                    {
                         // Iterate the collection of Image objects
                        foreach (MainGalleryView image in MainGalleryImages)
                        {
                            // if this is our image
                            if (image.ImageId == SelectedImage.Id)
                            {
                                // Set the selected image
                                SelectedImage = previousImage;

                                // exit
                                break;
                            }

                            // Set the previous
                            previousImage = image.Image;
                        }

                        // Update the UI
                        Refresh();
                    }
                    // if the SelectedFolder.Images and the SelectedImage exists
                    else if ((HasSelectedFolder) && (SelectedFolder.HasImages))
                    {
                        // Iterate the collection of Image objects
                        foreach (Image image in SelectedFolder.Images)
                        {
                            // if this is our image
                            if (image.Id == SelectedImage.Id)
                            {
                                // Set the selected image
                                SelectedImage = previousImage;

                                // exit
                                break;
                            }

                            // Set the previous
                            previousImage = image;
                        }

                        // Update the UI
                        Refresh();
                    }
                }
            }
            #endregion
            
            #region SetupScreen(ScreenTypeEnum screenType, string emailAddress = "", bool storePrevious = true)
            /// <summary>
            /// This method Setup Screen
            /// </summary>
            public void SetupScreen(ScreenTypeEnum screenType, string emailAddress = "", bool storePrevious = true)
            {
                // if storePrevious is true
                if (storePrevious)
                {
                    // Store this, so in case of a cancel, this can be put back to where the user was.
                    // Example clicking Feedback, then cancelling should go back to where the user was.
                    PreviousScreenType = screenType;
                }

                // set the ScreenType
                ScreenType = screenType;

                if (ScreenType == ScreenTypeEnum.Login)
                {
                    // If the emailAddress string exists
                    if (TextHelper.Exists(emailAddress))
                    {
                        // Store this so when the Login component is registered, the Email Address can be set
                        NewUserEmailAddress = emailAddress;
                    }
                }
                else if (ScreenType == ScreenTypeEnum.Index)
                {
                    // if the parent exists
                    if (HasLoggedInUser)
                    {
                        // Force a reload
                        ForceReload = true;

                        // Refresh
                        Refresh();
                    }
                }
                else if (ScreenType == ScreenTypeEnum.ViewingGallery)
                {
                    if (HasGalleryOwner)
                    {
                        // Force a reload
                        ForceReload = true;

                        // Refresh
                        Refresh();
                    }
                }
                else if (screenType == ScreenTypeEnum.TermsOfservice)
                {
                    // Force a reload
                    ForceReload = true;

                    // Refresh
                    Refresh();
                }
                else if (screenType == ScreenTypeEnum.SetProfileVisibility)
                {
                    // Force a reload
                    ForceReload = true;

                    // Refresh
                    Refresh();
                }
                else if (screenType == ScreenTypeEnum.ViewImage)
                {
                    // Force a reload
                    // ForceReload = true;

                    // Refresh
                    Refresh();
                }
                else if (screenType == ScreenTypeEnum.ViewImageInMainGallery)
                {
                    // Force a reload
                    ForceReload = true;

                    // Refresh
                    Refresh();
                }
                else if (screenType == ScreenTypeEnum.EmailVerification)
                {
                    // Refresh
                    Refresh();
                }
                else if (screenType == ScreenTypeEnum.MainScreen)
                {
                    // if the value for HasMainGalleryComponent is true
                    if (HasMainGalleryComponent)
                    {
                        // Create a new instance of a 'Gateway' object.
                        Gateway gateway = new Gateway(Connection.Name);

                        // Load the MainGalleryImages
                        MainGalleryImages = gateway.MainGalleryViews_LoadMostRecent();

                        // Set the images
                        MainGalleryComponent.Images = MainGalleryImages;

                        // Update the UI
                        // MainGalleryComponent.Refresh();

                        // Force a reload
                        ForceReload = true;

                        // Refresh
                        Refresh();
                    }
                    else if (ScreenType == ScreenTypeEnum.ChangePasswordMode)
                    {
                        // Refresh
                        Refresh();
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
                // Erase all objects
                LoggedInUser = null;
                GalleryOwner = null;
                SelectedFolder = null;

                // Remove the items the user has stored in the local browser storage
                await RemovedLocalStoreItems();

                // Setup the Screen for the main screen
                SetupScreen(ScreenTypeEnum.MainScreen);

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
                    DebugHelper.WriteDebugError("StoreLocalStoreItems", "MainLayout.razor.cs", error);
                }

                // return value
                return saved;
            }
            #endregion
            
            #region UnselectFolders(int selectedFolderId)
            /// <summary>
            /// Unselect Folders
            /// </summary>
            public async void UnselectFolders(int selectedFolderId)
            {
                if (ListHelper.HasOneOrMoreItems(Folders))
                {
                    // Iterate the collection of Folder objects
                    foreach (Folder tempFolder in Folders)
                    {
                        // if the FolderId is not the new folder
                        if (tempFolder.Id != selectedFolderId)
                        {
                            // no longer selected
                            tempFolder.Selected = false;

                            // if the LoggedInUser is the ower of the folder and not in ViewOnlyMode
                            if ((HasLoggedInUser) && (!LoggedInUser.ViewOnlyMode) && (SelectedFolder.UserId == LoggedInUser.Id))
                            {
                                // clone this object
                                Folder clone = tempFolder.Clone();

                                // save this folder
                                await FolderService.SaveFolder(ref clone);
                            }
                        }
                    }
                }
            }
            #endregion

            #region WindowResized(object _, BrowserWindowSize window)
            /// <summary>
            /// event is fired when Window Resized
            /// </summary>
            private async void WindowResized(object _, BrowserWindowSize window)
            {
                // Get the browsers's width / height
                Browser = window;
                
                // Check a media query to see if it was matched. We can do this at any time, but it's best to check on each resize
                IsSmallMedia = await Listener.MatchMedia(Breakpoints.SmallDown);

                // set the screensize properties
                ScreenWidth = Browser.Width;
                ScreenHeight = Browser.Height;
                
                // We're outside of the component's lifecycle, be sure to let it know it has to re-render.
                StateHasChanged();
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region AddButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'AddButtonStyle'.
            /// </summary>
            public string AddButtonStyle
            {
                get { return addButtonStyle; }
                set { addButtonStyle = value; }
            }
            #endregion
            
            #region AddButtonTop
            /// <summary>
            /// This property gets or sets the value for 'AddButtonTop'.
            /// </summary>
            public double AddButtonTop
            {
                get { return addButtonTop; }
                set { addButtonTop = value; }
            }
            #endregion
            
            #region AddButtonTopStyle
            /// <summary>
            /// This read only property returns the value of AddButtonTopStyle from the object AddButtonTop.
            /// </summary>
            public string AddButtonTopStyle
            {
                
                get
                {
                    // initial value
                    string addButtonTopStyle = AddButtonTop + "vh";
                    
                    // return value
                    return addButtonTopStyle;
                }
            }
            #endregion
            
            #region AddFolderMode
            /// <summary>
            /// This property gets or sets the value for 'AddFolderMode'.
            /// </summary>
            public bool AddFolderMode
            {
                get { return addFolderMode; }
                set { addFolderMode = value; }
            }
            #endregion
          
            #region Admin
            /// <summary>
            /// This property gets or sets the value for 'Admin'.
            /// </summary>
            public Admin Admin
            {
                get { return admin; }
                set { admin = value; }
            }
            #endregion
            
            #region BlueButton
            /// <summary>
            /// This property gets or sets the value for 'BlueButton'.
            /// </summary>
            public string BlueButton
            {
                get { return blueButton; }
                set { blueButton = value; }
            }
            #endregion
            
            #region Browser
            /// <summary>
            /// This property gets or sets the value for 'Browser'.
            /// </summary>
            public BrowserWindowSize Browser
            {
                get { return browser; }
                set { browser = value; }
            }
            #endregion

            #region ButtonHeight
            /// <summary>
            /// This read only property returns the value of ButtonHeight
            /// </summary>
            public double ButtonHeight
            {
                
                get
                {
                    // initial value
                    double buttonHeight = 3.7; // typical

                    if (ScreenHeight > 0)
                    {
                        // two digits is all that is needed
                        buttonHeight = Math.Round(100 / ScreenHeight * 40, 2);

                        // if the buttonheight is small = 1.0 zoom to 1.25 zoom for desktops, the only thing that matters (to me).
                        if (buttonHeight < 6.19)
                        {
                            // minimum size until about 1.5 zoom
                            buttonHeight = 6.19;
                        }
                    }

                    // return value
                    return buttonHeight;
                }
            }
            #endregion

            #region ButtonHeightStyle
            /// <summary>
            /// This read only property returns the value of ButtonHeight + "vh"
            /// </summary>
            public string ButtonHeightStyle
            {
                
                get
                {
                    // initial value
                    string buttonHeightStyle = ButtonHeight + "vh";
                    
                    // return value
                    return buttonHeightStyle;
                }
            }
            #endregion

            #region ButtonWidth
            /// <summary>
            /// This read only property returns the value of ButtonWidth
            /// </summary>
            public double ButtonWidth
            {
                
                get
                {
                    // initial value
                    double buttonWidth = 9.375;
                    
                    // if the ScreenWidth has been set
                    if (ScreenWidth > 0)
                    {
                        // set the value now that ScreenWidth is set - two digits is all that is needed
                        buttonWidth = Math.Round((100 / ScreenWidth * 120), 2);

                        // keep the button the same size until > 1.5 zoom
                        if (buttonWidth < 9.375)
                        {
                            // keep the button the same size until > 1.5 zoom
                            buttonWidth = 9.375;
                        }
                    }
                    
                    // return value
                    return buttonWidth;
                }
            }
            #endregion

            #region ButtonWidthStyle
            /// <summary>
            /// This read only property returns the ButtonWidth + "vw";
            /// </summary>
            public string ButtonWidthStyle
            {
                
                get
                {
                    // initial value
                    string loginButtonWidthStyle = ButtonWidth + "vw";
                    
                    // return value
                    return loginButtonWidthStyle;
                }
            }
            #endregion
            
            #region CancelButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'CancelButtonStyle'.
            /// </summary>
            public string CancelButtonStyle
            {
                get { return cancelButtonStyle; }
                set { cancelButtonStyle = value; }
            }
            #endregion
            
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

                    // if viewing an image in the main gallery
                    if ((ScreenType == ScreenTypeEnum.ViewImageInMainGallery) && (HasSelectedImage))
                    {
                        // if the value for HasMainGalleryImages is true
                        if (HasMainGalleryImages)
                        {
                            // This images are in the reverse order

                            // Set the return value to true if the SelectedImage.Id is less than the Id of the last image in the MainGallery
                            canMoveNext = (SelectedImage.Id > MainGalleryImages.Last().ImageId);
                        }
                    }
                    // if has selected folder
                    else if ((HasSelectedFolder) && (HasSelectedImage) && (SelectedFolder.HasImages))
                    {
                        // Set the return value to true if the SelectedImage.Id is less than the Id of the last image in the folder
                        canMoveNext = (SelectedImage.Id <  SelectedFolder.Images.Last().Id);
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

                    // if viewing an image in the main gallery
                    if ((ScreenType == ScreenTypeEnum.ViewImageInMainGallery) && (HasSelectedImage))
                    {
                        // if the value for HasMainGalleryImages is true
                        if (HasMainGalleryImages)
                        {
                            // Set the return value to true if the SelectedImage.Id is less than the Id of the last image in the MainGallery
                            canMovePrevious = (SelectedImage.Id < MainGalleryImages.First().ImageId);
                        }
                    }

                    // if has selected folder
                    if ((HasSelectedFolder) && (HasSelectedImage) && (SelectedFolder.HasImages))
                    {
                        // Set the return value to true if the SelectedImage.Id is less than the Id of the last image in the folder
                        canMovePrevious = (SelectedImage.Id > SelectedFolder.Images.First().Id);
                    }
                    
                    // return value
                    return canMovePrevious;
                }
            }
            #endregion
            
            #region CheckBoxStyle
            /// <summary>
            /// This property gets or sets the value for 'CheckMarkStyle'.
            /// </summary>
            public string CheckMarkStyle
            {
                get { return checkMarkStyle; }
                set { checkMarkStyle = value; }
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
            
            #region ConfirmationComponent
            /// <summary>
            /// This property gets or sets the value for 'ConfirmationComponent'.
            /// </summary>
            public ConfirmationComponent ConfirmationComponent
            {
                get { return confirmationComponent; }
                set { confirmationComponent = value; }
            }
            #endregion
            
            #region FileUpload
            /// <summary>
            /// This property gets or sets the value for 'FileUpload'.
            /// </summary>
            public FileUpload FileUpload
            {
                get { return fileUpload; }
                set { fileUpload = value; }
            }
            #endregion
            
            #region FolderBeingRenamed
            /// <summary>
            /// This property gets or sets the value for 'FolderBeingRenamed'.
            /// </summary>
            public Folder FolderBeingRenamed
            {
                get { return folderBeingRenamed; }
                set { folderBeingRenamed = value; }
            }
            #endregion
            
            #region FolderBeingRenamedId
            /// <summary>
            /// This read only property returns the value of FolderBeingRenamedId from the object FolderBeingRenamed.
            /// </summary>
            public int FolderBeingRenamedId
            {
                
                get
                {
                    // initial value
                    int folderBeingRenamedId = 0;
                    
                    // if the value for HasFolderBeingRenamed is true
                    if (HasFolderBeingRenamed)
                    {
                        // set the return value
                        folderBeingRenamedId = FolderBeingRenamed.Id;
                    }
                    
                    // return value
                    return folderBeingRenamedId;
                }
            }
            #endregion
            
            #region Folders
            /// <summary>
            /// This property gets or sets the value for 'Folders'.
            /// </summary>
            public List<Folder> Folders
            {
                get { return folders; }
                set { folders = value; }
            }
            #endregion
            
            #region FolderToDeleteId
            /// <summary>
            /// This property gets or sets the value for 'FolderToDeleteId'.
            /// </summary>
            public int FolderToDeleteId
            {
                get { return folderToDeleteId; }
                set { folderToDeleteId = value; }
            }
            #endregion
            
            #region ForceReload
            /// <summary>
            /// This property gets or sets the value for 'ForceReload'.
            /// </summary>
            public bool ForceReload
            {
                get { return forceReload; }
                set { forceReload = value; }
            }
            #endregion
            
            #region GalleryOwner
            /// <summary>
            /// This property gets or sets the value for 'GalleryOwner'.
            /// </summary>
            public User GalleryOwner
            {
                get { return galleryOwner; }
                set { galleryOwner = value; }
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
            
            #region HasAdmin
            /// <summary>
            /// This property returns true if this object has an 'Admin'.
            /// </summary>
            public bool HasAdmin
            {
                get
                {
                    // initial value
                    bool hasAdmin = (this.Admin != null);
                    
                    // return value
                    return hasAdmin;
                }
            }
            #endregion
            
            #region HasConfirmationComponent
            /// <summary>
            /// This property returns true if this object has a 'ConfirmationComponent'.
            /// </summary>
            public bool HasConfirmationComponent
            {
                get
                {
                    // initial value
                    bool hasConfirmationComponent = (this.ConfirmationComponent != null);
                    
                    // return value
                    return hasConfirmationComponent;
                }
            }
            #endregion
            
            #region HasFileUpload
            /// <summary>
            /// This property returns true if this object has a 'FileUpload'.
            /// </summary>
            public bool HasFileUpload
            {
                get
                {
                    // initial value
                    bool hasFileUpload = (this.FileUpload != null);
                    
                    // return value
                    return hasFileUpload;
                }
            }
            #endregion
            
            #region HasFolderBeingRenamed
            /// <summary>
            /// This property returns true if this object has a 'FolderBeingRenamed'.
            /// </summary>
            public bool HasFolderBeingRenamed
            {
                get
                {
                    // initial value
                    bool hasFolderBeingRenamed = (this.FolderBeingRenamed != null);
                    
                    // return value
                    return hasFolderBeingRenamed;
                }
            }
            #endregion
            
            #region HasFolders
            /// <summary>
            /// This property returns true if this object has a 'Folders'.
            /// </summary>
            public bool HasFolders
            {
                get
                {
                    // initial value
                    bool hasFolders = (this.Folders != null);
                    
                    // return value
                    return hasFolders;
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
            
            #region HasIndexPage
            /// <summary>
            /// This property returns true if this object has an 'IndexPage'.
            /// </summary>
            public bool HasIndexPage
            {
                get
                {
                    // initial value
                    bool hasIndexPage = (this.IndexPage != null);
                    
                    // return value
                    return hasIndexPage;
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
            
            #region HasMainGalleryComponent
            /// <summary>
            /// This property returns true if this object has a 'MainGalleryComponent'.
            /// </summary>
            public bool HasMainGalleryComponent
            {
                get
                {
                    // initial value
                    bool hasMainGalleryComponent = (this.MainGalleryComponent != null);
                    
                    // return value
                    return hasMainGalleryComponent;
                }
            }
            #endregion
            
            #region HasMainGalleryImages
            /// <summary>
            /// This property returns true if this object has a 'MainGalleryImages'.
            /// </summary>
            public bool HasMainGalleryImages
            {
                get
                {
                    // initial value
                    bool hasMainGalleryImages = (this.MainGalleryImages != null);
                    
                    // return value
                    return hasMainGalleryImages;
                }
            }
            #endregion
            
            #region HasNewFolderNameComponent
            /// <summary>
            /// This property returns true if this object has a 'NewFolderNameComponent'.
            /// </summary>
            public bool HasNewFolderNameComponent
            {
                get
                {
                    // initial value
                    bool hasNewFolderNameComponent = (this.NewFolderNameComponent != null);
                    
                    // return value
                    return hasNewFolderNameComponent;
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
            
            #region HasSelectedImage
            /// <summary>
            /// This property returns true if this object has a 'SelectedImage'.
            /// </summary>
            public bool HasSelectedImage
            {
                get
                {
                    // initial value
                    bool hasSelectedImage = (this.SelectedImage != null);
                    
                    // return value
                    return hasSelectedImage;
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
            
            #region HasValidationMessage
            /// <summary>
            /// This property returns true if the 'ValidationMessage' exists.
            /// </summary>
            public bool HasValidationMessage
            {
                get
                {
                    // initial value
                    bool hasValidationMessage = (!String.IsNullOrEmpty(this.ValidationMessage));
                    
                    // return value
                    return hasValidationMessage;
                }
            }
            #endregion

            #region IndexPage
            /// <summary>
            /// This property gets or sets the value for 'IndexPage'.
            /// </summary>
            public Pages.Index IndexPage
            {
                get { return indexPage; }
                set { indexPage = value; }
            }
            #endregion
            
            #region Initialized
            /// <summary>
            /// This property gets or sets the value for 'Initialized'.
            /// </summary>
            public bool Initialized
            {
                get { return initialized; }
                set { initialized = value; }
            }
            #endregion

            #region IsSmallMedia
            /// <summary>
            /// This property gets or sets the value for 'IsSmallMedia'.
            /// </summary>
            public bool IsSmallMedia
            {
                get { return isSmallMedia; }
                set { isSmallMedia = value; }
            }
            #endregion
            
            #region JoinButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'JoinButtonStyle'.
            /// </summary>
            public string JoinButtonStyle
            {
                get { return joinButtonStyle; }
                set { joinButtonStyle = value; }
            }
            #endregion
            
            #region Listener
            [Inject]
            IResizeListener Listener { get; set; }
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
            
            #region LoginButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'LoginButtonStyle'.
            /// </summary>
            public string LoginButtonStyle
            {
                get { return loginButtonStyle; }
                set { loginButtonStyle = value; }
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
            
            #region MainGalleryComponent
            /// <summary>
            /// This property gets or sets the value for 'MainGalleryComponent'.
            /// </summary>
            public MainGalleryComponent MainGalleryComponent
            {
                get { return mainGalleryComponent; }
                set { mainGalleryComponent = value; }
            }
            #endregion
            
            #region MainGalleryImages
            /// <summary>
            /// This property gets or sets the value for 'MainGalleryImages'.
            /// </summary>
            public List<MainGalleryView> MainGalleryImages
            {
                get { return mainGalleryImages; }
                set { mainGalleryImages = value; }
            }
            #endregion
            
            #region NewFolderNameComponent
            /// <summary>
            /// This property gets or sets the value for 'NewFolderNameComponent'.
            /// </summary>
            public ValidationComponent NewFolderNameComponent
            {
                get { return newFolderNameComponent; }
                set { newFolderNameComponent = value; }
            }
            #endregion
            
            #region NewFolderStyle
            /// <summary>
            /// This property gets or sets the value for 'NewFolderStyle'.
            /// </summary>
            public string NewFolderStyle
            {
                get { return newFolderStyle; }
                set { newFolderStyle = value; }
            }
            #endregion
            
            #region NewFolderTop
            /// <summary>
            /// This read only property returns the value of NewFolderTop from the object AddButtonTop.
            /// </summary>
            public double NewFolderTop
            {
                
                get
                {
                    // initial value
                    double newFolderTop = Top - (FolderHeight * 1.5);
                    
                    // return value
                    return newFolderTop;
                }
            }
            #endregion
            
            #region NewFolderTopStyle
            /// <summary>
            /// This read only property returns the value of NewFolderTopStyle from the object NewFolderTop.
            /// </summary>
            public string NewFolderTopStyle
            {
                
                get
                {
                    // initial value
                    string newFolderTopStyle = NewFolderTop + "vh";
                    
                    // return value
                    return newFolderTopStyle;
                }
            }
            #endregion
            
            #region NewUserEmailAddress
            /// <summary>
            /// This property gets or sets the value for 'NewUserEmailAddress'.
            /// </summary>
            public string NewUserEmailAddress
            {
                get { return newUserEmailAddress; }
                set { newUserEmailAddress = value; }
            }
            #endregion
            
            #region NoButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'NoButtonStyle'.
            /// </summary>
            public string NoButtonStyle
            {
                get { return noButtonStyle; }
                set { noButtonStyle = value; }
            }
            #endregion
            
            #region PreviousScreenType
            /// <summary>
            /// This property gets or sets the value for 'PreviousScreenType'.
            /// </summary>
            public ScreenTypeEnum PreviousScreenType
            {
                get { return previousScreenType; }
                set { previousScreenType = value; }
            }
            #endregion
            
            #region RenameFolderMode
            /// <summary>
            /// This property gets or sets the value for 'RenameFolderMode'.
            /// </summary>
            public bool RenameFolderMode
            {
                get { return renameFolderMode; }
                set { renameFolderMode = value; }
            }
            #endregion
            
            #region SaveButtonDisabledStyle
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonDisabledStyle'.
            /// </summary>
            public string SaveButtonDisabledStyle
            {
                get { return saveButtonDisabledStyle; }
                set { saveButtonDisabledStyle = value; }
            }
            #endregion
            
            #region SaveButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'SaveButtonStyle'.
            /// </summary>
            public string SaveButtonStyle
            {
                get { return saveButtonStyle; }
                set { saveButtonStyle = value; }
            }
            #endregion
                        
            #region ScreenHeight
            /// <summary>
            /// This property gets or sets the value for 'ScreenHeight'.
            /// </summary>
            public double ScreenHeight
            {
                get { return screenHeight; }
                set { screenHeight = value; }
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
            
            #region ScreenWidth
            /// <summary>
            /// This property gets or sets the value for 'ScreenWidth'.
            /// </summary>
            public double ScreenWidth
            {
                get { return screenWidth; }
                set { screenWidth = value; }
            }
            #endregion
            
            #region SelectedFolder
            /// <summary>
            /// This property gets or sets the value for 'SelectedFolder'.
            /// </summary>
            public Folder SelectedFolder
            {
                get { return selectedFolder; }
                set { selectedFolder = value; }
            }
            #endregion
                        
            #region SelectedImage
            /// <summary>
            /// This property gets or sets the value for 'SelectedImage'.
            /// </summary>
            public Image SelectedImage
            {
                get { return selectedImage; }
                set { selectedImage = value; }
            }
            #endregion
            
            #region SendButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'SendButtonStyle'.
            /// </summary>
            public string SendButtonStyle
            {
                get { return sendButtonStyle; }
                set { sendButtonStyle = value; }
            }
            #endregion
            
            #region ShowConfirmation
            /// <summary>
            /// This property gets or sets the value for 'ShowConfirmation'.
            /// </summary>
            public bool ShowConfirmation
            {
                get { return showConfirmation; }
                set { showConfirmation = value; }
            }
            #endregion
            
            #region SignOutButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'SignOutButtonStyle'.
            /// </summary>
            public string SignOutButtonStyle
            {
                get { return signOutButtonStyle; }
                set { signOutButtonStyle = value; }
            }
            #endregion
            
            #region SmallButtonWidth
            /// <summary>
            /// This read only property returns the value of SmallButtonWidth from the ButtonWidth * .6837
            /// </summary>
            public double SmallButtonWidth
            {
                
                get
                {
                    // initial value
                    double smallButtonWidth = (Math.Round(ButtonWidth * .6837 * 2, 2));

                    // return value
                    return smallButtonWidth;
                }
            }
            #endregion
            
            #region SmallButtonWidthStyle
            /// <summary>
            /// This read only property returns the value of SmallButtonWidth + "vh"
            /// </summary>
            public string SmallButtonWidthStyle
            {
                
                get
                {
                    // initial value
                    string smallButtonWidthStyle = SmallButtonWidth + "vh";
                    
                    // return value
                    return smallButtonWidthStyle;
                }
            }
            #endregion
            
            #region Sprite
            /// <summary>
            /// This property gets or sets the value for 'Sprite'.
            /// </summary>
            public Sprite Sprite
            {
                get { return sprite; }
                set { sprite = value; }
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
            
            #region Top
            /// <summary>
            /// This property gets or sets the value for 'Top'.
            /// </summary>
            public double Top
            {
                get { return top; }
                set { top = value; }
            }
            #endregion
            
            #region TopStyle
            /// <summary>
            /// This read only property returns the Top + px. Example 16px;
            /// </summary>
            public string TopStyle
            {
                
                get
                {
                    // initial value
                    string topStyle = Top + "vh";
                    
                    // return value
                    return topStyle;
                }
            }
            #endregion
            
            #region UserUrl
            /// <summary>
            /// This property gets or sets the value for 'UserUrl'.
            /// </summary>
            public string UserUrl
            {
                get { return userUrl; }
                set { userUrl = value; }
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
            
            #region VerifyButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'VerifyButtonStyle'.
            /// </summary>
            public string VerifyButtonStyle
            {
                get { return verifyButtonStyle; }
                set { verifyButtonStyle = value; }
            }
            #endregion
            
            #region YesButtonStyle
            /// <summary>
            /// This property gets or sets the value for 'YesButtonStyle'.
            /// </summary>
            public string YesButtonStyle
            {
                get { return yesButtonStyle; }
                set { yesButtonStyle = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
