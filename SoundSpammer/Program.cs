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
        /// Keeps track of every active window.
        /// </summary>
        private static List<MainWindow> activeWindows;

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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            activeWindows = new List<MainWindow>();
            AddWindow(null);

            Application.Run();
        }
    }
}
