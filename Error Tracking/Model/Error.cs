using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Error_Tracking.Model
{
    /// <summary>
    /// POCO model of an error
    /// </summary>
    public class Error
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public String Resolution { get; set; }
        public int SoftwareKey { get; set; }
    }
}
