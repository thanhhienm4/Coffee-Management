using Quan_li_quan_cafe.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DTO
{
    class BillInfo
    {
        private int id;
        private int idFood;
        private int idBill;
        private int Cnt;

        public BillInfo(int id, int idfood , int idbill, int cnt)
        {
            this.id = id;
            this.idFood = idfood;
            this.idBill = idbill;
            this.Cnt = cnt;
        }
       

        public int Id { get => id; set => id = value; }
        public int IdFood { get => idFood; set => idFood = value; }
        public int IdBill { get => idBill; set => idBill = value; }
        public int Cnt1 { get => Cnt; set => Cnt = value; }
    }
}
