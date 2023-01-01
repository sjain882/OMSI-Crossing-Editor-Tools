using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OMSICrossingEditorTools
{
    class Run
    {
        [STAThread]
        static void Main()
        {

            /* Debug Force Language 
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pl-PL");
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("pl-PL");
            MessageBox.Show(Thread.CurrentThread.CurrentUICulture.ToString());
            MessageBox.Show(System.Globalization.CultureInfo.DefaultThreadCurrentCulture.ToString());*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CrossingEditorTools instance = new CrossingEditorTools();
            Application.Run(instance);

        }
    }
}