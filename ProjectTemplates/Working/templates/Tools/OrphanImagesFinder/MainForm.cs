

#region using statements

using DataGateway;
using ApplicationLogicComponent.Connection;
using ObjectLibrary.BusinessObjects;
using System.IO;
using Image = ObjectLibrary.BusinessObjects.Image;
using DataJuggler.UltimateHelper;

#endregion

namespace OrphanImagesFinder
{

    #region class MainForm
    /// <summary>
    /// This class [Enter Class Description]
    /// </summary>
    public partial class MainForm : Form
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'MainForm' object.
        /// </summary>
        public MainForm()
        {
            // Create Controls
            InitializeComponent();
        }
        #endregion

        #region Events

        #region RemoveOrphanImagesButton_Click(object sender, EventArgs e)
        /// <summary>
        /// event is fired when the 'RemoveOrphanImagesButton' is clicked.
        /// </summary>
        private void RemoveOrphanImagesButton_Click(object sender, EventArgs e)
        {
            // local
            List<Image> imagesToDelete = new List<Image>();
            int deletedCount = 0;

            // Create a new instance of a 'Gateway' object.
            Gateway gateway = new Gateway(Connection.Name);

            // Load all the images
            List<Image> images = gateway.LoadImages();

            // If the images collection exists and has one or more items
            if (ListHelper.HasOneOrMoreItems(images))
            {
                // Setup the Graph
                Graph.Maximum = images.Count;
                Graph.Value = 0;
                Graph.Visible = true;

                // Display Status
                StatusLabel.Text = "Status: Checking images list, please wait.";

                // get the root path
                string root = @"c:\Projects\GitHub\BlazorGallery";

                // Iterate the collection of Image objects
                foreach (Image image in images)
                {
                    // Get the fullPath
                    string fullPath = root + "/" + image.FullPath;

                    // if the image does not exist
                    if (!File.Exists(fullPath))
                    {
                        // Add this image
                        imagesToDelete.Add(image);
                    }

                    // Increment the value for Graph
                    Graph.Value++;
                }

                // if there are images to delete
                if (ListHelper.HasOneOrMoreItems(imagesToDelete))
                {
                    // Setup the Graph
                    Graph.Maximum = imagesToDelete.Count;
                    Graph.Value = 0;

                    // Display Status
                    StatusLabel.Text = "Status: Deleting images, please wait.";

                    // Iterate the collection of Image objects
                    foreach (Image image in imagesToDelete)
                    {
                        // delete this image
                        bool deleted = gateway.DeleteImage(image.Id);

                        // if the value for deleted is true
                        if (deleted)
                        {
                            // Increment the value for deletedCount
                            deletedCount++;
                        }

                        // Increment thea value for Graph
                        Graph.Value++;
                    }

                    // Display final status
                    StatusLabel.Text = "Status: " + " Finished deleting " + deletedCount + " images from the database.";
                }
                else
                {
                    // Display final status
                    StatusLabel.Text = "Status: No orphan images found.";
                }

                // Hide the graph
                Graph.Visible = false;
            }
        }
        #endregion

        #endregion

    }
    #endregion

}
