using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlyquancafe.DTO
{
    public class table
    {
        private int id;
        private string status;
        private string name;
     
        public table(DataRow row)
        {
            this.id=(int)row["id"];
            this.name =row["ten"].ToString();

            this.status = row["trangthai"].ToString();

        }
        public table(int id, string status, string name)
        {
            this.id = id;
            this.name = name;
            this.status = status;

        }
        public string Name { get { return name; } set { name = value; } }
        public int Id { get { return id; } set { id = value; } }
        public string Status
        {
            get { return status; }
        }
    }
}
