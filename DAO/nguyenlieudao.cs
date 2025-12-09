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
        public bool insertnguyenlieu(string tenNL, string donVi, decimal tonKho)
        {
            
            return DataProvider.Instance.ExecuteNonQuery("insert into nguyenlieu (TenNL, DonVi, TonKho) values (N'" + tenNL + "', N'" + donVi + "', " + tonKho + ")") > 0;
        }
        public bool updatenguyenlieu(int maNL, string tenNL, string donVi)
        {
            return DataProvider.Instance.ExecuteNonQuery("update nguyenlieu set TenNL=N'" + tenNL + "', DonVi=N'" + donVi + "' where MaNL=" + maNL) > 0;
        }
        public bool deletenguyenlieu(int maNL)
        {
            return DataProvider.Instance.ExecuteNonQuery("delete from nguyenlieu where MaNL=" + maNL) > 0;
        }
        public string getnamenguyenlieubyid(int maNL)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from nguyenlieu where MaNL=" + maNL);
            if (data.Rows.Count > 0)
            {
                NguyenLieu nl = new NguyenLieu(data.Rows[0]);
                return nl.TenNL;
            }
            return "";
        }
    }
}
