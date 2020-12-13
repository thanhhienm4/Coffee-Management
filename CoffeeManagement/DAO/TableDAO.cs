using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_quan_cafe.DAO
{
    class TableDAO
    {
        private static TableDAO instacne;

        public static int height = 70 ;
        public static int width = 70;

        
        public static TableDAO Instacne { get { if (instacne == null) instacne = new TableDAO(); return instacne; } set => instacne = value; }
        public Table DataRow (DataRow row)
        {
            Table table = new Table((int)row["ID"], row["Name"].ToString(), row["Status"].ToString(), (int)row["Capacity"]);
            return table;

        }
        bool CheckNameAvailable(int id,string name)
        {
            int count = (int)DataProvider.Instance.ExcuteScalar("UPS_CheckTableNameAvailable @id , @name", new object[] { id.ToString(), name });
            if (count == 0)
                return true;
            else
            {
                MessageBox.Show("Tên bàn không khả dụng", "Thông báo");
                return false;
            }
        }
        public List<Table> LoadListTable ()
        {
            List<Table> ListTable = new List<Table>();
            DataTable Data = DataProvider.Instance.ExcuteQuery("Select * from TableFood");

            foreach(DataRow row in Data.Rows)
            {
                Table table = DataRow(row);
                ListTable.Add(table);
            }
            return ListTable; 

        }
        public List<Table> LoadListTableByName(string name)
        {
            List<Table> ListTable = new List<Table>();
            DataTable Data = DataProvider.Instance.ExcuteQuery(" USP_GetListTableByName @Name", new object[] {name});

            foreach (DataRow row in Data.Rows)
            {
                Table table = DataRow(row);
                ListTable.Add(table);
            }
            return ListTable;

        }

        public void ChangeTableStatus(int id,bool mode)
        {
            if(mode == true)
                DataProvider.Instance.ExcuteQuery("Update tablefood set status = N'Có khách' where id = N'" + id.ToString() + "'");
            else
                DataProvider.Instance.ExcuteQuery("Update tablefood set status = N'Trống' where id = N'" + id.ToString() + "'");

        }
        public int FindTableIdbyName(string Name)
        {
            return (int)DataProvider.Instance.ExcuteScalar("select max(id) from tablefood where name = N'" + Name + "'");
        }
        public void UpdateTableStatus()
        {
            DataProvider.Instance.ExcuteQuery(" UPS_UpdateStatus");
        }
        public void AddTable(int Capacity, string Name)
        {
            if(CheckNameAvailable(0,Name))
            {
                DataProvider.Instance.ExcuteQuery(" USP_InsertTable @capacity , @name , @status ", new object[] { Capacity.ToString(), Name, "Trống" });
            }    
        }
        public void EditTable(int id ,int Capacity ,string Name, string Status)
        {
            if(CheckNameAvailable(id, Name))
            {
                DataProvider.Instance.ExcuteQuery("USP_EditTable @id , @capacity , @name , @status ", new object[] { id.ToString(), Capacity.ToString(), Name, Status });
            }
        }
        public void DeleteTable(int id)
        {
            if((int)DataProvider.Instance.ExcuteScalar(string.Format("select count(*) from bill where idtablefood = {0}",id)) == 0)
            {
                DataProvider.Instance.ExcuteQuery(string.Format("delete from tablefood where id = {0} ", id));
            }else
            {
                MessageBox.Show("Không thể xóa bàn","Thông báo");
            }
        }
    }
}
