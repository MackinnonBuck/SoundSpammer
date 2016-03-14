using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace SoundSpammer
{
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The filepath and key for the released button image.
        /// </summary>
        private const string IMAGE_BUTTON_RELEASED = "button_released.png";

        /// <summary>
        /// The filepath and key for the pressed button image.
        /// </summary>
        private const string IMAGE_BUTTON_PRESSED = "button_pressed.png";
        
        /// <summary>
        /// The properties form that contains customizable settings.
        /// </summary>
        private PropertiesForm propertiesForm;

        /// <summary>
        /// The hook used to get keyboard input without window focus.
        /// </summary>
        private IKeyboardMouseEvents globalHook;

        /// <summary>
        /// Contains the active MediaPlayers and ensures that a reference is kept until the playback finishes.
        /// </summary>
        List<MediaPlayer> activePlayers;

        /// <summary>
        /// Returns true if a sound is currently playing.
        /// </summary>
        private bool IsSoundPlaying
        {
            get
            {
                return activePlayers.Count > 0;
            }
        }

        /// <summary>
        /// Gets or sets the value of the spam label.
        /// </summary>
        public string SpamLabel
        {
            get
            {
                return spamLabel.Text;
            }
            set
            {
                spamLabel.Text = value;
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
            spamLabel.Parent = buttonPictureBox;
            spamLabel.Dock = DockStyle.Fill;

            propertiesForm = new PropertiesForm(this);

            globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalKeyDown;
            globalHook.KeyUp += GlobalKeyUp;

            activePlayers = new List<MediaPlayer>();

            ButtonRelease();
        }

        /// <summary>
        /// Creates a new MediaPlayer that plays the sound selected from the Properties window.
        /// </summary>
        private void StartSound()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;

            mediaPlayer.Open(new Uri(propertiesForm.SoundFilePath));
            mediaPlayer.Volume = propertiesForm.Volume;
            mediaPlayer.Play();

            activePlayers.Add(mediaPlayer);
        }

        /// <summary>
        /// Stops all currently playing sounds.
        /// </summary>
        private void StopAllSounds()
        {
            foreach (MediaPlayer player in activePlayers)
                player.Close();

            activePlayers.Clear();
        }

        /// <summary>
        /// Plays the sound and changes the button's image when the desired effect is requested.
        /// </summary>
        private void ButtonPress()
        {
            if (propertiesForm.Visible)
                return;

            buttonPictureBox.BackgroundImage = buttonImageList.Images[IMAGE_BUTTON_PRESSED];
            
            if (propertiesForm.SoundFilePath.Length > 0)
            {
                try
                {
                    switch (propertiesForm.RepeatMode)
                    {
                        case PropertiesForm.SoundRepeatMode.Overlap:
                            StartSound();
                            break;
                        case PropertiesForm.SoundRepeatMode.StartOver:
                            StopAllSounds();
                            StartSound();
                            break;
                        case PropertiesForm.SoundRepeatMode.CancelPlayback:
                            if (IsSoundPlaying)
                                StopAllSounds();
                            else
                                StartSound();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not play sound.");
                    ButtonRelease();
                }
            }
            else
            {
                MessageBox.Show("Please select a sound file in Edit->Properties.", "Could not play sound.");
                ButtonRelease();
            }
        }
        
        /// <summary>
        /// Changes the button's image to the released image.
        /// </summary>
        private void ButtonRelease()
        {
            buttonPictureBox.BackgroundImage = buttonImageList.Images[IMAGE_BUTTON_RELEASED];
        }

        /// <summary>
        /// Simulates a button press when the hotkey is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == propertiesForm.Hotkey)
                ButtonPress();
        }

        /// <summary>
        /// Simulates a button release when the hotkey is pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlobalKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == propertiesForm.Hotkey)
                ButtonRelease();
        }

        /// <summary>
        /// Removes the reference to the MediaPlayer whose playback has finished.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            MediaPlayer player = (MediaPlayer)sender;
            player.Close();
            activePlayers.Remove(player);
        }

        /// <summary>
        /// Simulates a button press when the label (completely covering the button) was pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spamLabel_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPress();
        }

        /// <summary>
        /// Simulates a button release when the label (completely covering the button) was released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void spamLabel_MouseUp(object sender, MouseEventArgs e)
        {
            ButtonRelease();
        }

        /// <summary>
        /// Creates a new instance of the application when the New Instance menu item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(Application.ExecutablePath));
        }

        /// <summary>
        /// Opens an existing Spam file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAllSounds();
            propertiesForm.ReadProperties();
        }

        /// <summary>
        /// Saves the application's properties specified in the properties window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propertiesForm.WriteProperties();
        }

        /// <summary>
        /// Shows the save dialog and saves the application's properties specified in the properties window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            propertiesForm.WriteProperties(true);
        }

        /// <summary>
        /// Exits the application when the Exit menu item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Opens the properties window when the Properties menu item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StopAllSounds();
            propertiesForm.ShowDialog(this);

            spamLabel.Text = propertiesForm.ButtonText;

            if (propertiesForm.SoundFilePath.Length > 0)
            {
                soundPathLabel.Text = propertiesForm.SoundFilePath;
                soundPathToolTip.SetToolTip(soundPathLabel, propertiesForm.SoundFilePath);
                Text = propertiesForm.SoundFileName;
            }
        }

        /// <summary>
        /// Restores the window (if necessary) and resizes it when the Reset Size menu item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;

            Size = MinimumSize;
        }

        /// <summary>
        /// Displayes a message about the application when the About menu item is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("... this is what happens when you get bored and want to troll people on Rocket League.\n\nMade by Mackinnon Buck.", "Well...");
        }
    }
}
