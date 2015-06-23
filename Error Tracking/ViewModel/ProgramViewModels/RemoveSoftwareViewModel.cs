using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.ViewModel.ProgramViewModels
{
    class RemoveSoftwareViewModel : ViewModelBase
    {

        public Tools.RelayCommand Remove { get; set; }
        private Software _SelectedSoftware;

        public RemoveSoftwareViewModel()
        {
            Remove = new Tools.RelayCommand(RemoveFromDB, CanRemove);
        }


        /// <summary>
        /// The software selected to be removed
        /// </summary>
        public Software SelectedSoftware
        {
            get{
                return _SelectedSoftware;
            }
            set {
                if (_SelectedSoftware != value)
                {
                    _SelectedSoftware = value;
                    OnPropertyChanged("SelectedSoftware");
                }
            }
        }

        /// <summary>
        /// Removes object from database
        /// </summary>
        /// <param name="o"></param>
        public void RemoveFromDB(object o)
        {
            //Data.Software SWDB = Model_Data_Converters.Software.POCOtoCRUD(SelectedSoftware);

            //Data_Access.GenericDataAccess.DeleteEntry<Data.Software>(SWDB);

            using (var db = new DatabaseEntities())
            {
                db.Softwares.Attach(SelectedSoftware);
                db.Softwares.Remove(SelectedSoftware);
                db.SaveChanges();
            }
            SoftwareList.Clear();
            UpdateSoftwareList();
        }

        public bool CanRemove(object o)
        {
            return SelectedSoftware != null;
        }

    }
}
