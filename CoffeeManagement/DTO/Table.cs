using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DTO
{
    class Table
    {
        private int iD;
        private string name;
        private string status;
        private int  capacity;
        public  Table(int ID , string Name, string Status,int Capacity )
        {
            this.ID = ID;
            this.Name = Name;
            this.Status = Status;
            this.Capacity = Capacity;
        }
 

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public int  Capacity { get => capacity; set => capacity = value; }
    }
}
