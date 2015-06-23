using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.ViewModel.ProgramViewModels
{
    public class AddSoftwareViewModel : ViewModelBase
    {

        public Tools.RelayCommand Save { get; set; }
        private String _SoftwareName;


        // the software name to save
        public String SoftwareName
        {
            get
            {
                return _SoftwareName;
            }
            set
            {
                if (_SoftwareName != value)
                {
                    _SoftwareName = value;
                    OnPropertyChanged("SoftwareName");
                }
            }
        }

        /// <summary>
        /// Determines if the software's name field is filled out
        /// </summary>
        /// <param name="o">no purpose</param>
        /// <returns>A bool, true for a name entry, false for null or ""</returns>
        public bool CanSave(object o)
        {
                return (SoftwareName != "" && SoftwareName != null);
        }


        public AddSoftwareViewModel()
        {
           Save = new Tools.RelayCommand(SaveToDB, CanSave);
           
        }

        /// <summary>
        /// The command to save to the database
        /// </summary>
        /// <param name="parameter"></param>
        public void SaveToDB(object parameter)
        {
            if (parameter == null) return;
            using (var db = new DatabaseEntities())
            {
                Software tempsw = new Software()
                {
                    Name = SoftwareName,
                };
                db.Softwares.Add(tempsw);
                db.SaveChanges();
            }


            UpdateSoftwareList();
            CloseAction(); 
        }

    }
}
