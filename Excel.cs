using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;
using LinqToExcel;

namespace RimOptiList
{
    class Excel
    {
        
        public string NmHernes;
        string path = "";
        _Application excel = new _Excel.Application();
        public Workbook wb;
        public Worksheet ws;
        public Excel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = excel.Worksheets[Sheet];
        }
        public Excel()
        {
            
        }
        public  int RangeData()
        {
            int i = 6;
            while (ws.Cells[i, 1].Value2 != null)
            {
                i++;
            }
            return i-1;
        }
        public void TakeNendN()//sprawdzenie num. wiązki i pobranie nazy || jak błąd koloruj na czerwono w liście 
        {
            NmHernes = ws.Cells[2, 10].Value2;
        }
        public string ReadCell(int i,int j)
        {
            i++;
            j++;
            if(ws.Cells[i, j].Value2!=null)
            {
                return ws.Cells[i, j].Value2;
            }
            else
            {
                return "";
            }
        }
        public string[,] ReadRange(int starti, int starty, int endi, int endy)
        {
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            object[,] holder = range.Value2;
            string [,] returnstring = new string[endi - starti+1, endy - starty+1];
            for (int p = 1; p <= endi - starti+1; p++)
            {
                for (int q = 1; q <= endy - starty + 1; q++)
                {
                    if(holder[p, q] == null)
                    {
                        holder[p, q] = "---";
                    }
                    returnstring[p-1, q-1] = holder[p, q].ToString();
                }
                
            }
            return returnstring;
        }
        public void WriteRange(int starti, int starty, int endi, int endy,string[,] writestring)
        {
            Range range = (Range)ws.Range[ws.Cells[starti, starty], ws.Cells[endi, endy]];
            range.Value2 = writestring;
        }
        public void WriteToCell(int i, int j, string sc)
        {
            i++;
            j++;
            ws.Cells[i, j].Value2 = sc;
        }
 
        public void SaveData()
        {
            wb.Save();
        }
        public void SaveAsData(string path)
        {
            wb.SaveAs(path);
            wb.Close();
        }
        public void Close()
        {
            wb.Close();
            
        }

        public string Get_Colors(int a,int b )
        {
            a += 6;

           string CellColor = ws.Cells[a, b].Interior.Color.ToString(); //Here I go double value which is converted to string.
            return CellColor;

        }
    }
}
