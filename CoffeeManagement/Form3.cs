using Quan_li_quan_cafe.DAO;
using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Quan_li_quan_cafe
{
    public partial class AccountInfoForm : Form
    {
        #region method
        Account account;
        private event EventHandler <AccountEvent> updateEvent;
        public event EventHandler <AccountEvent> UpdateEvent
        {
            add { updateEvent += value ; }
            remove { updateEvent -= value ; }
        }

        public AccountInfoForm(Account account)
        {
            InitializeComponent();
            this.account = account;
            UserNametbx.Text = account.UserName;
            DisplayNamebtx.Text = account.DisplayName;
        }
        public void UpdateAccount ()
        {
            int Id = account.Id;
            string UserName = UserNametbx.Text;
            string DisplayName = DisplayNamebtx.Text;
            string PassWord = PassWordtbx.Text;
            string NewPassword = NewPWtbx.Text;
            string PreNewPassword = PrePassWordtbx.Text;

            if(NewPassword != PreNewPassword)
            {
                MessageBox.Show("Mật khẩu mới không đúng, vui lòng nhập lại", "Thông báo");
            }else
            {
                if (AccountDAO.Instance.CheckUserNameAvailable(Id, UserName))
                {

                    if (AccountDAO.Instance.UpDateAccount(Id, DisplayName, UserName, PassWord, NewPassword, account.Type))
                    {
                        MessageBox.Show("Cập nhật thông tin thành công", "Thông báo");
                        if(updateEvent!=null)
                        {
                            updateEvent(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(UserName)));
                        }
                       
                    }
                    else
                        MessageBox.Show("Mật khẩu chưa đúng cần nhập lại", "Thông báo");
                }
                else
                    MessageBox.Show("Tên đăng nhập không khả dụng, vui lòng chọn tên khác");

                    
            }    

        }
       

        
        #endregion
        #region event
        private void AccountInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                e.Cancel = false;
        }
        #endregion

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }
    }
    public class AccountEvent : EventArgs
    {
        private Account account;
        public AccountEvent(Account account)
        {
            this.Account = account;
        }

        public Account Account { get => account; set => account = value; }
    }
}
