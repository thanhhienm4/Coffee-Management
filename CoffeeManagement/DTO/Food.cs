using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DTO
{
    class Food
    {
        private int iD;
        private int iDCategory ;
        private string name;
        private int price;

        public Food(int id , int idcategory , string name , int price)
        {
            this.ID = id;
            this.IDCategory = idcategory;
            this.Name = name;
            this.Price = price;
        }

        public int ID { get => iD; set => iD = value; }
        public int IDCategory { get => iDCategory; set => iDCategory = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
    } 
}
