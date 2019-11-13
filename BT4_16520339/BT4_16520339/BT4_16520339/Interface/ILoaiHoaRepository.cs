using BT4_16520339.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BT4_16520339.Interface
{
    public interface ILoaiHoaRepository
    {
        ObservableCollection<LoaiHoa> getLoaiHoa();
        LoaiHoa getLoaiHoaById(int Maloai);
        bool Insert(LoaiHoa h);
        bool Update(LoaiHoa h);
        bool Delete(LoaiHoa h);
    }
}
