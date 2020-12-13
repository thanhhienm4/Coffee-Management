using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DTO
{
    class Category
    {
        private int iD;
        private string name;

        public Category(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
