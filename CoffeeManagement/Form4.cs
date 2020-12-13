using Quan_li_quan_cafe.DAO;
using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_quan_cafe
{
    public partial class AdminForm : Form
    {
        BindingSource FoodList = new BindingSource();
        BindingSource AccountList = new BindingSource();
        BindingSource CategoryList = new BindingSource();
        BindingSource TableList = new BindingSource();
        public AdminForm()
        {
            InitializeComponent();
            Load();
        }
        void Load() 
        {
            LoadAccountList();
            InnitialStaticticForMonth();
            LoadFood();
            AddBindingFood();
            LoadAccountList();
            AddBindingAccount();
            LoadCategory();
            AddBindingCategory();
            LoadTable();
            AddBindingTable();
        }
        #region Account
        void LoadAccountList()
        {
            Accountdtgv.DataSource = AccountList;
            AccountList.DataSource = DataTableType.Instance.GetLisAccoutByName(FindAccountbx1.Text);
            //AccountList.DataSource = DataProvider.Instance.ExcuteQuery("select * from account");
            Accountdtgv.Columns["DisplayName"].HeaderText = "Tền hiển thị";
            Accountdtgv.Columns["UserName"].HeaderText = "Tên đăng nhập";
            // Accountdtgv.Columns["Password"].HeaderText = "Mật khẩu";
            Accountdtgv.Columns["Type"].HeaderText = "Admin";

        }
        void AddBindingAccount()
        {
            AccoutIdtbx.DataBindings.Add(new Binding("Text", Accountdtgv.DataSource, "Id", true, DataSourceUpdateMode.Never));
            AccoutDisplayNametbx.DataBindings.Add(new Binding("Text", Accountdtgv.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            AccountUserNametbx.DataBindings.Add(new Binding("Text", Accountdtgv.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            AccountTypetbx.DataBindings.Add(new Binding("Text", Accountdtgv.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void AddAccount()
        {
            int id = Int32.Parse(AccoutIdtbx.Text);
            string UserName = AccountUserNametbx.Text;
            string DisPlayName = AccoutDisplayNametbx.Text;
            int Type;
            Int32.TryParse(AccountTypetbx.Text, out Type);
            if (Type == 0 || Type == 1)
            {
                if (AccountDAO.Instance.CheckUserNameAvailable(0, UserName))
                    AccountDAO.Instance.InsertAccount(DisPlayName, UserName, UserName, Type);
                else
                    MessageBox.Show("Tên đăng nhập không hợp lệ", "Thông báo");

            }
            else
                MessageBox.Show("Loại tài khoảng không hợp lệ", "Thông báo");
        }
        void EditAccount()
        {
            int id = Int32.Parse(AccoutIdtbx.Text);
            string UserName = AccountUserNametbx.Text;
            string DisPlayName = AccoutDisplayNametbx.Text;
            int Type;
            Int32.TryParse(AccountTypetbx.Text, out Type);
            if (Type == 0 || Type == 1)
            {
                if (AccountDAO.Instance.CheckUserNameAvailable(id, UserName))
                    AccountDAO.Instance.EditAccount(id, DisPlayName, UserName, Type);
                else
                    MessageBox.Show("Tên đăng nhập không hợp lệ", "Thông báo");

            }
            else
                MessageBox.Show("Loại tài khoảng không hợp lệ", "Thông báo");
        }
        void ResetPassWord()
        {
            int id = Int32.Parse(AccoutIdtbx.Text);
            string UserName = AccountUserNametbx.Text;
            //int Type = Int32.Parse(AccountTypetbx.Text);
            AccountDAO.Instance.ResetPassWord(id, UserName);
        }
        void DeleteAccount()
        {
            int id = Int32.Parse(AccoutIdtbx.Text);
            AccountDAO.Instance.DeleteAccount(id);
        }

        private void AddAccountbtn_Click(object sender, EventArgs e)
        {
            AddAccount();
            LoadAccountList();
        }

        private void DeleteAccountbtn_Click(object sender, EventArgs e)
        {
            DeleteAccount();
            LoadAccountList();
        }

        private void EditAccountbtn_Click(object sender, EventArgs e)
        {
            EditAccount();
            LoadAccountList();
        }
        private void ResetPasswordbtn_Click(object sender, EventArgs e)
        {
            ResetPassWord();
            LoadAccountList();
        }

        private void FindAccountbx1_TextChanged(object sender, EventArgs e)
        {
            LoadAccountList();
        }

        #endregion
        #region Category
        private event EventHandler updateCategory;
        public event EventHandler Updatecategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }
        void LoadCategory()
        {
            Categorydgv.DataSource = CategoryList;
            CategoryList.DataSource = CategoryDAO.Instance.GetListCateforyByName(FindCategorytbx.Text);
            Categorydgv.Columns["Name"].HeaderText = "Danh mục"; 
        }
        void AddBindingCategory()
        {
            CategoryIdtbx.DataBindings.Add("Text", Categorydgv.DataSource, "Id", true, DataSourceUpdateMode.Never);
            CategoryNamebtx.DataBindings.Add("Text", Categorydgv.DataSource, "Name", true, DataSourceUpdateMode.Never);
        }
        void AddCategory()
        {
            
            string Name = CategoryNamebtx.Text;
            if (Name != null)
            {
                CategoryDAO.Instance.AddCategory(Name);
                LoadCategory();
                updateCategory(this, new EventArgs());
            }


        }
        void DeleteCategory()
        {
            try
            {
                int id = Int32.Parse(CategoryIdtbx.Text);
                CategoryDAO.Instance.DeleteCategory(id);
                LoadCategory();
                updateCategory(this, new EventArgs());
            }
            catch
            {
                MessageBox.Show("Xóa thất bại", "Thông Báo");
            }
            
        }
        void EditCategory()
        {
            try
            {
                int id = Int32.Parse(CategoryIdtbx.Text);
                string Name = CategoryNamebtx.Text;
                CategoryDAO.Instance.EditCategory(id, Name);
                LoadCategory();
                updateCategory(this,new EventArgs());
            }catch
            {
                MessageBox.Show("Chỉnh sửa thất bại", "Thông báo");
            }
            
        }
        private void AddCateforybtn_Click(object sender, EventArgs e)
        {
            AddCategory();
        }

        private void DeleteCategorybtn_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }

        private void EditCategorybtn_Click(object sender, EventArgs e)
        {
            EditCategory();
        }

        private void FindCategorytbx_TextChanged(object sender, EventArgs e)
        {
            LoadCategory();
        }
        #endregion
        #region Table
        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        private void value(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void LoadTable()
        {
            Tabledgv.DataSource = TableList;
            TableList.DataSource = TableDAO.Instacne.LoadListTableByName(FindTabletbx.Text);
            Tabledgv.Columns["Name"].HeaderText = "Tên Bàn";
            Tabledgv.Columns["Capacity"].HeaderText = "Chỗ ngồi";
            Tabledgv.Columns["Status"].HeaderText = "Trạng thái";

        }
        void AddBindingTable()
        {
            TableIdtbx.DataBindings.Add("Text", Tabledgv.DataSource, "Id", true, DataSourceUpdateMode.Never);
            TableNametbx.DataBindings.Add("Text", Tabledgv.DataSource, "Name", true, DataSourceUpdateMode.Never);
            TableStatustbx.DataBindings.Add("Text", Tabledgv.DataSource, "Status", true, DataSourceUpdateMode.Never);
            TableCapacitytbx.DataBindings.Add("Text", Tabledgv.DataSource, "Capacity", true, DataSourceUpdateMode.Never);
        }
        void InsertTable()
        {
            string Name = TableNametbx.Text;
            int Capacity;
            Int32.TryParse(TableCapacitytbx.Text,out Capacity);
            try
            {
                TableDAO.Instacne.AddTable(Capacity, Name);
                LoadTable();
                updateTable(this, new EventArgs());
            }
            catch
            {
                MessageBox.Show("Thêm không thành công");
            }
        }
        void EditTable()
        {
            int Id = Int32.Parse(TableIdtbx.Text);
            string Name = TableNametbx.Text;
            int Capacity;
            Int32.TryParse(TableCapacitytbx.Text, out Capacity);
            string Status = TableStatustbx.Text;
            try
            {
                TableDAO.Instacne.EditTable(Id, Capacity, Name, Status);
                LoadTable();
                updateTable(this, new EventArgs());
            }
            catch
            {
                MessageBox.Show("Chỉnh sửa không thành công ", "Thông báo");
            }
            
        }
        void DeleteTable()
        {
            int Id = Int32.Parse(TableIdtbx.Text);
            try
            {
                TableDAO.Instacne.DeleteTable(Id);
                LoadTable();
                updateTable(this, new EventArgs());
            }
            catch
            {
                MessageBox.Show("Xóa không thành công", "Thông báo");
            }
            
        }
        private void AddTabletbn_Click(object sender, EventArgs e)
        {
            InsertTable();
        }

        private void DeleteTabletbn_Click(object sender, EventArgs e)
        {
            DeleteTable();
        }

        private void EditTabletbn_Click(object sender, EventArgs e)
        {
            EditTable();
        }
        private void FindTabletbx_TextChanged(object sender, EventArgs e)
        {
            LoadTable();
        }
        #endregion
        #region Bill
        private void InnitialStaticticForMonth()
        {
            DateTime today = DateTime.Now;

            Startdtp.Value = new DateTime(today.Year, today.Month, 1);
            Enddtp.Value = Startdtp.Value.AddMonths(1).AddDays(-1);

        }
        private void Statiticbtn_Click(object sender, EventArgs e)
        {
            PageMaxtbx.Text = Math.Ceiling(BillDAO.Instance.GetCountBillByDateAndPage(Startdtp.Value, Enddtp.Value)/15.0).ToString();
            DataTable data = BillDAO.Instance.GetBillByDateAndPage(Startdtp.Value, Enddtp.Value, 1);
            data.Columns.Add("Stt").SetOrdinal(0);
            int i = 0;
            foreach (DataRow row in data.Rows)
            {
                row["stt"] =  i + 1;
                i++;
            }
            Revenuedtgv.DataSource = data;

        }

        private void Firstbtn_Click(object sender, EventArgs e)
        {
            Pagetbx.Text = 1.ToString();
        }
        private void Previoustbx_Click(object sender, EventArgs e)
        {
            int Page;
            Int32.TryParse(Pagetbx.Text, out Page);
            if (Page != 1)
            {
                Pagetbx.Text = (Page - 1).ToString();
            }
        }

        private void Nextbtn_Click(object sender, EventArgs e)
        {
            int Page;
            Int32.TryParse(Pagetbx.Text, out Page);
            if (Page != Int32.Parse(PageMaxtbx.Text))
            {
                Pagetbx.Text = (Page + 1).ToString();
            }
        }

        private void Lastbtn_Click(object sender, EventArgs e)
        {
            Pagetbx.Text = PageMaxtbx.Text;
        }
        private void Pagetbx_TextChanged(object sender, EventArgs e)
        {
            int Page;
            Int32.TryParse(Pagetbx.Text, out Page);
            //BillDAO.Instance.GetBillByDateAndPage(Startdtp.Value, Enddtp.Value, Page);
            DataTable data = BillDAO.Instance.GetBillByDateAndPage(Startdtp.Value, Enddtp.Value, Page);
            data.Columns.Add("Stt").SetOrdinal(0);
            int i = 0;
            foreach (DataRow row in data.Rows)
            {
                row["stt"] = (Page - 1) * 15 + i+ 1;
                i++;
            }
            Revenuedtgv.DataSource = data;
        }
        #endregion
        #region Food
        void AddBindingFood()
        {
            Categorycbx.DataSource = CategoryDAO.Instance.GetListCategory();
            Categorycbx.DisplayMember = "Name";
            FoodIdtbx.DataBindings.Add(new Binding("Text", Fooddtgv.DataSource, "Id", true, DataSourceUpdateMode.Never));
            FoodNametbx.DataBindings.Add(new Binding("Text", Fooddtgv.DataSource, "Tên món", true, DataSourceUpdateMode.Never));
            FoodPricetbx.DataBindings.Add(new Binding("Text", Fooddtgv.DataSource, "Giá", true, DataSourceUpdateMode.Never));

        }
        void LoadFood()
        {
            Fooddtgv.DataSource = FoodList;
            FoodList.DataSource = DataProvider.Instance.ExcuteQuery("select f.id, f.FoodName as[Tên món] , c.CategoryFood as [Danh mục], f.Price as [Giá] from food as f , Category as c where c.id = f.idCategory ");
        }

        private void FoodIdtbx_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if(Fooddtgv.SelectedCells[0].OwningRow.Cells["Danh mục"].Value != null)
                {
                    string name = Fooddtgv.SelectedCells[0].OwningRow.Cells["Danh mục"].Value.ToString();
                    if (name != null)
                    {
                        Category category = CategoryDAO.Instance.GetCategoryByName(name);
                        int index = 0;
                        foreach (Category item in Categorycbx.Items)
                        {
                            if (item.ID == category.ID)
                            {
                                break;
                            }
                            else
                                index++;
                        }
                        Categorycbx.SelectedIndex = index;
                    }
                }
                
                
            }
            catch
            { }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            LoadFood();
        }
        void AddFood()
        {
            try
            {
                if (Categorycbx.SelectedItem != null)
                {
                    string Name = FoodNametbx.Text;
                    int CategoryId = (Categorycbx.SelectedItem as Category).ID;
                    int Price;
                    Int32.TryParse(FoodPricetbx.Text, out Price);
                    if (FoodDAO.Instance.CheckFoodNameAvailable(0, Name))
                    {
                        FoodDAO.Instance.InsertFood(Name, CategoryId, Price);
                        LoadFood();
                    }
                    else
                        MessageBox.Show("Tên không khả dụng", "Thông báo");

                }
                else

                    MessageBox.Show("Danh mục không hợp lệ", "Thông báo");
            }catch
            {
                MessageBox.Show("Thêm Thất bại", "Thông báo");
            }
            
        }
        void EditFood()
        {
            try
            {
                if (Categorycbx.SelectedItem != null)
                {
                    int CategoryId = (Categorycbx.SelectedItem as Category).ID;
                    int id = Int32.Parse(FoodIdtbx.Text);
                    string Name = FoodNametbx.Text;
                    int Price;
                    Int32.TryParse(FoodPricetbx.Text, out Price);
                    if (FoodDAO.Instance.CheckFoodNameAvailable(id, Name))
                    {
                        FoodDAO.Instance.EditFood(id, Name, CategoryId, Price);
                        LoadFood();
                    }
                    else
                        MessageBox.Show("Tên không khả dụng", "Thông báo");


                }
                else
                {
                    MessageBox.Show("Danh mục không hợp lệ", "Thông báo");
                }
            }catch
            {
                MessageBox.Show("Chỉnh sửa thất bại", "Thông báo");
            }
            
            
        }
        void DeleteFood()
        {
            try
            {
                if (Categorycbx.SelectedItem != null)
                {
                    int CategoryId = (Categorycbx.SelectedItem as Category).ID;
                    int Price;
                    Int32.TryParse(FoodPricetbx.Text, out Price);
                    int id = Int32.Parse(FoodIdtbx.Text);
                    FoodDAO.Instance.DeleleFood(id);
                    LoadFood();
                }
                else
                    MessageBox.Show("Danh mục không hợp lệ", "Thông báo");
            }catch
            {
                MessageBox.Show("Xóa Thất bại", "Thông báo");
            }
            



        }

        private void AddFoodbtn_Click(object sender, EventArgs e)
        {
            AddFood();
            updateFoodEvent(this, e);
            
            
        }

        private void DeleteFoodbtn_Click(object sender, EventArgs e)
        {
            DeleteFood();
            updateFoodEvent(this, e);
            
        }

        private void EditFoodbtn_Click(object sender, EventArgs e)
        {
            EditFood();
            updateFoodEvent(this, e);
            
            
        }
        private event EventHandler updateFoodEvent;

        public event EventHandler UpdateFoodEvent
        {
            add { updateFoodEvent += value; }
            remove { updateFoodEvent -= value; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(FindFoodbtx.Text != null)
            FoodList.DataSource = DataTableType.Instance.GetListFoodByName(FindFoodbtx.Text);
           
        }

        
    }
    #endregion

}
