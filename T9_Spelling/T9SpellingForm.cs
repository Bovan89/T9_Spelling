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
using T9_SpellingLib;
using static T9_SpellingLib.StaticData;

namespace T9_Spelling
{
    public partial class T9SpellingForm : Form
    {
        public T9SpellingForm()
        {
            InitializeComponent();
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bStartProcess_Click(object sender, EventArgs e)
        {
            if (File.Exists(tbFilePath.Text))
            {
                ParseT9 parseT9 = new ParseT9(tbFilePath.Text, tbFilePath2.Text);

                parseT9.ProcessFileAsync();
            }
            else
            {
                MessageBox.Show("Файл не найден");
            }            
        }        

        private void bOpenFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {                
                tbFilePath.Text = ofd.FileName;                
            }
        }

        private void bSaveFile_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tbFilePath2.Text = sfd.FileName;
            }
        }
    }
}
