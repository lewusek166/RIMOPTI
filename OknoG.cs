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
                    if (Int32.Parse(data[i, 2])<60)//długość
                    { 
                            data[i, 0] = null; 
                    }
                   // if (Double.Parse(data[i, 4]) < 6)// przekrój mam 6!!!!!!!!!!!!
                   // {
                   //        data[i, 0] = null;/// sprubować jeszcze null
                    // }   
                    
                }
                //czyszczenie tablicy z nulli 
                int zmiejszenieTablicy = 0;
                
                for (int i = 0; i < Range - 5; i++)
                {
                    if (data[i, 0] == null)
                    {
                        zmiejszenieTablicy++;
                        
                        for(int z = i+1;z < Range - 5 - zmiejszenieTablicy;z++)
                        {
                            for(int x = 0; x < 16; x++)
                            {
                                data[z-1, x] = data[z, x];
                            }
                            
                               
                        }
                    }
                }
                Range-= zmiejszenieTablicy;
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
                
                
                
                
                
                for (int i = 4; i < Range - 5; i++)
                {
                    lista.ws.Cells[i, 1].Value2 = ex.NmHernes + "__" + data[i - 4, 0];//dodane pierwszej kolumny nr wiazki 
                    lista.ws.Cells[i,5].Value2= "Pos. " + data[i-4, 0];//dodanie pos.
                    lista.ws.Cells[i, 6].Value2 = ex.NmHernes + "_";//dodanie numeru wiazki wraz z _
                    lista.ws.Cells[i, 8].Value2 = data[i-4, 2];//dodanie dlugosci przewodu 
                    lista.ws.Cells[i, 11].Value2 = data[i-4, 3];///dodanie rim przewodu 


                }///dodani
                lista.SaveData();
                ex.Close();
                lista.Close();

                
            }

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
