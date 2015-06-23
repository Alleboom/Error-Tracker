using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.ViewModel.ErrorViewModels
{
    class EditErrorViewModel : ViewModel.ErrorViewModels.BaseErrorViewModel
    {
        public Tools.RelayCommand Save {get;set;}

        private String _NewDescription;
        private String _NewResolution;
        private Software _NewSelectedSoftware;

        public Software NewSelectedSoftware
        {
            get
            {
                return _NewSelectedSoftware;
            }

            set
            {
                if (value != _NewSelectedSoftware)
                {
                    _NewSelectedSoftware = value;
                    OnPropertyChanged("NewSelectedSoftware");
                }
            }
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
                    // get the list of all errors from the db
                    using (var db = new DatabaseEntities())
                    {
                        var list = db.Errors;
                        ErrorList.Clear();
                        foreach (Error item in list)
                        {
                            //check for id match
                            if (item.Software.Id == SelectedSoftware.Id)
                            {
                                ErrorList.Add(item);
                            }
                        }
                    }
                }
            }
        }

        public String NewDescription {
            get
            {
                return _NewDescription;
            }

            set
            {
                if (_NewDescription != value)
                {
                    _NewDescription = value;
                    OnPropertyChanged("NewDescription");
                }
            }
        }
        public String NewResolution {

            get
            {
                return _NewResolution;
            }

            set
            {
                _NewResolution = value;
                OnPropertyChanged("NewResolution");
            }
        }


        public EditErrorViewModel() : base()
        {
            Save = new Tools.RelayCommand(SaveChangesToDB, AnyChanges);
            ErrorList.Clear();
        }

        private bool AnyChanges(object obj)
        {
            if (SelectedError != null && SelectedSoftware != null)
            {
                return (SelectedError.Resolution != NewResolution || SelectedSoftware != NewSelectedSoftware || SelectedError.ErrorMessage != NewDescription);
            }
            else
            {
                return false;
            }
        }
        private void SaveChangesToDB(object obj)
        {
            using (var db = new DatabaseEntities())
            {
                // Copy the new values over
                SelectedError.Resolution = NewResolution;
                SelectedError.ErrorMessage = NewDescription;
                SelectedError.SoftwareKey = NewSelectedSoftware.Id;
                SelectedError.Software = null;
                // save it
                db.Errors.Attach(SelectedError);
                db.Entry(SelectedError).State = System.Data.EntityState.Modified;
                db.SaveChanges();   
            }

            // get the list of all errors from the db
            using (var db = new DatabaseEntities())
            {
                var list = db.Errors;
                ErrorList.Clear();
                foreach (Error item in list)
                {
                    //check for id match
                    if (item.Software.Id == SelectedSoftware.Id)
                    {
                        ErrorList.Add(item);
                    }
                }
            }

        }

        /// <summary>
        /// The selected error, usually from a listview
        /// </summary>
        public Error SelectedError
        {
            get
            {
                return _SelectedError;
            }
            set
            {
                if (value != _SelectedError)
                {
                    _SelectedError = value;
                    if (_SelectedError != null)
                    {
                        foreach (Software sw in SoftwareList)
                        {
                            if(sw.Id == SelectedError.Software.Id){
                                NewSelectedSoftware = sw;
                            }
                        }

                        NewResolution = SelectedError.Resolution;
                        NewDescription = SelectedError.ErrorMessage;
                    }
                    OnPropertyChanged("SelectedError");
                }
            }
        }


    }
}
