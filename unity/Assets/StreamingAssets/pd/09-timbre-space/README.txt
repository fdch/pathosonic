**** To get started:

Open the version of timbre-space that is configured for your OS (-linux, -osx, or -win). Different environments report different keyboard/mouse data, so there are separate patches for Linux, OSX, and Windows.

Click on the "analysis" button within the [pd analysis-panel]. This will bring up a window with further instructions.

All audio you intend to analyze must be stored in the timbreID-examples/audio directory to avoid difficulties involving spaces in file names. Audio file names themselves may not contain any spaces.




**** Important Notes:

As of June 2019, the timbre space example is designed to work with Gem 0.94 for plotting and Pd version 0.49 (64-bit). Under Mac OSX, there are still some issues related to keyboard and mouse events triggered from a Gem window. The current timbre-space-osx.pd patch addresses these with some temporary hacks (an additional [gemcocoawindow] object, and inversion of mouse y-axis data). It was designed to work under OSX 10.13.6, and may not work properly for earlier OSX versions. If it doesn't work on your version of OSX, it should work under 32-bit Pd 0.49 and 32-bit Gem 0.93.3 if you disable "invert-y" in the mouse controls section at the bottom right.

Beyond Mac OSX issues, keyboard commands work differently depending on your OS and window manager. You may need to click the "kbd-nav" button in order to open the keyboard navigation subpatch and change the keyboard codes relative to your OS.

Timbre-space runs audio as a subprocess using [pd~] so that the audio and video components are on separate threads to avoid audio dropouts. You will not see the audio process patch unless you choose to load it without the -nogui option, or open it directly from the 09-timbre-space/lib/ directory. Audio is launched from the [pd analysis-panel]/[pd audio] subpatch if you want to dig in and edit.

In order to avoid dependencies beyond Gem, loading a directory full of separate .wav files requires a list of file names specified in a text file. Some example file lists are provided in the filename-lists directory. They list audio file names relative to the 09-timbre-space/lib/ directory, where the audio patch resides. Another option is to simply provide the full path to your file names so that you don't need to copy or move audio files to the 09-timbre-space/audio/ directory. This will only work if the full path and audio file name contain no spaces whatsoever. To automatically write full file paths to a text file, cd to a directory containing audio files, and run:

ls -d -1 $PWD/*.wav > filenames.txt

This will produce filenames.txt, where each line shows the full path of each .wav file in the directory. Remember that any such text files containing audio file names must be in the 09-timbre-space/filename-lists/ directory for the patch to find them.




**** Keyboard Navigation:

WASD: 						Navigate up, down, left, right
Up arrow/Down arrow: 		Zoom in/out
Return:						Reset plot to default position and zoom level
M:							Toggle on/off mouseover
Q/E:						Decrease/increase mouse radius
Z/C:						Decrease/increase num_matches parameter

R:							Activate "random" grain selection mode within the mouseover area when num_matches > 1. When disabled, in-range grains are played back in order of distance from the center of the mouseover area.

Left arrow/Right arrow:		Decrease/increase mouseover grain inter-onset time when num_matches > 1

1-5:						Select constellation sequencer voice 1 through 5 (red, green, blue, yellow, purple)

0:							Mouseover with no constellation sequencer functionality (white)

Backspace:					Toggle on/off constellation sequencer master clock




**** Mouse:

When a constellation sequencer voice is active, the cursor will be either red, green, blue, yellow, or purple. Clicking and dragging will add grains to the given constellation voice, and constellation connections will be drawn between grains. You can click and drag multiple times to append more grains to an existing constellation. Right clicking a grain in range of the mouse cursor will remove it from the constellation.

Clicking and dragging when mouseover is disabled will rotate the plot about the X and Y axes.




**** Keyboard Codes (Linux)

WASD: 						25 38 39 10
Up arrow/Down arrow: 		111 116
Return:						36
M:							58
Q/E:						24 26
Z/C:						52 54
R:							27
Left arrow/Right arrow:		113 114
1-5:						10 11 12 13 14
0:							19
Backspace:					22




**** Keyboard Codes (Mac OSX 10.13.6)

WASD: 						13 0 1 2
Up arrow/Down arrow: 		126 125
Return:						36
M:							46
Q/E:						12 14
Z/C:						6 8
R:							15
Left arrow/Right arrow:		123 124
1-5:						18 19 20 21 23
0:							29
Backspace:					51




**** Keyboard Codes (Windows 10)

WASD: 						87 65 83 68
Up arrow/Down arrow: 		38 40
Return:						13
M:							77
Q/E:						81 69
Z/C:						90 67
R:							82
Left arrow/Right arrow:		37 39
1-5:						49 50 51 52 53
0:							48
Backspace:					8