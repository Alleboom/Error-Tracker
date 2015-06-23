using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.ViewModel.ProgramViewModels
{
    public class EditSoftwareViewModel : ViewModelBase
    {

        public Tools.RelayCommand Change { get; set; }
        private Software _SelectedSoftware;
        private String _NameToChangeTo, _Name;


        public Software SelectedSoftware {
            get
            {
                return _SelectedSoftware;
            }
            set
            {
                if (_SelectedSoftware != value)
                {
                    _SelectedSoftware = value;
                    
                    OnPropertyChanged("SelectedSoftware");

                    if (_SelectedSoftware != null)
                    {
                        NameToChangeTo = _SelectedSoftware.Name;
                    }
                }
            }
        }

        public String Name
        {
            get
            {
                return _Name; 
            }
            set{
                if (_Name != value)
                {
                    _Name = value;
                    NameToChangeTo = SelectedSoftware.Name;
                    OnPropertyChanged("Name");
                }
            }
        }

        public String NameToChangeTo
        {
            get
            {
                return _NameToChangeTo;
            }
            set
            {
                if (_NameToChangeTo != value)
                {
                   _NameToChangeTo = value;
                    OnPropertyChanged("NameToChangeTo");
                }
            }
        }

        public bool NameChanged(object o)
        {
            return Name != NameToChangeTo && SelectedSoftware != null;
        }

        public void ChangeSoftware(object o)
        {
            if (SelectedSoftware != null)
            {
                //SelectedSoftware.Name = _NameToChangeTo;
                //Data_Access.GenericDataAccess.ModifyEntry<Data.Software>(Model_Data_Converters.Software.POCOtoCRUD(SelectedSoftware));
                //SoftwareList = Model_Data_Converters.Software.CRUDCollectionToPOCOCollection(Data_Access.GenericDataAccess.GetAll<Data.Software>());
                using (var db = new DatabaseEntities())
                {
                    SelectedSoftware.Name = NameToChangeTo;
                    db.Softwares.Attach(SelectedSoftware);
                    db.Entry(SelectedSoftware).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                }
                SoftwareList.Clear();
                UpdateSoftwareList();
            }
        }

        public EditSoftwareViewModel() : base()
        {
            Change = new Tools.RelayCommand(ChangeSoftware, NameChanged);
        }



    }
}
