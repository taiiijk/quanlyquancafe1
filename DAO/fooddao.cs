using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace quanlyquancafe.DAO
{
    internal class fooddao
    {
        private static fooddao instance;
        public static fooddao Instance
        {


            get
            {
                if (instance == null)
                    instance = new fooddao();
                return instance;

            }


        }

        public DataTable getfood()
        {
            return DataProvider.Instance.ExecuteQuery("select * from food");
        }
        public food getfoodbyid(int id)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("select * from food where id=@id", new object[] { id });
            food f = new food(dt.Rows[0]);
            return f;

        }
        public bool insertfood(string name, int id, float price)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("insert food(name,idcategory,price) values ( @name, @id, @price)", new object[] { name, id, price });
            return result > 0;
        }
        public bool updatefood(string name, int id, float price, int idfood)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("update food set name=@name,idcategory=@id,price=@price where id=@idfood", new object[] { name, id, price, idfood });
            return result > 0;
        }
        public bool deletefood(int idfood)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("delete from food where id=@idfood", new object[] { idfood });
            return result > 0;
        }
        public List<food> getlistfood(int id)
        {
            List<food> list = new List<food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from food where idcategory=" + id);
            foreach (DataRow row in data.Rows)
            {
                food food = new food(row);
                list.Add(food);
            }

            return list;
        }
        public int maxidfood()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select max(id) from food");
            if (data.Rows.Count > 0)
            {
                int maxid = (int)data.Rows[0][0];
                return maxid;
            }
            return -1;
        } }
    }

