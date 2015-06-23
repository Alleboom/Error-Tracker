using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.Model_Data_Converters
{
    public class Error
    {

        /// <summary>
        /// Used to transform a CRUD object to a POCO 
        /// </summary>
        /// <param name="CRUD">The CRUD object to convert</param>
        /// <returns>A POCO model of an error</returns>
        public static Model.Error CRUDtoPOCO(Data.Error CRUD)
        {
            return new Model.Error()
            {
                Description = CRUD.ErrorMessage,
                Id = CRUD.Id,
                Resolution = CRUD.Resolution,
                SoftwareKey = CRUD.SoftwareKey,
            };
        }

        /// <summary>
        /// Used to convert a POCO object to a CRUD
        /// </summary>
        /// <param name="POCO"></param>
        /// <returns></returns>
        public static Data.Error POCOtoCRUD(Model.Error POCO)
        {
            return new Data.Error()
            {
                ErrorMessage = POCO.Description,
                Id = POCO.Id,
                Resolution = POCO.Resolution,
                SoftwareKey = POCO.SoftwareKey, 
            };
        }

        /// <summary>
        /// Takes an Enumerable collection and returns an observable collection for MVVM use
        /// </summary>
        /// <param name="CRUDList">The list of CRUD objects to be converted to a POCO list</param>
        /// <returns>A List of Error POCOs </returns>
        public static ObservableCollection<Model.Error> CRUDCollectionToPOCOCollection(IEnumerable<Data.Error> CRUDList)
        {
            ObservableCollection<Model.Error> LTR = new ObservableCollection<Model.Error>();
            foreach (Data.Error item in CRUDList)
            {
                LTR.Add(CRUDtoPOCO(item));
            }
            return LTR;
        }
    }
}
