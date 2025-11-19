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

        public bool Login(string username, string password)
        {
            string query = "SELECT * FROM Account WHERE Username = @user AND Password = @pass";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { username, password });
            return result.Rows.Count > 0;
        }

    }
}
