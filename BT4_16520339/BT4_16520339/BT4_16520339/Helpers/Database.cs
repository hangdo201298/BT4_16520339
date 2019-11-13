using BT4_16520339.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BT4_16520339.Helpers
{
    public class Database
    {
        // Get stored folder database on the system
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        // Create database
        public Database()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    // Create 2 tables
                    connection.CreateTable<LoaiHoa>();
                    connection.CreateTable<Hoa>();
                }
            }
            catch (SQLiteException)
            {
            }
        }

        public List<LoaiHoa> getLoaiHoa()
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<LoaiHoa>().ToList();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public LoaiHoa getLoaiHoaById(int Maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    var dsh = from lhs in connection.Table<LoaiHoa>().ToList()
                              where lhs.MaLoai == Maloai
                              select lhs;
                    return dsh.ToList<LoaiHoa>().FirstOrDefault();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

        public bool InsertLoaiHoa(LoaiHoa lh)
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(lh);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public bool UpdateLoaiHoa(LoaiHoa lh)
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Update(lh);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        public bool DeleteLoaiHoa(LoaiHoa lh)
        {
            try
            {
                using (var connection = new SQLiteConnection
                    (System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Delete(lh);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
    }
}
