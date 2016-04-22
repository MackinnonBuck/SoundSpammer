using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundSpammer
{
    static class Program
    {
        /// <summary>
        /// Used for setting the WindowState of all active windows.
        /// </summary>
        public static FormWindowState GlobalWindowState
        {
            set
            {
                foreach (MainWindow window in activeWindows)
                    window.WindowState = value;
            }
        }

        /// <summary>
        /// Used for showing/hiding all the windows at once.
        /// </summary>
        public static bool WindowsVisible
        {
            set
            {
                foreach (MainWindow window in activeWindows)
                    window.Visible = value;

                notifyIcon.Visible = !value;
            }
        }

        /// <summary>
        /// Keeps track of every active window.
        /// </summary>
        private static List<MainWindow> activeWindows;

        /// <summary>
        /// The icon to appear in the notification area when the windows are hidden.
        /// </summary>
        private static NotifyIcon notifyIcon;

        /// <summary>
        /// Removes the window from the activeWindows list when it is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            activeWindows.Remove((MainWindow)sender);

            if (activeWindows.Count == 0)
                Application.Exit();
        }

        /// <summary>
        /// Simply shows a new MainWindow instance.
        /// </summary>
        public static MainWindow AddWindow(MainWindow relativeWindow)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.FormClosed += MainWindow_FormClosed;

            if (relativeWindow != null)
            {
                mainWindow.StartPosition = FormStartPosition.Manual;
                mainWindow.Location = new System.Drawing.Point(relativeWindow.Location.X + 24, relativeWindow.Location.Y + 24);
            }

            mainWindow.Show();

            activeWindows.Add(mainWindow);

            return mainWindow;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (System.Diagnostics.Process.GetProcessesByName(
                System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
            {
                MessageBox.Show(
                    "Another instance of Sound Spammer is already running.\nPlease open new files from within the existing Sound Spammer instance.",
                    "Unable to start Sound Spammer.");
                return;
            }

            activeWindows = new List<MainWindow>();

            if (args.Length == 0)
            {
                AddWindow(null);
            }
            else
            {
                MainWindow currentWindow = null;

                foreach (string file in args)
                {
                    currentWindow = AddWindow(currentWindow);
                    currentWindow.ChildPropertiesForm.ReadProperties(file);
                }
            }

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = activeWindows.First().Icon;
            notifyIcon.Click += NotifyIcon_Click;

            Application.Run();
        }

        /// <summary>
        /// Shows all windows when the notify icon is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void NotifyIcon_Click(object sender, EventArgs e)
        {
            WindowsVisible = true;
        }
    }
}
