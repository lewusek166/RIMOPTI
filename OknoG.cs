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

                DefaultExt = "xlsm",
                Filter = "xlsm files (*.xlsm)|*.xlsm",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Excel ex = new Excel(openFileDialog1.FileName, 1);
                ex.TakeNendN();
                int Range =ex.RangeData();
                Excel szablon = new Excel(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\Szablon.xml", 1);
                szablon.SaveAsData(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\" + ex.NmHernes+".xml");
                Excel start = new Excel(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\" + ex.NmHernes + ".xml",1);
                string[,] data =ex.ReadRange(6, 1, Range, 1);
                
                
                ex.Close();
                start.Close();

                progressBar1.Value += 5;
            }

            
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
