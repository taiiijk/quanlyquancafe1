using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlyquancafe.DAO
{
    public class nguyenlieudao
    {
        private static nguyenlieudao instance;
        public static nguyenlieudao Instance
        {


            get
            {
                if (instance == null)
                    instance = new nguyenlieudao();
                return instance;

            }


        }

        public DataTable getnguyenlieu()
        {
            return DataProvider.Instance.ExecuteQuery("select * from nguyenlieu");
        }
        
        public int getidnguyenlieuByname(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from nguyenlieu where TenNL=N'" + name + "'");
            if (data.Rows.Count > 0)
            {
                NguyenLieu nl = new NguyenLieu(data.Rows[0]);
                return nl.MaNL;
            }
            return -1;
        }

    }
}
