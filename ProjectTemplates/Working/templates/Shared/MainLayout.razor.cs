﻿

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using ObjectLibrary.BusinessObjects;
using DataGateway.Services;
using DataGateway;
using ApplicationLogicComponent.Connection;
using DataJuggler.Blazor.FileUpload;
using DataJuggler.UltimateHelper;
using OfficeOpenXml.Style;
using System.Runtime.Versioning;
using System.Linq;
using DataJuggler.BlazorGallery.Components;
using DataJuggler.PixelDatabase;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using DataJuggler.Cryptography;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ObjectLibrary.Enumerations;
using DataJuggler.BlazorGallery.Pages;

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
        private bool addFolderMode;
        private FileUpload fileUpload;
        private ValidationComponent newFolderNameComponent;
        private int top;
        private bool forceReload;
        private string resetButton;
        private Admin admin;
        private ConfirmationComponent confirmationComponent;
        private bool showConfirmation;
        private int folderToDeleteId; 
        private ScreenTypeEnum screenType;
        private Gallery gallery;
        private Sprite sprite;
        private Login loginComponent;
        private const int AdminId = 1;
        public const int FolderHeight = 48;
        public const int UploadLimit = 20480000;
        public const string FileTooLargeMessage = "The file must be 20 megs or less.";      
        public const int FolderTop = 140;
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

                // Set the Top
                Top = FolderTop + ((Folders.Count + 1) * FolderHeight);
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
                    // Set Selectd to true
                    SelectedFolder.Selected = true;

                    // if saved
                    bool saved = await FolderService.SaveFolder(ref selectedFolder);

                    // if saved
                    if (saved)
                    {
                        // Unselect all other folders
                        UnselectFolders(folderId);

                        // Force Reload
                        ForceReload = true;

                        // Redisplay
                        Refresh();
                    }
                }
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

                // Update
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

                // Update the UI
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
                        DebugHelper.WriteDebugError("OnAfterRenderAsync", "MainLayout.razor.cs", error);
                    }
                }

                // if firstRender
                if ((firstRender) || (ForceReload))
                {
                    // if the value for HasAdmin is false
                    if (!HasAdmin)
                    {
                        // Load the Admin  
                        Admin = await AdminService.FindAdmin(AdminId);
                    }

                    // if the value for HasLoggedInUser is true
                    if (HasLoggedInUser)
                    {
                       // get the folders
                       Folders = await FolderService.GetFolderListForUserId(LoggedInUser.Id);
                    }

                   // If the Folders collection exists and has one or more items
                   if (ListHelper.HasOneOrMoreItems(Folders))
                   {
                        // Iterate the collection of Folder objects
                        foreach (Folder folder in Folders)
                        {
                            // If the value for the property folder.Selected is true
                            if (folder.Selected)
                            {
                                // Set the SelectedFolder
                                SelectedFolder = folder;

                                // Load the image
                                SelectedFolder.Images = await ImageService.GetImageListForFolder(SelectedFolder.Id);

                                // break out of the loop
                                break;
                            }
                        }

                        // Set the Top
                        Top = FolderTop + (Folders.Count * FolderHeight);
                   }
                }

                // call base method
                await base.OnAfterRenderAsync(firstRender);

                // if firstRender
                if ((firstRender) || (ForceReload))
                {
                    // only force reload once
                    ForceReload = false;

                    // Update the UI
                    Refresh();
                }
            }
            #endregion

            #region OnFileUploaded(UploadedFileInfo file)
            /// <summary>
            /// This method On File Uploaded
            /// </summary>
            public async void OnFileUploaded(UploadedFileInfo file)
            {
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
                            // Load the imagess
                            SelectedFolder.Images = await ImageService.GetImageListForFolder(SelectedFolder.Id);

                            // update the UI
                            Refresh();
                        }
                   }

                    // if the value for HasFileUpload is true
                    if (HasFileUpload)
                    {
                        // Reset so the button shows again
                        FileUpload.Reset();
                    }
                }
                else
                {
                    // for debugging only
                    if (file.HasException)
                    {
                        // for debugging only
                        string message = file.Exception.Message;
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

                                // Unselect all other folders
                                UnselectFolders(folder.Id);

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
                else if (component is ValidationComponent)
                {
                    // set the NewFolderNameComponent
                    NewFolderNameComponent = component as ValidationComponent;

                    // Set Focus
                    NewFolderNameComponent.SetFocus();
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
                }
                else if (component is Join)
                {
                }
                else if (component is Gallery)
                {
                    // Set the value
                    Gallery = component as Gallery;

                    // if the value for HasGallery is true
                    if (HasGallery)
                    {
                        // Set to Gallery
                        ScreenType = ScreenTypeEnum.Gallery;

                        // Update the UI
                        Refresh();
                    }
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
                    if (HasLoggedInUser)
                    {
                        // Force a reload
                        ForceReload = true;

                        // Refresh
                        Refresh();
                    }
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
                // Iterate the collection of Folder objects
                foreach (Folder tempFolder in Folders)
                {
                    // if the FolderId is not the new folder
                    if (tempFolder.Id != selectedFolderId)
                    {
                        // no longer selected
                        tempFolder.Selected = false;

                        // clone this object
                        Folder clone = tempFolder.Clone();

                        // save this folder
                        bool saved = await FolderService.SaveFolder(ref clone);
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
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
            
            #region Gallery
            /// <summary>
            /// This property gets or sets the value for 'Gallery'.
            /// </summary>
            public Gallery Gallery
            {
                get { return gallery; }
                set { gallery = value; }
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
            
            #region HasGallery
            /// <summary>
            /// This property returns true if this object has a 'Gallery'.
            /// </summary>
            public bool HasGallery
            {
                get
                {
                    // initial value
                    bool hasGallery = (this.Gallery != null);
                    
                    // return value
                    return hasGallery;
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
            
            #region ResetButton
            /// <summary>
            /// This property gets or sets the value for 'ResetButton'.
            /// </summary>
            public string ResetButton
            {
                get { return resetButton; }
                set { resetButton = value; }
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
            
            #region Top
            /// <summary>
            /// This property gets or sets the value for 'Top'.
            /// </summary>
            public int Top
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
                    string topStyle = Top + "px";
                    
                    // return value
                    return topStyle;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
