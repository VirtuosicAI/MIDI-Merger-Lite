﻿using System.Diagnostics;
using System.Windows.Forms;

namespace MIDI_Merger_Lite
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/VirtuosicAI");
        }
    }
}
