//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Error_Tracking
{
    using System;
    using System.Collections.Generic;
    
    public partial class Software
    {
        public Software()
        {
            this.Errors = new HashSet<Error>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Error> Errors { get; set; }
    }
}