using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_quan_cafe.DAO
{
    class FoodDAO
    {
        private static FoodDAO instance;

        internal static FoodDAO Instance { get { if (instance == null) instance = new FoodDAO(); return instance; } set => instance = value; }
        Food Datarow(DataRow row)
        {
            Food food = new Food((int)row["id"], (int)row["idcategory"], (string)row["foodname"], (int)row["price"]);
            return food;
        }
        public List<Food> GetListFoodByCategory(int idCategory)
        {
            List<Food> listfood = new List<Food>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from food where idCategory = " + idCategory.ToString());
            foreach (DataRow row in data.Rows)
            {
                Food food = Datarow(row);
                listfood.Add(food);

            }
            return listfood;
        }
        public List <Food> GetListFood()
        {
            List<Food> listfood = new List<Food>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from food ");
            foreach (DataRow row in data.Rows)
            {
                Food food = Datarow(row);
                listfood.Add(food);

            }
            return listfood;
        }
        internal bool GetListFoodByCategory(object idCategory)
        {
            throw new NotImplementedException();
        }
        public void InsertFood (string Name , int CategoryId , int Price)
        {
            DataProvider.Instance.ExcuteQuery(string.Format("Insert into Food Values ({0} , N'{1}' , {2})",  CategoryId.ToString(), Name, Price.ToString()));

        }
        public void DeleleFood (int FoodId)
        {
            //DataProvider.Instance.ExcuteQuery(string.Format("Delete from BillInfo  where IdFood = N'" + FoodId.ToString()+ "'"));
            int count = (int)DataProvider.Instance.ExcuteScalar("Select count(*) from billinfo where idfood = "+ FoodId.ToString());
            if(count > 0)
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
            }else
            {
                DataProvider.Instance.ExcuteQuery("Delete from Food  where Id = N'" + FoodId.ToString() + "'");
            }    
            
        }
        public void EditFood (int id ,string Name ,int CategoryID, int Price)
        {
            DataProvider.Instance.ExcuteQuery("UPS_updatefood @id , @foodname , @idcategory , @price", new object[] {id.ToString(), Name , CategoryID.ToString(), Price.ToString() });
        }
        public bool CheckFoodNameAvailable(int id, string name)
        {
            int ok = (int)DataProvider.Instance.ExcuteScalar("UPS_CheckFoodNameAvailable @id , @foodname", new object[] {id.ToString() ,name });
            return ok > 0 ? false : true; 
        }
    }
}
