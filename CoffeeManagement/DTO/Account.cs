using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_li_quan_cafe.DTO
{
     public class Account
    {
        private int id;
        private string displayName;
        private string userName;
        private int type;
        private string passWord;

        public Account(int id, string displayname, string username, int type, string password = null)
        {
            this.Id = id;
            this.DisplayName = displayname;
            this.UserName = username;
            this.type = type;
            this.PassWord = password;
        }

        public int Id { get => id; set => id = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string UserName { get => userName; set => userName = value; }
        public int Type { get => type; set => type = value; }
        public string PassWord { get => passWord; set => passWord = value; }
    }
}
