using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DAO
{
    class MenuDAO
    {
        private static MenuDAO instance;

        internal static MenuDAO Instance { get { if (instance == null) instance = new MenuDAO(); return instance; } set => instance = value; }
        Menu Datarow (DataRow row)
        {
            Menu menu = new Menu(row["foodname"].ToString(), (int)row["price"], (int)row["price"]* (int)row["cnt"], (int)row["cnt"]);
            return menu;
        }


        public List<Menu> GetListMenu(int billid)
        {
            List<Menu> ListMenu = new List<Menu>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select Food.FoodName , Food.price , BillInfo.Cnt from Food , billinfo  where BillInfo.idBill =  " + billid.ToString()+ "  and food.id = billinfo.idfood");
            foreach (DataRow row in data.Rows)
            {
                Menu menu = Datarow(row);
                ListMenu.Add(menu);

            }
            return ListMenu;

        }
    }
}
