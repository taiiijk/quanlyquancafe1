using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DAO
{
    internal class accountdao
    {
        private static accountdao instance;
        public static accountdao Instance
        {


            get
            {
                if (instance == null)
                    instance = new accountdao();
                return instance;

            }


        }
        public DataTable GetAccountByUsername(string username)
        {
            return DataProvider.Instance.ExecuteQuery(
                "select * from account where username = @u",
                new object[] { username }
            );
        }

        public bool Login(string username, string password)
        {
            string query = "SELECT * FROM Account WHERE Username = @user AND Password = @pass";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }

        public bool updateaccount(string username, string newpass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update account set password=@newpass where username=@username", new object[] { newpass, username });
            return result > 0;



        }
        public bool addaccount(string username, string password, int type)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("insert account(username,password,type) values (@username,@password,@type)", new object[] { username, password, type });
            return result > 0;

        }
    }
}
