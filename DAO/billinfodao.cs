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
        public DataTable phantramfood(DateTime date1, DateTime date2)
        {
            return DataProvider.Instance.ExecuteQuery("exec phantramfood @date1, @date2", new object[] { date1, date2 });
        }
        public int insertMainFood(int idbill, int idfood, int count, string note)
        {
            food f = fooddao.Instance.getfoodbyid(idfood);

            string query = "exec insert_main_food @idbill, @idfood, @count, @realname, @realidcategory, @realprice, @note";

            return Convert.ToInt32(
                DataProvider.Instance.ExecuteScalar(
                    query,
                    new object[]
                    {
                idbill,
                idfood,
                count,
                f.Name,
                f.Categoryid,
                (int)f.Price,
                note,
           
                    }
                )
            );
        }

        public void insertTopping(int idbill, int idfood,int count, int idparent)
        {
            food f = fooddao.Instance.getfoodbyid(idfood);

            string query = "exec insert_topping @idbill, @idfood, @count, @realname, @realidcategory, @realprice, @idparent";

            DataProvider.Instance.ExecuteNonQuery(
                query,
                new object[]
                {
            idbill,
            idfood,
            count,
            f.Name,
            f.Categoryid,
            (int)f.Price,
            idparent
                }
            );
        }


        public void updateNote(int idbill, int idfood, string note)
        {
            string sql = @"UPDATE BILLINFO 
                   SET NOTE = @note 
                   WHERE idbill = @idbill 
                     AND idfood = @idfood 
                     AND ISMAIN = 1";

            DataProvider.Instance.ExecuteNonQuery(
                sql,
                new object[] { note, idbill, idfood }
            );
        }

        public void updaterealprice(int id, decimal realprice)
        {
            string sql = "UPDATE BILLINFO SET REALPRICE = @realprice  WHERE id = @id AND ISMAIN = 1";
            DataProvider.Instance.ExecuteNonQuery(
                sql,
                new object[] { realprice, id, realprice }
           
                );
        }
        public int? GetIdBillInfo(int idTable, string Food, string note)
        {
            int idBill = billdao.Instance.getbillbyidtable(idTable);

            string query = "SELECT id FROM billinfo WHERE idbill=@idbill AND realname=@Food AND note=@note";

            object result = DataProvider.Instance.ExecuteScalar(query, new object[]
            {
        idBill,
        Food,
        note
            });

            if (result == null || result == DBNull.Value)
                return null;

            return Convert.ToInt32(result);
        }
      public  void deletebillinfo(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("delete from billinfo where id =" + id );
        }

        public void updatebillinfo(int id, int count,string note)
        {
           
            DataProvider.Instance.ExecuteNonQuery("update billinfo set count = @count, note = @note where id = @id", new object[] { count, note, id });
        }
    }
}
