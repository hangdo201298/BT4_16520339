using BT4_16520339.Helpers;
using BT4_16520339.Interface;
using BT4_16520339.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BT4_16520339.Repository
{
    public class LoaiHoaRepository : ILoaiHoaRepository
    {
        Database db;
        public LoaiHoaRepository()
        {
            db = new Database();
        }

        public bool Delete(LoaiHoa h){
            return db.DeleteLoaiHoa(h);
        }

        public LoaiHoa getLoaiHoaById(int Maloai)
        {
            return db.getLoaiHoaById(Maloai);
        }

        public ObservableCollection<LoaiHoa> getLoaiHoa()
        {
            return new ObservableCollection<LoaiHoa>(db.getLoaiHoa());
        }

        public bool Insert(LoaiHoa h)
        {
            return db.InsertLoaiHoa(h);
        }

        public bool Update(LoaiHoa h)
        {
            return db.UpdateLoaiHoa(h);
        }
    }
}
