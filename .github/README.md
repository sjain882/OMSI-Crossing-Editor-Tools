# OMSI Crossing Editor Tools

<div align="center">

![SCREENSHOT](https://github.com/sjain882/OMSI-Crossing-Editor-Tools/blob/main/.github/Banner.png?raw=true)

[![ISSUES](https://img.shields.io/github/issues/sjain882/OMSI-Crossing-Editor-Tools?color=FF6D00&style=flat)](https://github.com/sjain882/OMSI-Crossing-Editor-Tools/issues)
[![VERSION](https://img.shields.io/github/v/release/sjain882/OMSI-Crossing-Editor-Tools?color=FF6D00&style=flat&label=version)](https://github.com/sjain882/OMSI-Crossing-Editor-Tools/releases/latest)
[![DOWNLOAD](https://img.shields.io/github/downloads/sjain882/OMSI-Crossing-Editor-Tools/total?color=2E7D32&label=Download&style=flat)]()
[![FRANÇAIS & DEUTSCH](https://img.shields.io/badge/-Français%20&%20Deutsch-%2301579B?style=flat)]()

Better camera controls for [OMSI 2](https://store.steampowered.com/app/252530)'s Crossing Editor!
</div>

‎
## Why?

For years, map developers have been forced to use the basic OMSI Crossing Editor (`OMSI 2\SDK\OmsiObjEditP.exe`) in order to add pathways to their maps.

In this tool, the only way to control the zoom level of the camera is to click a separate menu and drag a slider with your mouse! This is very painful to use.

On top of this, the default camera FoV (Field-of View) value is locked at 30°, compared to 45° inside OMSI 2's main game, which is slightly disorienting.

NOTE: For the best experience, if you are comfortable with using the 3D modelling software "Blender" (the ability to create 3D models is a must for high quality maps anyway), you should use [this](https://strefa-omsi.pl/Watek-OMSI-2-Automatyczny-generator-pojazdow-i-obiektow-scenerii-blender-2-8--27135) plugin for Blender v2.8+ to create and export AI Traffic paths from bezier curves. This partially removes the need to use the horrible outdated OMSI Crossing Editor. For other functionality such as setting up traffic lights, however, you will be limited to the OMSI Crossing Editor, where you can still make use my tool to improve the navigation experience.

‎
## Features

Not to worry - with OMSI Crossing Editor tools, you now have full control over the Zoom & FOV inside the OMSI Crossing Editor! With my tool, you can:

- Set default values for the camera zoom & FoV
- Set minimum and maximum limits for the camera zoom & FoV
- Easily adjust the Zoom & FoV with your mouse's scroll wheel (including holding the SHIFT key to increase/decrease speed)

    - The scrolling speed can be fine tuned via configuration files

‎

| Control  | Effect |
| ------------- | ------------- |
| Scroll Mouse Wheel Up/Down  | Increase/Decrease Zoom  |
| Hold down SHIFT key + Scroll Mouse Wheel Up/Down  | 	Increase/Decrease Zoom (fast)  |
| Hold down CTRL key + Scroll Mouse Wheel Up/Down  | 	Increase/Decrease FoV (Field-Of-View)  |

[Français & Deutsch](https://github.com/sjain882/OMSI-Crossing-Editor-Tools/blob/main/.github/Controls.png?raw=true)

There is also multilingual support for English, French, German, Polish and Finnish.

Please note: Additional functionality such as customization of modifier keys is reserved for potential future updates.

‎
## Important!

###### Anti-cheat warning

- Due to the nature of this tool, it is possible some game anti-cheats will flag this software. 

- Thus, **please ensure you keep all games which have anti-cheats closed while running OMSI 2 with OMSI Presentation Tools.** 

###### More information

- In theory there should be no issues since this tool restricts itself to memory regions OMSI has read-access to, but its possible it could be flagged up. The same applies to antivirus detections.

- As well as this, the OmniNavigation and Bus Company Simulator Addon DLCs read directly from to OMSI 2's process memory, similar to this tool. These DLCs have been public for several years and nobody has reported issues yet.

- Although all of these cases are extremely unlikely, if not impossible, please note that **I cannot be held personally responsible (directly or indirectly)** if usage of this tool results in an anti-cheat ban in other games, the breaking of your OMSI install or other software, or loss of data.

- Users will be reminded of this via a pop-up message box upon first launch of the tool (only).

‎
## Installation & Usage (!)

**---> ❗ NOTE - These are not what you expect! It is critical that you follow all the below steps and in the exact order given! ❗ <---**

❗ Please note that this tool requires .NET Framework 4.7.2 to be installed.
If you are using Windows 7 or a version of Windows 10 released before April 2018, you must install it manually from [here](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472) ("Runtime").
Otherwise, no action is required.

❗ Please note that the OMSI Crossing Editor has a bug where, after an unspecified amount of time, the main view will freeze randomly. This bug is not caused by OMSI Crossing Editor Tools. If this happens, simply save your work, close and re-open the application, then disable and re-enable OMSI Crossing Editor Tools.

1. Ensure you have OMSI Crossing Editor downloaded correctly:

    --- ❗ **The file name must be OmsiObjEditP - the tool will not work if you have renamed it!**<br/>
    --- The file must be located in the SDK folder of your OMSI 2 installation folder, so OMSI Crossing Editor can work correctly.<br/>
    --- e.g., C:\Program Files (x86)\Steam\steamapps\common\OMSI 2\SDK\OmsiObjEditP.exe<br/>
    --- You can download the OMSI Crossing Editor from here (extract to the OMSI 2\SDK folder)
    ‎
2. Download the OMSI Crossing Editor Tools .zip archive, open it, and extract the contents of the "Tool" folder to any folder on your PC. 
    ‎
3. Exclude this folder from all anti-virus programs on your PC - or you may experience problems. 
    ‎
4. If you have any games open that use anti-cheat software, please close them!<br/>
    You must do this step each time you launch the tool.<br/> 
    ‎
    These steps are necessary due to the nature of the tool.<br/>
    Don't worry - the source code of this tool will be made available at a later date.
    ‎
5. Right click on the OMSICrossingEditorTools .exe / Application file and click "Run as administrator".<br/>
    Click "Yes" if prompted by User Account Control.<br/>
    A small 🚦 traffic light icon should appear in your notification tray (bottom right of your taskbar)<br/>
    ❗ **It is critical that you do this step before continuing onto the next one (due to a bug in OMSI Crossing Editor)** 
    ‎
6. Now, open your copy of the OMSI Crossing Editor.
    ‎
7. In the top-left, click Object > Load... and open your desired .sco file from OMSI 2\Sceneryobjects.<br/>
    ❗ **It is critical that you have an object/crossing loaded at this stage.** 
    ‎
8. Right click on the previously mentioned 🚦 traffic light icon in your tray, and click "Enable tool" .
    ‎
9. Click on the OMSI Crossing Editor so it is the focused window.<br/>
    ❗ **The tool will not work unless you have the OMSI Crossing Editor focused.** 
    ‎
10. Use the controls listed in the the table under the "Features" section above. 
    ‎
If you are opening a new object in the Crossing Editor, please disable the tool before doing so, and re-enable it after it is loaded.
    ‎
11. If you wish, you can change some settings by right clicking on the 🚦 traffic light icon in your tray, then "Edit settings..." - a text file with descriptions for each setting in your language will open. You can adjust various parameters here.<br/>
    Once you have finished, save and close the file, then right click on the 🚦 traffic light icon in your tray, then "Reload settings".
    ‎
12. Once you have finished using OMSI Crossing Editor for the day, it's a good idea to right click on the 🚦 traffic light icon in your tray, and click "Exit".

‎
## Known issues:

- If you enable the tool when you're not supposed to (e.g., when OMSI Crossing Editor is not running), the tool will disable itself internally, but the GUI still reports that the tool is enabled. To re-use the tool you need to disable and re-enable the tool again via the GUI. For some reason theoretically correct code to fix this hasn't worked.

- Polish and Finnish languages are only available in the tool itself; the documentation remains untranslated.

‎
## Digital Signing of Release Binaries:

All `*.exe` binary files of this project compiled by me are digitally self-signed. The attached certificate should carry this serial number:

`18f6cc78c0fa778b4545c6d9d135cb52`

If the serial number on your copy does not match this, or the digital certificate is missing the file has potentially been tampered with and should be deleted immediately.

You can check this by right clicking on the `OMSICrossingEditorTools` .exe / Application file > Properties > Digital Signatures > Select the one named "sjain882" > Details > View Certificate > Details > Serial Number.

‎
## Building:

**You must build this project in x86 for it to work at runtime.** 

Simply install Visual Studio Community (I used 2019) with .NET Desktop Development support, clone this repo, open the solution (`*.sln`) file, set the Configuration to Release | x86 and run Build > Build Solution.

Required NuGet packages should already be configured and are present in the repository, but if you run into any issues, the packages I used are the latest versions of the ones listed in the credits below.

WinputManager.dll and Memory.dll, however, must be present as a pre-built .dll in the Libraries folder when you press the Start button in Visual Studio.

For binary distribution, they only need to be present in the tool's working directory. Please see the release .zip if further clarification is needed.

Lower versions of Visual Studio should work, but I used VS 2019.

‎
## License:

This software is licensed under the GNU General Public License v3 (GPL-3) licence. Please see https://www.gnu.

‎
## Credits:

- **[sjain882](https://github.com/sjain882)** - Reverse engineering of OMSI Crossing Editor, creating this tool

- **[Nano](https://reboot.omsi-webdisk.de/community/user/13389-nano/)** - Testing & suggestions

- **[BowsyCh16](https://reboot.omsi-webdisk.de/community/user/7394-bowsych16/)**, **[Sobol](https://reboot.omsi-webdisk.de/community/user/7944-sobol/)**, **[volvorider](https://reboot.omsi-webdisk.de/community/user/9681-volvorider/)**  - Testing & translation

- **[Erilambus](https://reboot.omsi-webdisk.de/community/user/9046-erilambus/)**, **[HalberCode](https://reboot.omsi-webdisk.de/community/user/5160-halbercode/)**, **[volvorider](https://reboot.omsi-webdisk.de/community/user/9681-volvorider/)**  - Testing & translation

- **Various C#.NET libraries** - **[ini-parser](https://github.com/rickyah/ini-parser)**, **[WInputManager](https://github.com/shy2net/WinputManager)**, **[Memory.dll.x86](https://github.com/erfg12/memory.dll/)**

- The **[Interactive Delphi Reconstructor](https://github.com/crypto2011/IDR)** project for making reverse-engineering OMSI Crossing Editor much easier

- **[M&R Software](http://www.m-r-software.de/)** - Original developers of the OMSI Crossing Editor
