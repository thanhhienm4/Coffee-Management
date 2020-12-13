using Quan_li_quan_cafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_quan_cafe
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            
        }


        private void EXbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
            

        }

        private void LIBtn_Click(object sender, EventArgs e)
        {
            string Username = tbxusername.Text;
            string Password = tbxpassword.Text;
            if (Login(Username, Password))
            {
                this.Hide();
                FunctFrom f = new FunctFrom(AccountDAO.Instance.GetAccountByUserName(Username));
                f.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng");
            
            
        }
        bool Login(string username , string password)
        {
            try
            {
                return AccountDAO.Instance.Login(username, password);
            }
            catch 
            {
                return false;
            }
            
        }

        private void LogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát chương trình", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
               e.Cancel = false;
            }
        }
    }
}
