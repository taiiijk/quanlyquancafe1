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
    public class menudao
    {
        private static menudao instance;
        public static menudao Instance
        {


            get
            {
                if (instance == null)
                    instance = new menudao ();
                return instance;

            }


        }

        public List<menu> getlist(int idbill, int idtable)
        {
            List<menu> list = new List<menu>();

            string query =
 "SELECT bin.idfood, bin.realname, bin.count, bin.realprice, " +
 "bin.realprice * bin.count AS totalprice, bin.note " +
 "FROM billinfo bin JOIN bill bi ON bin.idbill = bi.id " +
 "WHERE bi.id=@idbill AND bi.idtable=@idtable AND bin.ismain=1";


            DataTable data = DataProvider.Instance.ExecuteQuery(
                query,
                new object[] { idbill, idtable }
            );

            foreach (DataRow dr in data.Rows)
            {
                list.Add(new menu(dr));
            }

            return list;
        }
        public DataTable getlistbillinfo(int idbill, int idtable)
        {
           

            string query =
 "SELECT bin.realname, bin.count, bin.realprice, " +
 "bin.realprice * bin.count AS totalprice, bin.note " +
 "FROM billinfo bin JOIN bill bi ON bin.idbill = bi.id " +
 "WHERE bi.id=@idbill AND bi.idtable=@idtable AND bin.ismain=1";


            DataTable data = DataProvider.Instance.ExecuteQuery(
                query,
                new object[] { idbill, idtable }
            );

           

            return data;
        }

    }
}
