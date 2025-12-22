using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DTO
{
    public class category
    {
        private string name;
        public string Name {  get { return name; } }
        private int id;
        public int Id { get { return id; } }
            public category(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
        public category(DataRow row)
        {
            this.name =row["name"].ToString();
            this.id = (int)row["id"];

        } 
        public category()
        {

        }

    }
}
