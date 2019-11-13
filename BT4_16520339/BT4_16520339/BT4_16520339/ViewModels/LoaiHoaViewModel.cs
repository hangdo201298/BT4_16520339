using BT4_16520339.Interface;
using BT4_16520339.Models;
using BT4_16520339.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BT4_16520339.ViewModels
{
    public class LoaiHoaViewModel : INotifyPropertyChanged
    {
        private LoaiHoa loaihoa;
        public ILoaiHoaRepository loaihoaRepository;
        public ICommand AddLoaiHoa { get; private set; }
        public ICommand UpdateLoaiHoa { get; private set; }
        public ICommand DeleteLoaiHoa{get; private set;}
        
        public LoaiHoaViewModel()
        {
            loaihoaRepository = new LoaiHoaRepository();
            loadLoaiHoa();
            AddLoaiHoa = new Command(Insert);
            UpdateLoaiHoa = new Command(Update, CanExe);
            DeleteLoaiHoa = new Command(Delete, CanExe);
            loaihoa = new LoaiHoa();
        }

        private void Delete()
        {
            loaihoaRepository.Delete(LoaiHoa);
            loadLoaiHoa();
        }

        private bool CanExe()
        {
            if (LoaiHoa == null || LoaiHoa.MaLoai == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Update()
        {
            loaihoaRepository.Update(LoaiHoa);
            loadLoaiHoa();
        }

        public LoaiHoa LoaiHoa
        {
            get
            {
                return loaihoa;
            }
            set
            {
                loaihoa = value;
                RaisePropertyChanged("LoaiHoa");
                ((Command)UpdateLoaiHoa).ChangeCanExecute();

            }
        }

        private void Insert()
        {
            loaihoaRepository.Insert(loaihoa);
            loadLoaiHoa();
        }

        public int MaLoai
        {
            get
            {
                return loaihoa.MaLoai;
            }
            set
            {
                loaihoa.MaLoai = value;
                RaisePropertyChanged("MaLoai");
            }
        }

        public string TenLoai
        {
            get
            {
                return loaihoa.TenLoai;
            }

            set
            {
                loaihoa.TenLoai = value;
                RaisePropertyChanged("TenLoai");
            }
        }

        ObservableCollection<LoaiHoa> loaihoalist;

        public ObservableCollection<LoaiHoa> Loaihoalist
        {
            get
            {
                return loaihoalist;
            }
            set
            {
                loaihoalist = value;
                RaisePropertyChanged("Loaihoalist");
            }
        }

        void loadLoaiHoa()
        {
            Loaihoalist = loaihoaRepository.getLoaiHoa();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
