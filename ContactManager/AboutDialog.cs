using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            // read file - under construction
        }

        // Event - About 
        private void aboutButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        // Event - dialog load
        private void AboutDialog_Load(object sender, EventArgs e)
        {
            // load about information from file
            string filepath = Directory.GetCurrentDirectory() + "//about.txt";
            if (!(File.Exists(filepath)))
            {
                return;
            }
            StreamReader input = new StreamReader(filepath);

            while (!input.EndOfStream)
            {
                string lineFromFile = input.ReadLine();

                aboutTextBox.AppendText(lineFromFile + "\r\n");
            }
            input.Close();
        }
    }
}
