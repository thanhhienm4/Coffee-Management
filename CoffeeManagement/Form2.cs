using Quan_li_quan_cafe.DAO;
using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_quan_cafe
{
    public partial class FunctFrom : Form
    {
        private Account accountLogin;

        public Account AccountLogin { get => accountLogin; set { accountLogin = value; ChangeAccount(AccountLogin.Type); } }

        public FunctFrom(Account accountlogin)
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            this.AccountLogin = accountlogin;
           // ChangeAccount(this.AccountLogin.Type);
        }
        #region method
        void ChangeAccount(int Type)
        {
            adminToolStripMenuItem.Enabled = Type == 1;
        }
        void LoadTable()
        {
            TableDAO.Instacne.UpdateTableStatus();
            Tablefpnl.Controls.Clear();
            List<Table> ListTable = new List<Table>();
            ListTable = TableDAO.Instacne.LoadListTable();
            foreach(Table table in ListTable)
            {
                Button btn = new Button();
                btn.Height = TableDAO.height;
                btn.Width = TableDAO.width;

                btn.Text = table.Name + "\n" + table.Status;
               
                btn.Tag = table;
                btn.Click += Btn_Click;
                if (table.Status != "Trống")
                    btn.BackColor = Color.GreenYellow;
                else
                    btn.BackColor = Color.Cyan;
                Tablefpnl.Controls.Add(btn);


            }
        }
        void ChangeButtonStatusPay(Button btn )
        {
           
            if (btn != null)
            {
                btn.BackColor = Color.Cyan;
                Table table = MenuLvw.Tag as Table;
                table.Status = "Trống";
                btn.Text = table.Name + Environment.NewLine + table.Status;
            }
            
        }
        void ChangeButtonStatusNoPay(Button btn)
        {
            if (btn != null)
            {
                btn.BackColor = Color.GreenYellow;
                Table table = MenuLvw.Tag as Table;
                table.Status = "Có khách";
                btn.Text = table.Name + Environment.NewLine + table.Status;
            }    
               
        }


        void ShowBIll (int BillId)
        {
            MenuLvw.Items.Clear();
            TotalPricetbx.Text = "0";
            if (BillId!=-1)
            {
                Discoutnmud.Value = BillDAO.Instance.FindDiscountbyBillId(BillId);
                List<DAO.Menu> ListMenu = new List<DAO.Menu>();

                ListMenu = MenuDAO.Instance.GetListMenu(BillId);
                int TotalPrice = 0;
                foreach (DAO.Menu menu in ListMenu)
                {
                    TotalPrice += menu.Thanhtien;
                    ListViewItem lvItem = new ListViewItem(menu.Name);
                    lvItem.SubItems.Add(menu.Dongia.ToString());
                    lvItem.SubItems.Add(menu.Soluong.ToString());
                    lvItem.SubItems.Add(menu.Thanhtien.ToString());
                    MenuLvw.Items.Add(lvItem);
                }

                CultureInfo culture = new CultureInfo("vn-VN");

                //TotalPricetbx.Text = string.Format(	"{0:#.##}" ,TotalPrice.ToString("c",culture));
                TotalPricetbx.Text = TotalPrice.ToString();
                DataProvider.Instance.ExcuteQuery("update bill set cost = " + TotalPrice.ToString() + " Where id = " + BillId.ToString());

            }

        }
        void LoadCategory()
        {
            List<Category> listcategory = CategoryDAO.Instance.GetListCategory();
            Categorycbx.DataSource = listcategory;
            Categorycbx.DisplayMember = "name";

        }
        void LoadFood(int IdCategory)
        {
            List<Food> listfood = FoodDAO.Instance.GetListFoodByCategory(IdCategory);
            Foodcbx.DataSource = listfood;
            Foodcbx.DisplayMember = "Name";

        }
        void AddFood(int TableId)
        {
            int BillId = BillDAO.Instance.FindBillIDbyTableID(TableId);
            if(BillId == -1)
            {
                DataProvider.Instance.ExcuteNonQuery("exec USP_AddBill @idaccount , @idtablefood , @discount ", new object []  { AccountLogin.Id.ToString() , TableId.ToString(), "0" }  );
                BillId =(int) DataProvider.Instance.ExcuteScalar("select Max(id) from bill") ;
                DataProvider.Instance.ExcuteQuery("Update tablefood set status = N'Có khách' where id = " + TableId.ToString());

               

            }
            int foodid = (int)DataProvider.Instance.ExcuteScalar("select max(id) from food where FoodName = N'" + (Foodcbx.SelectedItem as Food).Name+"'");
            DataProvider.Instance.ExcuteNonQuery("exec USP_AddFoodtoBill @idfood , @idbill , @cnt ", new object[] { foodid.ToString() , BillId.ToString() , CountFood.Value.ToString() });
            if ((int)DataProvider.Instance.ExcuteScalar("select count (*) from billinfo where idbill = " + BillId.ToString()) > 0)
                ChangeButtonStatusNoPay(Tablefpnl.Tag as Button);
            else
                ChangeButtonStatusPay(Tablefpnl.Tag as Button);

        }
        void Pay(Table Table)
        {
            int BillId = BillDAO.Instance.FindBillIDbyTableID(Table.ID);
            if(BillId != -1)
            {
                if(MessageBox.Show("Bạn có chắc muốn thanh toán cho " + Table.Name,"Thông báo",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
                {
                    DataProvider.Instance.ExcuteQuery("exec USP_pay @IdBill ", new object[] { BillId.ToString() });
                    ChangeButtonStatusPay(Tablefpnl.Tag as Button);
                }    
               
            }    
        }
        void ChangeTable(Table table)
        {
            if (table != null)
            {
                int BillId = BillDAO.Instance.FindBillIDbyTableID(table.ID);
                if (BillId != -1)
                { 
                    if (BillDAO.Instance.FindBillIDbyTableID(TableDAO.Instacne.FindTableIdbyName("Bàn " + ChangeTablenud.Value.ToString())) != -1)
                        MessageBox.Show("Bàn " + ChangeTablenud.Value.ToString() + " đã có khách");
                    else
                    {
                        if (MessageBox.Show("Bạn có chắc muốn chuyển từ " + table.Name + " sang Bàn " + ChangeTablenud.Value.ToString(), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                        {
                            BillDAO.Instance.ChangTableID(BillId, "Bàn " + ChangeTablenud.Value.ToString());
                            TableDAO.Instacne.ChangeTableStatus(table.ID, false);
                            TableDAO.Instacne.ChangeTableStatus(TableDAO.Instacne.FindTableIdbyName("Bàn " + ChangeTablenud.Value.ToString()), true);

                            LoadTable();
                        }
                    }

                    


                }
            }
        }
        #endregion


        #region even
        private void Btn_Click(object sender, EventArgs e)
        {
           
            int tableID = ((sender as Button).Tag as Table).ID;
            MenuLvw.Tag = (sender as Button).Tag;
            Discoutnmud.Value = 0;
            Tablefpnl.Tag = sender as Button;
            ShowBIll(BillDAO.Instance.FindBillIDbyTableID(tableID));
        }
       

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountInfoForm f = new AccountInfoForm(AccountLogin);
            f.UpdateEvent += F_UpdateEvent;
            
            f.ShowDialog(); 
            this.Show();
        }

        private void F_UpdateEvent(object sender, AccountEvent e)
        {
            AccountLogin = e.Account;
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminForm f = new AdminForm();
            f.UpdateTable += F_UpdateTable;
            f.UpdateFoodEvent += F_UpdateFoodEvent;
            f.Updatecategory += F_Updatecategory;
            f.ShowDialog();
            this.Show();

        }

        private void F_UpdateTable(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void F_Updatecategory(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void F_UpdateFoodEvent(object sender, EventArgs e)
        {
            //LoadTable();
            LoadCategory();
            LoadTable();
            if(MenuLvw.Tag != null)
            {
                int tableID = (MenuLvw.Tag as Table).ID;
                ShowBIll(BillDAO.Instance.FindBillIDbyTableID(tableID));
            }
            

        }

        private void Categorycbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox ;
            Category category = comboBox.SelectedItem as Category;
            LoadFood(category.ID);

        }
       

       

        private void AddFoodbtn_Click(object sender, EventArgs e)
        {
            if(MenuLvw.Tag!=null && CountFood.Value!=0)
            {
                Table table = (MenuLvw.Tag as Table);
                AddFood(table.ID);
                ShowBIll(BillDAO.Instance.FindBillIDbyTableID(table.ID));
            }    
            


        }

        private void Paybtn_Click(object sender, EventArgs e)
        {
            if (MenuLvw.Tag != null)
            {
                Table table = (MenuLvw.Tag as Table);
                Pay(table);
            }
        }

      

        private void Discoutnmud_ValueChanged(object sender, EventArgs e)
        {
            //tbxTotalPrice.Text = string.Format("{0:#.##}", TotalPrice.ToString("c", culture));
            Table table = MenuLvw.Tag as Table;
            if(table!=null)
            {
                int BillId = BillDAO.Instance.FindBillIDbyTableID(table.ID);

                CultureInfo culture = new CultureInfo("vn-VN");
                Costtbx.Text = (Convert.ToInt32(TotalPricetbx.Text) * (100 - Discoutnmud.Value) / 100).ToString("c", culture);
                DataProvider.Instance.ExcuteQuery("Update bill set discount = " + Discoutnmud.Value.ToString() + " where id = " + BillId.ToString());
            }
           
        }

        private void TotalPricetbx_TextChanged(object sender, EventArgs e)
        {
            CultureInfo culture = new CultureInfo("vn-VN");
            Costtbx.Text = (Convert.ToInt32(TotalPricetbx.Text) * (100 - Discoutnmud.Value) / 100).ToString("c", culture);
           // DataProvider.Instance.ExcuteQuery("Update bill set discount = " + Discoutnmud.Value.ToString() + " where id = " + BillId.ToString());
        }

        private void CTbtn_Click(object sender, EventArgs e)
        {
            ChangeTable(MenuLvw.Tag as Table);
           
        }
        #endregion

        
    }
}
