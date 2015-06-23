using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.ViewModel.ErrorViewModels
{
    public class RemoveErrorViewModel : ViewModel.ErrorViewModels.BaseErrorViewModel
    {

        public Tools.RelayCommand Remove{ get; set; }

        public RemoveErrorViewModel() : base()
        {
            Remove = new Tools.RelayCommand(RemoveFromDb, IsItemSelected);
            ErrorList.Clear();
        }

        public new Software SelectedSoftware
        {

            get
            {
                return _SelectedSoftware;
            }

            set
            {
                if (value != _SelectedSoftware)
                {
                    _SelectedSoftware = value;
                    ErrorList.Clear();
                    using (var db = new DatabaseEntities())
                    {
                        var list = db.Errors;
                        foreach (Error item in list)
                        {
                            if (item.SoftwareKey == SelectedSoftware.Id)
                            {
                                ErrorList.Add(item);
                            }
                        }
                    }
                }
            }
        }



        public Error SelectedError
        {
            get
            {
                return _SelectedError;
            }
            set
            {
                _SelectedError = value;
                OnPropertyChanged("SelectedError");
            }
        }

        private bool IsItemSelected(object obj)
        {
            return (SelectedError != null);
        }

        private void RemoveFromDb(object obj)
        {
            using (var db = new DatabaseEntities())
            {
                db.Errors.Attach(SelectedError);
                db.Errors.Remove(SelectedError);
                db.SaveChanges();
                ErrorList.Remove(SelectedError);
            }
        }



    }
}
