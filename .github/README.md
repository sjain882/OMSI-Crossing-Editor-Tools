# HELEN ClearType Control Toggler

<div align="center">

![SCREENSHOT](https://github.com/sjain882/HELEN-ClearType-Toggle/blob/main/.github/Preview.gif?raw=true)

https://user-images.githubusercontent.com/43217178/175432463-e83ff24a-7153-433a-bc8a-a94c0b25053a.mp4

[![ISSUES](https://img.shields.io/github/issues/sjain882/HELEN-ClearType-Toggle?color=FF6D00&style=flat)](https://github.com/sjain882/HELEN-ClearType-Toggle/issues)
[![VERSION](https://img.shields.io/github/v/release/sjain882/HELEN-ClearType-Toggle?color=FF6D00&style=flat&label=version)](https://github.com/sjain882/HELEN-ClearType-Toggle/releases/latest)
[![DOWNLOAD](https://img.shields.io/github/downloads/sjain882/HELEN-ClearType-Toggle/total?color=2E7D32&label=Download&style=flat)](https://github.com/sjain882/HELEN-ClearType-Toggle/releases/latest/download/HelenClearTypeToggle.exe)

Simple patcher for HELEN software that toggles its ability to enable or disable Windows ClearType.

Tested on Windows XP & above.
</div>

‎
## Supported versions:

- v3.03.00 (or v3.3)
- v3.10.02
- v3.12.06 (or v3.12.6)

‎
## Usage:

If you are using Windows XP - please download & install .NET Framework 4 from [here](https://www.microsoft.com/en-gb/download/details.aspx?id=17718).

If you are using Windows 7 - please obtain .NET Framework 4 via Windows Update or from [here](https://www.microsoft.com/en-gb/download/details.aspx?id=17718).

If you are using Windows 10 - no extra steps are required prior to usage of this application.

1. Please ensure you have a currently supported version of HELEN installed and that all HELEN windows are closed.

2. Download the latest release from [here](https://github.com/sjain882/HELEN-ClearType-Toggle/releases/latest/download/HelenClearTypeToggle.exe) and run it.

3. Click on the `...` button in the first section to open your `HELEN.exe` executable file.

4. Check the version information section to ensure the correct version was detected. If it is patchable, the below controls will become available.

5. Select your desired behaviour from the next section.

6. Confirm your changes with the Save button. A backup copy of the original will automatically be created (this won't be overwritten by future patches)

‎
## Command line parameters (any order):

- `--help`, `-h` or any unrecognised arguments: Displays a help page with the information of this section.

- `--path`, `-p`: Followed by a space then a full or relative (from directory tool was launched from) path to the HELEN executable (*.exe) file in quotes. e.g., `--path "C:\Applications\HELEN.exe"`.
    - Required in conjunction with `--enable` or `--disable` parameters.

- `--enable`, `-e`: Patches the HELEN executable so that it has control over ClearType (it will attempt to turn ClearType on/off as required - default). Displays message box indicating success/failure.

- `--disable`, `-d`: Patches the HELEN executable so that it has no control over ClearType (it will never attempt to turn ClearType on/off). Displays message box indicating success/failure.

- Example usage: `HelenClearTypeToggle -p "C:\Applications\HELEN.exe" --enable`

- If no arguments are specified, the GUI will launch.

‎
## Why is the patch needed?

When certain parts of HELEN's GUI are accessed, HELEN will disable Windows ClearType system wide. This is important for certain functionality such as importing fonts - if ClearType is enabled, the result is quite jumbled - if it is disabled, the font is intact.

However, it will unnecessarily disable ClearType in parts of the GUI that have links to such functionality (e.g., buttons), even if the part of the GUI holding that link doesn't need to disable ClearType.

Some users rarely need to access functionality that needs to disable ClearType, but regularly access parts of the GUI that unnecessarily disable ClearType.

Therefore, this patch is offered as a toggle instead of a one-way disable.

It can be infuriating to have ClearType unnecessarily disabled system wide as this makes text in Windows appear very low quality and can make it difficult to read. 

Existing windows will slowly have their text degrade to poor quality as the user mouses over them and although HELEN attempts to re-enable ClearType after the GUI it was disabled for is exited, for this can sometimes fail for unknown reasons, requiring the user to manually re-enable ClearType. This worsens the infuriating effect.

‎
## How the patch works

HELEN makes calls to the [`SystemParametersInfoA`](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-systemparametersinfoa) system function of `user32.dll` to enable or disable ClearType.

This function can take argument `SPI_GETCLEARTYPE` (`0x4A` in HELEN binary) or `SPI_SETCLEARTYPE` (`0x4B` in HELEN binary) to read or write to the ClearType bit in Windows respectively.

We can simply "null" any attempts to disable ClearType in the first place by switching the `SPI_SETCLEARTYPE` (changes the status of ClearType) arguments to `SPI_GETCLEARTYPE` (returns the current status of ClearType) arguments.

This is by no means a perfect solution, but since the remaining arguments of the replaced `SPI_SETCLEARTYPE` function calls in HELEN are presumed to become invalid; the worst result is the function [returning false](https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-systemparametersinfoa#return-value); the best result is the function successfully getting the ClearType bit.

Since the relevant `SystemParametersInfoA` calls are never assigned to a value, the form code shouldn't be influenced by it. Stability testing has reflected this.

A perfect (in code terms) solution would be to move the `SystemParametersInfoA` calls so that only the forms which explicitly require ClearType to be off actually disable ClearType. This would eliminate the need for a toggle patcher, and thus the need to ever use the patcher again. However:

- Due to the way some forms are split up, this isn't always possible.

- This would be a much more advanced patch - I do not currently have the required expertise or time for this and it creates more possibilities for the patch to go wrong.

‎
## FAQ:

**Q:** Why must the patcher run as administrator?

**A:** The default installation location for `HELEN.exe` is a directory inside `C:\Program Files (x86)` which requires administrator permissions to write to by default. Since most users do not change this default directory, this will avoid a lot of potential confusion resulting from unauthorised access errors.

**A:** Since drag and dropping files in Windows is unsupported for elevated applications, the ability to drag and drop HELEN.exe onto the patcher window for ease of use was omitted from development for the same reason.

**Q:** Why does the application target the now outdated .NET Framework 4?

**A:** This is to ensure it is compatible with Windows XP & above, since HELEN should run on the same operating systems.

‎
## Known issues:

There are no currently known issues, however:

- Languages & locales other than 'English (United Kingdom)' and special/unicode/cyrillic characters in file paths are untested.

- Multi-language support is currently unavailable. If you would like this please open an issue. If it accumulates enough requests (comments) then I may consider refactoring the code to allow for easy translation with language files.

‎
## Digital Signing of Release Binaries:

All `*.exe` binary files of this project compiled by me are digitally self-signed. The attached certificate should carry this serial number:

`18f6cc78c0fa778b4545c6d9d135cb52`

If the serial number on your copy does not match this, or the digital certificate is missing the file has potentially been tampered with and should be deleted immediately.

You can check this by right clicking on the `HelenClearTypeToggle` .exe / Application file > Properties > Digital Signatures > Select the one named "sjain882" > Details > View Certificate > Details > Serial Number.

‎
## Building:

There is no specific build process. Simply install Visual Studio Community (I used 2019) with .NET Desktop Development support, clone this repo, open the solution (`*.sln`) file, set the Configuration to Release | Any CPU and run Build > Build Solution.

‎
## Credits:

- **[sjain882](https://github.com/sjain882)** - Reverse engineering of HELEN, creating this tool

- The **[LEGO Island Rebuilder](https://github.com/itsmattkc/LEGOIslandRebuilder/tree/net)** (old C# .NET version) project by **[MattKC](https://github.com/itsmattkc)** for a brilliant example of a simple backwards compatible executable patcher - code design inspiration & some small snippets

- The **[Large Address Aware](https://www.techpowerup.com/forums/threads/large-address-aware.112556/)** project - GUI inspiration

- **[MrChips](https://fellowsfilm.com/members/mrchips.3079/#resources)** - Beta testing

‎
## Disclaimer:

I am not a regular user of HELEN and am not very familiar with this software. It is entirely possible that in some corner of the application, simply opening your work with ClearType control disabled in HELEN could cause loss of work, and if saved - this could become permanent. It goes without saying that you should always backup your work regularly and before using this patcher for the first few times.

This software is provided "As is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. **I cannot be held personally responsible if usage of this software results in loss of work or breakage of your HELEN installation**.