using System;
using System.Runtime.InteropServices;
using System.Text;

namespace OMSICrossingEditorTools
{
    static class Interop
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int key);

        // Gets the title of the currently focused window.
        // https://stackoverflow.com/a/32965421/12948636
        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
    }
}