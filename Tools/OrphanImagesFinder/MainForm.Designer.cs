namespace OrphanImagesFinder
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            RemoveOrphanImagesButton = new DataJuggler.Win.Controls.Button();
            StatusLabel = new Label();
            Graph = new ProgressBar();
            SuspendLayout();
            // 
            // RemoveOrphanImagesButton
            // 
            RemoveOrphanImagesButton.BackColor = Color.Transparent;
            RemoveOrphanImagesButton.ButtonText = "Remove Orphan Images";
            RemoveOrphanImagesButton.FlatStyle = FlatStyle.Flat;
            RemoveOrphanImagesButton.ForeColor = Color.Black;
            RemoveOrphanImagesButton.Location = new Point(45, 53);
            RemoveOrphanImagesButton.Name = "RemoveOrphanImagesButton";
            RemoveOrphanImagesButton.Size = new Size(253, 44);
            RemoveOrphanImagesButton.TabIndex = 0;
            RemoveOrphanImagesButton.Theme = DataJuggler.Win.Controls.Enumerations.ThemeEnum.Wood;
            RemoveOrphanImagesButton.Click += RemoveOrphanImagesButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point);
            StatusLabel.ForeColor = Color.LemonChiffon;
            StatusLabel.Location = new Point(34, 133);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(612, 23);
            StatusLabel.TabIndex = 25;
            StatusLabel.Text = "Status:";
            // 
            // Graph
            // 
            Graph.Location = new Point(34, 165);
            Graph.Name = "Graph";
            Graph.Size = new Size(612, 23);
            Graph.TabIndex = 24;
            Graph.Visible = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.BlackImage;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(687, 221);
            Controls.Add(StatusLabel);
            Controls.Add(Graph);
            Controls.Add(RemoveOrphanImagesButton);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Remove Orphan Images";
            ResumeLayout(false);
        }

        #endregion

        private DataJuggler.Win.Controls.Button RemoveOrphanImagesButton;
        private Label StatusLabel;
        private ProgressBar Graph;
    }
}