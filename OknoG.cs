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
        public string[,] data;
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
                Excel lista = new Excel(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\" + ex.NmHernes + ".xml",1);
                data =ex.ReadRange(6, 1, Range, 16);
                ///////////////////////////// sprawdzenie długosci przewodów oraz przekroju 
                for(int i = 0; i<Range-5; i++)
                {
                    if (Int32.Parse(data[i, 2])<60)
                    {
                        for(int j = 0; j < 16; j++)
                        {
                            data[i, j] = "";/// sprubować jeszcze null
                        }
                    }
                }
                for (int i = 0; i < Range-5; i++)
                {
                    if (data[i, 0].Length == 1)
                    {
                       data[i, 0] = "00" + data[i, 0];
                        
                        continue;
                    }
                    if (data[i, 0].Length == 2)
                    {
                        data[i, 0] = "0" + data[i, 0];
                        
                        continue;
                    }
                    
                }//dodanie 0 do lp
                progressBar1.Value += 30;
                
                
                
                
                
                for (int i = 4; i < Range - 1; i++)
                {
                    lista.ws.Cells[i, 1].Value2 = ex.NmHernes + "__" + data[i - 4, 0];//dodane pierwszej kolumny nr wiazki 
                    lista.ws.Cells[i,5].Value2= "Pos. " + data[i-4, 0];//dodanie pos.
                    lista.ws.Cells[i, 6].Value2 = ex.NmHernes + "_";//dodanie numeru wiazki wraz z _
                    lista.ws.Cells[i, 8].Value2 = data[i, 2];//dodanie dlugosci przewodu 
                    lista.ws.Cells[i, 11].Value2 = data[i, 3];///dodanie rim przewodu 


                }///dodani
                lista.SaveData();
                ex.Close();
                lista.Close();

                
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
