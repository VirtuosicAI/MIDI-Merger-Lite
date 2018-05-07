namespace MIDI_Merger_Lite
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSelectedMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mergeMIDIsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abortMergingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MIDIListView = new System.Windows.Forms.ListView();
            this.MIDIName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MIDIPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tracks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addMIDI = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.exportPathTXTBox = new System.Windows.Forms.TextBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.saveMIDI = new System.Windows.Forms.SaveFileDialog();
            this.trackTotalLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.totalTracksUpdater = new System.Windows.Forms.Timer(this.components);
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(624, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMIDIsToolStripMenuItem,
            this.removeSelectedMIDIsToolStripMenuItem,
            this.clearMIDIsToolStripMenuItem,
            this.toolStripSeparator1,
            this.mergeMIDIsToolStripMenuItem,
            this.abortMergingToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addMIDIsToolStripMenuItem
            // 
            this.addMIDIsToolStripMenuItem.Name = "addMIDIsToolStripMenuItem";
            this.addMIDIsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.addMIDIsToolStripMenuItem.Text = "Add MIDIs";
            this.addMIDIsToolStripMenuItem.Click += new System.EventHandler(this.addMIDIsToolStripMenuItem_Click);
            // 
            // removeSelectedMIDIsToolStripMenuItem
            // 
            this.removeSelectedMIDIsToolStripMenuItem.Name = "removeSelectedMIDIsToolStripMenuItem";
            this.removeSelectedMIDIsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.removeSelectedMIDIsToolStripMenuItem.Text = "Remove selected MIDIs";
            this.removeSelectedMIDIsToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedMIDIsToolStripMenuItem_Click);
            // 
            // clearMIDIsToolStripMenuItem
            // 
            this.clearMIDIsToolStripMenuItem.Name = "clearMIDIsToolStripMenuItem";
            this.clearMIDIsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.clearMIDIsToolStripMenuItem.Text = "Clear MIDIs";
            this.clearMIDIsToolStripMenuItem.Click += new System.EventHandler(this.clearMIDIsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // mergeMIDIsToolStripMenuItem
            // 
            this.mergeMIDIsToolStripMenuItem.Name = "mergeMIDIsToolStripMenuItem";
            this.mergeMIDIsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.mergeMIDIsToolStripMenuItem.Text = "Merge MIDIs";
            this.mergeMIDIsToolStripMenuItem.Click += new System.EventHandler(this.mergeMIDIsToolStripMenuItem_Click);
            // 
            // abortMergingToolStripMenuItem
            // 
            this.abortMergingToolStripMenuItem.Enabled = false;
            this.abortMergingToolStripMenuItem.Name = "abortMergingToolStripMenuItem";
            this.abortMergingToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.abortMergingToolStripMenuItem.Text = "Abort merging";
            this.abortMergingToolStripMenuItem.Click += new System.EventHandler(this.abortMergingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MIDIListView
            // 
            this.MIDIListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MIDIName,
            this.MIDIPath,
            this.Tracks});
            this.MIDIListView.FullRowSelect = true;
            this.MIDIListView.GridLines = true;
            this.MIDIListView.HideSelection = false;
            this.MIDIListView.Location = new System.Drawing.Point(12, 40);
            this.MIDIListView.Name = "MIDIListView";
            this.MIDIListView.Size = new System.Drawing.Size(521, 156);
            this.MIDIListView.TabIndex = 3;
            this.MIDIListView.UseCompatibleStateImageBehavior = false;
            this.MIDIListView.View = System.Windows.Forms.View.Details;
            this.MIDIListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.midiListView_ColumnWidthChanging);
            // 
            // MIDIName
            // 
            this.MIDIName.Text = "MIDI Name";
            this.MIDIName.Width = 225;
            // 
            // MIDIPath
            // 
            this.MIDIPath.Text = "MIDI Path";
            this.MIDIPath.Width = 225;
            // 
            // Tracks
            // 
            this.Tracks.Text = "Tracks";
            this.Tracks.Width = 50;
            // 
            // addMIDI
            // 
            this.addMIDI.Filter = "MIDI Files|*.mid";
            this.addMIDI.Multiselect = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Output Path:";
            // 
            // exportPathTXTBox
            // 
            this.exportPathTXTBox.Location = new System.Drawing.Point(85, 204);
            this.exportPathTXTBox.Name = "exportPathTXTBox";
            this.exportPathTXTBox.ReadOnly = true;
            this.exportPathTXTBox.Size = new System.Drawing.Size(448, 20);
            this.exportPathTXTBox.TabIndex = 8;
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(539, 202);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 9;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // saveMIDI
            // 
            this.saveMIDI.FileName = "Merged";
            this.saveMIDI.Filter = "MIDI File|*.mid";
            // 
            // trackTotalLabel
            // 
            this.trackTotalLabel.AutoSize = true;
            this.trackTotalLabel.Location = new System.Drawing.Point(12, 24);
            this.trackTotalLabel.Name = "trackTotalLabel";
            this.trackTotalLabel.Size = new System.Drawing.Size(125, 13);
            this.trackTotalLabel.TabIndex = 10;
            this.trackTotalLabel.Text = "Total number of tracks: 0";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 231);
            this.progressBar.MarqueeAnimationSpeed = 50;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(624, 23);
            this.progressBar.TabIndex = 12;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // totalTracksUpdater
            // 
            this.totalTracksUpdater.Enabled = true;
            this.totalTracksUpdater.Interval = 1000;
            this.totalTracksUpdater.Tick += new System.EventHandler(this.totalTracksUpdater_Tick);
            // 
            // downButton
            // 
            this.downButton.BackgroundImage = global::MIDI_Merger_Lite.Properties.Resources.DownButtonSmall;
            this.downButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.downButton.Location = new System.Drawing.Point(539, 121);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(75, 75);
            this.downButton.TabIndex = 6;
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.BackgroundImage = global::MIDI_Merger_Lite.Properties.Resources.UpButtonSmall;
            this.upButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.upButton.Location = new System.Drawing.Point(539, 40);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(75, 75);
            this.upButton.TabIndex = 5;
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 254);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.trackTotalLabel);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.exportPathTXTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Controls.Add(this.MIDIListView);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIDI Merger Lite";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ListView MIDIListView;
        private System.Windows.Forms.ColumnHeader MIDIName;
        private System.Windows.Forms.ColumnHeader Tracks;
        private System.Windows.Forms.OpenFileDialog addMIDI;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.ToolStripMenuItem addMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mergeMIDIsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox exportPathTXTBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.SaveFileDialog saveMIDI;
        private System.Windows.Forms.Label trackTotalLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem abortMergingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Timer totalTracksUpdater;
        private System.Windows.Forms.ColumnHeader MIDIPath;
    }
}

