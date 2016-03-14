namespace SoundSpammer
{
    partial class PropertiesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesForm));
            this.soundPathLabel = new System.Windows.Forms.Label();
            this.soundPathTextBox = new System.Windows.Forms.TextBox();
            this.soundPathButton = new System.Windows.Forms.Button();
            this.soundPathOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.okButton = new System.Windows.Forms.Button();
            this.hotkeyLabel = new System.Windows.Forms.Label();
            this.hotkeyTextBox = new System.Windows.Forms.TextBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.buttonTextLabel = new System.Windows.Forms.Label();
            this.buttonTextBox = new System.Windows.Forms.TextBox();
            this.playbackGroupBox = new System.Windows.Forms.GroupBox();
            this.repeatModeGroupBox = new System.Windows.Forms.GroupBox();
            this.cancelPlaybackRadioButton = new System.Windows.Forms.RadioButton();
            this.startOverRadioButton = new System.Windows.Forms.RadioButton();
            this.overlapRadioButton = new System.Windows.Forms.RadioButton();
            this.aestheticsGroupBox = new System.Windows.Forms.GroupBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.spamOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.playbackGroupBox.SuspendLayout();
            this.repeatModeGroupBox.SuspendLayout();
            this.aestheticsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // soundPathLabel
            // 
            this.soundPathLabel.AutoSize = true;
            this.soundPathLabel.Location = new System.Drawing.Point(6, 25);
            this.soundPathLabel.Name = "soundPathLabel";
            this.soundPathLabel.Size = new System.Drawing.Size(66, 13);
            this.soundPathLabel.TabIndex = 0;
            this.soundPathLabel.Text = "Sound Path:";
            // 
            // soundPathTextBox
            // 
            this.soundPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundPathTextBox.Location = new System.Drawing.Point(78, 22);
            this.soundPathTextBox.Name = "soundPathTextBox";
            this.soundPathTextBox.ReadOnly = true;
            this.soundPathTextBox.Size = new System.Drawing.Size(142, 20);
            this.soundPathTextBox.TabIndex = 1;
            // 
            // soundPathButton
            // 
            this.soundPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.soundPathButton.Location = new System.Drawing.Point(226, 19);
            this.soundPathButton.Name = "soundPathButton";
            this.soundPathButton.Size = new System.Drawing.Size(24, 24);
            this.soundPathButton.TabIndex = 2;
            this.soundPathButton.Text = "...";
            this.soundPathButton.UseVisualStyleBackColor = true;
            this.soundPathButton.Click += new System.EventHandler(this.soundPathButton_Click);
            // 
            // soundPathOpenFileDialog
            // 
            this.soundPathOpenFileDialog.Filter = "Audio Files (*.mp3, *.wav, *.ogg)|*.mp3;*.wav;*.ogg";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(193, 289);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // hotkeyLabel
            // 
            this.hotkeyLabel.AutoSize = true;
            this.hotkeyLabel.Location = new System.Drawing.Point(6, 52);
            this.hotkeyLabel.Name = "hotkeyLabel";
            this.hotkeyLabel.Size = new System.Drawing.Size(44, 13);
            this.hotkeyLabel.TabIndex = 4;
            this.hotkeyLabel.Text = "Hotkey:";
            // 
            // hotkeyTextBox
            // 
            this.hotkeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hotkeyTextBox.Location = new System.Drawing.Point(56, 49);
            this.hotkeyTextBox.Name = "hotkeyTextBox";
            this.hotkeyTextBox.ReadOnly = true;
            this.hotkeyTextBox.Size = new System.Drawing.Size(194, 20);
            this.hotkeyTextBox.TabIndex = 5;
            this.hotkeyTextBox.Text = "<Press any key>";
            this.hotkeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hotkeyTextBox_KeyDown);
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(6, 75);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(45, 26);
            this.volumeLabel.TabIndex = 6;
            this.volumeLabel.Text = "Volume:\r\n100%";
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.volumeTrackBar.Location = new System.Drawing.Point(57, 75);
            this.volumeTrackBar.Maximum = 20;
            this.volumeTrackBar.Minimum = 1;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(193, 45);
            this.volumeTrackBar.TabIndex = 7;
            this.volumeTrackBar.Value = 10;
            this.volumeTrackBar.ValueChanged += new System.EventHandler(this.volumeTrackBar_ValueChanged);
            // 
            // buttonTextLabel
            // 
            this.buttonTextLabel.AutoSize = true;
            this.buttonTextLabel.Location = new System.Drawing.Point(6, 22);
            this.buttonTextLabel.Name = "buttonTextLabel";
            this.buttonTextLabel.Size = new System.Drawing.Size(65, 13);
            this.buttonTextLabel.TabIndex = 8;
            this.buttonTextLabel.Text = "Button Text:";
            // 
            // buttonTextBox
            // 
            this.buttonTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTextBox.Location = new System.Drawing.Point(77, 19);
            this.buttonTextBox.Name = "buttonTextBox";
            this.buttonTextBox.Size = new System.Drawing.Size(173, 20);
            this.buttonTextBox.TabIndex = 9;
            this.buttonTextBox.Text = "SPAM!";
            // 
            // playbackGroupBox
            // 
            this.playbackGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playbackGroupBox.Controls.Add(this.repeatModeGroupBox);
            this.playbackGroupBox.Controls.Add(this.soundPathButton);
            this.playbackGroupBox.Controls.Add(this.soundPathTextBox);
            this.playbackGroupBox.Controls.Add(this.soundPathLabel);
            this.playbackGroupBox.Controls.Add(this.volumeLabel);
            this.playbackGroupBox.Controls.Add(this.volumeTrackBar);
            this.playbackGroupBox.Controls.Add(this.hotkeyTextBox);
            this.playbackGroupBox.Controls.Add(this.hotkeyLabel);
            this.playbackGroupBox.Location = new System.Drawing.Point(12, 12);
            this.playbackGroupBox.Name = "playbackGroupBox";
            this.playbackGroupBox.Size = new System.Drawing.Size(256, 220);
            this.playbackGroupBox.TabIndex = 10;
            this.playbackGroupBox.TabStop = false;
            this.playbackGroupBox.Text = "Playback";
            // 
            // repeatModeGroupBox
            // 
            this.repeatModeGroupBox.Controls.Add(this.cancelPlaybackRadioButton);
            this.repeatModeGroupBox.Controls.Add(this.startOverRadioButton);
            this.repeatModeGroupBox.Controls.Add(this.overlapRadioButton);
            this.repeatModeGroupBox.Location = new System.Drawing.Point(6, 126);
            this.repeatModeGroupBox.Name = "repeatModeGroupBox";
            this.repeatModeGroupBox.Size = new System.Drawing.Size(244, 88);
            this.repeatModeGroupBox.TabIndex = 8;
            this.repeatModeGroupBox.TabStop = false;
            this.repeatModeGroupBox.Text = "Repeat Mode";
            // 
            // cancelPlaybackRadioButton
            // 
            this.cancelPlaybackRadioButton.AutoSize = true;
            this.cancelPlaybackRadioButton.Location = new System.Drawing.Point(6, 65);
            this.cancelPlaybackRadioButton.Name = "cancelPlaybackRadioButton";
            this.cancelPlaybackRadioButton.Size = new System.Drawing.Size(105, 17);
            this.cancelPlaybackRadioButton.TabIndex = 2;
            this.cancelPlaybackRadioButton.Text = "Cancel Playback";
            this.cancelPlaybackRadioButton.UseVisualStyleBackColor = true;
            // 
            // startOverRadioButton
            // 
            this.startOverRadioButton.AutoSize = true;
            this.startOverRadioButton.Location = new System.Drawing.Point(6, 42);
            this.startOverRadioButton.Name = "startOverRadioButton";
            this.startOverRadioButton.Size = new System.Drawing.Size(73, 17);
            this.startOverRadioButton.TabIndex = 1;
            this.startOverRadioButton.Text = "Start Over";
            this.startOverRadioButton.UseVisualStyleBackColor = true;
            // 
            // overlapRadioButton
            // 
            this.overlapRadioButton.AutoSize = true;
            this.overlapRadioButton.Checked = true;
            this.overlapRadioButton.Location = new System.Drawing.Point(6, 19);
            this.overlapRadioButton.Name = "overlapRadioButton";
            this.overlapRadioButton.Size = new System.Drawing.Size(62, 17);
            this.overlapRadioButton.TabIndex = 0;
            this.overlapRadioButton.TabStop = true;
            this.overlapRadioButton.Text = "Overlap";
            this.overlapRadioButton.UseVisualStyleBackColor = true;
            // 
            // aestheticsGroupBox
            // 
            this.aestheticsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aestheticsGroupBox.Controls.Add(this.buttonTextBox);
            this.aestheticsGroupBox.Controls.Add(this.buttonTextLabel);
            this.aestheticsGroupBox.Location = new System.Drawing.Point(12, 238);
            this.aestheticsGroupBox.Name = "aestheticsGroupBox";
            this.aestheticsGroupBox.Size = new System.Drawing.Size(256, 45);
            this.aestheticsGroupBox.TabIndex = 11;
            this.aestheticsGroupBox.TabStop = false;
            this.aestheticsGroupBox.Text = "Aesthetics";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Spam Files|*.spam";
            this.saveFileDialog.Title = "Save Spam File";
            // 
            // spamOpenFileDialog
            // 
            this.spamOpenFileDialog.Filter = "Spam Files|*.spam";
            // 
            // PropertiesForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(280, 324);
            this.Controls.Add(this.aestheticsGroupBox);
            this.Controls.Add(this.playbackGroupBox);
            this.Controls.Add(this.okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties";
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.playbackGroupBox.ResumeLayout(false);
            this.playbackGroupBox.PerformLayout();
            this.repeatModeGroupBox.ResumeLayout(false);
            this.repeatModeGroupBox.PerformLayout();
            this.aestheticsGroupBox.ResumeLayout(false);
            this.aestheticsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label soundPathLabel;
        private System.Windows.Forms.TextBox soundPathTextBox;
        private System.Windows.Forms.Button soundPathButton;
        private System.Windows.Forms.OpenFileDialog soundPathOpenFileDialog;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label hotkeyLabel;
        private System.Windows.Forms.TextBox hotkeyTextBox;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.Label buttonTextLabel;
        private System.Windows.Forms.TextBox buttonTextBox;
        private System.Windows.Forms.GroupBox aestheticsGroupBox;
        private System.Windows.Forms.GroupBox playbackGroupBox;
        private System.Windows.Forms.GroupBox repeatModeGroupBox;
        private System.Windows.Forms.RadioButton cancelPlaybackRadioButton;
        private System.Windows.Forms.RadioButton startOverRadioButton;
        private System.Windows.Forms.RadioButton overlapRadioButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog spamOpenFileDialog;
    }
}