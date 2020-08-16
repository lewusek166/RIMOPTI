using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimOptiList
{
    class SQLittleDataBase
    {
        public SQLiteConnection sql_con;
        public SQLiteCommand sql_cmd;
        public SQLiteDataAdapter DB;
        public DataSet DS = new DataSet();
        public DataTable DT = new DataTable();
       


       public SQLittleDataBase()
        {

            SetConnection();
        }

        public void SetConnection()
        {
            sql_con = new SQLiteConnection
                (@"Data Source=C:\Users\Przemysław\source\repos\RimOptiList\RIMOPTI\Data\testDB.db;Version=3;New=False;Compress=True;");
        }

        public void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        public void LoadData(string CommandText)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            sql_con.Close();
        }
        public void Add()
        {
            string txtSQLQuery = "insert into  mains (desc) values (6666666)";
            ExecuteQuery(txtSQLQuery);
        }
        public bool SprRimPrzewodu(string RimP)
        {
             bool czyistnieje=true;
            string cu = "'" + RimP + "'";
            RimP = cu;
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string sqllitleQuery = "SELECT* FROM Przewody WHERE Rim =" + RimP;
            DB = new SQLiteDataAdapter(sqllitleQuery, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            sql_con.Close();
            try
            {
                if(DT.Rows[0].ItemArray[1] != null)
                {
                    czyistnieje= true;
                }
            }
            catch
            {
                czyistnieje= false;
            }
            return czyistnieje;
        }

    }
}


