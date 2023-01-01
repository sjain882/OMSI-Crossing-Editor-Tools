using IniParser;
using IniParser.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace OMSICrossingEditorTools
{
    class IniFile
    {

        // Declarations
        private const string iniFileName = "OMSICrossingEditorTools.ini";
        private string iniFilePath = "";

        // Replicate fields from .ini file as C# attributes
        public float ScrollUp { get; set; }
        public float ScrollDown { get; set; }
        public float ShiftScrollUp { get; set; }
        public float ShiftScrollDown { get; set; }
        public float MinZoom { get; set; }
        public float MaxZoom { get; set; }
        public float MinFov { get; set; }
        public float MaxFov { get; set; }
        public float DefaultZoom { get; set; }
        public float DefaultFov { get; set; }


        // Constructor
        public IniFile()
        {
            // Get ini file path from .exe file location (not working directory)
            // Avoids problems with e.g., running as admin from cmd...
            this.iniFilePath = Path.Combine(
                                    Path.GetDirectoryName(
                                            Assembly.GetExecutingAssembly().Location),
                                                                        iniFileName);

            SetIniDefaults();

        }


        private void SetIniDefaults()
        {
            // C# Defaults Initial Values

            // [ScrollWheel]
            ScrollUp = (float)5.0;
            ScrollDown = (float)5.0;
            ShiftScrollUp = (float)20.0;
            ShiftScrollDown = (float)20.0;

            // [Limits]
            MinZoom = (float)1.0;
            MaxZoom = (float)300.0;
            MinFov = (float)5.0;
            MaxFov = (float)120.0;

            // [Defaults]
            DefaultZoom = (float)100.0;
            DefaultFov = (float)30.0;

        }


        public string GetIniFilePath()
        {
            return iniFilePath;
        }


        public bool CreateDefaultIni()
        {
            try
            {
                // If an .ini file with the same name exists, send to recycle bin
                if (File.Exists(iniFilePath))
                {
                    FileSystem.DeleteFile(iniFilePath,
                                        UIOption.OnlyErrorDialogs,
                                        RecycleOption.SendToRecycleBin);
                }

                // Check to ensure that was successful
                if (!File.Exists(iniFilePath))
                {

                    // Create an empty .ini file
                    File.Create(iniFilePath).Dispose();

                    // Write the .ini contents in the user's language
                    using (StreamWriter writer = new StreamWriter(iniFilePath))
                    {
                        writer.WriteLine("");
                        writer.WriteLine(Languages.Strings.iniHeader);
                        writer.WriteLine("; ");
                        writer.WriteLine(Languages.Strings.iniUsage);
                        writer.WriteLine(Languages.Strings.iniSection);
                        writer.WriteLine(Languages.Strings.iniSetting);
                        writer.WriteLine("");
                        writer.WriteLine("");
                        writer.WriteLine("; ============================================================================");
                        writer.WriteLine("");
                        writer.WriteLine("");
                        writer.WriteLine(Languages.Strings.iniScroll1);
                        writer.WriteLine(Languages.Strings.iniScroll2);
                        writer.WriteLine(Languages.Strings.iniScroll3);
                        writer.WriteLine("[ScrollWheel]");
                        writer.WriteLine(Languages.Strings.iniValidValuesNumbers);
                        writer.WriteLine("ScrollUp = 5.0");
                        writer.WriteLine("ScrollDown = 5.0");
                        writer.WriteLine("ShiftScrollUp = 20.0");
                        writer.WriteLine("ShiftScrollDown = 20.0");
                        writer.WriteLine("");
                        writer.WriteLine("");
                        writer.WriteLine("; ============================================================================");
                        writer.WriteLine("");
                        writer.WriteLine("");
                        writer.WriteLine(Languages.Strings.iniLimits);
                        writer.WriteLine("[Limits]");
                        writer.WriteLine(Languages.Strings.iniValidValuesNumbers);
                        writer.WriteLine("MinZoom = 1.0");
                        writer.WriteLine("MaxZoom = 300.0");
                        writer.WriteLine("MinFov = 5.0");
                        writer.WriteLine("MaxFov = 120.0");
                        writer.WriteLine("");
                        writer.WriteLine("");
                        writer.WriteLine("; ============================================================================");
                        writer.WriteLine("");
                        writer.WriteLine("");
                        writer.WriteLine(Languages.Strings.iniDefaults1);
                        writer.WriteLine("[Defaults]");
                        writer.WriteLine(Languages.Strings.iniValidValuesNumbers);
                        writer.WriteLine(Languages.Strings.iniDefaults2);
                        writer.WriteLine("DefaultZoom = 100.0");
                        writer.WriteLine("DefaultFov = 30.0");
                        writer.WriteLine("");
                        writer.WriteLine("");

                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                SetIniDefaults();
                return false;
            }
        }


        // Load .ini file from disk & read its values into C#
        public bool Init()
        {

            // Success status
            bool returnValue = false;

            // Check if the .ini exists
            if (File.Exists(iniFilePath))
            {

                try
                {
                    var parser = new FileIniDataParser();
                    IniData iniFile = parser.ReadFile(iniFilePath);

                    // [MouseWheel]
                    ScrollUp = float.Parse(iniFile["ScrollWheel"]["ScrollUp"], CultureInfo.InvariantCulture);
                    ScrollDown = float.Parse(iniFile["ScrollWheel"]["ScrollDown"], CultureInfo.InvariantCulture);
                    ShiftScrollUp = float.Parse(iniFile["ScrollWheel"]["ShiftScrollUp"], CultureInfo.InvariantCulture);
                    ShiftScrollDown = float.Parse(iniFile["ScrollWheel"]["ShiftScrollDown"], CultureInfo.InvariantCulture);

                    // [Limits]
                    MinZoom = float.Parse(iniFile["Limits"]["MinZoom"], CultureInfo.InvariantCulture);
                    MaxZoom = float.Parse(iniFile["Limits"]["MaxZoom"], CultureInfo.InvariantCulture);
                    MinFov = float.Parse(iniFile["Limits"]["MinFov"], CultureInfo.InvariantCulture);
                    MaxFov = float.Parse(iniFile["Limits"]["MaxFov"], CultureInfo.InvariantCulture);

                    // [Defaults]
                    DefaultZoom = float.Parse(iniFile["Defaults"]["DefaultZoom"], CultureInfo.InvariantCulture);
                    DefaultFov = float.Parse(iniFile["Defaults"]["DefaultFov"], CultureInfo.InvariantCulture);

                    // If defaults or limits are below 1, force them to 1
                    // to prevent division by zero errors in the tool
                    if (MinZoom < 1) { MinZoom = 1; }
                    if (MinFov < 1) { MinFov = 1; }
                    if (DefaultZoom < 1) { DefaultZoom = 1; }
                    if (DefaultFov < 1) { DefaultFov = 1; }

                    /* Debug
                    MessageBox.Show("ScrollUp set no 1: " + ScrollUp.ToString() + "\r\n"
                    + "ScrollDown set: " + ScrollDown.ToString() + "\r\n"
                    + "ShiftScrollUp set: " + ShiftScrollUp.ToString() + "\r\n"
                    + "ShiftScrollDown set: " + ShiftScrollDown.ToString() + "\r\n"
                    + "MinZoom set: " + MinZoom.ToString() + "\r\n"
                    + "MaxZoom set: " + MaxZoom.ToString() + "\r\n"
                    + "MinFov set: " + MinFov.ToString() + "\r\n"
                    + "MaxFov set: " + MaxFov.ToString() + "\r\n"
                    + "DefaultZoom set: " + DefaultZoom.ToString() + "\r\n"
                    + "DefaultFov set: " + DefaultFov.ToString() + "\r\n");*/
                }
                catch (Exception ex)
                {

                    /* Stack trace debug
                    new Thread(() => {

                        // Get stack trace for the exception with source file information
                        var st = new StackTrace(ex, true);

                        // Get the top stack frame
                        var frame = st.GetFrame(0);

                        // Get the line number from the stack frame
                        var line = frame.GetFileLineNumber();

                        MessageBox.Show(line.ToString());
                        MessageBox.Show(ex.ToString());
                    }).Start();
                    */

                    SetIniDefaults();
                    return false;
                }

                // Success
                returnValue = true;
            }
            // If the file doesn't exist
            else
            {

                try
                {
                    CreateDefaultIni();
                }
                catch (Exception ex)
                {
                    /* Stack trace debug
                    new Thread(() => {

                        // Get stack trace for the exception with source file information
                        var st = new StackTrace(ex, true);

                        // Get the top stack frame
                        var frame = st.GetFrame(0);

                        // Get the line number from the stack frame
                        var line = frame.GetFileLineNumber();

                        MessageBox.Show(line.ToString());
                        MessageBox.Show(ex.ToString());
                    }).Start();
                    */

                    SetIniDefaults();
                    return false;
                }
                // Success
                returnValue = true;
            }
            return returnValue;
        }
    }
}