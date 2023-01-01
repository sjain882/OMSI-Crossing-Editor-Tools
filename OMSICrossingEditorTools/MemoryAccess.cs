using Memory;
using System.Diagnostics;

namespace OMSICrossingEditorTools
{
    class MemoryAccess
    {
        // Declarations
        private Process[] processes;
        private Mem memory;

        // Pointers
        // The 4 bytes at this location are the pointer to the camera struct
        // (caution: little endian)
        // However memory.dll auto-evaluates / follows that pointer,
        // so we can just give it the location of the pointer.
        private const string cameraPointerLocation = "OmsiObjEditP.exe+0xE93A0";

        // Camera struct offsets
        private const string zoomOffset = "0x20";
        private const string fovOffset = "0x24";


        // Constructor
        public MemoryAccess() { }


        public int CheckIfRunning()
        {
            int runningStatus = -1;          // Function failure (default)

            processes = Process.GetProcessesByName("OmsiObjEditP");
            if (processes.Length == 0)
                runningStatus = 0;           // Not running
            else if (processes.Length > 1)
                runningStatus = 1;           // Multiple instances (unsupported)
            else if (processes.Length == 1)
                runningStatus = 2;           // Single instance (good)

            return runningStatus;
        }


        public bool OpenProcess()
        {
            bool status = false;
            memory = new Mem();
            status = memory.OpenProcess("OmsiObjEditP.exe");
            return status;
        }


        public float GetZoom()
        {
            // We don't check if Mem memory has been initialised here, for speed.
            // I've setup the program so it should be impossible to trigger this
            // function before Mem memory has been instantiated.
            // Even if that happens, however, memory.dll has covered this and
            // the function will just return false rather than attempt to write
            // to random memory.
            // CAUTION: Be aware that these get and set method formulate STRINGS
            // because memory.dll actually takes strings, it's basically a very
            // very dumbed down wrapper on Read/WriteProcessMemory
            return memory.ReadFloat(cameraPointerLocation + ", " + zoomOffset);
        }

        public float GetFov()
        {
            return memory.ReadFloat(cameraPointerLocation + ", " + fovOffset);
        }

        public void SetZoom(float newZoom)
        {
            memory.WriteMemory(cameraPointerLocation + ", " + zoomOffset,
                               "float",
                               newZoom.ToString());
        }

        public void SetFov(float newFov)
        {
            memory.WriteMemory(cameraPointerLocation + ", " + fovOffset,
                               "float",
                               newFov.ToString());
        }
    }
}