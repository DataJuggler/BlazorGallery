

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using ObjectLibrary.BusinessObjects;
using DataGateway.Services;

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
        private Pages.Index indexPage;
        private List<Folder> folders;
        private Folder selectedFolder;
        private bool addFolderMode;
        private ValidationComponent newFolderNameComponent;
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

                // To Do: Load the Images for the selected folder
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
                if (firstRender)
                {
                   // get the folders
                   Folders = await FolderService.GetFolderList();
                }

                // call the base
                await base.OnAfterRenderAsync(firstRender);

                // if firstRender
                if (firstRender)
                {
                    // Update the UI
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
            
        #endregion
        
    }
    #endregion

}
