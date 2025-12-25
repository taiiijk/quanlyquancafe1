using System;
using System.Collections.Generic;
using System.Data;

namespace quanlyquancafe.DTO
{
    public class showbill
    {
        public showbill(DataRow row)
        {
            idfood = Convert.ToInt32(row["idfood"]);
            foodname = row["realname"].ToString();
            count = Convert.ToInt32(row["count"]);
            price = Convert.ToDecimal(row["realprice"]);
            totalprice = Convert.ToDecimal(row["totalprice"]);
            note = row.Table.Columns.Contains("note") ? row["note"].ToString() : "";
         
            


        }

        private int idfood;
        
        public int Idfood { get { return idfood; } }

        private string foodname;
        public string Foodname { get { return foodname; } }

        private int count;
        public int Count { get { return count; } }

        private decimal price;
        public decimal Price { get { return price; } }

        private decimal totalprice;
        public decimal Totalprice { get { return totalprice; } }

        private string note;
        public string Note { get { return note; } }

        private bool ismain;
        public bool IsMain { get { return ismain; } }
        
        public List<showbill> Toppings { get; set; }
       
    }
}
