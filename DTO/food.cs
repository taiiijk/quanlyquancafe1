using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DTO
{
    public class food
    {
        private int id;
        private string name;
        private int categoryid;
        private float price;
        private int totalprice;
        public int Totalprice { get { return totalprice; } set { totalprice = value; } }
        private int finalprice;
        public int Finalprice { get { return finalprice; } set { finalprice = value; } }
        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Categoryid { get { return categoryid; } set { categoryid = value; } }
        public float Price { get { return price; } set { price = value; } }
        public food(int id,string name,int categoryid,float price) {
            this.id = id;
            this.name = name;
            this.categoryid = categoryid;
            this.price = price;

                
                }
        public food(DataRow row)
        {
            this.id = (int)row["id"];
            this.name =row["name"].ToString();
            this.categoryid =(int)row["idcategory"];
            this.price =(float)Convert.ToDouble(row["price"].ToString());

        }
    }
}
