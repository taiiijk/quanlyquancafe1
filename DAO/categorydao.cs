using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DAO
{
    internal class categorydao
    {
        private static categorydao instance;
        public static categorydao Instance
        {


            get
            {
                if (instance == null)
                    instance = new categorydao();
                return instance;

            }


        }
        public List<category> getlistcategory()
        {
            List<category> list = new List<category>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from foodcategory where id!=9");
            foreach (DataRow row in data.Rows)
            {
                category category = new category(row);
                list.Add(category);
            }

            return list;
        }
        public List<category> getlistcategory2()
        {
            List<category> list = new List<category>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from foodcategory");
            foreach (DataRow row in data.Rows)
            {
                category category = new category(row);
                list.Add(category);
            }

            return list;
        }
        public DataTable getlistcate()
        {
           
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from foodcategory");
            

            return data;
        }
        public bool insertcategory(string name)
        {
          return  DataProvider.Instance.ExecuteNonQuery("insert into foodcategory (name) values (N'" + name + "')")>0;
        }
       public bool updatecategory(int id,string name)
        {
          return  DataProvider.Instance.ExecuteNonQuery("update foodcategory set name=N'"+name+"' where id="+id)>0;
        }
        public bool deletecategory(int id)
        {
          return  DataProvider.Instance.ExecuteNonQuery("delete from foodcategory where id="+id)>0;
        }
        public bool categoryhavefood(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from food where idcategory=" + id);
            return data.Rows.Count > 0;

        }
        public int soluongcategory()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from foodcategory");
            return data.Rows.Count;
        }

    }
}
