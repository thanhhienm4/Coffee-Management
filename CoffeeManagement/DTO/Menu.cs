using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DAO
{
    class Menu
    {
        private string name;
        private int dongia;
        private int thanhtien;
        private int soluong;

        public Menu(string name, int dongia, int thanhtien, int soluong)
        {
            this.name = name;
            this.dongia = dongia;
            this.thanhtien = thanhtien;
            this.soluong = soluong;

        }
       
        public string Name { get => name; set => name = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public int Thanhtien { get => thanhtien; set => thanhtien = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
