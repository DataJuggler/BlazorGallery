

#region using statements

using DataJuggler.Blazor.Components;
using DataJuggler.Blazor.Components.Interfaces;
using DataJuggler.Blazor.Components.Util;
using Microsoft.AspNetCore.Components;
using ObjectLibrary.Enumerations;
using ObjectLibrary.BusinessObjects;
using DataJuggler.BlazorGallery.Shared;
using System.Runtime.Versioning;
using DataJuggler.UltimateHelper;
using ApplicationLogicComponent.Connection;
using DataGateway;
using Timer = System.Timers.Timer;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

#endregion

namespace DataJuggler.BlazorGallery.Components
{

    #region class FeedbackComponent
    /// <summary>
    /// This class is used for users to provide feedback of the site.
    /// </summary>
    [SupportedOSPlatform("windows")]
    public partial class FeedbackComponent : IBlazorComponent, IBlazorComponentParent
    {

        #region Private Variables
        private string name;
        private IBlazorComponentParent parent;
        private List<IBlazorComponent> children;
        private ComboBox comboBox;
        private ValidationComponent feedbackText;        
        private ValidationComponent permissionToEmail;
        private string statusMessage;
        private Timer timer;
        #endregion

        #region Methods

            #region CancelSendFeedback()
            /// <summary>
            /// Cancel Send Feedback
            /// </summary>
            public void CancelSendFeedback()
            {
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Send back to the parent and back to where the user was (in theory)
                    ParentMainLayout.RestoreScreenType();
                }
            }
            #endregion
            
            #region FindChildByName(string name)
            /// <summary>
            /// method returns the Child By Name
            /// </summary>
            public IBlazorComponent FindChildByName(string name)
            {
                // not used here
                return ComponentHelper.FindChildByName(Children, name);
            }
            #endregion
            
            #region ParseComboBoxSelection(object selection)
            /// <summary>
            /// returns the Combo Box Selection
            /// </summary>
            public FeedbackTypeEnum ParseComboBoxSelection(object selection)
            {
                // initial value
                FeedbackTypeEnum selectedItem = FeedbackTypeEnum.Bug;

                // If the selection object exists
                if (NullHelper.Exists(selection))
                {
                    // set to temp
                    string temp = selection.ToString().Replace("_", "");

                    if (temp == "Suggestion")
                    {
                        // Set to Suggestion
                    }
                    else if (temp == "VisualDisplay")
                    {
                        // Set to Visual_Display
                        selectedItem = FeedbackTypeEnum.Visual_Display;
                    }
                }

                // return value
                return selectedItem;
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
                // if this is the ComboBox
                if (component is ComboBox)
                {
                    // Store this component
                    ComboBox = component as ComboBox;
                    
                    // Load the ComboBox
                    ComboBox.LoadItems(typeof(FeedbackTypeEnum));

                    // Set the selected item to Bug
                    ComboBox.SetSelectedItem("Bug");
                }
                else if (component is ValidationComponent)
                {
                    if (component.Name == "FeedbackText")
                    {
                        // Store this component
                        FeedbackText = component as ValidationComponent;
                    }
                    else if (component.Name == "PermissionToEmail")
                    {
                        // Store this component
                        PermissionToEmail = component as ValidationComponent;

                        // if the value for HasPermissionToEmail is true
                        if (HasPermissionToEmail)
                        {
                            // Default to true
                            PermissionToEmail.SetCheckBoxValue(true);
                        }
                    }
                }
            }
            #endregion
            
            #region SendFeedback()
            /// <summary>
            /// Send Feedback
            /// </summary>
            public void SendFeedback()
            {
                // if the value for HasLoggedInUser is true
                if ((HasLoggedInUser) && (HasComboBox) && (HasFeedbackText) && (HasPermissionToEmail))
                {
                    // Create a new instance of a 'Feedback' object.
                    Feedback feedback = new Feedback();
                    feedback.FeedbackType = ParseComboBoxSelection(ComboBox.SelectedItem);
                    feedback.Details = feedbackText.Text;
                    feedback.PermissionToEmail = PermissionToEmail.CheckBoxValue;
                    feedback.UserId = LoggedInUser.Id;
                    feedback.CreatedDate = DateTime.Now;
                    
                    // Create a new instance of a 'Gateway' object.
                    Gateway gateway = new Gateway(Connection.Name);
                    
                    // Perform The Feedback
                    bool saved = gateway.SaveFeedback(ref feedback);

                    // if the value for saved is true
                    if (saved)
                    {
                        // Update the StatusMessage
                        StatusMessage = "Thank you for your feedback. A response will be sent to you as soon as possible.";

                        // Update the UI
                        Refresh();

                        // Start the timer
                        Timer = new Timer(4200);
                        Timer.Elapsed += TimerElapsed;
                        Timer.Start();
                    }
                    else
                    {
                        // get the last error
                        Exception error = gateway.GetLastException();

                        string temp = error.ToString();

                        // Show a message
                        StatusMessage = "Oops! Something went wrong.";
                    }
                }
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
                
                // if the value for HasParentMainLayout is true
                if (HasParentMainLayout)
                {
                    // Send the user back to what they were doing before clicking Feedback.
                    ParentMainLayout.RestoreScreenType();
                }
            }
            #endregion
            
        #endregion

        #region Properties

            #region CancelButtonStyle
            /// <summary>
            /// This read only property returns the value of CancelButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string CancelButtonStyle
            {
                
                get
                {
                    // initial value
                    string cancelButtonStyle = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        cancelButtonStyle = ParentMainLayout.CancelButtonStyle;
                    }
                    
                    // return value
                    return cancelButtonStyle;
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
            
            #region ComboBox
            /// <summary>
            /// This property gets or sets the value for 'ComboBox'.
            /// </summary>
            public ComboBox ComboBox
            {
                get { return comboBox; }
                set { comboBox = value; }
            }
            #endregion
            
            #region FeedbackText
            /// <summary>
            /// This property gets or sets the value for 'FeedbackText'.
            /// </summary>
            public ValidationComponent FeedbackText
            {
                get { return feedbackText; }
                set { feedbackText = value; }
            }
            #endregion
            
            #region HasComboBox
            /// <summary>
            /// This property returns true if this object has a 'ComboBox'.
            /// </summary>
            public bool HasComboBox
            {
                get
                {
                    // initial value
                    bool hasComboBox = (this.ComboBox != null);
                    
                    // return value
                    return hasComboBox;
                }
            }
            #endregion
            
            #region HasFeedbackText
            /// <summary>
            /// This property returns true if this object has a 'FeedbackText'.
            /// </summary>
            public bool HasFeedbackText
            {
                get
                {
                    // initial value
                    bool hasFeedbackText = (this.FeedbackText != null);
                    
                    // return value
                    return hasFeedbackText;
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
            
            #region HasPermissionToEmail
            /// <summary>
            /// This property returns true if this object has a 'PermissionToEmail'.
            /// </summary>
            public bool HasPermissionToEmail
            {
                get
                {
                    // initial value
                    bool hasPermissionToEmail = (this.PermissionToEmail != null);
                    
                    // return value
                    return hasPermissionToEmail;
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
                    if (HasParent)
                    {
                        // set the return value
                        parentMainLayout = Parent as MainLayout;
                    }
                    
                    // return value
                    return parentMainLayout;
                }
            }
            #endregion
            
            #region PermissionToEmail
            /// <summary>
            /// This property gets or sets the value for 'PermissionToEmail'.
            /// </summary>
            public ValidationComponent PermissionToEmail
            {
                get { return permissionToEmail; }
                set { permissionToEmail = value; }
            }
            #endregion
            
            #region SendButtonStyle
            /// <summary>
            /// This read only property returns the value of SendButtonStyle from the object ParentMainLayout.
            /// </summary>
            public string SendButtonStyle
            {
                
                get
                {
                    // initial value
                    string sendButton = "";
                    
                    // if ParentMainLayout exists
                    if (ParentMainLayout != null)
                    {
                        // set the return value
                        sendButton = ParentMainLayout.SendButtonStyle;
                    }
                    
                    // return value
                    return sendButton;
                }
            }
            #endregion
            
            #region StatusMessage
            /// <summary>
            /// This property gets or sets the value for 'StatusMessage'.
            /// </summary>
            public string StatusMessage
            {
                get { return statusMessage; }
                set { statusMessage = value; }
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
