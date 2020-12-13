using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DAO
{
     class BillInfoDAO
    {
        private static  BillInfoDAO instance;

        public static BillInfoDAO Instance { get { if (instance == null) instance = new BillInfoDAO(); return instance; } set => instance = value; }
        private BillInfo Datarow (DataRow row)
        {
            BillInfo billinfo = new BillInfo((int)row["id"],(int)row["idfood"],(int)row["idbill"],(int)row["idtable"]);
            return billinfo;

        }
        private BillInfoDAO() {}
        public List  <BillInfo> GetBillInfo(int BillId)
        {
            List<BillInfo> ListBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from bill where idbill = " + BillId.ToString());
            
            foreach(DataRow row in data.Rows)
            {
                ListBillInfo.Add(Datarow(row));
            }
            return ListBillInfo;
            
        }

    }
}
