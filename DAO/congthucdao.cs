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
        public int getSoluongMonConLai(int idfood)
        {
           
            DataTable congthuc = congthucdao.Instance.getcongthucbyidfood(idfood);
      

            int soluongMax = int.MaxValue; 
            foreach (DataRow r in congthuc.Rows)
            {
                int idNL = Convert.ToInt32(r["MaNL"]);
                int can = Convert.ToInt32(r["SoLuongCan"]);

                
                int tonKho = nguyenlieudao.Instance.getsoluong(idNL); 

               
                int soluongNL = tonKho / can;

                if (soluongNL < soluongMax)
                    soluongMax = soluongNL;
            }

            return soluongMax!= int.MaxValue?soluongMax:0; 
        }
        public int getSoluongConLai(int idFood, List<int> idToppings)
        {
            Dictionary<int, int> mapNguyenLieu = new Dictionary<int, int>();

            // 1. Công thức món chính
            DataTable ctMon = congthucdao.Instance.getcongthucbyidfood(idFood);
            foreach (DataRow r in ctMon.Rows)
            {
                int idNL = Convert.ToInt32(r["MaNL"]);
                int soLuong = Convert.ToInt32(r["SoLuongCan"]);

                if (!mapNguyenLieu.ContainsKey(idNL))
                    mapNguyenLieu[idNL] = soLuong;
                else
                    mapNguyenLieu[idNL] += soLuong;
            }

            // 2. Công thức topping
            foreach (int idTop in idToppings)
            {
                DataTable ctTop = congthucdao.Instance.getcongthucbyidfood(idTop);
                foreach (DataRow r in ctTop.Rows)
                {
                    int idNL = Convert.ToInt32(r["MaNL"]);
                    int soLuong = Convert.ToInt32(r["SoLuongCan"]);

                    if (!mapNguyenLieu.ContainsKey(idNL))
                        mapNguyenLieu[idNL] = soLuong;
                    else
                        mapNguyenLieu[idNL] += soLuong;
                }
            }

            // 3. Tính số phần tối đa
            int max = int.MaxValue;
            foreach (var item in mapNguyenLieu)
            {
                int ton = nguyenlieudao.Instance.getsoluong(item.Key);
                int coTheLam = ton / item.Value;
                if (coTheLam < max) max = coTheLam;
            }

            return max!=int.MaxValue?max:0;
        }

    }
}
