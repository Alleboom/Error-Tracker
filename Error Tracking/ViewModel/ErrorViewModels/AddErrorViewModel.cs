using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.ViewModel.ErrorViewModels
{
    public class AddErrorViewModel : ViewModel.ErrorViewModels.BaseErrorViewModel
    {

        public Tools.RelayCommand Save { get; set; }

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
                    OnPropertyChanged("SelectedError");
                }
            }
        }


        public AddErrorViewModel()
        {
            Save = new Tools.RelayCommand(SaveToDb, FormsFilled);
        }

        public void SaveToDb(object o)
        {
            if (o == null) return;
            using (var db = new DatabaseEntities())
            {

                var test = new Error()
                {
                    ErrorMessage = Description,
                    Resolution = this.Resolution,
                    SoftwareKey = this.SelectedSoftware.Id,
                };
                db.Errors.Add(test);
                db.SaveChanges();
            }
            CloseAction();
        }

        public bool FormsFilled(object o)
        {
            return (Description != null && Description != "" && SelectedSoftware != null);
        }
    }
}
