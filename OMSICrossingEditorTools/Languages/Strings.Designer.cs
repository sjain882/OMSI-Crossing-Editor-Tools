﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OMSICrossingEditorTools.Languages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("OMSICrossingEditorTools.Languages.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OMSI Crossing Editor Tools.
        /// </summary>
        public static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to restore the default settings?
        ///Your existing settings will be sent to the Recycle Bin..
        /// </summary>
        public static string ConfirmDefaults {
            get {
                return ResourceManager.GetString("ConfirmDefaults", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The .ini configuration file is either missing or invalid!
        ///Would you like to create/restore the default settings (Yes), or manually fix them yourself (No)?.
        /// </summary>
        public static string ErrorBadIniFile {
            get {
                return ResourceManager.GetString("ErrorBadIniFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to create the default .ini configuration file. Please try again later.
        ///If this error persists, please contact the author of this software..
        /// </summary>
        public static string ErrorDefaultIni {
            get {
                return ResourceManager.GetString("ErrorDefaultIni", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to enable the tool, for some reason.
        ///Please contact the author of this software..
        /// </summary>
        public static string ErrorFailedToEnableTool {
            get {
                return ResourceManager.GetString("ErrorFailedToEnableTool", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Internal error. Exiting....
        /// </summary>
        public static string ErrorGeneric {
            get {
                return ResourceManager.GetString("ErrorGeneric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Multiple instances of OMSI Crossing Editor (OmsiObjEditP.exe) are running!
        ///Please close all but one of the windows.
        ///Ensure it is running and has a crossing loaded before enabling this tool..
        /// </summary>
        public static string ErrorMultipleInstances {
            get {
                return ResourceManager.GetString("ErrorMultipleInstances", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OMSI Crossing Editor (OmsiObjEditP.exe) is not running!
        ///Ensure it is running and has a crossing loaded before enabling this tool..
        /// </summary>
        public static string ErrorToolNotRunning {
            get {
                return ResourceManager.GetString("ErrorToolNotRunning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to If you have any games open that use anti-cheat software, please close them immediately (for technical reasons)!
        ///You should also exclude this tool from all anti-virus programs.
        ///You will not be reminded next time!.
        /// </summary>
        public static string FirstLaunchMessage {
            get {
                return ResourceManager.GetString("FirstLaunchMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OMSI Crossing Editor Tools - First Launch Message.
        /// </summary>
        public static string FirstLaunchMessageTitle {
            get {
                return ResourceManager.GetString("FirstLaunchMessageTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; On start-up, these values will be set.
        /// </summary>
        public static string iniDefaults1 {
            get {
                return ResourceManager.GetString("iniDefaults1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; These initial provided values match the original tool&apos;s behaviour.
        /// </summary>
        public static string iniDefaults2 {
            get {
                return ResourceManager.GetString("iniDefaults2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; OMSI Crossing Editor Tools - Settings.
        /// </summary>
        public static string iniHeader {
            get {
                return ResourceManager.GetString("iniHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; Useful for fast mouse wheel scroll speeds.
        /// </summary>
        public static string iniLimits {
            get {
                return ResourceManager.GetString("iniLimits", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; The amounts to adjust the zoom/fov by when scrolling the mouse wheel.
        /// </summary>
        public static string iniScroll1 {
            get {
                return ResourceManager.GetString("iniScroll1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; Scrolling up adds to the zoom/fov and scrolling down subtracts from it....
        /// </summary>
        public static string iniScroll2 {
            get {
                return ResourceManager.GetString("iniScroll2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; ...currently, that behaviour cannot be changed.
        /// </summary>
        public static string iniScroll3 {
            get {
                return ResourceManager.GetString("iniScroll3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; [Section].
        /// </summary>
        public static string iniSection {
            get {
                return ResourceManager.GetString("iniSection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; Setting = Value.
        /// </summary>
        public static string iniSetting {
            get {
                return ResourceManager.GetString("iniSetting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; Usage:.
        /// </summary>
        public static string iniUsage {
            get {
                return ResourceManager.GetString("iniUsage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ; Valid values: Only numbers (e.g., 1.2, 0.1, 0, 1, 2, 45).
        /// </summary>
        public static string iniValidValuesNumbers {
            get {
                return ResourceManager.GetString("iniValidValuesNumbers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Refer to the Readme.txt included with the download..
        /// </summary>
        public static string ReferToReadme {
            get {
                return ResourceManager.GetString("ReferToReadme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OMSI Crossing Editor.
        /// </summary>
        public static string TargetName {
            get {
                return ResourceManager.GetString("TargetName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Disable tool.
        /// </summary>
        public static string TrayMenuDisable {
            get {
                return ResourceManager.GetString("TrayMenuDisable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Edit settings....
        /// </summary>
        public static string TrayMenuEdit {
            get {
                return ResourceManager.GetString("TrayMenuEdit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enable tool.
        /// </summary>
        public static string TrayMenuEnable {
            get {
                return ResourceManager.GetString("TrayMenuEnable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Exit.
        /// </summary>
        public static string TrayMenuExit {
            get {
                return ResourceManager.GetString("TrayMenuExit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Help &amp;&amp; about....
        /// </summary>
        public static string TrayMenuHelp {
            get {
                return ResourceManager.GetString("TrayMenuHelp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Reload settings.
        /// </summary>
        public static string TrayMenuReload {
            get {
                return ResourceManager.GetString("TrayMenuReload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Restore default settings....
        /// </summary>
        public static string TrayMenuRestore {
            get {
                return ResourceManager.GetString("TrayMenuRestore", resourceCulture);
            }
        }
    }
}
