# MIDI Merger Lite

Overview
------------

MIDI Merger Lite is a simple, lightweight program that merges tracks from multiple MIDI files into one MIDI file.

Usage
------------

1. Click the "Add MIDIs" item under the File Menu to populate the list with MIDI files to be merged, or simply drag and drop MIDI files or folders containing MIDI files to populate the list as well (MIDIs in subdirectories will also be added to the list).

2. Merge order is based on the order of the MIDI files that appear in the list (i.e. The MIDI file that appears at the very top of the list will be merged first, while the MIDI file that appears at the very bottom of the list will be merged last). To change the merge order of the MIDI files, select one or multiple files from the list and use the arrow buttons to move the items up or down the list.

3. Click the "Export" button and enter in the desired name for the output MIDI file to be saved under.

4. **Optional:** In the options menu, you can choose whether or not to skip the first track of all MIDI files other than the very first MIDI file that appears in the list. This may be useful if all of the MIDI files in the list have the first track as a setup track with the same or similar data as one another, but only want to have one setup track instead of several.

5. When finished configuring, select the "Merge MIDIs" item under the File Menu to begin merging the MIDI files.

Limitations
------------

- Only MIDIs created under the MIDI 1.0 specification are supported
- Only Format 1 MIDI files are supported
- Output MIDI file cannot contain more than 65535 tracks (a limitation of the MIDI 1.0 specification)
- All MIDIs that are being merged must have the same time divisions (i.e. A MIDI file with 384 ticks per bar cannot be merged with a MIDI file with 1920 ticks per bar)
	- You can use the [MIDI Time Division Reader](https://github.com/VirtuosicAI/MIDI-Time-Division-Reader) program to check time division of MIDI files

References
------------

To learn more about the MIDI 1.0 specification, visit the links below:
- MIDI File Format Specifications: https://github.com/colxi/midi-parser-js/wiki/MIDI-File-Format-Specifications
- The MIDI File Format: https://www.csie.ntu.edu.tw/~r92092/ref/midi/
