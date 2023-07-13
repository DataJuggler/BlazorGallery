

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.BlazorGallery.Shared;
using Microsoft.AspNetCore.Components;
using System.Runtime.Versioning;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class ConfirmationComponent
    /// <summary>
    /// This class is used to get a yes no response
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class ConfirmationComponent : IBlazorComponent
    {
        
        #region Private Variables
        private string name;
        private bool visible;
        private string prompt;
        private IBlazorComponentParent parent;
        private string componentStyle;
        private string displayStyle;               
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instasnce of a ConfirmationComponent
        /// </summary>
        public ConfirmationComponent()
        {
            // Perform initializations for this object
            Init();
        }
        #endregion
        
        #region Methods
            
            #region Init()
            /// <summary>
            ///  This method performs initializations for this object.
            /// </summary>
            public void Init()
            {
                DisplayStyle = "inline-block";
                Name = "ConfirmationComponent";
            }
            #endregion

            #region NoClicked()
            /// <summary>
            /// No Clicked
            /// </summary>
            public void NoClicked()
            {
                // if the value for HasParent is true
                if (HasParent)
                {
                    // Create a new instance of a 'Message' object.
                    Message message = new Message();

                    // Set the message
                    message.Text = "NoClicked";

                    // Setup the sender
                    message.Sender = this;

                    // Notify the parent
                    Parent.ReceiveData(message);
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
            
            #region SetPrompt(string prompt)
            /// <summary>
            /// Set Prompt
            /// </summary>
            public void SetPrompt(string prompt)
            {
                // store
                Prompt = prompt;

                // Update the UI
                // Refresh();
            }
            #endregion
            
            #region SetVisible(bool visible)
            /// <summary>
            /// Set Visible
            /// </summary>
            public void SetVisible(bool visible)
            {
                // set the property
                Visible = visible;

                if (Visible)
                {
                    DisplayStyle = "inline-block";
                }
                else
                {
                    DisplayStyle = "none";
                }

                // Update the UI
                Refresh();
            }
            #endregion

            #region YesClicked()
            /// <summary>
            /// Yes Clicked
            /// </summary>
            public void YesClicked()
            {
                // if the value for HasParent is true
                if (HasParent)
                {
                    // Create a new instance of a 'Message' object.
                    Message message = new Message();

                    // Set the message
                    message.Text = "YesClicked";

                    // Setup the sender
                    message.Sender = this;

                    // Notify the parent
                    Parent.ReceiveData(message);
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region ComponentStyle
            /// <summary>
            /// This property gets or sets the value for 'ComponentStyle'.
            /// </summary>
            public string ComponentStyle
            {
                get { return componentStyle; }
                set { componentStyle = value; }
            }
            #endregion
            
            #region ConfirmationTop
            /// <summary>
            /// This read only property returns the value of ConfirmationTop from the object ParentMainLayout.
            /// </summary>
            public double ConfirmationTop
            {
                
                get
                {
                    // initial value
                    double confirmationTop = 0;
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        confirmationTop = ParentMainLayout.Top + 8;
                    }
                    
                    // return value
                    return confirmationTop;
                }
            }
            #endregion
            
            #region ConfirmationTopStyle
            /// <summary>
            /// This read only property returns the value of ConfirmationTopStyle from the object ConfirmationTop.
            /// </summary>
            public string ConfirmationTopStyle
            {
                
                get
                {
                    // initial value
                    string confirmationTopStyle = ConfirmationTop + "vh";
                    
                    // return value
                    return confirmationTopStyle;
                }
            }
            #endregion
            
            #region DisplayStyle
            /// <summary>
            /// This property gets or sets the value for 'DisplayStyle'.
            /// </summary>
            public string DisplayStyle
            {
                get { return displayStyle; }
                set { displayStyle = value; }
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
            
            #region NoButtonStyle
            /// <summary>
            /// This read only property returns the value of NoButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string NoButtonStyle
            {
                
                get
                {
                    // initial value
                    string noButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        noButtonStyle = ParentMainLayout.NoButtonStyle;
                    }
                    
                    // return value
                    return noButtonStyle;
                }
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

                    // if the parent exists
                    if (HasParent)
                    {
                        // register with the parent
                        parent.Register(this);
                    }
                }
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
            
            #region Prompt
            /// <summary>
            /// This property gets or sets the value for 'Prompt'.
            /// </summary>
            [Parameter]
            public string Prompt
            {
                get { return prompt; }
                set { prompt = value; }
            }
            #endregion
            
            #region Visible
            /// <summary>
            /// This property gets or sets the value for 'Visible'.
            /// </summary>
            [Parameter]
            public bool Visible
            {
                get { return visible; }
                set 
                {
                    visible = value;

                     if (visible)
                    {
                        DisplayStyle = "inline-block";
                    }
                    else
                    {
                        DisplayStyle = "none";
                    }
                }
            }
            #endregion
            
            #region YesButtonStyle
            /// <summary>
            /// This read only property returns the value of YesButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string YesButtonStyle
            {
                
                get
                {
                    // initial value
                    string yesButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        yesButtonStyle = ParentMainLayout.YesButtonStyle;
                    }
                    
                    // return value
                    return yesButtonStyle;
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
