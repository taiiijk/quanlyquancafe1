using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DTO
{
    public class menu
    {
        public menu(string foodname,int count,float price,float totalprice)
        {
            this.foodname = foodname;   
            this.count = count;
            this.price = price;
            this.totalprice = totalprice;
               
        }
        public menu(DataRow row) {
            this.foodname = row["realname"] == DBNull.Value ? "" : row["realname"].ToString();
            this.count = (int)row["count"];
            this.price = Convert.ToSingle(row["realprice"]);
            this.totalprice = Convert.ToSingle(row["totalprice"]);

        }
        private string foodname;
        public string Foodname
        {
            get { return foodname; }
        }
        private int count;
        public int Count { get { return count; } }
        private float price;
        public float Price { get { return price; } }
        private float totalprice;
        public float Totalprice { get { return totalprice; } }
    }
}
