using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;

namespace Error_Tracking.Data_Access
{
    public class GenericDataAccess
    {

        public static String SqlConn = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=S:\MILLSTONE\6\DATA4\IT_LFS\Error Tracker\Database.mdf;Integrated Security=True;Connect Timeout=30";



        /// <summary>
        /// Gets all entries from a particular datacontext
        /// </summary>
        /// <typeparam name="T">The type of CRUD object that should be return back</typeparam>
        /// <param name="db">The datacontext of the CRUD object</param>
        /// <returns>An ObservableCollection of the CRUD objects</returns>
        public static ObservableCollection<T> GetAll<T>() where T : class
        {
            ObservableCollection<T> LTR = new ObservableCollection<T>();
            try
            {
                // using our passed in data context
                using (DataContext db = new DataContext(SqlConn))
                {
                    Table<T> table = db.GetTable<T>();
                    // add each item from the datacontext table to our collection
                    foreach (T item in table)
                    {
                        LTR.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return LTR;
        }

        /// <summary>
        /// Deletes a CRUD object from the database
        /// </summary>
        /// <typeparam name="T">The object type of the CRUD object</typeparam>
        /// <param name="db">The data context of the CRUD object</param>
        /// <param name="CRUDobj">The CRUD object to delete</param>
        public static void DeleteEntry<T>(T CRUDobj) where T : class
        {
            try
            {

                // create a new object based off the passed in CRUD object
                Type type = CRUDobj.GetType();
                Object newObj = Activator.CreateInstance(type, new object[0]);

                // get the properties of the passed in object
                PropertyDescriptorCollection orignalProps = TypeDescriptor.GetProperties(CRUDobj);

                // copy them over
                foreach (PropertyDescriptor prop in orignalProps)
                {
                    // check to make sure there is a column attribute
                    if (prop.Attributes[typeof(ColumnAttribute)] != null)
                    {
                        // get the value of the property and assign it to the new object
                        object val = prop.GetValue(CRUDobj);
                        prop.SetValue(newObj, val);
                    }
                }

                

                // establish the context
                using (DataContext db = new DataContext(SqlConn))
                {
                    // grab the table
                    var table = db.GetTable<T>();

                    

                    table.Attach((T)newObj);

                    table.DeleteOnSubmit((T)newObj);
                    db.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Inserts a CRUD object from the database
        /// </summary>
        /// <typeparam name="T">The object type of the CRUD object</typeparam>
        /// <param name="db">The data context of the CRUD object</param>
        /// <param name="CRUDobj">The CRUD object to Insert</param>
        public static void InsertEntry<T>(T CRUDobj) where T : class
        {
            try
            {

                // establish the context
                using (DataContext db = new DataContext(SqlConn))
                {
                    
                    db.Log = Console.Out;
                    // grab the table
                    var table = db.GetTable<T>();
                    table.InsertOnSubmit(CRUDobj);
                    db.SubmitChanges();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Inserts a CRUD object from the database
        /// </summary>
        /// <typeparam name="T">The object type of the CRUD object</typeparam>
        /// <param name="db">The data context of the CRUD object</param>
        /// <param name="CRUDobj">The CRUD object to Insert</param>
        public static void ModifyEntry<T>(T CRUDobj) where T : class
        {
            try
            {
                

                using (DataContext db = new DataContext(SqlConn))
                {

                    var table = db.GetTable<T>();

                    table.Attach(CRUDobj);
                    db.Refresh(RefreshMode.KeepCurrentValues, CRUDobj);
                    db.SubmitChanges();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
