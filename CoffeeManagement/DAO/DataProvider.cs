using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_quan_cafe.DAO
{
     public class DataProvider
    {
        private static DataProvider instance;
        private string ConnectionSTR = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLiQuanCafe1;Integrated Security=True";

        public static DataProvider Instance { get {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            } set => instance = value; }
        private DataProvider() { }
        public DataTable ExcuteQuery (string Query, object  [] parameter = null)
        {
            DataTable Data = new DataTable();
            using (SqlConnection Connection = new SqlConnection(ConnectionSTR))
            {
                Connection.Open();
                SqlCommand Commmand = new SqlCommand(Query, Connection);
                int i = 0;
                if(parameter != null)
                {
                    string[] listpara = Query.Split(' ');
                    foreach( string item in listpara)
                    {
                        if(item.Contains('@'))
                        {
                            Commmand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                

                SqlDataAdapter Adapter = new SqlDataAdapter(Commmand);
                Adapter.Fill(Data);
                Connection.Close();
            }
            
            return Data;
        }

        public int ExcuteNonQuery(string Query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection Connection = new SqlConnection(ConnectionSTR))
            {
                Connection.Open();
                SqlCommand Commmand = new SqlCommand(Query, Connection);
                int i = 0;
                if (parameter != null)
                {
                    string[] listpara = Query.Split(' ');
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            Commmand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                data = Commmand.ExecuteNonQuery();
                Connection.Close();
            }

            return data;
        }
        public object ExcuteScalar(string Query, object[] parameter = null)
        {
            object Data = new object();
            using (SqlConnection Connection = new SqlConnection(ConnectionSTR))
            {
                Connection.Open();
                SqlCommand Commmand = new SqlCommand(Query, Connection);
                int i = 0;
                if (parameter != null)
                {
                    string[] listpara = Query.Split(' ');
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            Commmand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }


                Data = Commmand.ExecuteScalar();
                Connection.Close();
            }

            return Data;
        }
    }

   
    
            
}
