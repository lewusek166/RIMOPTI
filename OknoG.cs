

using System;
using System.Collections;
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
                int Range = ex.RangeData();
                Excel szablon = new Excel(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\Szablon.xml", 1);
                szablon.SaveAsData(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\" + ex.NmHernes + ".xml");
                Excel lista = new Excel(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\" + ex.NmHernes + ".xml", 1);
                data = ex.ReadRange(6, 1, Range, 16);
                Range -= 5;
                ///////////////////////////// sprawdzenie długosci przewodów oraz przekroju 
                for (int i = 0; i < Range; i++)
                {
                    if (Int32.Parse(data[i, 2]) < 60)//długość
                    {
                        data[i, 0] = null;
                    }
                    if (Double.Parse(data[i, 4]) >= 6)// przekrój 6 !!
                    {
                        data[i, 0] = null;
                    }

                }
                //czyszczenie tablicy z nulli 
                int zmiejszenieTablicy = 0;

                for (int i = 0; i < Range; i++)
                {
                    if (data[i, 0] == null)
                    {
                        zmiejszenieTablicy++;

                        for (int z = i + 1; z <= Range - zmiejszenieTablicy; z++)
                        {
                            for (int x = 0; x < 16; x++)
                            {
                                data[z - 1, x] = data[z, x];
                            }
                        }
                    }
                }
                //dodanie 0 do lp
                Range -= (zmiejszenieTablicy);
                for (int i = 0; i < Range; i++)
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

                }
                progressBar1.Value += 10;

                //sortowanie (rim przewodu)
                string[,] pomoc;
                pomoc = new string[Range+1, 16];
                for(int z = 0; z < 16; z++)
                {
                    pomoc[0, z] = data[0, z];
                }
                int iteratorA = 0, iteratorB = 0;
                for (int a = 0; a < Range-iteratorB; a++)
                {
                    for (int i = 1; i < Range; i++)
                    {
                        if (pomoc[iteratorA, 3] == data[i, 3] && data[i, 3] != "1")
                        {
                            iteratorA++;

                            for (int o = 0; o < 16; o++)
                            {
                                pomoc[iteratorA, o] = data[i, o];
                                if (o == 15)
                                {
                                    data[i, 3] = "1";//znak rozpoznawczy
                                }
                            }
                        }
                    }
                    for (int s = 1 + iteratorB; s < Range; s++)
                    {
                        if (data[s, 3] != "1")
                        {
                            iteratorA++;
                            for (int o = 0; o < 16; o++)
                            {
                                pomoc[iteratorA, o] = data[s, o];
                                if (o == 15)
                                {
                                    data[s, 3] = "1";//znak rozpoznawczy
                                }
                            }
                            iteratorB++;
                            break;
                        }

                    }

                }

                    data = pomoc;
                    for (int i = 4; i < Range+2; i++)
                    {
                        lista.ws.Cells[i, 1].Value2 = ex.NmHernes + "__" + data[i - 4, 0];//dodane pierwszej kolumny nr wiazki 
                        lista.ws.Cells[i, 5].Value2 = "Pos. " + data[i - 4, 0];//dodanie pos.
                        lista.ws.Cells[i, 6].Value2 = ex.NmHernes + "_";//dodanie numeru wiazki wraz z _
                        lista.ws.Cells[i, 8].Value2 = data[i - 4, 2];//dodanie dlugosci przewodu 
                        lista.ws.Cells[i, 11].Value2 = data[i - 4, 3];///dodanie rim przewodu 

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

        private void WyszukajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[,] pomoc;
            string[,] test;

            pomoc = new string[5, 2];
            test = new string[5, 2];
            test[0, 0] = "1";
            test[0, 1] = "22";
            test[1, 0] = "2";
            test[1, 1] = "33";
            test[2, 0] = "3";
            test[2, 1] = "22";
            test[3, 0] = "4";
            test[3, 1] = "55";
            test[4, 0] = "5";
            test[4, 1] = "22";
            pomoc[0, 0] = test[0, 0];
            pomoc[0, 1] = test[0, 1];

            int iteratorA = 0, iteratorB = 0;

            for (int a = 0; a < 5; a++)
            {

                for (int i = 1; i < 5; i++)
                {
                    if (pomoc[iteratorA, 1] == test[i, 1] && test[i, 1] != "1")
                    {
                        iteratorA++;

                        for (int o = 0; o < 2; o++)
                        {
                            pomoc[iteratorA, o] = test[i, o];
                            if (o == 1)
                            { 
                            test[i, 1] = "1";//znak rozpoznawczy
                            }
                        }
                    }
                }
                    for (int s = 1 + iteratorB; s < 5; s++)
                    {
                        if (test[s, 1] != "1")
                        {
                            iteratorA++;
                            for (int o = 0; o < 2; o++)
                            {
                                pomoc[iteratorA, o] = test[s, o];
                            if (o == 1)
                            {
                                test[s, 1] = "1";//znak rozpoznawczy
                            }
                        }
                            iteratorB++;
                            break;
                        }

                    }



                
            }
        }
    }
}
