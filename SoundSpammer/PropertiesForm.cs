using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundSpammer
{
    public partial class PropertiesForm : Form
    {
        /// <summary>
        /// Used for determining what should happen when the button is clicked twice.
        /// </summary>
        public enum SoundRepeatMode
        {
            Overlap,
            StartOver,
            CancelPlayback
        }

        /// <summary>
        /// Returns the full file path for the sound file.
        /// </summary>
        public String SoundFilePath
        {
            get
            {
                return openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Returns the file name of the sound.
        /// </summary>
        public String SoundFileName
        {
            get
            {
                return openFileDialog.SafeFileName;
            }
        }

        /// <summary>
        /// Stores the key that triggers sound playback.
        /// </summary>
        public Keys Hotkey
        {
            get;
            private set;
        }

        /// <summary>
        /// Returns the sound volume selected from the trackbar.
        /// </summary>
        public double Volume
        {
            get
            {
                return volumeTrackBar.Value / 100.0;
            }
        }

        /// <summary>
        /// Returns the selected SoundRepeatMode.
        /// </summary>
        public SoundRepeatMode RepeatMode
        {
            get
            {
                if (overlapRadioButton.Checked)
                    return SoundRepeatMode.Overlap;
                else if (startOverRadioButton.Checked)
                    return SoundRepeatMode.StartOver;
                else
                    return SoundRepeatMode.CancelPlayback;
            }
        }

        /// <summary>
        /// Returns the large text covering the button.
        /// </summary>
        public String ButtonText
        {
            get
            {
                return buttonTextBox.Text;
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public PropertiesForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens a file dialog for the user to select the sound filepath.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soundPathButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            soundPathTextBox.Text = openFileDialog.FileName;
        }

        /// <summary>
        /// Sets the hotkey depending on what key is pressed when the hotkeyTextBox has focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotkeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Hotkey = e.KeyCode;
            hotkeyTextBox.Text = e.KeyCode.ToString();
        }

        /// <summary>
        /// Sets the volume label to represent the volume trackbar value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            volumeLabel.Text = "Volume:\n" + volumeTrackBar.Value.ToString() + "0%";
        }
    }
}
