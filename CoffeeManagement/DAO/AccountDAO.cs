using Quan_li_quan_cafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_quan_cafe.DAO
{
     public class AccountDAO
    {
        private static AccountDAO instance;

        #region method
        private AccountDAO() { }
        public static AccountDAO Instance { get {if (instance == null) instance = new AccountDAO(); return instance; }
                 set => instance = value; }
        public bool Login(string username, string password)
        {
            string a = PassWordEnCryption(password);


            DataTable dada = DataProvider.Instance.ExcuteQuery("USP_Login @username , @password ", new object[] { username, PassWordEnCryption(password) });
            if (dada.Rows.Count > 0)
                return true;
            return false;
        }
        private Account Datarow (DataRow row)
        {
            Account account = new Account((int)row["Id"], (string)row["Displayname"], (string)row["UserName"], (int)row["Type"]);
            return account;
        }
        public Account GetAccountByUserName(string username )
        {
            DataTable account = DataProvider.Instance.ExcuteQuery(" USP_GetAccountByUserName @UserName", new object[] { username });
            return Datarow(account.Rows[0]);
        }
        public string PassWordEnCryption(string PassWord)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(PassWord);
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(temp);
            string PassWordCryted = "";
            foreach  (byte item in hash)
            {
                PassWordCryted += item;
            }

            return PassWordCryted;
        }
        public bool UpDateAccount(int Id, string DisPlayName, string UserName,string PassWord,string NewPassWord,int Type)
        {
            int ok = DataProvider.Instance.ExcuteNonQuery("USP_UpdateAccount @id , @DisplayName , @UserName , @PassWord , @NewPassWord , @Type ",
               new object[] {Id.ToString(),DisPlayName,UserName,PassWordEnCryption(PassWord),PassWordEnCryption( NewPassWord),Type.ToString() });
            return ok > 0 ? true : false;
        }
        public bool CheckUserNameAvailable(int id, string username)
        {
            int find = (int)DataProvider.Instance.ExcuteScalar("USP_CheckUserNameAvailable @id , @username ", new object[] { id.ToString(), username });
            return find > 0 ? false : true;
        }
        public void InsertAccount(string DisplayName, string UserName,string PassWord, int Type)
        {
            DataProvider.Instance.ExcuteQuery("USP_InsertAccount @DisplayName , @UserName , @PassWord , @Type ",
                new object[] { DisplayName, UserName,PassWordEnCryption(PassWord), Type });
        }
        public void DeleteAccount(int id)
        {
            if(IsAdmin(id)==true)
            {
                int count = (int)DataProvider.Instance.ExcuteScalar("Select count(*) from account, bill , billinfo where billinfo.idbill = bill.id and bill.idAccount= " + id.ToString());
                if (count > 0)
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo");
                }
                else
                {
                    DataProvider.Instance.ExcuteQuery("delete from account where id = " + id.ToString());
                }
            }else
            {
                MessageBox.Show("Không thể xóa tài khoảng Admin", "Thông báo");
            }
           
        }
        public void EditAccount (int id, string DisplayName, string UserName ,int Type)
        {
            if(IsAdmin(id)==false)
            {
                DataProvider.Instance.ExcuteQuery("USP_EditAccount @id , @UserName , @DisplayName , @Type", new object[] { id.ToString(), UserName, DisplayName, Type.ToString() });
            }else
            {
                MessageBox.Show("Không thể chỉnh sửa tài khoản Admin", "Thông báo");
            }    
            

        }
        public void ResetPassWord(int id, string DefaultPassWord)
        {
            if(IsAdmin(id)==true)
            {
                MessageBox.Show("Không thể đặt lại mật khẩu tài khoản Admin", "Thông báo");
            }
            else
                DataProvider.Instance.ExcuteQuery("USP_ResetPassWord @id , @DefaultPassWord", new object[] { id.ToString(), PassWordEnCryption(DefaultPassWord) });
        }
        public bool IsAdmin(int id)
        {
            if ((int)DataProvider.Instance.ExcuteScalar(string.Format("Select count (*) from account where id = {0} and type = 1", id)) > 0)
            {
                return true;
            }
            else
                return false;
        }
        #endregion
    }
}
