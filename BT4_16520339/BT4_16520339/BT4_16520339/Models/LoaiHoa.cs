using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BT4_16520339.Models
{
    public class LoaiHoa
    {
        [PrimaryKey, AutoIncrement]

        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
}
