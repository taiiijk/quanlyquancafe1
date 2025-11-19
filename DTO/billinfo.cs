using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DTO
{
    public class billinfo
    {
        private int id;
        public int Id { get { return id; } }
        private int billid;
        public int Billid { get { return billid; } }

        private int foodid;
        public int Foodid { get { return foodid; } }
        private int count;
        public int Count
        {
            get { return count; } }
            public billinfo(int id, int billid, int foodid, int count)
        {
            this.id = id;
            this.billid = billid;
            this.foodid = foodid;
            this.count = count;


        }
        public billinfo(DataRow row)
        {
            this.id = (int)row["id"];
            this.billid = (int)row["idbill"];
            this.foodid = (int)row["idfood"];
            this.count = (int)row["count"];


        }
    }
}
