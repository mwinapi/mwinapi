ManagedWinapi 0.2
~~~~~~~~~~~~~~~~~

A collection of .NET components that wrap PInvoke calls to access 
native API by managed code.

For documentation for these functions, look at ManagedWinapi.chm in the
binary release or generate it with ndoc from http://ndoc.sourceforge.net/
from the source release.

This library is licensed by the GNU Lesser General Public License.

For more information see the website at http://mwinapi.sourceforge.net/

You may contact me at <schierlm@users.sourceforge.net>.


ManagedWinapi Tools 0.2
~~~~~~~~~~~~~~~~~~~~~~~

Started as a collection of ManagedWinapi samples, the Managed Winapi tools
evolved into a toolbox of lots of small but useful tools that solve their
specific task well. They can still be used as reference for how to use
ManagedWinapi, but their functionality may make it hard to find the
relevant code parts quickly.

See the website for a list of tools and descriptions.


Changelog
~~~~~~~~~


+++ Not yet released +++ (revision 43)

- New SystemWindow features
  * Lots of new SystemWindow properties (see the documentation)
  * support arbitrary length window class names.
  * Create SystemWindows not only from a Form but from any Control.
- Add classes to inspect list boxes, combo boxes, list views and
  tree views.
- WindowContents framework that allows to retrieve contents of
  windows from other processes 
  * From Textbox/Listbox/Combobox/ListView/TreeView 
  * From any window that supports screen readers
- Crosshair control (drag crosshair and get point at destination)
- Shortcut editing text box control
- Accessibility (Screen reader support)
  * New SystemAccessibleObject class that wraps accessibility 
    objects of other processes
  * AccessibleObjectListener for listening to accessible events
- Helper method to check API return values
- Managed Audio Mixer API
- Managed hooks (Local message hook and journal record/playback hook)
  (need ManagedWinapiNativeHelper.dll)
- ExtendedFileInfo (Get icon and hard disk size for files)
- Extract keyboard specific functions into new KeyboardKey class
- ProcessMemoryChunk: Access memory of another process
- Add ManagedWinapi tools/samples:
  * AOExplorer: Browse accessibility objects
  * ContentsSaver: Save contents of list boxes and other controls to a text file
  * ClipHancer: Clipboard enhancer tool that provides unlimited number of clipboards.
  * DeskIconRestore: Tool to save and restore desktop icon positions
  * GuessEXE: Tool that guesses programming language of another program.
  * NeatKeys: a program to resize windows neatly by keyboard.
  * QuickMacro: Simple macro recorder using Journal Hooks
  * ShootNotes: Make screen shots from parts of screen, put them on your screen and annotate them
  * TreeSize#: TreeSize in C# (with more features than the original one)
  * Volume fader
- bug fixes
  * fix VS GUI designer problem (class order) in Hotkey.cs
  * fix setter for SystemWindow's VisibilityFlag property
  * fix trivial bug in SystemWindow's FromPointEx

+++ 2006-08-27 Released Version 0.1 +++