

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

#endregion

namespace DataJuggler.BlazorGallery.Shared
{

    #region class MainLayout
    /// <summary>
    /// This class is the main layout of this application.
    /// </summary>
    public partial class MainLayout : IBlazorComponentParent
    {
        
        #region Private Variables
        private List<IBlazorComponent> children;
        private string blueButton;
        private Pages.Index indexPage;
        private List<Folder> folders;
        private Folder selectedFolder;
        private bool addFolderMode;
        private ValidationComponent newFolderNameComponent;
        private int top;
        private bool forceReload;
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
                    // If the value for the property folder.Selected is true
                    if (folder.Selected)
                    {
                        // Unselect all others
                        UnselectFolders(folderId);
                    }

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
            
            #region OnAfterRenderAsync(bool firstRender)
            /// <summary>
            /// This method is used to verify a user
            /// </summary>
            /// <param name="firstRender"></param>
            /// <returns></returns>
            protected async override Task OnAfterRenderAsync(bool firstRender)
            {
                // if firstRender
                if ((firstRender) || (ForceReload))
                {
                   // get the folders
                   Folders = await FolderService.GetFolderList();

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
                    // only force reload oncea
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
            public void OnFileUploaded(UploadedFileInfo file)
            {
                // if the file was uploaded
                if (!file.Aborted)
                {
                   // To Do: Save the uploaded file
                   string fileName = file.Name;

                   // auto reset
                   OnReset();                   
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
                        // Handle the save
                        Folder folder = new Folder();
                        folder.Name = NewFolderNameComponent.Text;
                        folder.Selected = true;
                        folder.CreatedDate = DateTime.Now;

                        // to do: Change to LoggedInUser.UserId
                        folder.UserId = 1;

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
