using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        public string SoundFilePath
        {
            get
            {
                return soundPathOpenFileDialog.FileName;
            }
            private set
            {
                soundPathOpenFileDialog.FileName = value;
                soundPathTextBox.Text = value;
            }
        }

        /// <summary>
        /// Returns the file name of the sound.
        /// </summary>
        public string SoundFileName
        {
            get
            {
                return soundPathOpenFileDialog.SafeFileName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Keys _hotkey;

        /// <summary>
        /// Sets and gets the key that triggers sound playback.
        /// </summary>
        public Keys Hotkey
        {
            get
            {
                return _hotkey;
            }
            private set
            {
                _hotkey = value;
                hotkeyTextBox.Text = value.ToString();
            }
        }

        /// <summary>
        /// Returns the sound volume selected from the trackbar.
        /// </summary>
        public double Volume
        {
            get
            {
                return (float)volumeTrackBar.Value / volumeTrackBar.Maximum;
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
            set
            {
                switch (value)
                {
                    case SoundRepeatMode.Overlap:
                        overlapRadioButton.Checked = true;
                        break;
                    case SoundRepeatMode.StartOver:
                        startOverRadioButton.Checked = true;
                        break;
                    case SoundRepeatMode.CancelPlayback:
                        cancelPlaybackRadioButton.Checked = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Returns the large text covering the button.
        /// </summary>
        public string ButtonText
        {
            get
            {
                return buttonTextBox.Text;
            }
            private set
            {
                buttonTextBox.Text = value;
                parentWindow.SpamLabel = value;
            }
        }

        /// <summary>
        /// Stores the value of the save path.
        /// </summary>
        private string _savePath;

        /// <summary>
        /// The path to which properties are saved.
        /// </summary>
        public string SavePath
        {
            get
            {
                return _savePath;
            }
            private set
            {
                _savePath = value;
                parentWindow.SoundFilePath = value;
                parentWindow.Text = new FileInfo(value).Name;
            }
        }

        /// <summary>
        /// The parent MainWindow.
        /// </summary>
        private MainWindow parentWindow;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public PropertiesForm(MainWindow parent)
        {
            InitializeComponent();

            parentWindow = parent;
        }

        /// <summary>
        /// Shows the SaveDialog and gets the save path if one is provided.
        /// </summary>
        /// <returns>True if the user selects a file.</returns>
        public bool RequestSavePath()
        {
            if (saveFileDialog.ShowDialog(parentWindow) != DialogResult.OK)
                return false;

            SavePath = saveFileDialog.FileName;
            parentWindow.SoundFilePath = saveFileDialog.FileName;

            return true;
        }

        /// <summary>
        /// Writes the current properties to the user-selected file.
        /// </summary>
        /// <param name="mustRequestSavePath"></param>
        public void SaveProperties(bool mustRequestSavePath = false)
        {
            if (SavePath == null || mustRequestSavePath)
                if (!RequestSavePath())
                    return;

            StreamWriter propertiesWriter = new StreamWriter(SavePath);

            if (SoundFilePath.Length > 0)
                propertiesWriter.WriteLine("SoundPath=" + SoundFilePath);

            if (Hotkey != Keys.None)
                propertiesWriter.WriteLine("Hotkey=" + Hotkey.ToString());

            propertiesWriter.WriteLine("Volume=" + volumeTrackBar.Value.ToString());
            propertiesWriter.WriteLine("RepeatMode=" + RepeatMode.ToString());
            propertiesWriter.WriteLine("ButtonText=" + ButtonText);

            propertiesWriter.Close();
        }

        /// <summary>
        /// Used for iterating through properties of a Spam file.
        /// </summary>
        /// <param name="propertyReader"></param>
        /// <returns></returns>
        private IEnumerable<KeyValuePair<string, string>> ParseProperties(StreamReader propertyReader)
        {
            while (!propertyReader.EndOfStream)
            {
                string currentLine = propertyReader.ReadLine();
                int equalsIndex = currentLine.IndexOf('=');

                yield return new KeyValuePair<string, string>(
                    currentLine.Substring(0, equalsIndex),
                    currentLine.Substring(equalsIndex + 1));
            }
        }

        /// <summary>
        /// Reads and loads properties from the given file.
        /// </summary>
        /// <param name="filepath"></param>
        public void ReadProperties(string filepath)
        {
            StreamReader propertiesReader = new StreamReader(filepath);

            foreach (KeyValuePair<string, string> property in ParseProperties(propertiesReader))
            {
                switch (property.Key)
                {
                    case "SoundPath":
                        SoundFilePath = property.Value;
                        break;
                    case "Hotkey":
                        Hotkey = (Keys)Enum.Parse(typeof(Keys), property.Value);
                        break;
                    case "Volume":
                        volumeTrackBar.Value = int.Parse(property.Value);
                        break;
                    case "RepeatMode":
                        RepeatMode = (SoundRepeatMode)Enum.Parse(typeof(SoundRepeatMode), property.Value);
                        break;
                    case "ButtonText":
                        ButtonText = property.Value;
                        break;
                }
            }

            propertiesReader.Close();

            SavePath = filepath;
        }

        /// <summary>
        /// Shows the spamOpenFileDialog and reads and loads the spam file selected.
        /// </summary>
        public void OpenProperties(bool readAsNew = false)
        {
            if (spamOpenFileDialog.ShowDialog(parentWindow) != DialogResult.OK)
                return;

            if (!readAsNew)
                ReadProperties(spamOpenFileDialog.FileNames[0]);

            MainWindow lastWindow = parentWindow;

            for (int i = readAsNew ? 0 : 1; i < spamOpenFileDialog.FileNames.Length; i++)
            {
                MainWindow newWindow = Program.AddWindow(lastWindow);
                newWindow.ChildPropertiesForm.ReadProperties(spamOpenFileDialog.FileNames[i]);
                lastWindow = newWindow;
            }
        }

        /// <summary>
        /// Opens a file dialog for the user to select the sound filepath.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void soundPathButton_Click(object sender, EventArgs e)
        {
            if (soundPathOpenFileDialog.ShowDialog(this) != DialogResult.OK)
                return;

            soundPathTextBox.Text = soundPathOpenFileDialog.FileName;
        }

        /// <summary>
        /// Sets the hotkey depending on what key is pressed when the hotkeyTextBox has focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotkeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Hotkey = e.KeyCode;
        }

        /// <summary>
        /// Sets the volume label to represent the volume trackbar value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void volumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            volumeLabel.Text = "Volume:\n" + ((float)volumeTrackBar.Value / volumeTrackBar.Maximum * 100.0f) + "%";
        }
    }
}
