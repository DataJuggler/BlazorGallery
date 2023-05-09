

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using Microsoft.AspNetCore.Components;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class ConfirmationComponent
    /// <summary>
    /// This class is used to get a yes no response
    /// </summary>
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

                    // if the parent exists
                    if (parent != null)
                    {
                        // register with the parent
                        parent.Register(this);
                    }
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
            
        #endregion
        
    }
    #endregion

}
