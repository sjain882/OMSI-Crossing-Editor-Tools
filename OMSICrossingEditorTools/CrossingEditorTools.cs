using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WinputManager;

// IMPORTANT: Must be compiled in x86 (NOT Any CPU)

namespace OMSICrossingEditorTools
{
    public class CrossingEditorTools : ApplicationContext
    {

        // Declarations
        private NotifyIcon trayIcon;

        private MemoryAccess memoryAccess;

        private MouseHook mouseWheel;

        private IniFile iniFile;

        // Strings
        private string appName = "OMSI Crossing Editor Tools";

        private string targetName = "OMSI Crossing Editor";

        private string errorGeneric = Languages.Strings.ErrorGeneric;

        private string errorToolNotRunning = Languages.Strings.ErrorToolNotRunning;

        private string errorMultipleInstances = Languages.Strings.ErrorMultipleInstances;

        private string errorFailedToEnableTool = Languages.Strings.ErrorFailedToEnableTool;

        private string errorBadIniFile = Languages.Strings.ErrorBadIniFile;

        private string errorDefaultIni = Languages.Strings.ErrorDefaultIni;

        private string confirmDefaults = Languages.Strings.ConfirmDefaults;

        private string trayMenuEnable = Languages.Strings.TrayMenuEnable;

        private string trayMenuDisable = Languages.Strings.TrayMenuDisable;

        private string trayMenuEdit = Languages.Strings.TrayMenuEdit;

        private string trayMenuReload = Languages.Strings.TrayMenuReload;

        private string trayMenuRestore = Languages.Strings.TrayMenuRestore;

        private string trayMenuHelp = Languages.Strings.TrayMenuHelp;

        private string trayMenuExit = Languages.Strings.TrayMenuExit;

        private string referToReadme = Languages.Strings.ReferToReadme;



        /* -----------------------------  Core  ----------------------------- */

        // Constructor
        public CrossingEditorTools()
        {

            /* Start GUI in a new thread (disabled)
            Thread TrayThread = new Thread(LaunchTray);
            TrayThread.Start(); */

            // Instantiation
            memoryAccess = new MemoryAccess();
            mouseWheel = new MouseHook();
            iniFile = new IniFile();

            // First launch status is stored in %localappdata%
            // But if you move the .exe to a new location, it will reset this
            // Windows will generate a new config for that app path only
            if (Properties.Settings.Default.FirstRun == true)
            {

                // First launch message
                MessageBox.Show(Languages.Strings.FirstLaunchMessage,
                                Languages.Strings.FirstLaunchMessageTitle,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                // Ensure the user's ini is in the correct language
                iniFile.CreateDefaultIni();

                // Update first launch status
                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.Save();
            }

            ReloadSettings();

            // Start GUI
            LaunchTray();
        }
        private void ReloadSettings()
        {
            // Attempt to read .ini file from disk
            // If unsuccessful... (murky reason)
            if (!iniFile.Init())
            {

                // Prompt user to reset to defaults or let them manually fix it
                DialogResult dialogResult = MessageBox.Show(
                                                errorBadIniFile,
                                                appName,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Error);

                // Re-create default .ini file and load it if confirmed
                if (dialogResult == DialogResult.Yes)
                {
                    if (!iniFile.CreateDefaultIni())
                    {
                        MessageBox.Show(errorDefaultIni,
                                        appName,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }

                    if (!iniFile.Init())
                    {
                        MessageBox.Show(errorBadIniFile,
                                        appName,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }

        private void EnableTool()
        {

            // Check if OmsiObjEditP.exe is running first
            int crossingEditorStatus = memoryAccess.CheckIfRunning();

            switch (crossingEditorStatus)
            {
                // WARNING: This switch case uses fallthroughs / cascades!
                // Fail: Unknown error
                case -1:
                default:
                    trayIcon.ContextMenu.MenuItems[1].Checked = false;
                    trayIcon.ContextMenu.MenuItems[2].Checked = true;
                    MessageBox.Show(
                        errorGeneric,
                        appName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    break;

                // Fail: Not running
                case 0:
                    trayIcon.ContextMenu.MenuItems[1].Checked = false;
                    trayIcon.ContextMenu.MenuItems[2].Checked = true;
                    MessageBox.Show(
                        errorToolNotRunning,
                        appName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    break;

                // Fail: Multiple instances
                case 1:
                    trayIcon.ContextMenu.MenuItems[1].Checked = false;
                    trayIcon.ContextMenu.MenuItems[2].Checked = true;
                    MessageBox.Show(
                        errorMultipleInstances,
                        appName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    break;

                // Success: Single instance
                case 2:
                    break;
            }
            
            if (crossingEditorStatus == 2)
            {
                if (memoryAccess.OpenProcess())
                {
                    // Start the mouse wheel functionality
                    StartMouseHook();
                        
                    // Set the default values
                    memoryAccess.SetZoom(iniFile.DefaultZoom);
                    memoryAccess.SetFov(iniFile.DefaultFov);
                }
                else
                {
                    MessageBox.Show(
                        errorFailedToEnableTool,
                        appName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        } 

        private void DisableTool()
        {
            StopMouseHook();
        }



        /* --------------------------  Mouse Hook  -------------------------- */

        public void StartMouseHook()
        {
            mouseWheel.OnMouseWheelEvent += MouseHook_OnMouseWheelEvent;
            mouseWheel.Install();
        }

        public void StopMouseHook()
        {
            mouseWheel.OnMouseWheelEvent -= MouseHook_OnMouseWheelEvent;
            mouseWheel.Uninstall();
        }

        // On each mouse wheel scroll
        public bool MouseHook_OnMouseWheelEvent(int wheelValue)
        {
            /* Debug
            Console.WriteLine(String.Format("{0} mouse wheel value captured",
                            (MouseHook.MouseWheelEvents)wheelValue).ToString()); */

            // Only proceed if OmsiObjEditP.exe is focused
            if (Interop.GetActiveWindowTitle() == targetName)
            {
                // Scroll up
                if (wheelValue < 0)
                {
                    // Holding Shift key
                    if ((Interop.GetAsyncKeyState(0x10) & 0x8000) > 0)
                    {
                        // Calculate the resultant value
                        float targetZoom = (memoryAccess.GetZoom() + iniFile.ShiftScrollDown);

                        // Only apply it if its within the limits
                        if (targetZoom <= iniFile.MaxZoom) { memoryAccess.SetZoom(targetZoom); }
                    }
                    // Holding Alt key
                    else if ((Interop.GetAsyncKeyState(0x11) & 0x8000) > 0)
                    {
                        float targetFov = (memoryAccess.GetFov() + iniFile.ScrollDown);
                        if (targetFov <= iniFile.MaxFov) { memoryAccess.SetFov(targetFov); }
                    }
                    else
                    {
                        float targetZoom = (memoryAccess.GetZoom() + iniFile.ScrollDown);
                        if (targetZoom <= iniFile.MaxZoom) { memoryAccess.SetZoom(targetZoom); }
                    }

                }
                // Scroll down
                else
                {
                    // Holding Shift key
                    if ((Interop.GetAsyncKeyState(0x10) & 0x8000) > 0)
                    {
                        float targetZoom = (memoryAccess.GetZoom() - iniFile.ShiftScrollUp);
                        if (targetZoom >= iniFile.MinZoom) { memoryAccess.SetZoom(targetZoom); }
                    }
                    // Holding Alt key
                    else if ((Interop.GetAsyncKeyState(0x11) & 0x8000) > 0)
                    {
                        float targetFov = (memoryAccess.GetFov() - iniFile.ScrollUp);
                        if (targetFov >= iniFile.MinFov ) { memoryAccess.SetFov(targetFov); }
                    }
                    else
                    {
                        float targetZoom = (memoryAccess.GetZoom() - iniFile.ScrollUp);
                        if (targetZoom >= iniFile.MinZoom) { memoryAccess.SetZoom(targetZoom); }
                    }
                }
            }
            return false; // For some reason, this is required by WInputManager
        }



        /* -----------------------------  Tray  ----------------------------- */

        // GUI Start Method
        private void LaunchTray()
        {

            trayIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.Icon,

                ContextMenu = new ContextMenu(new MenuItem[]
                {
                        new MenuItem (appName, TrayEnable), // Dummy
                        new MenuItem (trayMenuEnable, TrayEnable),
                        new MenuItem (trayMenuDisable, TrayDisable),
                        new MenuItem (trayMenuEdit, TrayEditSettings),
                        new MenuItem (trayMenuReload, TrayReloadSettings),
                        new MenuItem (trayMenuRestore, TrayRestoreDefaultSettings),
                        new MenuItem (trayMenuHelp, TrayHelpAbout),
                        new MenuItem (trayMenuExit, TrayExit)
                }),

                Visible = true
            };

            // Make the app name entry unclickable / greyed out
            trayIcon.ContextMenu.MenuItems[0].Enabled = false;

            // GUI reflects initial tool state (disabled)
            trayIcon.ContextMenu.MenuItems[1].Checked = false;
            trayIcon.ContextMenu.MenuItems[2].Checked = true;

            // Hover tooltip
            trayIcon.Text = appName;
        }

        public void TrayEnable(object sender, EventArgs e)
        {
            EnableTool();
            trayIcon.ContextMenu.MenuItems[1].Checked = true;
            trayIcon.ContextMenu.MenuItems[2].Checked = false;
        }

        public void TrayDisable(object sender, EventArgs e)
        {
            DisableTool();
            trayIcon.ContextMenu.MenuItems[1].Checked = false;
            trayIcon.ContextMenu.MenuItems[2].Checked = true;
        }

        public void TrayEditSettings(object sender, EventArgs e)
        {

            // Confirm the .ini file exists
            if (File.Exists(iniFile.GetIniFilePath()))
            {

                // Open file using default program
                using (Process fileopener = new Process())
                {

                    fileopener.StartInfo.FileName = "explorer";
                    fileopener.StartInfo.Arguments = "\""
                                                    + iniFile.GetIniFilePath()
                                                    + "\"";
                    fileopener.Start();
                }
            }
        }

        public void TrayReloadSettings(object sender, EventArgs e)
        {
            ReloadSettings();
        }

        public void TrayRestoreDefaultSettings(object sender, EventArgs e)
        {
            // Confirmation dialog
            DialogResult dialogResult = MessageBox.Show(confirmDefaults,
                                                        appName,
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                iniFile.CreateDefaultIni();
                iniFile.Init();
            }
        }

        public void TrayHelpAbout(object sender, EventArgs e)
        {
            // After webdisk calendar
            // System.Diagnostics.Process.Start("http://github.com/sjain882/OMSI-Crossing-Editor-Tools");

            // New thread - don't block main program as this isn't a critical dialog
            new Thread(() => {

                MessageBox.Show(referToReadme,
                                appName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                }).Start();
        }

        public void TrayExit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Environment.Exit(0);
        }
    }
}