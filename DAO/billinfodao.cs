using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DAO
{
    internal class billinfodao

    {
        private static billinfodao instance;
        public static billinfodao Instance
        {


            get
            {
                if (instance == null)
                    instance = new billinfodao();
                return instance;

            }


        }
        public List<billinfo> getlistbillinfo(int id)
        {
            List<billinfo> list=new List<billinfo> ();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from billinfo where idbill=" + id);
            foreach (DataRow dr in data.Rows)
            {
                billinfo billinfo = new billinfo(dr);
                list.Add(billinfo);
            }
            return list;
        }
        public void insertbillinfo(int idbill, int idfood, int count)
        {
            food f = fooddao.Instance.getfoodbyid(idfood);

            string query = "exec insertbillinfo @idbill, @idfood, @count, @price, @name, @idcategory";

            DataProvider.Instance.ExecuteNonQuery(
                query,
                new object[] { idbill, idfood, count, f.Price, f.Name, f.Categoryid }
            );
        }

    }
}
