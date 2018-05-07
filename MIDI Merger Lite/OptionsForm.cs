using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MIDI_Merger_Lite.Properties;

namespace MIDI_Merger_Lite
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            setupCheckBox.Checked = Settings.Default.Skip1stTrackOnNonPrimaryMIDIs;
        }

        private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Skip1stTrackOnNonPrimaryMIDIs = setupCheckBox.Checked;
            Settings.Default.Save();
        }
    }
}
