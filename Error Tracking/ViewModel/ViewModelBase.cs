using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Error_Tracking.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {

        #region property event
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion



        private ObservableCollection<Software> _SoftwareList = new ObservableCollection<Software>();

        public ObservableCollection<Software> SoftwareList
        {
            get
            {
                return _SoftwareList;
            }
            set
            {
                if (value != _SoftwareList)
                {
                    _SoftwareList = value;
                    OnPropertyChanged("SoftwareList");
                }
            }
        }

        private ObservableCollection<Error> _ErrorList = new ObservableCollection<Error>();

        public ObservableCollection<Error> ErrorList
        {
            get
            {
                return _ErrorList;
            }
            set
            {
                if (value != _ErrorList)
                {
                    _ErrorList = value;
                    OnPropertyChanged("ErrorList");
                }
            }
        }

        public void UpdateErrorList()
        {
            using(var db = new DatabaseEntities()){
                foreach (var item in db.Errors)
                {
                    ErrorList.Add(item);   
                }
            }
        }

        public void UpdateErrorList(object sender, EventArgs e)
        {
            UpdateErrorList();
        }

        public void UpdateSoftwareList()
        {
            using (var db = new DatabaseEntities())
            {
                foreach (var item in db.Softwares)
                {
                    SoftwareList.Add(item);
                }
            }
        }

        public void UpdateSoftwareList(object sender, EventArgs e)
        {
            UpdateSoftwareList();
        }


        public Action CloseAction { get; set; }

        public ViewModelBase()
        {
            UpdateErrorList();
            UpdateSoftwareList();
        }
    }
}
