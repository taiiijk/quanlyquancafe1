using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DAO
{
    internal class billdao
    {
        private static billdao instance;
        public static billdao Instance
        {


            get
            {
                if (instance == null)
                    instance = new billdao();
                return instance;

            }


        }
        public Bill selectbill(int id)
        {
           DataTable  data= DataProvider.Instance.ExecuteQuery("select * from bill where id=" + id);

            Bill bill = new Bill(data.Rows[0]);
            return bill;

        }
        public bool billhaveidfood(int idfood)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery(
                "select * from bill b join billinfo bi on b.id = bi.idbill where bi.idfood = "
                + idfood + " and status = 0"
            );

            return data.Rows.Count > 0;
        }


        public DataTable getbillbydate(DateTime checkin,DateTime checkout)
        {
          return  DataProvider.Instance.ExecuteQuery("exec thongke @checkin, @checkout", new object[] { checkin, checkout });
        }
        public void checkout(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("update bill set status = 1,datecheckout=GETDATE() where id=" + id);
        }
        public int getbillbyidtable(int id)
        {
           DataTable data= DataProvider.Instance.ExecuteQuery("select * from bill where idtable="+id+"and status=0");
            if(data.Rows.Count>0)
            {
               Bill bill=new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }
        public void insertbill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec insertbill @id",new object[] {id});
        }
        public int maxidbill()
        {
            return (int)DataProvider.Instance.ExecuteScalar("select Max(id) from bill");
        }
        public DataTable doanhthu(DateTime date1,DateTime date2)
        {
            return DataProvider.Instance.ExecuteQuery("exec doanhthu @date1, @date2", new object[] { date1, date2 });
        }
        public decimal GetTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            object result = DataProvider.Instance.ExecuteScalar(
                "exec tongdoanhthu @TuNgay, @DenNgay",
                new object[] { tuNgay, denNgay }
            );

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToDecimal(result);
        }
public void updatediscount(int idbill, int discount)
        {
            DataProvider.Instance.ExecuteNonQuery("update bill set discount=@discount where id=@idbill", new object[] { discount, idbill });
        }
        public int GetDiscountByIdBill(int idbill)
        {
            object result = DataProvider.Instance.ExecuteScalar(
                "SELECT discount FROM bill WHERE id = @idbill",
                new object[] { idbill }
            );

            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }

        public DateTime getdatecheckin(int idbill)
        {
            object result = DataProvider.Instance.ExecuteScalar(
                "SELECT datecheckin FROM bill WHERE id = @idbill",
                new object[] { idbill }
            );
            if (result == null || result == DBNull.Value)
                return DateTime.MinValue;
            return Convert.ToDateTime(result);
        }
    }
}
