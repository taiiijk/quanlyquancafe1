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
    public class phieunhapkhodao
    {
        private static phieunhapkhodao instance;
        public static phieunhapkhodao Instance
        {


            get
            {
                if (instance == null)
                    instance = new phieunhapkhodao();
                return instance;

            }


        }

        public void insertphieunhapkho()
        {
            DataProvider.Instance.ExecuteNonQuery("exec insertphieunhapkho");
        }
        public int maxidphieunhapkho()
        {
            int id = (int)DataProvider.Instance.ExecuteScalar("select max(MaPN) from phieunhapkho");
            return id;

        }
        public void deletephieunhapkho(int mapn)
        {
            DataProvider.Instance.ExecuteNonQuery("delete phieunhapkho where MaPN=" + mapn);
        }

        public void insertchitietphieunhapkho(int mapn, int manl, int soluong, decimal dongia)
        {
            DataProvider.Instance.ExecuteNonQuery("exec insertchitietphieunhapkho @mapn , @manl , @soluong , @dongia", new object[] { mapn, manl, soluong, dongia });
        }
        public decimal GetTongTienChi(DateTime tuNgay, DateTime denNgay)
        {
            object result = DataProvider.Instance.ExecuteScalar(
                "exec sp_TongTienChi @TuNgay , @DenNgay",
                new object[] { tuNgay, denNgay }
            );

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToDecimal(result);
        }

    }
}
