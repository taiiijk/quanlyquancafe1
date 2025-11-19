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
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from foodcategory");
            foreach (DataRow row in data.Rows)
            {
                category category = new category(row);
                list.Add(category);
            }

            return list;
        }

    }
}
