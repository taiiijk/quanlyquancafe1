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

        public List<menu> getlist(int id,int idbill)
        {
            
            List<menu> list=new List<menu> ();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT bin.realname, bin.count, bin.realprice, bin.realprice * bin.count AS totalprice FROM billinfo AS bin JOIN bill AS bi ON bin.idbill = bi.id  WHERE bi.id=@idbill and bi.idtable = @id ", new object[] {idbill,id});
            foreach (DataRow dr in data.Rows)
            {
                menu mn = new menu(dr); 
                list.Add(mn); 
            }
            return list ;
            

        }
        }
    }
