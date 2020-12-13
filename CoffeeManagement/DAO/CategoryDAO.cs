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
    class CategoryDAO
    {
        private  static CategoryDAO instance;

        public static CategoryDAO Instance { get {if(instance==null) instance = new CategoryDAO();return instance; } set => instance = value; }
        Category Datarow(DataRow row)
        {
            Category category = new Category((int) row["id"],(string)row["CategoryFood"]);
            return category;

        }
        public List<Category> GetListCategory()
        {
            List<Category> ListCategory = new List<Category>();
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from category");
            foreach (DataRow row in data.Rows)
            {
                Category category = Datarow(row);
                ListCategory.Add(category);
            }
            return ListCategory;
        }
        public List<Category> GetListCateforyByName(string name)
        {
            List<Category> ListCategory = new List<Category>();
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetListCategoryByName @CategoryFood",new object[] { name });
            foreach (DataRow row in data.Rows)
            {
                Category category = Datarow(row);
                ListCategory.Add(category);
            }
            return ListCategory;
        }
      
        public Category GetCategoryByName (string name)
        {
            DataTable category = DataProvider.Instance.ExcuteQuery("select * from category where CategoryFood =N'" + name + "'");
            return Datarow(category.Rows[0]);
        }
        private bool CheckCategoryAvailable(int id, string name)
        {
            if ((int)(DataProvider.Instance.ExcuteScalar("USP_CheckCategoryAvailable @id , @name ", new object[] { id.ToString(), name }))>0)
            {
                return false;
            }
            return true;
        }
        public void  AddCategory(string Name)
        {
            if (CheckCategoryAvailable(0, Name))
            {
                DataProvider.Instance.ExcuteQuery(string.Format("insert into Category values(N'{0}')", Name));
            }
            else
                MessageBox.Show("Tên danh mục không hợp lệ","Thông báo");
        }
        public void EditCategory(int id, string Name)
        {
            if(CheckCategoryAvailable(id,Name))
            {
                DataProvider.Instance.ExcuteQuery(string.Format("Update Category set CategoryFood = N'{0}'" +
                    " where id = {1}",  Name, id.ToString()));
            }else
                MessageBox.Show("Tên danh mục không hợp lệ", "Thông báo");
        }
        public void DeleteCategory(int id)
        {
            if ((int)DataProvider.Instance.ExcuteScalar("select count(*) from food where idCategory = " + id.ToString()) == 0)
            {
                DataProvider.Instance.ExcuteQuery("delete from category where id = " + id.ToString());
            }
            else
                MessageBox.Show("Không thể xóa danh mục");
        }



    }
}
