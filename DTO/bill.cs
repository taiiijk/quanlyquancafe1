using System;
using System.Data;

namespace quanlyquancafe.DTO
{
    public class Bill
    {
        private int id;
        public int Id { get { return id; } }

        private DateTime? datecheckin;
        public DateTime? DateCheckIn { get { return datecheckin; } }

        private DateTime? datecheckout;
        public DateTime? DateCheckOut { get { return datecheckout; } }

        private int status;
        public int Status { get { return status; } }

        public Bill(int id, DateTime? datecheckin, DateTime? datecheckout, int status)
        {
            this.id = id;
            this.datecheckin = datecheckin;
            this.datecheckout = datecheckout;
            this.status = status;
        }

        public Bill(DataRow row)
        {
            this.id = (int)row["id"];

            if (row["datecheckin"] != DBNull.Value)
                this.datecheckin = (DateTime?)row["datecheckin"];

            if (row["datecheckout"] != DBNull.Value)
                this.datecheckout = (DateTime?)row["datecheckout"];

            this.status = (int)row["status"];
        }
    }
}
