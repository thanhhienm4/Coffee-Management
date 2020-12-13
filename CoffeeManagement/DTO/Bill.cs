using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DTO
{
    class Bill
    {
        private int iD;
        private DateTime date;
        //private string idAccount;
        private int  idTable;
        private string status;
        private int cost;
        private int discount;

        public  Bill (int  iD, DateTime date ,int idTable,string status , int  cost,int discount = 0)
        {
            this.iD = iD;
            this.date = date;
            //this.idAccount = idAccount;
            this.idTable = idTable;
            this.status = status;
            this.cost = cost;
            this.discount = discount;
        }

        public int ID { get => iD; set => iD = value; }
        public DateTime Date { get => date; set => date = value; }
       // public string IdAccount { get => idAccount; set => idAccount = value; }
        public int IdTable { get => idTable; set => idTable = value; }
        public string Status { get => status; set => status = value; }
        public int Cost { get => cost; set => cost = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
