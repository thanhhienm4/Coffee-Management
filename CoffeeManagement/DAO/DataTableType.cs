using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DAO
{
    public class DataTableType
    {
        private static DataTableType instance;

        internal static DataTableType Instance { get { return instance == null ? new DataTableType() : instance; } set => instance = value; }
        private DataTableType() { }
        public DataTable GetListFoodByName(string name)
        {
            DataTable data = new DataTable();
            try
            {
                data = DataProvider.Instance.ExcuteQuery("USP_GetDataTableFoodByName @Name ", new object[] { name });
            }
            catch { }

            return data;
        }
        public DataTable GetLisAccoutByName(string name)
        {
            if (name == null)
                name = "";
            DataTable data = new DataTable();
          
            data = DataProvider.Instance.ExcuteQuery(" USP_GetDataTableAccountByName N'"+ name+"'" );
    

            return data;
        }

    }
}
