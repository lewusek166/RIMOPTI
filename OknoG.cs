using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RimOptiList
{
    public partial class OknoG : Form
    {
        public OknoG()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "xml",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
            }

            progressBar1.Value = progressBar1.Value + 10;
           // Excel ex = new Excel(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\Szablon.xml",1);
           // ex.SaveAsData(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\kopiaa.xml");
        }

        private void TestPołączeniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                SQLittleDataBase sql = new SQLittleDataBase();
            sql.LoadData();
            
        }

        private void DodajUsuńModyfikujToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DUM pokaz = new DUM();
            pokaz.Show();
        }
    }
}
