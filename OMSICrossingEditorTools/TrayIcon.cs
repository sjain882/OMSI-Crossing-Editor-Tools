using System.Windows.Forms;

namespace OMSICrossingEditorTools
{
    class TrayIcon
    {
        private NotifyIcon trayIcon;

        public TrayIcon(NotifyIcon notifyIcon)
        {
            trayIcon = notifyIcon;
        }
    }
}