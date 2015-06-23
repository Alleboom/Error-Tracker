using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.ViewModel.ErrorViewModels
{
    public class BaseErrorViewModel : ViewModel.ViewModelBase
    {

        protected Error _SelectedError;
        private String _Description;
        protected Software _SelectedSoftware;
        private String _Resolution;
        
        protected int SoftwareKey;

        /// <summary>
        /// The resolution of the error
        /// </summary>
        public String Resolution
        {
            get
            {
                return _Resolution;
            }
            set
            {
                if (_Resolution != value)
                {
                    _Resolution = value;
                    OnPropertyChanged("Resolution");
                }
            }
        }

        /// <summary>
        /// A brief description of the error
        /// </summary>
        public String Description
        {
            get
            {
                return _Description;
            }

            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        /// The selected software, usually from a combo box
        /// </summary>
        public Software SelectedSoftware
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
                    OnPropertyChanged("SelectedSoftware");
                    if (_SelectedSoftware != null)
                    {
                        SoftwareKey = SelectedSoftware.Id;
                    }
                }
            }
        }

    }
}
