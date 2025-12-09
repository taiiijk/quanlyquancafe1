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
    public class congthucdao
    {
        private static congthucdao instance;
        public static congthucdao Instance
        {


            get
            {
                if (instance == null)
                    instance = new congthucdao();
                return instance;

            }


        }




        public bool insertcongthuc(int idfood, int MaNL, decimal SoLuongCan)
        {
            return DataProvider.Instance.ExecuteNonQuery("insert into congthuc (idfood, MaNL, SoLuongCan) values (" + idfood + ", " + MaNL + ", " + SoLuongCan + ")") > 0;
        }
        public bool updatecongthuc(int idfood, int MaNL, decimal SoLuongCan)
        {
            return DataProvider.Instance.ExecuteNonQuery("update congthuc set SoLuongCan=" + SoLuongCan + " where idfood=" + idfood + " and MaNL=" + MaNL) > 0;
        }
        public bool deletefullcongthuc(int idfood)
        {
            return DataProvider.Instance.ExecuteNonQuery("delete from congthuc where idfood=" + idfood ) > 0;
        }
      public bool deletecongthuc(int idfood, int MaNL)
        {
            return DataProvider.Instance.ExecuteNonQuery("delete from congthuc where idfood=" + idfood + " and MaNL=" + MaNL) > 0;
        }
        public DataTable getcongthucbyidfood(int idfood)
        {
            return DataProvider.Instance.ExecuteQuery("select * from congthuc where idfood=" + idfood);
        }
    }
}
