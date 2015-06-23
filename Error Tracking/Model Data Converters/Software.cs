using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.Model_Data_Converters
{
    class Software
    {

        /// <summary>
        /// Used to transform a CRUD object to a POCO 
        /// </summary>
        /// <param name="CRUD">The CRUD object to convert</param>
        /// <returns>A POCO model of an error</returns>
        public static Model.Software CRUDtoPOCO(Data.Software CRUD)
        {
            return new Model.Software()
            {
                Id = CRUD.Id,
                Name = CRUD.Name,
            };
        }

        /// <summary>
        /// Used to convert a POCO object to a CRUD
        /// </summary>
        /// <param name="POCO">The POCO object to convert to a CRUD</param>
        /// <returns>A CRUD object</returns>
        public static Data.Software POCOtoCRUD(Model.Software POCO)
        {
            return new Data.Software()
            {
                Id = POCO.Id,
                Name = POCO.Name,
            };
        }

        /// <summary>
        /// Takes an Enumerable collection and returns an observable collection for MVVM use
        /// </summary>
        /// <param name="CRUDList">The list of CRUD objects to be converted to a POCO list</param>
        /// <returns>A List of Software POCOs </returns>
        public static ObservableCollection<Model.Software> CRUDCollectionToPOCOCollection(IEnumerable<Data.Software> CRUDList)
        {
            ObservableCollection<Model.Software> LTR = new ObservableCollection<Model.Software>();
            foreach (Data.Software item in CRUDList)
            {
                LTR.Add(CRUDtoPOCO(item));
            }
            return LTR;
        }

    }
}
