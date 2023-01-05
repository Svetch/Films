using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Films
{
    internal class Database
    {
        static Database db;
        static MySqlConnection dbConn;
        public static Database Instance
        {
            get
            {
                if (db != null) return db;
                else
                {
                    db = new Database();
                }
                return db;
            }
        }

        private Database()
        {
            dbConn = new MySqlConnection("Server = localhost; Database = films; Uid = films; Pwd = films;");
        }

        public MySqlCommand newMysqlCommand(string cmd)
        {
            return new MySqlCommand(cmd, dbConn);
        }

        public void init()
        {
            if (dbConn.State == System.Data.ConnectionState.Open) return;
            dbConn.Open();
        }
    }
}
