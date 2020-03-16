using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace RimOptiList
{
    class Excel
    {
        string path = "";
        _Application excel = new _Excel.Application();
        Workbook wb,wbSource,wbTarget;
        Worksheet ws;
        public Excel(string path, int Sheet)
        {
            this.path = path;
            wb = excel.Workbooks.Open(path);
            ws = excel.Worksheets[Sheet];
        }
        public Excel()
        {

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
            string[,] returnstring = new string[endi - starti, endy - starty];
            for (int p = 1; p <= endi - starti; p++)
            {
                for (int q = 1; q <= endy - starty; q++)
                {
                    returnstring[p - 1, q - 1] = holder[p, q].ToString();
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
        public void CreateNewFileWithTemplate(string fileName,string path, string sorceFilename)
        {
            string sourceFileName = sorceFilename;
            string tempFileName = path;
            string folderPath = @"Data\";
            string sourceFilePath = System.IO.Path.Combine(folderPath, sourceFileName);
            string destinationFilePath = System.IO.Path.Combine(folderPath, tempFileName);

            File.Copy(sourceFilePath, destinationFilePath, true);
            wbSource = excel.Workbooks.Open(sourceFilePath);
            wbTarget = excel.Workbooks.Open(destinationFilePath);
            ws = wbSource.Worksheets["Sheet1"]; 
            ws.Name = "TempSheet"; 

            ws.Copy(wbTarget.Worksheets[1]); //Actual copy
            wbSource.Close(false);
            wbTarget.Close(true);
            excel.Quit();

            System.IO.File.Delete(sourceFilePath);
            System.IO.File.Move(destinationFilePath, sourceFilePath);
        }
    }
        public void SaveData()
        {
            wb.Save();
        }
        public void SaveAsData(string path)
        {
            wb.SaveAs(path);
        }
        public void Close()
        {
            wb.Close();
        }
    }
}
