using System;
using System.Data;

namespace quanlyquancafe.DTO
{
    public class NguyenLieu
    {
        private int maNL;
        private string tenNL;
        private string donVi;
        private decimal tonKho;

        public int MaNL { get => maNL; set => maNL = value; }
        public string TenNL { get => tenNL; set => tenNL = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public decimal TonKho { get => tonKho; set => tonKho = value; }

        // Constructor đầy đủ
        public NguyenLieu(int maNL, string tenNL, string donVi, decimal tonKho)
        {
            this.maNL = maNL;
            this.tenNL = tenNL;
            this.donVi = donVi;
            this.tonKho = tonKho;
        }

        // Constructor từ DataRow
        public NguyenLieu(DataRow row)
        {
            this.maNL = (int)row["MaNL"];
            this.tenNL = row["TenNL"].ToString();
            this.donVi = row["DonVi"].ToString();
            this.tonKho = (decimal)row["TonKho"];
        }
    }
}
