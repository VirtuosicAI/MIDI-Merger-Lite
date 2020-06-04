using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MIDI_Merger_Lite.Properties;

namespace MIDI_Merger_Lite
{
    public partial class MainForm : Form
    {
        int totalTrackNum = 0;
        int totalTrackNumWithoutFirstTrack = 0;

        List<string> midiList = new List<string>();
        List<ushort> trackCount = new List<ushort>();

        string BGWorkerExMessage = "";

        public MainForm()
        {
            InitializeComponent();
            PreventSleepAndMonitorOff();
        }

        // Prevent the system from entering sleep and turning off monitor.
        private void PreventSleepAndMonitorOff()
        {
            NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED | NativeMethods.ES_DISPLAY_REQUIRED);
        }

        // Clear EXECUTION_STATE flags to allow the system to sleep and turn off monitor normally.
        private void AllowSleep()
        {
            NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS);
        }

        internal static class NativeMethods
        {
            // Import SetThreadExecutionState Win32 API and necessary flags.
            [DllImport("kernel32.dll")]
            public static extern uint SetThreadExecutionState(uint esFlags);
            public const uint ES_CONTINUOUS = 0x80000000;
            public const uint ES_SYSTEM_REQUIRED = 0x00000001;
            public const uint ES_DISPLAY_REQUIRED = 0x00000002;
        }

        private void MoveListViewItems(ListView sourceListView, int direction)
        {
            foreach (ListViewItem lvi in sourceListView.SelectedItems)
            {
                int index = lvi.Index + direction;
                if (index >= sourceListView.Items.Count)
                    index = 0;
                else if (index < 0)
                    index = sourceListView.Items.Count + direction;

                sourceListView.Items.RemoveAt(lvi.Index);
                sourceListView.Items.Insert(index, lvi);
            }
        }

        // Get a list of all files in directory and subdirectories recursively, ignoring those that need elevated privileges.
        private static List<string> SearchDirectory(DirectoryInfo dirInfo, List<string> fileList)
        {
            try
            {
                foreach (DirectoryInfo subdir_info in dirInfo.GetDirectories())
                {
                    SearchDirectory(subdir_info, fileList);
                }
            }
            catch
            {
                // Ignore potential UnauthorizedAccessException from folders that need elevated privilege to access.
            }
            try
            {
                foreach (FileInfo file_info in dirInfo.GetFiles())
                {
                    fileList.Add(file_info.FullName);
                }
            }
            catch
            {
                // Ignore potential UnauthorizedAccessException from files that need elevated privilege to access.
            }
            return fileList;
        }

        // Move selected items in the MIDI list up the list to a higher priority.
        private void upButton_Click(object sender, EventArgs e)
        {
            if(MIDIListView.SelectedItems.Count == MIDIListView.Items.Count)
            {
                MoveListViewItems(MIDIListView, MIDIListView.SelectedItems.Count * -1);
            }
            else
            {
                MoveListViewItems(MIDIListView, -1);
            }
        }

        // Move selected items in the MIDI list down the list to a lower priority.
        private void downButton_Click(object sender, EventArgs e)
        {
            MoveListViewItems(MIDIListView, MIDIListView.SelectedItems.Count);
        }

        private void addMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (addMIDI.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in addMIDI.FileNames)
                {
                    using (FileStream midiReader = new FileStream(file, FileMode.Open))
                    {
                        midiReader.Seek(4, SeekOrigin.Begin);

                        byte[] headerLength = new byte[4];
                        midiReader.Read(headerLength, 0, headerLength.Length);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(headerLength);
                        int headerLengthInt = BitConverter.ToInt32(headerLength, 0);

                        byte[] midiFormat = new byte[2];
                        midiReader.Read(midiFormat, 0, midiFormat.Length);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(midiFormat);
                        ushort formatNum = BitConverter.ToUInt16(midiFormat, 0);

                        if (headerLengthInt != 6)
                        {
                            MessageBox.Show(this, Path.GetFileName(file) + " is not a MIDI file created under the MIDI 1.0 specification, and won't be added to the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (formatNum != 1)
                        {
                            MessageBox.Show(this, Path.GetFileName(file) + " is not a Format 1 MIDI file, and won't be added to the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            byte[] tempNum = new byte[2];
                            midiReader.Read(tempNum, 0, tempNum.Length);
                            if (BitConverter.IsLittleEndian)
                                Array.Reverse(tempNum);
                            ushort tempShort = BitConverter.ToUInt16(tempNum, 0);
                            totalTrackNum += tempShort;

                            string[] newRow = { Path.GetFileNameWithoutExtension(file), file, tempShort.ToString() };
                            ListViewItem newItem = new ListViewItem(newRow);
                            MIDIListView.Items.Add(newItem);
                        }
                    }                    
                }

                totalTrackNumWithoutFirstTrack = totalTrackNum - MIDIListView.Items.Count + 1;
                trackTotalLabel.Text = "Total number of tracks: " + totalTrackNum.ToString() + " (" + totalTrackNumWithoutFirstTrack.ToString() + " without 1st track on non-primary MIDIs)";
            }
        }

        private void removeSelectedMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MIDIListView.Items.Count != 0)
            {
                foreach (ListViewItem sItem in MIDIListView.SelectedItems)
                {
                    MIDIListView.Items.Remove(sItem);
                }

                ushort tempShort = 0;

                for (int i = 0; i < MIDIListView.Items.Count; i++)
                {
                    tempShort += Convert.ToUInt16(MIDIListView.Items[i].SubItems[2].Text.ToString());
                }

                totalTrackNum = tempShort;
                totalTrackNumWithoutFirstTrack = totalTrackNum - MIDIListView.Items.Count + 1;
                trackTotalLabel.Text = "Total number of tracks: " + totalTrackNum.ToString() + " (" + totalTrackNumWithoutFirstTrack.ToString() + " without 1st track on non-primary MIDIs)";
            }
        }

        private void clearMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MIDIListView.Items.Clear();
            totalTrackNum = 0;
            totalTrackNumWithoutFirstTrack = 0;
            trackTotalLabel.Text = "Total number of tracks: 0";
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if(saveMIDI.ShowDialog() == DialogResult.OK)
                exportPathTXTBox.Text = saveMIDI.FileName;
        }

        private void mergeMIDIsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((totalTrackNum > 65535 && !Settings.Default.Skip1stTrackOnNonPrimaryMIDIs) || (totalTrackNumWithoutFirstTrack > 65535 && Settings.Default.Skip1stTrackOnNonPrimaryMIDIs))
            {
                MessageBox.Show(this, "Error: Total number of tracks exceeds the maximum allowed (65535).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MIDIListView.Items.Count <= 1)
            {
                MessageBox.Show(this, "Error: A minimum of 2 files can be merged.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(exportPathTXTBox.Text) || !Directory.Exists(Path.GetDirectoryName(exportPathTXTBox.Text)))
            {
                MessageBox.Show(this, "Error: Output path does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (File.Exists(exportPathTXTBox.Text))
                {
                    int counter = 1;
                    do
                    {
                        exportPathTXTBox.Text = Path.GetDirectoryName(exportPathTXTBox.Text) + @"\" + Path.GetFileNameWithoutExtension(exportPathTXTBox.Text) + " (Copy " + counter.ToString() + ").mid";
                        counter++;
                    } while (File.Exists(exportPathTXTBox.Text));
                }

                foreach (ListViewItem midiFile in MIDIListView.Items)
                {
                    midiList.Add(midiFile.SubItems[1].Text);
                    trackCount.Add(Convert.ToUInt16(midiFile.SubItems[2].Text));
                }

                backgroundWorker.RunWorkerAsync();

                addMIDIsToolStripMenuItem.Enabled = false;
                removeSelectedMIDIsToolStripMenuItem.Enabled = false;
                clearMIDIsToolStripMenuItem.Enabled = false;
                mergeMIDIsToolStripMenuItem.Enabled = false;
                abortMergingToolStripMenuItem.Enabled = true;
                optionsToolStripMenuItem.Enabled = false;
                upButton.Enabled = false;
                downButton.Enabled = false;
                exportButton.Enabled = false;
                totalTracksUpdater.Stop();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(backgroundWorker.IsBusy)
            {
                DialogResult confirmation = MessageBox.Show(this, "The program is still merging MIDIs.\n\nAre you sure you want to exit?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if(confirmation == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (Settings.Default.Skip1stTrackOnNonPrimaryMIDIs)
                {
                    using (FileStream fs = new FileStream(exportPathTXTBox.Text, FileMode.Append, FileAccess.Write))
                    {
                        using (BinaryWriter midiWriter = new BinaryWriter(fs))
                        {
                            using (FileStream headerStream = new FileStream(midiList.ElementAt(0), FileMode.Open))
                            {
                                byte[] header = new byte[10];
                                headerStream.Read(header, 0, header.Length);
                                midiWriter.Write(header);

                                ushort totalTrackNumShort = (ushort)(totalTrackNum - midiList.Count);
                                totalTrackNumShort++;

                                byte[] totalTrackBytes = BitConverter.GetBytes(totalTrackNumShort);
                                if (BitConverter.IsLittleEndian)
                                    Array.Reverse(totalTrackBytes);
                                midiWriter.Write(totalTrackBytes);
                                headerStream.Seek(2, SeekOrigin.Current);

                                byte[] headerDivision = new byte[2];
                                headerStream.Read(headerDivision, 0, headerDivision.Length);
                                midiWriter.Write(headerDivision);

                                byte[] firstTrackHeader = new byte[4];
                                headerStream.Read(firstTrackHeader, 0, firstTrackHeader.Length);
                                midiWriter.Write(firstTrackHeader);

                                byte[] firstTrackLength = new byte[4];
                                headerStream.Read(firstTrackLength, 0, firstTrackLength.Length);
                                midiWriter.Write(firstTrackLength);
                                if (BitConverter.IsLittleEndian)
                                    Array.Reverse(firstTrackLength);
                                int firstTrackDataLength = BitConverter.ToInt32(firstTrackLength, 0);

                                byte[] firstTrackData = new byte[firstTrackDataLength];
                                headerStream.Read(firstTrackData, 0, firstTrackData.Length);
                                midiWriter.Write(firstTrackData);
                            }

                            for (int i = 0; i < midiList.Count; i++)
                            {
                                if (backgroundWorker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break;
                                }
                                string file = midiList.ElementAt(i);
                                ushort fileTracks = trackCount.ElementAt(i);

                                using (FileStream midiReader = new FileStream(file, FileMode.Open))
                                {
                                    midiReader.Seek(18, SeekOrigin.Begin);

                                    byte[] skipFirstTrackLength = new byte[4];
                                    midiReader.Read(skipFirstTrackLength, 0, skipFirstTrackLength.Length);
                                    if (BitConverter.IsLittleEndian)
                                        Array.Reverse(skipFirstTrackLength);
                                    int skipFirstTrackLengthInt = BitConverter.ToInt32(skipFirstTrackLength, 0);
                                    midiReader.Seek(skipFirstTrackLengthInt, SeekOrigin.Current);

                                    for (ushort j = 1; j < fileTracks; j++)
                                    {
                                        if (backgroundWorker.CancellationPending)
                                        {
                                            e.Cancel = true;
                                            break;
                                        }
                                        byte[] trackHeader = new byte[4];
                                        midiReader.Read(trackHeader, 0, trackHeader.Length);
                                        midiWriter.Write(trackHeader);

                                        byte[] trackLength = new byte[4];
                                        midiReader.Read(trackLength, 0, trackLength.Length);
                                        midiWriter.Write(trackLength);
                                        if (BitConverter.IsLittleEndian)
                                            Array.Reverse(trackLength);

                                        int bufferLength4Track = BitConverter.ToInt32(trackLength, 0);
                                        byte[] trackData = new byte[bufferLength4Track];
                                        midiReader.Read(trackData, 0, trackData.Length);
                                        midiWriter.Write(trackData);
                                    }
                                }
                                int percentage = (i + 1) * 100 / midiList.Count;
                                backgroundWorker.ReportProgress(percentage);
                            }
                        }
                    } 
                }
                else
                {
                    using (FileStream fs = new FileStream(exportPathTXTBox.Text, FileMode.Append, FileAccess.Write))
                    {
                        using (BinaryWriter midiWriter = new BinaryWriter(fs))
                        {
                            using (FileStream headerStream = new FileStream(midiList.ElementAt(0), FileMode.Open))
                            {
                                byte[] header = new byte[10];
                                headerStream.Read(header, 0, header.Length);
                                midiWriter.Write(header);

                                byte[] totalTrackBytes = BitConverter.GetBytes((ushort)totalTrackNum);
                                if (BitConverter.IsLittleEndian)
                                    Array.Reverse(totalTrackBytes);
                                midiWriter.Write(totalTrackBytes);
                                headerStream.Seek(2, SeekOrigin.Current);

                                byte[] headerDivision = new byte[2];
                                headerStream.Read(headerDivision, 0, headerDivision.Length);
                                midiWriter.Write(headerDivision);
                            }

                            for (int i = 0; i < midiList.Count; i++)
                            {
                                if (backgroundWorker.CancellationPending)
                                {
                                    e.Cancel = true;
                                    break;
                                }
                                string file = midiList.ElementAt(i);
                                ushort fileTracks = trackCount.ElementAt(i);

                                using (FileStream midiReader = new FileStream(file, FileMode.Open))
                                {
                                    midiReader.Seek(14, SeekOrigin.Begin);

                                    for (ushort j = 0; j < fileTracks; j++)
                                    {
                                        if (backgroundWorker.CancellationPending)
                                        {
                                            e.Cancel = true;
                                            break;
                                        }
                                        byte[] trackHeader = new byte[4];
                                        midiReader.Read(trackHeader, 0, trackHeader.Length);
                                        midiWriter.Write(trackHeader);

                                        byte[] trackLength = new byte[4];
                                        midiReader.Read(trackLength, 0, trackLength.Length);
                                        midiWriter.Write(trackLength);
                                        if (BitConverter.IsLittleEndian)
                                            Array.Reverse(trackLength);

                                        int bufferLength4Track = BitConverter.ToInt32(trackLength, 0);
                                        byte[] trackData = new byte[bufferLength4Track];
                                        midiReader.Read(trackData, 0, trackData.Length);
                                        midiWriter.Write(trackData);
                                    }
                                }
                                int percentage = (i + 1) * 100 / midiList.Count;
                                backgroundWorker.ReportProgress(percentage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BGWorkerExMessage = ex.Message;
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            addMIDIsToolStripMenuItem.Enabled = true;
            removeSelectedMIDIsToolStripMenuItem.Enabled = true;
            clearMIDIsToolStripMenuItem.Enabled = true;
            mergeMIDIsToolStripMenuItem.Enabled = true;
            abortMergingToolStripMenuItem.Enabled = false;
            optionsToolStripMenuItem.Enabled = true;
            upButton.Enabled = true;
            downButton.Enabled = true;
            exportButton.Enabled = true;
            totalTracksUpdater.Start();

            midiList.Clear();
            trackCount.Clear();

            if (BGWorkerExMessage != "")
            {
                progressBar.Value = 0;
                MessageBox.Show(this, "Error: " + BGWorkerExMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BGWorkerExMessage = "";
                File.Delete(exportPathTXTBox.Text);
            }
            else if (e.Cancelled)
            {
                progressBar.Value = 0;
                MessageBox.Show(this, "Merging aborted.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                File.Delete(exportPathTXTBox.Text);
            }
            else
            {
                progressBar.Value = 0;
                MessageBox.Show(this, "Successfully merged all MIDIs.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void midiListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = MIDIListView.Columns[e.ColumnIndex].Width;
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void abortMergingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm optionsFrm = new OptionsForm();
            optionsFrm.ShowDialog();
        }

        private void totalTracksUpdater_Tick(object sender, EventArgs e)
        {
            if (totalTrackNum > ushort.MaxValue && !Settings.Default.Skip1stTrackOnNonPrimaryMIDIs)
            {
                trackTotalLabel.ForeColor = Color.Red;
            }
            else if (totalTrackNumWithoutFirstTrack > ushort.MaxValue && Settings.Default.Skip1stTrackOnNonPrimaryMIDIs)
            {
                trackTotalLabel.ForeColor = Color.Red;
            }
            else
            {
                trackTotalLabel.ForeColor = Color.Black;
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!backgroundWorker.IsBusy && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] data = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string uFile in data)
                {
                    if (Path.GetExtension(uFile) == ".mid" || Directory.Exists(uFile))
                    {
                        e.Effect = DragDropEffects.All;
                    }
                }
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            List<string> testList = new List<string>();
            foreach (var s in (string[])e.Data.GetData(DataFormats.FileDrop, false))
            {
                if (Directory.Exists(s))
                {
                    List<string> tempList = new List<string>();
                    DirectoryInfo dInfo = new DirectoryInfo(s);
                    tempList.AddRange(SearchDirectory(dInfo, tempList));
                    foreach (string uFile in tempList)
                    {
                        if (Path.GetExtension(uFile) == ".mid")
                        {
                            testList.Add(uFile);
                        }
                    }
                }
                else
                {
                    if (Path.GetExtension(s) == ".mid")
                    {
                        testList.Add(s);
                    }
                }
            }

            List<string> uniqueList = testList.Distinct().ToList();
            testList.Clear();

            foreach (string file in uniqueList)
            {
                using (FileStream midiReader = new FileStream(file, FileMode.Open))
                {
                    midiReader.Seek(4, SeekOrigin.Begin);

                    byte[] headerLength = new byte[4];
                    midiReader.Read(headerLength, 0, headerLength.Length);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(headerLength);
                    int headerLengthInt = BitConverter.ToInt32(headerLength, 0);

                    byte[] midiFormat = new byte[2];
                    midiReader.Read(midiFormat, 0, midiFormat.Length);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(midiFormat);
                    ushort formatNum = BitConverter.ToUInt16(midiFormat, 0);

                    if (headerLengthInt != 6)
                    {
                        MessageBox.Show(this, Path.GetFileName(file) + " is not a MIDI file created under the MIDI 1.0 specification, and won't be added to the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (formatNum != 1)
                    {
                        MessageBox.Show(this, Path.GetFileName(file) + " is not a Format 1 MIDI file, and won't be added to the list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        byte[] tempNum = new byte[2];
                        midiReader.Read(tempNum, 0, tempNum.Length);
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(tempNum);
                        ushort tempShort = BitConverter.ToUInt16(tempNum, 0);
                        totalTrackNum += tempShort;

                        string[] newRow = { Path.GetFileNameWithoutExtension(file), file, tempShort.ToString() };
                        ListViewItem newItem = new ListViewItem(newRow);
                        MIDIListView.Items.Add(newItem);
                    }
                }
            }

            totalTrackNumWithoutFirstTrack = totalTrackNum - MIDIListView.Items.Count + 1;
            trackTotalLabel.Text = "Total number of tracks: " + totalTrackNum.ToString() + " (" + totalTrackNumWithoutFirstTrack.ToString() + " without 1st track on non-primary MIDIs)";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutFrm = new AboutForm();
            aboutFrm.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AllowSleep();
        }
    }
}
