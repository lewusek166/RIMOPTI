

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
        public string[,] zasięgiRimP;
        public OknoG()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Wybierz Listę połączeń",

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
                int licznikRK = 0;
                Excel ex = new Excel(openFileDialog1.FileName, 1);
                ex.TakeNendN();
                //numer wiązki sprawdzenie ,, kolorowanie listy co źle
                if (ex.NmHernes==null||ex.NmHernes=="")
                {
                    MessageBox.Show("Popraw numer wiązki", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ex.ws.Range["J2:J2"].Interior.Color = Color.Red;
                    ex.Close();
                    Application.Exit();
                    Environment.Exit(0);
                }

                int Range = ex.RangeData();
                //Excel szablon = new Excel(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\Szablon.xml", 1);
                //szablon.SaveAsData(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\" + ex.NmHernes + ".xml");
                //Excel lista = new Excel(@"C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\" + ex.NmHernes + ".xml", 1);
                data = ex.ReadRange(6, 1, Range, 16);
                ex.Close();
                
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
                for (int a = 0; a < Range; a++)
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
                            licznikRK++;
                            iteratorB++;
                            break;
                        }

                    }

                }
                data = pomoc;
                ///zasięgi rimow przewodów;
                zasięgiRimP =new string[licznikRK+1, 3];
                zasięgiRimP[0, 0] = data[0, 3];
                zasięgiRimP[0, 1] = "0";
                int licznikZ = 0;
                for(int i = 1; i <= Range; i++)
                {
                    if (data[i, 3] == data[i - 1, 3])
                    {
                       
                    }
                    else
                    {
                        if (licznikZ <= licznikRK)
                        {
                            zasięgiRimP[licznikZ, 2] = (i-1).ToString();
                            if (i == Range)
                            {
                              
                            }
                            else
                            {
                            licznikZ++;
                            zasięgiRimP[licznikZ, 1] = i .ToString();
                            zasięgiRimP[licznikZ, 0] = data[i , 3];
                            
                            }   
                        }
                    }
                }
                //połączenie z baza danych sprawdzenie rimów przewodów
                for(int i = 0; i < licznikRK; i++)
                {
                    
                }
                //pobranie koloru kom. do czyszczenia rimów kont. niezakówanych 
                    
                   /* for (int i = 4; i < Range+4; i++)
                    {
                        lista.ws.Cells[i, 1].Value2 = ex.NmHernes + "__" + data[i - 4, 0];//dodane pierwszej kolumny nr wiazki 
                        lista.ws.Cells[i, 5].Value2 = "Pos. " + data[i - 4, 0];//dodanie pos.
                        lista.ws.Cells[i, 6].Value2 = ex.NmHernes + "_";//dodanie numeru wiazki wraz z _
                        lista.ws.Cells[i, 8].Value2 = data[i - 4, 2];//dodanie dlugosci przewodu 
                        lista.ws.Cells[i, 11].Value2 = data[i - 4, 3];///dodanie rim przewodu 

                    }///dodani
                    lista.SaveData();
                    ex.Close();
                    lista.Close();*/
                    

            }
        }

        private void TestPołączeniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SQLittleDataBase sql = new SQLittleDataBase();
            if (sql.SprRimPrzewodu("RIM0001") == true)
            {
                string dataz = sql.DT.Rows[0].ItemArray[1].ToString();
                MessageBox.Show(dataz, "rezultat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void DodajUsuńModyfikujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DUM pokaz = new DUM();
            pokaz.Show();
        }
        
    }
}
