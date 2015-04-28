using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GRU_Verkefni
{
    class sql
    {
        private string Server;
        private string uid;
        private string database;
        private string password;
        string tngstr = null;
        string fyrsp = null;
        MySqlConnection sqltenging;
        MySqlCommand mysqlskipun;
        MySqlDataReader sqllesari = null;

        public void TengingVidGagnagrunn()
        {
            Server = "tsuts.tskoli.is";
            database = "gru_h6_main_database";
            uid = "GRU_H6";
            password = "***";
            tngstr = "server=" + Server + ";uid=" + uid + ";password=" + password + ";database=" + database;
            sqltenging = new MySqlConnection(tngstr);
        }
        private bool OpenConnection()
        {
            try
            {
                sqltenging.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private bool CloseConnection()
        {
            try
            {
                sqltenging.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertMedlim(string username,string name,string password,string status)
        {
            if (OpenConnection() == true)
            {
                fyrsp = "insert into notendur(username,nafn,password,status) values ('" + username + "','" + name + "','" + password + "'," + status + ");";
                mysqlskipun = new MySqlCommand(fyrsp,sqltenging);
                mysqlskipun.ExecuteNonQuery();
                CloseConnection();
            }

        }
        public List<String> SelectMedlim()
        {
            List<string> faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrsp = "select * from notendur;";
                mysqlskipun = new MySqlCommand(fyrsp,sqltenging);
                sqllesari = mysqlskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ";";
                    }
                    faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }
        public void UpdateMedlim(string id, string username, string name, string password, string status, string currid)
        {
            if (OpenConnection() == true)
            {
                fyrsp = "update notendur set id=" + id + ",username='" + username + "',nafn='" + name + "',password='" + password + "',status=" + status + " where id=" + currid + ";";
                mysqlskipun = new MySqlCommand(fyrsp,sqltenging);
                mysqlskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void DeleteMedlim(string id)
        {
            if (OpenConnection() == true)
            {
                fyrsp = "delete from notendur where id=" + id + ";";
                mysqlskipun = new MySqlCommand(fyrsp,sqltenging);
                mysqlskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void InsertAtburd(string name,string dest,string date,string desc)
        {
            if (OpenConnection() == true)
            {
                fyrsp = "insert into vidburdir(name,stadsetning,dagsetning,description) values('" + name + "','" + dest + "','" + date + "','" + desc + "');";
                mysqlskipun = new MySqlCommand(fyrsp, sqltenging);
                mysqlskipun.ExecuteNonQuery();
                CloseConnection();
            }

        }
        public List<String> SelectAtburd()
        {
            List<string> faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrsp = "select * from vidburdir;";
                mysqlskipun = new MySqlCommand(fyrsp, sqltenging);
                sqllesari = mysqlskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ";";
                    }
                    faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }
        public void UppfaeraAtburd(string id, string name, string dest, string date, string desc, string currid)
        {
            if (OpenConnection() == true)
            {
                fyrsp = "update vidburdir set id=" + id + ",name='" + "name" + "',stadsetning='" + dest + "',dagsetning='" + date + "',description='" + desc + "' where id=" + currid + ";";
                mysqlskipun = new MySqlCommand(fyrsp,sqltenging);
                mysqlskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void EydaAtburd(string id)
        {
            if (OpenConnection() == true)
            {
                fyrsp = "delete from vidburdir where id=" + id + ";";
                mysqlskipun = new MySqlCommand(fyrsp, sqltenging);
                mysqlskipun.ExecuteNonQuery();
                CloseConnection();
            }
        }
        public void InsertThattakend(string medlimid, string vidburdid)
        {
            if (OpenConnection() == true)
            {
                fyrsp = "insert into skra(notendurID,vidburdirID) values(" + medlimid + "," + vidburdid + ");";
                mysqlskipun = new MySqlCommand(fyrsp,sqltenging);
                mysqlskipun.ExecuteNonQuery();
                CloseConnection();
            }

        }
        public List<String> SelectThattakend()
        {
            List<string> faerslur = new List<string>();
            string lina = null;
            if (OpenConnection() == true)
            {
                fyrsp = "select * from skra;";
                mysqlskipun = new MySqlCommand(fyrsp, sqltenging);
                sqllesari = mysqlskipun.ExecuteReader();
                while (sqllesari.Read())
                {
                    for (int i = 0; i < sqllesari.FieldCount; i++)
                    {
                        lina += (sqllesari.GetValue(i).ToString()) + ";";
                    }
                    faerslur.Add(lina);
                    lina = null;
                }
                CloseConnection();
                return faerslur;
            }
            return faerslur;
        }
       public void UppfaeraThattakend(string id,string medid,string atid,string currid)
        {
            if (OpenConnection() == true)
            {
                fyrsp = "update skra set id="+id+",notendurID="+medid+",vidburdirID="+atid+" where id="+currid+";";
                mysqlskipun = new MySqlCommand(fyrsp, sqltenging);
                mysqlskipun.ExecuteNonQuery();
                CloseConnection();


            }


        }
       public void EydaThattakend(string id)
       {
           if (OpenConnection() == true)
           {
               fyrsp = "delete from skra where id=" + id + ";";
               mysqlskipun = new MySqlCommand(fyrsp, sqltenging);
               mysqlskipun.ExecuteNonQuery();
               CloseConnection();
           }
       }
    }
}
