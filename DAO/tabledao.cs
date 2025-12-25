using quanlyquancafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DAO
{
    public class tabledao
    {
        private static tabledao instance;
        public static tabledao Inststace
        {
            get
            {
                if (instance == null)
                    instance = new tabledao();
                return instance;
            }
        }

        public static int tbw = 90;
        public static int tbh = 90;

        private tabledao() { }

        public void switchtable(int id1,int id2)
        {
            DataProvider.Instance.ExecuteQuery(
                "exec chuyenban @idtable1 , @idtable2",
                new object[] { id1, id2 }
            );



        }
        public table selectable(int id)
        {
           DataTable dt= DataProvider.Instance.ExecuteQuery("select * from tablefood where id=" + id);
            table table = new table(dt.Rows[0]);
            return table;
        }
        public int getidtablefromten(string tenban)
        {
            DataTable dt = DataProvider.Instance.ExecuteQuery("select id from tablefood where ten = @tenban", new object[] { tenban } );
                
             return Convert.ToInt32(dt.Rows[0]["id"]);
        }
        public List<table> Loadtablelist()
        {
           List<table> list = new List<table>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("gettablelist");
            foreach (DataRow item in dt.Rows)
            {
                table tb=new table(item);
                list.Add(tb);

            }    
                return list;

        }
        public DataTable listtable()
        {
            return DataProvider.Instance.ExecuteQuery("select * from tablefood");
        }
        public bool inserttable(string name)
        {
          return  DataProvider.Instance.ExecuteNonQuery("insert into tablefood(ten,trangthai) values (N'"+name+"',N'Trống')")>0;
        }
        public bool deletetable(int id)
        {
          return  DataProvider.Instance.ExecuteNonQuery("delete from tablefood where id="+id)>0;
        }
      public bool tablehavebill(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from bill where idtable=" + id + " and status=0");
            return data.Rows.Count > 0;
        }
        
    }
}
