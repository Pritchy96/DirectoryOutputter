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

namespace DirectoryOut
{
    public partial class Grabber : Form
    {
        public Grabber()
        {
            InitializeComponent();
        }


        private void Grabber_Load(object sender, EventArgs e)
        {

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            SearchOption searchOption = new SearchOption();

            if (chkSearchSub.Checked)
            {
                searchOption = SearchOption.AllDirectories;
            }
            else
            {
                searchOption = SearchOption.TopDirectoryOnly;
            }

            browser.ShowNewFolderButton = false;
            browser.Description = "Please select a folder for file listing:";
            browser.ShowDialog();
            string path = browser.SelectedPath.ToString();
            string[] log = Directory.GetFiles(path, ".", searchOption);

            if (!chkFullPath.Checked)
            {
                for (int i = 0; i < log.Count(); i++)
                {
                    log[i] = log[i].Remove(0, path.Count());
                }
            }
            File.WriteAllLines(path + "\\Output.txt", log);
            Application.Exit();
        }

    }
}
