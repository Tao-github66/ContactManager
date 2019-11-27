using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{
    public partial class SearchDialog : Form
    {
        public string SearchFn           // first name for search
        {
            get { return searchFn; }
        }
        public string SearchLn          // last name for search
        {
            get { return searchLn; }
        }

        public int SearchType
        {
            get { return searchType; }
            set { searchType = value; }
        }

        private string searchFn;
        private string searchLn;
        private int searchType;   // 0 - first name, 1 - last name, 2 - full name

        public SearchDialog()
        {
            InitializeComponent();
        }

        // Event - cancel
        private void searchCancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // Event - search
        private void searchSearchButton_Click(object sender, EventArgs e)
        {

            searchFn = searchFirstNameTextBox.Text.Trim();
            searchLn = searchLastNameTextBox.Text.Trim();

            DialogResult = DialogResult.OK;

        }

        // Event - dialog load
        private void SearchDialog_Load(object sender, EventArgs e)
        {
            // based on event handler comes from

            switch(searchType)
            {
                case 0:         // first name
                    searchFirstNameTextBox.Enabled = true;
                    searchLastNameTextBox.Enabled = false;

                    break;
                case 1:
                    searchFirstNameTextBox.Enabled = false;
                    searchLastNameTextBox.Enabled = true;
                    break;
                case 2:
                    searchFirstNameTextBox.Enabled = true;
                    searchLastNameTextBox.Enabled = true;
                    break;
                default:
                    MessageBox.Show("unknown search handler");
                    break;
            }
        }
    }
}
