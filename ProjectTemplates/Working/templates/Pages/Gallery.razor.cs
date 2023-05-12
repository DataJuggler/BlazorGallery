

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;

#endregion

namespace DataJuggler.BlazorGallery.Pages
{

    #region class Gallery
    /// <summary>
    /// This class is the code behind for the Gallery page
    /// </summary>
    public partial class Gallery : IBlazorComponent
    {
        
        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        #endregion
        
        #region Methods
            
            #region ReceiveData(Message message)
            /// <summary>
            /// method Receive Data
            /// </summary>
            public void ReceiveData(Message message)
            {
                
            }
            #endregion
            
        #endregion
        
        #region Properties
            
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
                    parent = value;

                    // If the parent object exists
                    if (parent != null)
                    {
                        // register with thte parent
                        parent.Register(this);
                    }
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
