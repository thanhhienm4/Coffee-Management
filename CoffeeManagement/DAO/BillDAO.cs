using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DAO
{
    class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance { get { if (instance == null) instance = new BillDAO(); return instance; } set => instance = value; }
        public Bill DataRow(DataRow row)
        {
            Bill bill = new Bill((int)row["id"], (DateTime)row["DateCheck"], (int)row["idtablefood"], row["Status"].ToString(), (int)row["Cost"], (int)row["Discount"]);
            return bill;
        }

        public int FindBillIDbyTableID(int TableID)
        {

            DataTable Data = DataProvider.Instance.ExcuteQuery("select * from bill where idtablefood = " + TableID.ToString() + " and status = N'Chưa thanh toán'");
            if (Data.Rows.Count > 0)
            {
                Bill bill = DataRow(Data.Rows[0]);
                return bill.ID;

            }
            return -1;
        }
        public int FindDiscountbyBillId(int BillId)
        {

            DataTable Data = DataProvider.Instance.ExcuteQuery("select * from bill where id = " + BillId.ToString());
            Bill bill = DataRow(Data.Rows[0]);
            return bill.Discount;
        }
        public void ChangTableID(int BillId, string TableName)
        {

            int NewTableId = (int)DataProvider.Instance.ExcuteScalar("select max(id) from tablefood where Name = N'" + TableName + "'");
            DataProvider.Instance.ExcuteQuery("exec USP_ChangeTable @NewTableId , @BillId ", new object[] { NewTableId.ToString(), BillId.ToString() });
        }

        public void ClearBill()
        {
            DataProvider.Instance.ExcuteQuery("delete Bill  where   (select count(*) from BillInfo where Bill.id = BillInfo.idBill) = 0");
        }
        public DataTable GetBillByDate(DateTime Start, DateTime End)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetBillByDate @DateStart , @DateEnd ", new Object[] { Start, End });
            return data;
        }
        public DataTable GetBillByDateAndPage(DateTime Start, DateTime End,int Page)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetListBillByDateAndPage @DateStart , @DateEnd , @page ", new Object[] { Start, End, Page.ToString() });
            return data;
        }
        public int GetCountBillByDateAndPage(DateTime Start, DateTime End)
        {
            return (int)DataProvider.Instance.ExcuteScalar("USP_GetCountBillByDate @DatesStart , @DateEnd", new object[] { Start, End });
        }

    }
}
