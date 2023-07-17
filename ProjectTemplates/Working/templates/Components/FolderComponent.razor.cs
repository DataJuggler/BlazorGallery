

#region using statements

using Microsoft.AspNetCore.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components;
using DataJuggler.BlazorGallery.Shared;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System.Runtime.Versioning;
using DataGateway.Services;
using DataJuggler.UltimateHelper;
using Microsoft.JSInterop;
using DataJuggler.Blazor.Components.Util;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class FolderComponent : IBlazorComponent, IBlazorComponentParent
    /// <summary>
    /// This class is used to display folders, with a copy button and remove button is visible if the logged in
    /// user is the owner of the folder and the folder is not the Home folder.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class FolderComponent : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables
        private int buttonNumber;
        private string folderStyle;      
        private const double FolderBase = 15.6;        
        private const double FolderHeight = 7;
        private string name;
        private IBlazorComponentParent parent;
        private Folder folder;
        private ValidationComponent renameFolderComponent;
        #endregion

        #region Methods

            #region CopyFolder(int folderId, int buttonNumber)
            /// <summary>
            /// Copy Folder
            /// </summary>
            public void CopyFolder(int folderId)
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Let the parent do the work
                    ParentMainLayout.CopyFolder(folderId);
                }
            }
            #endregion

            #region DeleteFolder(int folderId)
            /// <summary>
            /// Delete Folder
            /// </summary>
            public void DeleteFolder(int folderId)
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Perform the delete
                    ParentMainLayout.DeleteFolder(folderId);
                }
            }
            #endregion

            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // return the child (not used, need to update the interface).
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion
            
            #region FolderSelected(int folderId)
            /// <summary>
            /// Folder Selected
            /// </summary>
            public void FolderSelected(int folderId)
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Notify the parent a folder was selected
                    ParentMainLayout.FolderSelected(folderId);
                }
            }
            #endregion
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method returns the Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                // if the message exists value for HasParentMainLayout is true
                if ((NullHelper.Exists(message)) && (HasParentMainLayout) && (HasRenameFolderComponent))
                {
                    // Create a new collection of 'NamedParameter' objects.
                    message.Parameters = new List<NamedParameter>();
                    NamedParameter param = new NamedParameter();
                    param.Name = "RenameFolderComponent";
                    param.Value = RenameFolderComponent.Text;
                    message.Parameters.Add(param);

                    // Pass the message to the parent for processing
                    ParentMainLayout.ReceiveData(message);
                }
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
                if (component.Name == "RenameFolderTextBox")
                {
                    // set the RenameFolderComponent
                    RenameFolderComponent = component as ValidationComponent;

                    // if the value for HasRenameFolderComponent is true
                    if (HasRenameFolderComponent)
                    {
                        // Set Focus
                        RenameFolderComponent.SetFocus();
                    }
                }
        }
            #endregion
            
            #region RenameFolder(Folder folder)
            /// <summary>
            /// Rename Folder
            /// </summary>
            public void RenameFolder(Folder folder)
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // enter rename folder mode (moving that to this component soon).
                    ParentMainLayout.RenameFolder(folder);
                }
            }
            #endregion

        #endregion

        #region Properties

            #region ButtonNumber
            /// <summary>
            /// This property gets or sets the value for 'ButtonNumber'.
            /// </summary>
            [Parameter]
            public int ButtonNumber
            {
                get { return buttonNumber; }
                set { buttonNumber = value; }
            }
            #endregion
            
            #region Folder
            /// <summary>
            /// This property gets or sets the value for 'Folder'.
            /// </summary>
            [Parameter]
            public Folder Folder
            {
                get { return folder; }
                set { folder = value; }
            }
            #endregion
            
            #region FolderBeingRenamed
            /// <summary>
            /// This read only property returns the value of FolderBeingRenamed from the object ParentMainLayout.
            /// </summary>
            public Folder FolderBeingRenamed
            {
                
                get
                {
                    // initial value
                    Folder folderBeingRenamed = null;
                    
                    // if ParentMainLayout exists
                    if (HasParentMainLayout)
                    {
                        // set the return value
                        folderBeingRenamed = ParentMainLayout.FolderBeingRenamed;
                    }
                    
                    // return value
                    return folderBeingRenamed;
                }
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
                    
                    // if FolderBeingRenamed exists
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
            
            #region FolderStyle
            /// <summary>
            /// This property gets or sets the value for 'FolderStyle'.
            /// </summary>
            public string FolderStyle
            {
                get { return folderStyle; }
                set { folderStyle = value; }
            }
            #endregion
            
            #region HasFolder
            /// <summary>
            /// This property returns true if this object has a 'Folder'.
            /// </summary>
            public bool HasFolder
            {
                get
                {
                    // initial value
                    bool hasFolder = (this.Folder != null);
                    
                    // return value
                    return hasFolder;
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
            
            #region HasRenameFolderComponent
            /// <summary>
            /// This property returns true if this object has a 'RenameFolderComponent'.
            /// </summary>
            public bool HasRenameFolderComponent
            {
                get
                {
                    // initial value
                    bool hasRenameFolderComponent = (this.RenameFolderComponent != null);
                    
                    // return value
                    return hasRenameFolderComponent;
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
            [Parameter]
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
            
            #region RenameFolderComponent
            /// <summary>
            /// This property gets or sets the value for 'RenameFolderComponent'.
            /// </summary>
            public ValidationComponent RenameFolderComponent
            {
                get { return renameFolderComponent; }
                set { renameFolderComponent = value; }
            }
            #endregion
            
            #region RenameFolderMode
            /// <summary>
            /// This read only property returns the value of RenameFolderMode from the object ParentMainLayout.
            /// </summary>
            public bool RenameFolderMode
            {
                
                get
                {
                    // initial value
                    bool renameFolderMode = false;
                    
                    // if ParentMainLayout exists
                    if (HasParentMainLayout)
                    {
                        // set the return value
                        renameFolderMode = ParentMainLayout.RenameFolderMode;
                    }
                    
                    // return value
                    return renameFolderMode;
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
            
            #region Top
            /// <summary>
            /// This read only property returns the value of Top from the object ButtonNumber.
            /// </summary>
            public double Top
            {
                
                get
                {
                    // initial value
                    double top = FolderBase + (ButtonNumber * FolderHeight);
                    
                    // return value
                    return top;
                }
            }
            #endregion
            
            #region TopStyle
            /// <summary>
            /// This read only property returns the value of TopStyle from the object Top.
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

        public List<IBlazorComponent> Children { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #endregion

    }
    #endregion

}
