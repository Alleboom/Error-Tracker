using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region Members
        private Software _SelectedSoftware;
        private String _ErrorSearchText;
        public Tools.RelayCommand NewPageCommand {get;set;}
        public Tools.RelayCommand Search { get; set; }
        public ObservableCollection<Error> _SearchResults = new ObservableCollection<Error>();
        #endregion



        #region Properties


        /// <summary>
        /// The search text to be queried against
        /// </summary>
        public String ErrorSearchText
        {
            get
            {
                return _ErrorSearchText;
            }
            set
            {
                if (_ErrorSearchText != value)
                {
                    _ErrorSearchText = value;
                    OnPropertyChanged("ErrorSearchText");
                }
            }
        }


        public Software SelectedSoftware
        {
            get
            {
                return _SelectedSoftware;
            }

            set
            {
                _SelectedSoftware = value;
                OnPropertyChanged("SelectedSoftware");
            }
        }

        public ObservableCollection<Error> SearchResults
        {
            get
            {
                return _SearchResults;
            }

            set
            {
                _SearchResults = value;
                OnPropertyChanged("SearchResults");
            }
        }


        public MainViewModel()
        {
            NewPageCommand = new Tools.RelayCommand(NewPage);
            Search = new Tools.RelayCommand(SearchCommand, CanSearch);
        }

        private bool CanSearch(object obj)
        {
            return SelectedSoftware != null;
        }

        private void SearchCommand(object obj)
        {
            SearchResults.Clear();
            foreach (Error item in ErrorList)
            {
                if (SelectedSoftware.Id == item.SoftwareKey)
                {
                    SearchResults.Add(item);
                }
            }

        }

        /// <summary>
        /// Opens a new page based off the passed parameter
        /// </summary>
        /// <param name="parameter">The new page to open</param>
        void NewPage(object parameter)
        {
            if (parameter == null) return;

            SoftwareList.Clear();
            ErrorList.Clear();
            switch ((String)parameter)
            { 
                case ("AddNewSoftware") :
                    View.Software_Pages.AddSoftware win = new View.Software_Pages.AddSoftware();
                    win.Show();
                    win.Closed += new EventHandler(UpdateSoftwareList);
                    win.Closed += new EventHandler(UpdateErrorList);
                    break;
                case ("RemoveSoftware") :
                    var remsw = new View.Software_Pages.RemoveSoftware();
                    remsw.Show();
                    remsw.Closed += new EventHandler(UpdateSoftwareList);
                    remsw.Closed += new EventHandler(UpdateErrorList);
                    break;
                case ("EditSoftware"):
                    var esw = new View.Software_Pages.EditSoftware();
                    esw.Show();
                    esw.Closed += new EventHandler(UpdateSoftwareList);
                    esw.Closed += new EventHandler(UpdateErrorList);
                    break;
                case ("AddNewError"):
                    var erradd = new View.Error_Pages.AddError();
                    erradd.Show();
                    erradd.Closed += new EventHandler(UpdateErrorList);
                    erradd.Closed += new EventHandler(UpdateSoftwareList);
                    break;
                case ("EditError"):
                    var erredit = new View.Error_Pages.EditError();
                    erredit.Show();
                    erredit.Closed += new EventHandler(UpdateErrorList);
                    erredit.Closed += new EventHandler(UpdateSoftwareList);
                    break;
                case ("RemoveError"):
                    var errrem = new View.Error_Pages.DeleteError();
                    errrem.Show();
                    errrem.Closed += new EventHandler(UpdateErrorList);
                    errrem.Closed += new EventHandler(UpdateSoftwareList);
                    break;

                default :
                    break;
            }
        }
        #endregion

    }
}
