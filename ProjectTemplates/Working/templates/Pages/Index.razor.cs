

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

#endregion

namespace DataJuggler.BlazorGallery.Pages
{

    #region class Index
    /// <summary>
    /// This class is the main page of this app.
    /// </summary>
    public partial class Index : IBlazorComponent, IBlazorComponentParent
    {
        
        #region Private Variables        
        private string name;
        private List<IBlazorComponent> children;
        private IBlazorComponentParent parent;                
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

        #endregion

    }
    #endregion

}
